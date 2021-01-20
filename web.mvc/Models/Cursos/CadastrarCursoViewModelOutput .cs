using System.ComponentModel.DataAnnotations;

namespace web.mvc.Models.Cursos
{
    public class CadastrarCursoViewModelOutput
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Login { get; set; }
    }
}
