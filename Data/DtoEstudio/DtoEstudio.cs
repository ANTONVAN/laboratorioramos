using System.Security.Cryptography;

namespace LaboratorioRamos.Data.DtoEstudio
{
    public class DtoEstudio
    {
        public List<DtoResultGral> Results{ get; set; }
    }

    public class DtoResultGral
    {
        public string Id {get; set; }
        public string? Clave {get; set; }
        public string? Paciente {get; set; }
        public Int32 Edad {get; set; }
        public string? Genero {get; set; }
        public Int32 ReuqestStudyId { get; set; }
        public string ExpedienteId { get; set; }
        public string? NombreEstudio { get; set; }
        public string? HoraSolicitud { get; set; }
        public List<DtoParameters>? Parameters { get; set; }

    }
    public class DtoParameters
    {
        public string Id { get; set; }
        public string? TipoValor { get; set; }
        public Int32 EstudioId { get; set; }
        public Int32 SolicitudEstudioId { get; set; }
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public string? Unidades { get; set; }
        public string? Etiqueta { get; set; }
        public string? Valor { get; set; }
        

    }

    public class DtoEstudioGrafica
    {
        public string Fecha { get; set; }
        public string Estudio { get; set; }
        public string? Valor { get; set; }
    }
}
