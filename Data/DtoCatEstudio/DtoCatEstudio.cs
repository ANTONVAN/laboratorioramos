using System;

namespace LaboratorioRamos.Data.DtoCatEstudio
{
    public class DtoCatEstudio
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Titulo { get; set; }
        public string? Area { get; set; }
        public int? AreaId { get; set; }
        public string? Departamento { get; set; }
        public int? DepartamentoId { get; set; }
        public string? Formato{ get; set; }
        public string? Maquilador { get; set; }
        public string? Metodo { get; set; }
        public int? Orden { get; set; }
        public bool Activo { get; set; }
        public string? Tipo { get; set; }
        public List<DtoParameterValueStudy> Parametros{ get; set; }
    }
    
    public class DtoParameterValueStudy
    {
        public string? Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? NombreCorto { get; set; }
        public string? Area { get; set; }
        public string? Departamento { get; set; }
        public bool Activo { get; set; }
        public bool DeltaCheck { get; set; }
        public bool ValoresCriticos { get; set; }
        public bool MostrarFormato { get; set; }
        public int? Unidades { get; set; }
        public string? UnidadNombre { get; set; }
        public string TipoValor { get; set; }
        public string? ValorInicial { get; set; }
        public string? ValorFinal { get; set; }
        public string? CriticoMinimo { get; set; }
        public string? CriticoMaximo { get; set; }
        public int EstudioId { get; set; }
        public int SolicitudEstudioId { get; set; }
        public string? Formula { get; set; }
        public string? Fcsi { get; set; }
        public int Orden { get; set; }
        public bool OcultarSiNulo { get; set; }
        
        /*tipoValores[...]*/
    }

}
