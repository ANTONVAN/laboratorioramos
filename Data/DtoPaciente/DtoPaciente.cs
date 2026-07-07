namespace LaboratorioRamos.Data.DtoPaciente
{
    public class DtoPaciente
    {
        public string Id{ get; set; }
        public string Expediente { get; set; }
        public string SolicitudIMR { get; set; }
        public string NombrePaciente { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string FechaNacimiento { get; set; }
        public double MonederoElectronico { get; set; }
        public bool monederoActivo { get; set; }
        public string SucursalId { get; set; }
        public string Sucursal { get; set; }
        public string Telefono { get; set; }
        public string FechaAlta { get; set; }
        public string Token { get; set; } = "";

        /// <summary>Sucursal de autenticación (branchid) para llamadas API en nuevos circuitos Blazor.</summary>
        public string AuthBranchId { get; set; } = "";

    }
}
