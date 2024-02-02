namespace EmailMarketing.Architecture.WebApi.Core.Logs.Contracts
{
    public interface IAppLogger
    {
        void LogInfo(string messageTemplate, params object[] propertyValues);
        void LogWarning(string messageTemplate, params object[] propertyValues);
        void LogError(Exception exception, string messageTemplate, params object[] propertyValues);
        void LogError(Exception exception, Guid? triggerId);
        void LogError(string message);
        void LogFatal(Exception exception, string messageTemplate, params object[] propertyValues);
    }
}
