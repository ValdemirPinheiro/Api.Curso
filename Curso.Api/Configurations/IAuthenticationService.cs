using curso.Api.Models.Users;

namespace curso.Api.Configurations
{
    public interface IAuthenticationService
    {
        string GerarToken(UserViewModelOutput userViewModelOutput);
    }
}
