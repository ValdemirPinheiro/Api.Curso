using curso.Api.Business.Entities;

namespace curso.Api.Business.Repositories
{
    public interface IUserRepository
    {
        void Adicionar(User user);
        void Commit();
        User ObterUser(string login);
    }
}
