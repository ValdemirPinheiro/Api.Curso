using curso.Api.Business.Entities;
using curso.Api.Business.Repositories;
using System.Linq;

namespace curso.Api.Infraestruture.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CursoDbContext _contexto;

        public UserRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(User user)
        {
            _contexto.User.Add(user);
            
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public User ObterUser(string login)
        {
            return _contexto.User.FirstOrDefault(u => u.Login == login);
        }
    }
}
