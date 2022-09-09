using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegLogin.Models
{
    public class Register
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
