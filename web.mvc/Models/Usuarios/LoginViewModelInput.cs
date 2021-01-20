using System.ComponentModel.DataAnnotations;

namespace web.mvc.Models.Usuarios
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

    }
}
