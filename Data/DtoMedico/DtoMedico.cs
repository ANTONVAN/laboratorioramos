using LaboratorioRamos.Data.DtoClinica;

namespace LaboratorioRamos.Data.DtoMedico
{
    public class DtoMedico
    {
        public string IdMedico { get; set; }
        public string Clave { get; set; }
        public string NombreCompleto { get; set; }
        public Int32? EspecialidadId { get; set; }
        public string Especialidad { get; set; }
        public string Observaciones { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string ActivoDescripcion { get; set; }
        public bool Activo { get; set; }
        public List<DtoClinicaMedico> Clinicas{ get; set; }
        public string Token { get; set; } = "";

    }
    public class DtoClinicaMedico
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

    public class DtoMedicoPwd
    {
        public string IdMedico { get; set; }
        public string Clave { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Int32? EspecialidadId { get; set; }
        public string Especialidad { get; set; }
        public string Observaciones { get; set; }
        public string CodigoPostal { get; set; }
        public string EstadoId { get; set; }
        public string CiudadId { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Calle { get; set; }
        public string ColoniaId { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public string IdUsuario { get; set; }
        public List<DtoClinicaMedico> Clinicas { get; set; }
        public string Token { get; set; } = "";
        public Guid Sucursal { get; set; }







    }
}
