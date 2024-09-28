namespace Review.Model
{
    static class LogLine
    {
        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        public enum LogLevel
        {
            Unknown = 0,
            Trace = 1,
            Debug = 2,
            Info = 4,
            Warning = 5,
            Error = 6,
            Fatal = 42
        }


        public static LogLevel ParseLogLevel(string logLine)
        {
            var index = logLine.IndexOf('[');

            string level = logLine.Substring(index + 1, 3);

            switch (level)
            {
                case "TRC": return LogLevel.Trace;
                case "DBG": return LogLevel.Debug;
                case "INF": return LogLevel.Info;
                case "WRN": return LogLevel.Warning;
                case "ERR": return LogLevel.Error;
                case "FTL": return LogLevel.Fatal;
                default: return LogLevel.Unknown;
            }
        }

        public static string OutputForShortLog(LogLevel logLevel, string message)
        {
            return $"{(int)logLevel}:{message}";
        }


    }
}
