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



    public class Estudios
    {
        public int Id { get; set; }
        public string CotizacionId { get; set; }
        public int EstudioId { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        //public int PaqueteId { get; set; }
        //public string Paquete { get; set; }
        public string ListaPrecioId { get; set; }
        public string ListaPrecio { get; set; }
        public int? PromocionId { get; set; }
        public string Promocion { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public double Precio { get; set; }
        public bool DescuentoManual { get; set; }
        public int Descuento { get; set; }
        public int DescuentoPorcentaje { get; set; }
        public double PrecioFinal { get; set; }
        public string TipoMuestra { get; set; }
        public List<Promociones> Promociones { get; set; }
        //public List<Parametros> Parametros { get; set; }
        public List<Indicaciones> Indicaciones { get; set; }
    }

    public class Indicaciones
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class Paquetes
    {
        public int Id { get; set; }
        public string CotizacionId { get; set; }
        public int PaqueteId { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ListaPrecioId { get; set; }
        public string ListaPrecio { get; set; }
        public int PromocionId { get; set; }
        public string Promocion { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public int PrecioEstudios { get; set; }
        public int PaqueteDescuento { get; set; }
        public int PaqueteDescuentoPorcentaje { get; set; }
        public int Precio { get; set; }
        public bool DescuentoManual { get; set; }
        public int Descuento { get; set; }
        public int DescuentoPorcentaje { get; set; }
        public int PrecioFinal { get; set; }
        public List<Promociones> Promociones { get; set; }
        public List<Estudios> Estudios { get; set; }
    }

    public class Parametros
    {
        public string Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Area { get; set; }
        public string Departamento { get; set; }
        public bool Activo { get; set; }
        public bool Requerido { get; set; }
        public bool DeltaCheck { get; set; }
        public bool MostrarFormato { get; set; }
        public int Unidades { get; set; }
        public string UnidadNombre { get; set; }
        public string TipoValor { get; set; }
        public string ValorInicial { get; set; }
        public string ValorFinal { get; set; }
        public string CriticoMinimo { get; set; }
        public string CriticoMaximo { get; set; }
        public string Resultado { get; set; }
        public int EstudioId { get; set; }
        public int SolicitudEstudioId { get; set; }
        public string ResultadoId { get; set; }
        public string UltimoResultado { get; set; }
        public string UltimaSolicitud { get; set; }
        public string UltimaSolicitudId { get; set; }
        public string UltimoExpedienteId { get; set; }
        public string Formula { get; set; }
        public int Orden { get; set; }
        public string Fcsi { get; set; }
        public string ObservacionesId { get; set; }
        public bool Asignado { get; set; }
        public bool OcultarSiNulo { get; set; }
        public bool HasHistory { get; set; }
        public List<TipoValores> TipoValores { get; set; }
    }

    public class Promociones
    {
        public int EstudioId { get; set; }
        public int PaqueteId { get; set; }
        public int PromocionId { get; set; }
        public string Promocion { get; set; }
        public double Descuento { get; set; }
        public double DescuentoPorcentaje { get; set; }
    }

    public class DtoNewEstudiosByOrden
    {
        public string CotizacionId { get; set; }
        public List<Estudios> Estudios { get; set; }
        public List<Paquetes> Paquetes { get; set; }
        public TotalGral Total { get; set; }
    }

    public class TipoValores
    {
        public string Id { get; set; }
        public string ParametroId { get; set; }
        public string Nombre { get; set; }
        public string ValorInicial { get; set; }
        public string ValorFinal { get; set; }
        public string ValorInicialNumerico { get; set; }
        public string ValorFinalNumerico { get; set; }
        public int RangoEdadInicial { get; set; }
        public int RangoEdadFinal { get; set; }
        public string HombreValorInicial { get; set; }
        public string HombreValorFinal { get; set; }
        public string MujerValorInicial { get; set; }
        public string MujerValorFinal { get; set; }
        public string CriticoMinimo { get; set; }
        public string CriticoMaximo { get; set; }
        public string HombreCriticoMinimo { get; set; }
        public string HombreCriticoMaximo { get; set; }
        public string MujerCriticoMinimo { get; set; }
        public string MujerCriticoMaximo { get; set; }
        public int MedidaTiempoId { get; set; }
        public string Opcion { get; set; }
        public string DescripcionTexto { get; set; }
        public string DescripcionParrafo { get; set; }
        public string PrimeraColumna { get; set; }
        public string SegundaColumna { get; set; }
        public string TerceraColumna { get; set; }
        public string CuartaColumna { get; set; }
        public string QuintaColumna { get; set; }
        public DateTime FechaCreo { get; set; }
    }

    public class TotalGral
    {
        public string CotizacionId { get; set; }
        public int TotalEstudios { get; set; }
        public int Descuento { get; set; }
        public int Total { get; set; }
    }
}
