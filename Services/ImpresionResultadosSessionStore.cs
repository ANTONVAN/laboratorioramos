using LaboratorioRamos.Data.DtoMedico.DtoResponseMedicoPaciente;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LaboratorioRamos.Services
{
    /// <summary>
    /// Cache de estudios listos para imprimir tras validación en login Consulta,
    /// evitando repetir la búsqueda en /ImpresionResultados.
    /// </summary>
    public class ImpresionResultadosSessionStore
    {
        private const string StorageKey = "LrImpresionStudiosPending";

        private readonly ProtectedSessionStorage _sessionStorage;

        public ImpresionResultadosSessionStore(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task SavePendingStudiosAsync(string expediente, string solicitud, List<DtoResponseMedicoPacienteStudios> estudios)
        {
            if (estudios.Count == 0)
                return;

            try
            {
                await _sessionStorage.SetAsync(StorageKey, new PendingImpresionStudios
                {
                    Expediente = expediente?.Trim() ?? "",
                    Solicitud = solicitud?.Trim() ?? "",
                    Estudios = estudios
                });
            }
            catch
            {
                // Prerender o almacenamiento no disponible
            }
        }

        /// <summary>
        /// Obtiene estudios en caché si coinciden expediente/solicitud; borra el valor al leer.
        /// </summary>
        public async Task<List<DtoResponseMedicoPacienteStudios>?> GetAndClearPendingStudiosAsync(string expediente, string solicitud)
        {
            try
            {
                var result = await _sessionStorage.GetAsync<PendingImpresionStudios>(StorageKey);
                await _sessionStorage.DeleteAsync(StorageKey);

                if (!result.Success || result.Value == null || result.Value.Estudios.Count == 0)
                    return null;

                var exp = expediente?.Trim() ?? "";
                var sol = solicitud?.Trim() ?? "";

                if (!string.Equals(result.Value.Expediente, exp, StringComparison.OrdinalIgnoreCase)
                    || !string.Equals(result.Value.Solicitud, sol, StringComparison.OrdinalIgnoreCase))
                    return null;

                return result.Value.Estudios;
            }
            catch
            {
                return null;
            }
        }

        public async Task ClearAsync()
        {
            try
            {
                await _sessionStorage.DeleteAsync(StorageKey);
            }
            catch
            {
                // ignore
            }
        }
    }

    public sealed class PendingImpresionStudios
    {
        public string Expediente { get; set; } = "";
        public string Solicitud { get; set; } = "";
        public List<DtoResponseMedicoPacienteStudios> Estudios { get; set; } = new();
    }
}
