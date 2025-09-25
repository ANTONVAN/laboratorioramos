namespace LaboratorioRamos.Configuration
{
    public class SessionSettings
    {
        public int TimeoutMinutes { get; set; } = 30;
        public bool SlidingExpiration { get; set; } = true;
        public int AbsoluteExpirationMinutes { get; set; } = 480;
    }
}


