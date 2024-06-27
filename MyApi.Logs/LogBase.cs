using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Logs
{


    public abstract class LogBase<T> where T : class
    {
        public LogBase()
        {
                
        }
        public abstract void DoLog(T logSubject, DateTime logDate, string logState);
        
    }
}
