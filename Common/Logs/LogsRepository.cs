using MallMapKiosk.Common.Utilities;
using Serilog;
using Serilog.Sinks.File;

namespace MallMapKiosk.Common.Logs
{
    public sealed class LogsRepository
    {
        public static void Log(Exception ex, LogType LogType)
        {
            var path_to_log = "";

            if (LogType == LogType.Error)
                path_to_log = FileRetriever.GetFile("logs\\", "errors.txt");
            else if (LogType == LogType.Warning)
                path_to_log = FileRetriever.GetFile("logs\\", "warnings.txt");
            else if (LogType == LogType.Information)
                path_to_log = FileRetriever.GetFile("logs\\", "information.txt");

            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo
                .File($"logs/{path_to_log}", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            switch (LogType)
            {
                case LogType.Error:
                    Serilog.Log.Fatal(ex, ex.Message);
                    break;
                case LogType.Warning:
                    Serilog.Log.Warning(ex, ex.Message);
                    break;
                default:
                    Serilog.Log.Information(ex, ex.Message);
                    break;
            }

            Serilog.Log.CloseAndFlush();
        }
    }
}
