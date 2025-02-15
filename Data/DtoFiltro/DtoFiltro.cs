using System.ComponentModel.DataAnnotations;

namespace LaboratorioRamos.Data.DtoFiltro
{
    public class DtoFiltro
    {
        //[Required(ErrorMessage = "El campo es requerido")]
        public string? ExpedienteNombre { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public string? Solicitud { get; set; }
        //[Required(ErrorMessage = "Fecha Inicial es requerida")]
        public DateTime? DateInicial { get; set; } = DateTime.Now;
        //[Required(ErrorMessage = "Fecha Final es requerida")]
        public DateTime? DateFinal { get; set; } = DateTime.Now;
    }

    public class DtoFiltroLst
    {
        public string? OriginPage { get; set; } = "";
        public string? PageNo { get; set; } = "";
        public string? ExpedienteNombreSol { get; set; } = "";
        public DateTime? DateInicial { get; set; } = DateTime.Now;
        public DateTime? DateFinal { get; set; } = DateTime.Now;
        public bool ExistReg { get; set; } = false;
    }
    public class DtoFiltroNavega
    {
        public List<DtoFiltroLst> LstFiltro { get; set; }
    }
}
