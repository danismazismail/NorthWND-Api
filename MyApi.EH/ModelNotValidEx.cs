using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.EH
{
    public class ModelNotValidEx:EXBase
    {
        public ModelNotValidEx(string? msg) : base(msg)
        {
        }
        public ModelNotValidEx(string? msg, Exception? innerException) : base(msg, innerException)
        {
        }
    }
}
