namespace LaboratorioRamos.Data.DtoImpresionResultados
{
    public class DtoImpresionResultados
    {
        public List<DtoSolicitudPDF> Estudios { get; set; }
        public string UsuarioId { get; set; } = "f984d60a-6c13-4f59-8710-a768aa46ba88";
        public string Usuario { get; set; } = "admin";
        public List<string> MediosEnvio { get; set; }
    }
    public class DtoSolicitudPDF
    {
        public string SolicitudId { get; set; }
        public List<DtoEstudiosPDF> EstudiosId { get; set; }
    }
    public class DtoEstudiosPDF
    {
        public int EstudioId { get; set; }
        public int Tipo { get; set; }
    }
}
