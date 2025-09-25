using LaboratorioRamos.Data.DtoFiltro;

namespace LaboratorioRamos.Data.DtoStateProvider
{
    public class DtoUserProvider
    {
        public string testsuncretr { get; set; } = "";
        public int Type { get; set; }=1;
        public string filtros { get; set; } = "";
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime LastActivityUtc { get; set; } = DateTime.UtcNow;
        public int TimeoutMinutes { get; set; } = 30;
        public bool SlidingExpiration { get; set; } = true;
        public int AbsoluteExpirationMinutes { get; set; } = 480;
    }
}
