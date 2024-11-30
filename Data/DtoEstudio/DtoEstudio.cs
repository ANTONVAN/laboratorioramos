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

    public class DtoEstudiosOrden
    {
        public int Id { get; set; }
        public int EstudioId { get; set; }
        public string Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public int? AreaId { get; set; }
        public int? DepartamentoId { get; set; }
        public bool Activo { get; set; }
        public int Precio { get; set; }
        public int Descuento { get; set; }
        public int DescuenNum { get; set; }
        public int PrecioFinal { get; set; }
        //public object ack { get; set; }
    }

    public class DtoEstudioRequestPrice
    {
        public string SucursalId { get; set; }
        public string MedicoId { get; set; }
        public string CompañiaId { get; set; }
        public int EstudioId { get; set; }

    }

    public class DtoEtiqueta
    {
        public int Id { get; set; }
        public string? DestinoId { get; set; }
        public string? Destino { get; set; }
        public int DestinoTipo { get; set; }
        public int EtiquetaId { get; set; }
        public int EstudioId { get; set; }
        public string? ClaveEtiqueta { get; set; }
        public string? ClaveInicial { get; set; }
        public string? Color { get; set; }
        public double Cantidad { get; set; }
        public int Orden { get; set; }
        public string? NombreEtiqueta { get; set; }
        public string? NombreEstudio { get; set; }
        public string? ClaveEstudio { get; set; }
    }

    public class DtoIndicacion
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class DtoParametro
    {
        public string? Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? NombreCorto { get; set; }
        public string? Area { get; set; }
        public string? Departamento { get; set; }
        public bool Activo { get; set; }
        public bool Requerido { get; set; }
        public bool DeltaCheck { get; set; }
        public bool MostrarFormato { get; set; }
        public int? Unidades { get; set; }
        public string? UnidadNombre { get; set; }
        public string? TipoValor { get; set; }
        public string? ValorInicial { get; set; }
        public string? ValorFinal { get; set; }
        public string? Tipo { get; set; }
    }

    public class DtoPromocion
    {
        public int EstudioId { get; set; }
        public int PaqueteId { get; set; }
        public int PromocionId { get; set; }
        public string? Promocion { get; set; }
        public double Descuento { get; set; }
        public double DescuentoPorcentaje { get; set; }
    }

    public class DtoEstudioResponsePrice
    {
        public string? Identificador { get; set; }
        public string ListaPrecioId { get; set; }
        public string? ListaPrecio { get; set; }
        public int? PromocionId { get; set; }
        public string? Promocion { get; set; }
        public double Descuento { get; set; }
        public double DescuentoPorcentaje { get; set; }
        public int EstudioId { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public int? DepartamentoId { get; set; }
        public int? AreaId { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public int OrdenEstudio { get; set; }
        public string? Destino { get; set; }
        public string? DestinoId { get; set; }
        public int? DestinoTipo { get; set; }
        public int? MaquilaId { get; set; }
        public string? Maquila { get; set; }
        public string? Metodo { get; set; }
        public string? TipoMuestra { get; set; }
        public double Precio { get; set; }
        public bool Activo { get; set; }
        public double PrecioFinal { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<DtoPromocion> Promociones { get; set; }
        public List<DtoParametro> Parametros { get; set; }
        public List<DtoIndicacion> Indicaciones { get; set; }
        public List<DtoEtiqueta> Etiquetas { get; set; }
    }
}
