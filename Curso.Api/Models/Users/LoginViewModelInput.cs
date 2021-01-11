using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Models.Users
{
    public class LoginViewModelInput
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
