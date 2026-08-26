namespace LaboratorioRamos.Data.DtoMedico.DtoResponseMedicoPaciente
{
    public class DtoResponseMedicoPaciente
    {
        public string SolicitudId { get; set; }
        public string ExpedienteId { get; set; }
        public string? Expediente { get; set; }
        public string? ClavePatologica { get; set; }
        public string? Solicitud { get; set; }
        public string? Nombre { get; set; }
        public string? Registro { get; set; }
        public DateTime? RegistroTmp { get; set; }
        public string? Sucursal { get; set; }
        public int Edad { get; set; }
        public string? Sexo { get; set; }
        public string? Compania { get; set; }
        public string? Parcialidad { get; set; }
        public double Saldo { get; set; }
        public bool SaldoPendiente { get; set; }
        public string? EnvioCorreo { get; set; }
        public string? EnvioWhatsapp { get; set; }
        public string? Telefono { get; set; }
        public string? FechaNacimiento { get; set; }
        public List<DtoResponseMedicoPacienteStudios>? Estudios { get; set; }
        public bool ShowEstudios { get; set; } = false;

    }

    public class DtoResponseMedicoPacienteStudios
    {
        public string SolicitudId { get; set; }
        public Int32 EstudioId { get; set; }
        public Int32 EstatusId { get; set; }
        public int? DepartamentoId { get; set; }
        public string? Estudio { get; set; }
        public string? MedioSolicitado { get; set; }
        public string? FechaEntrega { get; set; }
        public string Estatus { get; set; }
        public string? Registro { get; set; }
        public bool IsPathological { get; set; }
        public bool IsActiveCheckbox { get; set; }
       

    }

    public class DtoResponseMedicoPacienteExpediente
    {
        public string Id { get; set; }
        public string? Expediente { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public string? Sexo { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        


    }


}
