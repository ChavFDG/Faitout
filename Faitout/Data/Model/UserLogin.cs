using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faitout.Data.Model
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public bool Loged { get; set; } = false;
        public string ErrorMessage { get; set; }
    }
}
