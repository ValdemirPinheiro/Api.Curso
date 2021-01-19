using System.ComponentModel.DataAnnotations;

namespace web.mvc.Models.Usuarios
{
    public class RegistrarUsuarioViewModelInput
    {
        [Required(ErrorMessage ="O login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido")]
        public string Email { get; set; }
    }
}
