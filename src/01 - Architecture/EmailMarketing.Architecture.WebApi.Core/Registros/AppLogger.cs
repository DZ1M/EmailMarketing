
using EmailMarketing.Architecture.WebApi.Core.Logs.Contracts;
using Serilog;

namespace EmailMarketing.Architecture.WebApi.Core.Registros
{
    public class AppLogger : IAppLogger
    {
        public void LogInfo(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Information(messageTemplate, propertyValues);
        }

        public void LogWarning(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Warning(messageTemplate, propertyValues);
        }

        public void LogError(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Error(exception, messageTemplate, propertyValues);
        }
        public void LogError(Exception exception, Guid? triggerId = null)
        {
            Log.Logger.Error("Error {@ex} {triggerId}", exception, triggerId);
        }

        public void LogError(string message)
        {
            Log.Logger.Error(message);
        }

        public void LogFatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Fatal(exception, messageTemplate, propertyValues);
        }
    }
}
