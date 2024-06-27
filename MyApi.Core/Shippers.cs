using MyApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Core
{
    public class Shippers:EntityBase
    {
        [Key]
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string  Phone  { get; set; }
    }
}
