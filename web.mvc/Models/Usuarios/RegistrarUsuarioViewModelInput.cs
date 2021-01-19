using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.mvc.Models.Usuarios
{
    public class RegistrarUsuarioViewModelInput
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
