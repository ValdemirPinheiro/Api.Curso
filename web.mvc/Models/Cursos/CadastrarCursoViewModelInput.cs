using System.ComponentModel.DataAnnotations;

namespace web.mvc.Models.Cursos
{
    public class CadastrarCursoViewModelInput
    {
        [Required(ErrorMessage = "O Nome do curso é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição do curso é obrigatória")]
        public string Descricao { get; set; }
    }
}
