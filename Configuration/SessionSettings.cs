namespace LaboratorioRamos.Configuration
{
    public class SessionSettings
    {
        public int TimeoutMinutes { get; set; } = 30;
        public bool SlidingExpiration { get; set; } = true;
        public int AbsoluteExpirationMinutes { get; set; } = 480;

        // Session timeout watcher behavior (UI)
        // How often the client checks the session (seconds).
        public int CheckIntervalSeconds { get; set; } = 10;
        // How long before inactivity timeout to show the warning dialog (seconds).
        public int WarningBeforeSeconds { get; set; } = 15;
    }
}


