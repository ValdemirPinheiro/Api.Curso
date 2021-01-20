using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.mvc.Models.Cursos;
using web.mvc.Services;

namespace web.mvc.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput)
        {
            try
            {
                var curso = await _cursoService.Registrar(cadastrarCursoViewModelInput);
                ModelState.AddModelError("", $"O Curso foi cadastrado com sucesso {curso.Nome}");

            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

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
