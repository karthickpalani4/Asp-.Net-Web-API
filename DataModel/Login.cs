using System;
using System.Collections.Generic;

#nullable disable

namespace RegLogin.DataModel
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
