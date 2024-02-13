namespace LaboratorioRamos.Data.DtoMedico.DtoRequestMedicoPacientes
{
    public class DtoRequestMedicoPacientes
    {
        public List<string> MedicoId { get; set; }
        public List<string> CompañiaId { get; set; }
        public List<string> Fecha { get; set; }
        public string Buscar { get; set; }
        public int TipoFecha { get; set; } = 1;
    }

    public class DtoRequestMedicoPacientesExpediente
    {
        public List<string> expedienteId { get; set; }
    }
}
