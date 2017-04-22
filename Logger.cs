using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;

namespace Logger
{
    public class Logger
    {
        static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(HostingEnvironment.MapPath("~/log4net.config")));
            SetUpDbConnection(ConfigurationManager.AppSettings.Get("LoggerConectionString"));
        }

        #region configuration commands
        public static void SetUpDbConnection(string connectionString)
        {
            var hier = LogManager.GetRepository() as Hierarchy;

            if (hier != null)
            {
                var adoNetAppenders = hier.GetAppenders().OfType<AdoNetAppender>();
                foreach (var adoNetAppender in adoNetAppenders)
                {
                    adoNetAppender.ConnectionString = connectionString;
                    adoNetAppender.ActivateOptions();
                }
            }
        }
        #endregion

        #region logging commands

        #region Debug
        public static void Debug(string message, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.DebugFormat(message.Trim(), GlobalContext.Properties["Tear"] = tear);
        }
        public static void Debug(string message, object[] args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.DebugFormat(message.Trim(), GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }
        public static void Debug(string message, object args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.DebugFormat(message.Trim(), GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }
        #endregion

        #region Error
        public static void Error(string message, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.ErrorFormat(message.Trim(), GlobalContext.Properties["Tear"] = tear);
        }
        public static void Error(string message, object[] args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.ErrorFormat(message.Trim(), GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }
        public static void Error(string message, object args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.ErrorFormat(message.Trim(), GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }

        public static void Error(Exception ex, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.ErrorFormat(ex.Message, ex, GlobalContext.Properties["Tear"] = tear);
        }
        public static void Error(Exception ex, object[] args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.ErrorFormat(ex.Message, ex, GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }
        public static void Error(Exception ex, object args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.ErrorFormat(ex.Message, ex, GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }
        #endregion

        #region Info
        public static void Info(string message, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.InfoFormat(message.Trim(), GlobalContext.Properties["Tear"] = tear);
        }
        public static void Info(string message, object[] args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.InfoFormat(message.Trim(), GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }
        public static void Info(string message, object args, string tear)
        {
            GlobalContext.Properties["Params"] = "";
            _logger.InfoFormat(message.Trim(), GlobalContext.Properties["Params"] = args, GlobalContext.Properties["Tear"] = tear);
        }
        #endregion

        #endregion

    }
}
