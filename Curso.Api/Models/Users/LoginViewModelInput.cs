using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.Api.Models.Users
{
    public class LoginViewModelInput
    {

        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }


    }
}
