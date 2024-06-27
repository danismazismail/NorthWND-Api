using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.EH
{
    public abstract class EXBase : Exception
    {
        public EXBase(string? msg) : base(msg)
        {
        }
        public EXBase(string? msg, Exception? innerException) : base(msg, innerException)
        {
        }
    }
}
