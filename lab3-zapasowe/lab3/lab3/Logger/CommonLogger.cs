using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Logger
{
    class CommonLogger : ILogger
    {
        private ILogger[] delegates;

        public CommonLogger(ILogger[] loggers)
        {
            this.delegates = loggers;
        }

        public void Dispose()
        {
            foreach (var logger in delegates)
            {
                logger.Dispose();
            }
        }

        public void Log(params string[] messages)
        {
            foreach (var logger in delegates)
            {
                logger.Log(messages);
            }

        }
    }
}
