namespace LaboratorioRamos.Data.DtoExpediente
{
    public class DtoExpediente
    {
        public string? Id { get; set; }
        public string ExpedienteId { get; set; }
        public string? Solicitud { get; set; }
        public string? Nombre { get; set; }
        public string? Registro { get; set; }
        public string? Entrega { get; set; }
        public string? UsuarioCreo { get; set; }
        public string? Sucursal { get; set; }
        public string? SucursalNombre { get; set; }
        public string? Edad { get; set; }
        public string? Sexo { get; set; }
        public string? Compañia { get; set; }
        public int Procedencia { get; set; }
        public string? Departamento { get; set; }
        public string? Area { get; set; }
        public string? NombreMedico { get; set; }
        public string? ClavePatologica { get; set; }
        public string? Observacion { get; set; }
        public List<DtoEstudioExpediente>? Estudios { get; set; }
        public bool ShowEstudios { get; set; } = false;
    }
    public class DtoEstudioExpediente
    {
        public int Id { get; set; }
        public int SolicitudEstudioId { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public List<DtoAreaEstudioExpediente>? Areas { get; set; }
        public int Estatus { get; set; }
        public string? Registro { get; set; }
        public string? Entrega { get; set; }
        public string? FechaEntrega { get; set; }
        public bool Seleccion { get; set; }
        public string? Clave{ get; set; }
        public string? NombreEstatus{ get; set; }
        public string? SolicitudId{ get; set; }
        public string? SolicitudIdFechaActualizacion{ get; set; }
        public string? UsuariosActualizacion{ get; set; }
        public int Urgencia{ get; set; }
        public string? Observacion{ get; set; }
        public List<DtoParametroEstudio>? Parametros{ get; set; }
    }
    public class DtoAreaEstudioExpediente
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
        public bool DepartamentoId { get; set; }
        public string? Departamento { get; set; }
        public string UsuarioID { get; set; }
    }

    public class DtoParametroEstudio
    {
        public string Id { get; set; }
        public string? NombreParametro { get; set; }
        public string? Unidades { get; set; }
        public string? Resultado { get; set; }
        public int ValorInicial { get; set; }
        public int ValorFinal { get; set; }

    }

    
}
