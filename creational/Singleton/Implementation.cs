namespace Singleton
{
    internal class Implementation
    {
        internal class Logger
        {
            private static readonly Lazy<Logger> lazyLogger = new Lazy<Logger>(() => new Logger());

            public static Logger Instance = lazyLogger.Value;

            protected Logger() { }

            public void Log(string message)
            {
                Console.WriteLine($"Message to log: {message}");
            }
        }
    }
}
