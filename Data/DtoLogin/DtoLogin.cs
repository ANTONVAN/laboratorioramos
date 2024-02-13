using System.ComponentModel.DataAnnotations;

namespace LaboratorioRamos.Data.DtoPaciente
{
    public class DtoLogin
    {
        [Required(ErrorMessage = "El Usuario es requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La Contraseña es requerida")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public string Contraseña { get; set; }
    }
    public class DtoLoginMedico
    {
        [Required(ErrorMessage = "El Usuario es requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La Contraseña es requerida")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public string Contraseña { get; set; }
    }
    public class DtoLoginEmpresa
    {
        [Required(ErrorMessage = "El Usuario es requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La Contraseña es requerida")]
        public string Contraseña { get; set; }
    }
}
