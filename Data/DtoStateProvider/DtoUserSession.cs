namespace LaboratorioRamos.Data.DtoStateProvider
{
    public class DtoUserSession
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Token { get; set; } = "";
        public bool RequiereCambio { get; set; }
        public Guid Sucursal { get; set; }
        public Guid Rol { get; set; }
        public bool Admin { get; set; }
        public List<Guid> Sucursales { get; set; }
        public bool CancelaPagos { get; set; }
        public bool AplicaDescuentos { get; set; }
        public string TipoUsuario { get; set; } = "";


    }
}
