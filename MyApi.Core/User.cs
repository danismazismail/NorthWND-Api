using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Core
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        //  [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PassSalt { get; set; }
    }
}
