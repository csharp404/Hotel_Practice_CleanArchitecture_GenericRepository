using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class SignUpDto
    {
        public string Email { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }

    }
}
