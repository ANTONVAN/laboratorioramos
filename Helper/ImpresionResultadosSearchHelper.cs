using LaboratorioRamos.Data.DtoMedico.DtoRequestMedicoPacientes;
using LaboratorioRamos.Data.DtoMedico.DtoResponseMedicoPaciente;
using LaboratorioRamos.Data.DtoPaciente;
using LaboratorioRamos.Services;

namespace LaboratorioRamos.Helper
{
    /// <summary>
    /// Búsqueda de resultados para impresión (mismo API y criterios que ConsultaResultadosPaciente).
    /// </summary>
    public static class ImpresionResultadosSearchHelper
    {
        public const string SearchUrl = "services/gateway/api/deliveryResults/GetAllCaptureResults";

        public static async Task<List<DtoResponseMedicoPaciente>> FetchResultadosAsync(
            HttpClient http,
            IApiResponseHandler apiHandler,
            DtoPaciente paciente)
        {
            var expediente = paciente.Expediente?.Trim() ?? string.Empty;
            var nombre = paciente.NombrePaciente?.Trim() ?? string.Empty;

            // Una sola consulta, mismo criterio que ConsultaResultadosPaciente: Buscar por nombre.
            DtoRequestMedicoPacientes parametros;
            if (!string.IsNullOrEmpty(nombre))
                parametros = BuildSearchByNombre(nombre);
            else if (IsNumericExpediente(expediente))
                parametros = BuildSearchByExpediente(expediente);
            else if (!string.IsNullOrEmpty(expediente))
                parametros = BuildSearchByNombre(expediente);
            else
                return new List<DtoResponseMedicoPaciente>();

            return await QueryResultadosAsync(http, apiHandler, parametros);
        }

        public static List<DtoResponseMedicoPacienteStudios> SelectStudiosForImpresion(
            IEnumerable<DtoResponseMedicoPaciente> expedientes,
            string solicitudBuscada,
            IEnumerable<int> estatusPermitidos)
        {
            var estatus = estatusPermitidos.ToHashSet();
            var seleccionados = new List<DtoResponseMedicoPacienteStudios>();

            foreach (var itemExp in expedientes)
            {
                if (!SolicitudMatches(itemExp, solicitudBuscada))
                    continue;

                foreach (var itemSol in itemExp.Estudios ?? Enumerable.Empty<DtoResponseMedicoPacienteStudios>())
                {
                    if (!estatus.Contains(itemSol.EstatusId))
                        continue;

                    itemSol.SolicitudId = itemExp.SolicitudId;
                    seleccionados.Add(itemSol);
                }
            }

            return seleccionados;
        }

        public static bool SolicitudExists(
            IEnumerable<DtoResponseMedicoPaciente> expedientes,
            string solicitudBuscada) =>
            expedientes.Any(e => SolicitudMatches(e, solicitudBuscada));

        public static bool SolicitudMatches(DtoResponseMedicoPaciente item, string solicitudBuscada)
        {
            var normalizada = NormalizeSolicitud(solicitudBuscada);
            if (string.IsNullOrEmpty(normalizada))
                return false;

            foreach (var candidato in new[] { item.Solicitud, item.SolicitudId })
            {
                if (string.IsNullOrWhiteSpace(candidato))
                    continue;

                var valor = NormalizeSolicitud(candidato);
                if (valor.Equals(normalizada, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (valor.Contains(normalizada, StringComparison.OrdinalIgnoreCase)
                    || normalizada.Contains(valor, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static List<int> ParseEstatusImpresion(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            var raw = config.GetSection("IdImpresion").Value?.Trim();
            if (string.IsNullOrEmpty(raw))
                return new List<int>();

            return raw.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(s => int.TryParse(s, out var id) ? id : -1)
                .Where(id => id >= 0)
                .ToList();
        }

        public static void ConfigureHttpHeaders(HttpClient http, string token, string branchId)
        {
            http.DefaultRequestHeaders.Remove("Authorization");
            http.DefaultRequestHeaders.Remove("branchid");
            http.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            http.DefaultRequestHeaders.Add("branchid", branchId);
        }

        private static async Task<List<DtoResponseMedicoPaciente>> QueryResultadosAsync(
            HttpClient http,
            IApiResponseHandler apiHandler,
            DtoRequestMedicoPacientes parametros)
        {
            using var response = await http.PostAsJsonAsync(SearchUrl, parametros);
            var success = await apiHandler.HandleResponseAsync<DtoRequestMedicoPacientes>(response, "búsqueda de resultados", false);
            if (!success || !response.IsSuccessStatusCode)
                return new List<DtoResponseMedicoPaciente>();

            return await response.Content.ReadFromJsonAsync<List<DtoResponseMedicoPaciente>>() ?? new();
        }

        private static DtoRequestMedicoPacientes BuildSearchByExpediente(string expediente) => new()
        {
            MedicoId = new(),
            CompañiaId = new(),
            Buscar = null,
            Expediente = expediente,
            TipoFecha = 1,
            Fecha = new()
        };

        private static DtoRequestMedicoPacientes BuildSearchByNombre(string nombre) => new()
        {
            MedicoId = new(),
            CompañiaId = new(),
            Buscar = nombre,
            Expediente = null,
            TipoFecha = 1,
            Fecha = new()
        };

        private static bool IsNumericExpediente(string value) =>
            !string.IsNullOrWhiteSpace(value) && long.TryParse(value, out _);

        private static string NormalizeSolicitud(string value) =>
            value.Trim().TrimStart('0');
    }
}
