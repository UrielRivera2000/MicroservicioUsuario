using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces;
using log4net;

namespace UserService.Infrastructure.Logging
{
    public class Log4NetAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(T));

        public void LogInfo(string message) => _logger.Info(message);
        public void LogError(string message, Exception ex) => _logger.Error(message, ex);
    }
}
