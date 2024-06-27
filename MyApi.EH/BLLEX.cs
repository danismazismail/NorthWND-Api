using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.EH
{
    
    public class BLLEX : EXBase
    {
        public BLLEX(string? msg) : base(msg)
        {
        }
        public BLLEX(string? msg, Exception? innerException) : base(msg, innerException)
        {
        }
    }
}
