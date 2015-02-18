using System;
using EnterpriseDT.Util.Debug;
using Serilog;

namespace Gxs.Ecxpress
{
    public static class EcxpressLogger
    {
        private static ILogger _logger;

        public static void Register(ILogger logger)
        {
            _logger = logger;
            Logger.LogMessageReceived += LogMessageReceived;
        }

        private static void LogMessageReceived(object sender, LogMessageEventArgs e)
        {
            if (e.Arguments != null && e.Arguments.Length == 1 && e.Arguments[0] is Exception)
                LogSerilog(e.LogLevel, e.FormattedText, (Exception)e.Arguments[0]);
            else if (e.Arguments != null)
                LogSerilog(e.LogLevel, string.Format(e.FormattedText, e.Arguments));
            else
                LogSerilog(e.LogLevel, e.FormattedText);
        }

        private static void LogSerilog(Level level, string message, Exception exception = null)
        {
            var args = new { exception };
            message = string.Concat("Ecxpress: ", message);

            if (level == Level.DEBUG)
                _logger.Debug(exception, message, args);
            if (level == Level.ERROR)
                _logger.Error(exception, message, args);
            if (level == Level.FATAL)
                _logger.Fatal(exception, message, args);
            if (level == Level.INFO)
                _logger.Information(exception, message, args);
            if (level == Level.WARN)
                _logger.Warning(exception, message, args);
        }
    }
}
