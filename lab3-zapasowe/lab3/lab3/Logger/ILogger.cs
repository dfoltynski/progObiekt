using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Logger
{
    public interface ILogger: IDisposable
    {
        void Log(params String[] messages);
    }
}
