namespace LaboratorioRamos.Services
{
    /// <summary>
    /// Cache en memoria del circuito Blazor (scoped): PDF ya generado tras login Consulta.
    /// Evita fallos de ProtectedSessionStorage y la segunda llamada a printResultFilePreview.
    /// </summary>
    public class ImpresionResultadosPendingStore
    {
        private PendingImpresionData? _pending;

        public void Set(PendingImpresionData data)
        {
            _pending = data;
        }

        /// <summary>
        /// Obtiene el PDF pendiente si coincide expediente/solicitud; lo elimina al leer.
        /// </summary>
        public PendingImpresionData? GetAndClear(string expediente, string solicitud)
        {
            if (_pending == null || _pending.PdfBytes.Length == 0)
                return null;

            var exp = expediente?.Trim() ?? "";
            var sol = solicitud?.Trim() ?? "";

            if (!string.Equals(_pending.Expediente, exp, StringComparison.OrdinalIgnoreCase)
                || !string.Equals(_pending.Solicitud, sol, StringComparison.OrdinalIgnoreCase))
                return null;

            var data = _pending;
            _pending = null;
            return data;
        }

        public void Clear() => _pending = null;
    }

    public sealed class PendingImpresionData
    {
        public string Expediente { get; set; } = "";
        public string Solicitud { get; set; } = "";
        public byte[] PdfBytes { get; set; } = Array.Empty<byte>();
    }
}
