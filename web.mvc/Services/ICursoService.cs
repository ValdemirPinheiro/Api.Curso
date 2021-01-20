using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.mvc.Models.Cursos;

namespace web.mvc.Services
{
    public interface ICursoService
    {
        [Post("/api/v1/cursos")]
        Task<CadastrarCursoViewModelOutput> Registrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput);

    }
}
