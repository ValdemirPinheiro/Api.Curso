using curso.Api.Business.Entities;
using System.Collections.Generic;

namespace curso.Api.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso cursos);
        void Commit();

        IList<Curso> ObterPorUser(int codigoUser);
    }
}
