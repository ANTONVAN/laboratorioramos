namespace LaboratorioRamos.Data.DtoEstudiosGral
{
    public class DtoEstudiosGral
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string? Area { get; set; }
        public int? AreaId { get; set; }
        public string? Departamento { get; set; }
        public int? DepartamentoId { get; set; }
        public string? Formato { get; set; }
        public string? Maquilador { get; set; }
        public string? Metodo { get; set; }
        public int Orden { get; set; }
        public bool Activo { get; set; }
        public string? Tipo { get; set; }
        public string? ClavesExternas { get; set; }
        public string? Parametros { get; set; }
        public string? Indicaciones { get; set; }
        public string? Etiquetas { get; set; }
    }

    public class DtoEstudiosById
    {
        //public int Id { get; set; }
        //public string? Clave { get; set; }
        //public int? Orden { get; set; }
        //public string? Nombre { get; set; }
        //public string? Titulo { get; set; }
        //public string? NombreCorto { get; set; }
        public bool Visible { get; set; }
        //public int? Dias { get; set; }
        //public bool Activo { get; set; }
        //public int? Area { get; set; }
        //public int? Departamento { get; set; }
        //public string? WorkLists { get; set; }
        //public int? Maquilador { get; set; }
        //public string? StrMetodo { get; set; }
        //public int? Metodo { get; set; }
        //public int? Tipomuestra { get; set; }
        //public int? Tiemporespuesta { get; set; }
        //public int? Diasrespuesta { get; set; }
        //public int? Tapon { get; set; }
        //public int? Cantidad { get; set; }
        //public bool Prioridad { get; set; }
        //public bool Urgencia { get; set; }
        //public string? Instrucciones { get; set; }
        //public int? DiasEstabilidad { get; set; }
        //public int? DiasRefrigeracion { get; set; }
        //public List<string>? ClavesExternas { get; set; }
        //public List<WorkList>? WorkList { get; set; }
        //public List<Parameter>? Parameters { get; set; }
        //public List<Indicacione>? Indicaciones { get; set; }
        //public List<Reactivo>? Reactivos { get; set; }
        //public List<Paquete>? Paquete { get; set; }
        ////public List<Etiqueta>? Etiquetas { get; set; }
        //public List<int>? LabelsToAdd { get; set; }
        //public List<int>? LabelsToRemove { get; set; }
        //public Areas? Areas { get; set; }
        //public Maquila? Maquila { get; set; }
        //public Format? Format { get; set; }
        //public Method? Method { get; set; }
        //public SampleType? SampleType { get; set; }
        //public string? UsuarioId { get; set; }
    }
    public class Areas
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
        public string? UsuarioCreoId { get; set; }
        public DateTime? FechaCreo { get; set; }
        public string? UsuarioModificoId { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int? DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public int? Orden { get; set; }
    }

    public class Ciudad
    {
        public int? Id { get; set; }
        public int? EstadoId { get; set; }
        public Estado? EEstado { get; set; }
        public string? SCiudad { get; set; }
    }

    public class Colonia
    {
        public int? Id { get; set; }
        public int? CiudadId { get; set; }
        public Ciudad? CCiudad { get; set; }
        public string? SColonia { get; set; }
        public string? CodigoPostal { get; set; }
    }

    public class Departamento
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
        public string? UsuarioCreoId { get; set; }
        public DateTime? FechaCreo { get; set; }
        public string? UsuarioModificoId { get; set; }
        public DateTime? FechaModifico { get; set; }
    }

    public class Estado
    {
        public int Id { get; set; }
        public string? SEstado { get; set; }
    }

    public class Etiqueta
    {
        public int Id { get; set; }
        public string? DestinoId { get; set; }
        public string? Destino { get; set; }
        public int? DestinoTipo { get; set; }
        public int? EtiquetaId { get; set; }
        public int? EstudioId { get; set; }
        public string? ClaveEtiqueta { get; set; }
        public string? ClaveInicial { get; set; }
        public string? Color { get; set; }
        public int? Cantidad { get; set; }
        public int? Orden { get; set; }
        public string? NombreEtiqueta { get; set; }
        public string? NombreEstudio { get; set; }
        public string? ClaveEstudio { get; set; }
    }

    public class Format
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
        public string? UsuarioCreoId { get; set; }
        public DateTime? FechaCreo { get; set; }
        public string? UsuarioModificoId { get; set; }
        public DateTime? FechaModifico { get; set; }
    }

    public class Indicacione
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }

    public class Maquila
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? PaginaWeb { get; set; }
        public string? NumeroExterior { get; set; }
        public string? NumeroInterior { get; set; }
        public string? Calle { get; set; }
        public int? ColoniaId { get; set; }
        public Colonia? Colonia { get; set; }
        public bool? Activo { get; set; }
        public string? UsuarioCreoId { get; set; }
        public DateTime? FechaCreo { get; set; }
        public string? UsuarioModificoId { get; set; }
        public DateTime? FechaModifico { get; set; }
    }

    public class Method
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }
        public string? UsuarioCreoId { get; set; }
        public DateTime? FechaCreo { get; set; }
        public string UsuarioModificoId { get; set; }
        public DateTime? FechaModifico { get; set; }
    }

    public class Paquete
    {
        public int Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }
    }

    public class Parameter
    {
        public string? Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? NombreCorto { get; set; }
        public string? Area { get; set; }
        public string? Departamento { get; set; }
        public bool? Activo { get; set; }
        public bool? Requerido { get; set; }
        public bool? DeltaCheck { get; set; }
        public bool? MostrarFormato { get; set; }
        public int? Unidades { get; set; }
        public string? UnidadNombre { get; set; }
        public string? TipoValor { get; set; }
        public string? ValorInicial { get; set; }
        public string? ValorFinal { get; set; }
        public List<TipoValore>? TipoValores { get; set; }
        public string? Tipo { get; set; }
    }

    public class Reactivo
    {
        public string? Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? ClaveSistema { get; set; }
        public string? NombreSistema { get; set; }
        public bool? Activo { get; set; }
    }

    public class SampleType
    {
        public int? Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }
        public string? UsuarioCreoId { get; set; }
        public DateTime? FechaCreo { get; set; }
        public string? UsuarioModificoId { get; set; }
        public DateTime? FechaModifico { get; set; }
    }

    public class TipoValore
    {
        public string? Id { get; set; }
        public string? ParametroId { get; set; }
        public string? Nombre { get; set; }
        public string? ValorInicial { get; set; }
        public string? ValorFinal { get; set; }
        public string? ValorInicialNumerico { get; set; }
        public string? ValorFinalNumerico { get; set; }
        public int? RangoEdadInicial { get; set; }
        public int? RangoEdadFinal { get; set; }
        public string? HombreValorInicial { get; set; }
        public string? HombreValorFinal { get; set; }
        public string? MujerValorInicial { get; set; }
        public string? MujerValorFinal { get; set; }
        public string? CriticoMinimo { get; set; }
        public string? CriticoMaximo { get; set; }
        public string? HombreCriticoMinimo { get; set; }
        public string? HombreCriticoMaximo { get; set; }
        public string? MujerCriticoMinimo { get; set; }
        public string? MujerCriticoMaximo { get; set; }
        public int? MedidaTiempoId { get; set; }
        public string? Opcion { get; set; }
        public string? DescripcionTexto { get; set; }
        public string? DescripcionParrafo { get; set; }
        public string PrimeraColumna { get; set; }
        public string? SegundaColumna { get; set; }
        public string? TerceraColumna { get; set; }
        public string? CuartaColumna { get; set; }
        public string? QuintaColumna { get; set; }
        public int? Orden { get; set; }
        public bool? Activo { get; set; }
        public string? UsuarioId { get; set; }
        public DateTime? FechaCreo { get; set; }
    }

    public class WorkList
    {
        public int? Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }
    }


}
