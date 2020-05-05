using Microsoft.Extensions.Logging;
using Nexos.Core.Interfaces;

namespace Nexos.Infraestructure.Logging
{
    public class LoggerAdaptador<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdaptador(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformacion(string informacion, params object[] argumentos)
        {
           _logger.LogInformation(informacion,argumentos );
        }

        public void LogWarning(string informacion, params object[] argumentos)
        {
            _logger.LogWarning(informacion, argumentos);
        }
    }
}