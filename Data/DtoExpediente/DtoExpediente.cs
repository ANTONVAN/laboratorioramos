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

    public class DtoExpedienteResponse
    {
        public string Id { get; set; }
        public string Expediente { get; set; }
        public string NombrePaciente { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string FechaNacimiento { get; set; }
        public double MonederoElectronico { get; set; }
        public bool MonederoActivo { get; set; }
        public string SucursalId { get; set; }
        public string Sucursal { get; set; }
        public string Telefono { get; set; }
        public string FechaAlta { get; set; }
        public string ClaveSucursal { get; set; }
    }

    public class DtoInfoExpediente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Expediente { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string FechaNacimientoFormat { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Cp { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Celular { get; set; }
        public string Calle { get; set; }
        public string Observaciones { get; set; }
        public string Colonia { get; set; }
        public string Sucursal { get; set; }
        public string UsuarioId { get; set; }
        public bool HasWallet { get; set; }
        public double Wallet { get; set; }
        public DateTime FechaActivacionMonedero { get; set; }
        public List<TaxDatum> TaxData { get; set; }
    }

    public class TaxDatum
    {
        public string Id { get; set; }
        public string ExpedienteId { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public string RegimenFiscal { get; set; }
        public string Cp { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Correo { get; set; }
        public string Calle { get; set; }
        public int Colonia { get; set; }
        public bool IsDefaultTaxData { get; set; }
        public string UsuarioId { get; set; }
    }

    public class DtoEstudioBySolicitudForExpediente
    {
        public int Id { get; set; }
        public int EstudioId { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int EstatusId { get; set; }
        public string Estatus { get; set; }
        public string Color { get; set; }
        public int Departamento { get; set; }
        public int AreaId { get; set; }
        public object FechaTomaMuestra { get; set; }
        public object FechaValidacion { get; set; }
        public object FechaSolicitado { get; set; }
        public object FechaCaptura { get; set; }
        public object FechaLiberado { get; set; }
        public object FechaEnviado { get; set; }
    }

    public class DtoSolicitudesForExpediente
    {
        public string SolicitudId { get; set; }
        public string ExpedienteId { get; set; }
        public string Clave { get; set; }
        public object ClavePatologica { get; set; }
        public object Afiliacion { get; set; }
        public string Paciente { get; set; }
        public string Compaia { get; set; }
        public string Procedencia { get; set; }
        public int EstatusId { get; set; }
        public string Factura { get; set; }
        public double Importe { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }
        public double Saldo { get; set; }
        public object FolioWeeClinic { get; set; }
        public string Sucursal { get; set; }
        public string ClaveSucursal { get; set; }
        public bool EsWeeClinic { get; set; }
        public List<DtoEstudioBySolicitudForExpediente> Estudios { get; set; }
        public int Urgencia { get; set; }
    }

}
