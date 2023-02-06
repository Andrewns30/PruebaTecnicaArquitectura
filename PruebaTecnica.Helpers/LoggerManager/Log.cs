using NLog;
using System.Diagnostics;
using System.Reflection;

namespace PruebaTecnica.Helpers.LoggerManager
{
    public class Log : ILog
    {
        public Log()
        {
            LogManager.LoadConfiguration(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "nlog.config"));
        }

        /// <summary>
        /// Instance of NLog
        /// </summary>
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private string _class { get; set; } = null!;
        private string _method { get; set; } = null!;

        /// <summary>
        /// Error type exception
        /// </summary>
        /// <param name="ex"></param>
        public void LogError(Exception ex)
        {
            MethodBase methodBase = new StackTrace().GetFrame(1)!.GetMethod()!;
            GetConfiguration(methodBase);

            string mensaje = ex.Message;
            Exception innerException = ex.InnerException!;
            while (innerException != null)
            {
                mensaje = $"{mensaje}; {innerException.Message}";
                innerException = innerException.InnerException!;
            }

            logger.Error($"{_class}.{_method}:\t{mensaje}\n{innerException}");
        }


        private void GetConfiguration(MethodBase methodBase)
        {

            _class = methodBase.ReflectedType!.Name.Split('<')[1].Split('>').FirstOrDefault()!;
            _method = methodBase.ReflectedType!.ReflectedType!.Name;
        }
    }
}
