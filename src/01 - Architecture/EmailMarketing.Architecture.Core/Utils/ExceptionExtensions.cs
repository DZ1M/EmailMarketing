using System.Text;

namespace EmailMarketing.Architecture.Core.Utils
{
    public static class ExceptionExtensions
    {
        public static string GetStackTraceMessage(this Exception ex)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendFormat("[{0}: {1}]", ex.GetType().Name, ex.Message);
            msg.AppendLine();
            msg.AppendLine(ex.StackTrace);

            return msg.ToString();
        }

        public static string GetCompleteMessage(this Exception ex)
        {
            var msg = new StringBuilder();

            Exception baseEx = ex.GetBaseException();

            if (baseEx == null)
            {
                baseEx = ex;
            }

            msg.AppendFormat("Message: {0}", baseEx.Message);
            msg.AppendLine();
            msg.AppendLine();

            if (baseEx.TargetSite != null)
            {
                msg.AppendFormat("Class: {0}\n", baseEx.TargetSite?.DeclaringType?.Name);
                msg.AppendLine();

                msg.AppendFormat("Method: {0}", baseEx.TargetSite?.Name);
                msg.AppendLine();
            }

            msg.AppendLine();
            msg.AppendLine("StackTrace:");
            msg.Append(baseEx.GetStackTraceMessage());

            return msg.ToString();
        }

        public static string GetCompleteRecursiveMessage(this Exception ex)
        {
            var msg = new StringBuilder();

            msg.Append(ex.GetCompleteMessage());

            if (ex.InnerException != null)
            {
                ex.InnerException.InternalGetCompleteRecursiveMessage(msg);
            }

            return msg.ToString();
        }

        private static void InternalGetCompleteRecursiveMessage(this Exception ex, StringBuilder msg)
        {
            if (ex.InnerException != null)
            {
                ex.InnerException.InternalGetCompleteRecursiveMessage(msg);
                msg.AppendLine();
            }

            msg.Append(ex.GetStackTraceMessage());
        }
    }
}
