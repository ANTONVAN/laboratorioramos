namespace LaboratorioRamos.Data.DtoEmpresa
{
    public class DtoEmpresa
    {
        public string Id { get; set; }
        public string? Clave { get; set; }
        public string? Contrasena { get; set; }
        public string? NombreComercial { get; set; }
        public string? Procedencia { get; set; }
        public int ProcedenciaId{ get; set; }
        public string? PrecioListaId{ get; set; }
        public string? PrecioLista{ get; set; }
        public bool Activo{ get; set; }
        public int? DiasCredito { get; set; }
        public List<DtoContact>? Contacts { get; set; }
        public string Token { get; set; } = "";

    }

    public class DtoEmpresaInfo
    {
        public string Id { get; set; }
        public string? Clave { get; set; }
        public string? Contrasena { get; set; }
        public string? EmailEmpresarial { get; set; }
        public string? NombreComercial { get; set; }
        public int ProcedenciaId { get; set; }
        public List<string>? PrecioListaId { get; set; }
        public List<string>? PromocionesId { get; set; }
        public string? Procedencia { get; set; }
        public string? PrecioLista { get; set; }
        public string? Promociones { get; set; }
        public string? Rfc { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Estado { get; set; }
        public string? Ciudad { get; set; }
        public string? RazonSocial { get; set; }
        public Int32? ColoniaId { get; set; }
        public string? Colonia { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? RegimenFiscal { get; set; }
        public Int32? MetodoDePagoId { get; set; }
        public Int32? FormaDePagoId { get; set; }
        public string? LimiteDeCredito { get; set; }
        public int? DiasCredito { get; set; }
        public int? CfdiId { get; set; }
        public string? NumeroDeCuenta { get; set; }
        public int? BancoId { get; set; }
        public bool Activo { get; set; }
        public string UsuarioCreoId { get; set; }
        public string FechaCreo { get; set; }
        public string UduarioModId { get; set; }
        public DateTime FechaMod { get; set; }
        public List<DtoContact>? Contacts { get; set; }
        public string Token { get; set; } = "";

    }
    public class DtoContact
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public Int64? Telefono { get; set; }
        public string? Correo { get; set; }
        public bool Activo { get; set; }

    }
}
