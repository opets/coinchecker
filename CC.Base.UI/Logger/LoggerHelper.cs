using System.Linq;
using CC.Base.Extensions;
using log4net;
using log4net.Appender;
using log4net.Core;

namespace CC.Base.UI.Logger
{
    public class LoggerHelper
    {
        public static void SetAppenderLogLevel(Level level, string appenderName) =>
            LogManager.GetRepository().GetAppenders()
                .Where(a => string.Equals(a.Name, appenderName))
                .OfType<AppenderSkeleton>()
                .Foreach(appender => appender.Threshold = level);
    }
}