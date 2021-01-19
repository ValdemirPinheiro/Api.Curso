using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.mvc.Models.Cursos;

namespace web.mvc.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput)
        {
            return View();
        }

        
        public IActionResult Listar()
        {
            var cursos = new List<ListrarCursoViewModelOutput>();

            cursos.Add(new ListrarCursoViewModelOutput()
            {
                Nome = "Curso A",
                Descricao = "Descricao Curso A",
                Login = "Valdemir Pinheiro"
            });

            cursos.Add(new ListrarCursoViewModelOutput()
            {
                Nome = "Curso B",
                Descricao = "Descricao Curso B",
                Login = "Valdemir Pinheiro"
            });
            return View(cursos);
        }

    }
}
