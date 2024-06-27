using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Dtos.LogDTO
{
    public class RequestLogDTO
    {
        public string RequestQueryString { get; set; }
        public string HttpVerbORAction { get; set; }
    }
}
