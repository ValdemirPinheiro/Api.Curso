using Refit;
using System.Threading.Tasks;
using web.mvc.Models.Usuarios;

namespace web.mvc.Services
{
   public interface IUsuarioService
    {
        [Post("/api/v1/user/register")]
        Task<RegistrarUsuarioViewModelInput> Registrar(RegistrarUsuarioViewModelInput registrarUsuarioViewModelInput);

        [Post("/api/v1/user/login")]
        Task <LoginViewModelOutput> Login(LoginViewModelInput loginViewModelInput );
    }
}
