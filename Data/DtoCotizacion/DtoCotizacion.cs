using System;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioRamos.Data.DtoCotizacion
{
    public class DtoCotizacion
    {
        public string CotizacionId { get; set; }
        public string? NombreMedico { get; set; }
        public string? nombreCompania { get; set; }
        public string? claveMedico { get; set; }
        public string? observaciones { get; set; }
        public string? expedienteId { get; set; }
        public string sucursalId { get; set; }
        public string? clave { get; set; }
        public string? registro { get; set; }
        public string? envioCorreo { get; set; }
        public string? envioWhatsApp { get; set; }
        public bool activo { get; set; }
        public int estatusId { get; set; }
    }
    public class DtoCotizacionRequest
    {
        public List<string> SucursalId { get; set; }
        public List<string> MedicoId { get; set; }
        public List<string> CompañiaId { get; set; }
        public string Expediente { get; set; }
        public string Ciudad { get; set; }
        public List<string> Fecha { get; set; }
        public int TipoFecha { get; set; } = 1;
    }

    public class DtoCotizacionResponse
    {
        public string CotizacionId { get; set; }
        public string? Clave { get; set; }
        public string? Expediente { get; set; }
        public string? Paciente { get; set; }
        public string? Correo { get; set; }
        public string? Whatsapp { get; set; }
        public string? Fecha { get; set; }
        public bool Activo { get; set; }=false;
        public int EstatusId { get; set; }
        public List<DtoCotizacionEstudios> Estudios { get; set; }
    }

    public class DtoCotizacionEstudios
    {
        public int Id { get; set; }
        public int EstudioId { get; set; }
        public string? Clave{ get; set; }
        public string? Nombre{ get; set; }
    }
    public class DtoDraftCotizacion
    {
        public string CotizacionId { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string? SucursalId { get; set; }
        public int EstatusId { get; set; } = 0;
    }

    public class DtoGeneralesCotizacion
    {
        public string Ciudad { get; set; }
        public string? Observaciones { get; set; }
        public string? Paciente { get; set; }
    }

    public class DtoBusquedaCotizacion
    {
        public string? searchString1 { get; set; }
        public DateTime? dateInicial { get; set; } = DateTime.Today;
        public DateTime? dateFinal { get; set; } = DateTime.Today;
    }
}
