using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using web.mvc.Models.Usuarios;

namespace web.mvc.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(RegistrarUsuarioViewModelInput registrarUsuarioViewModelInput)
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            var httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = new Uri("https://localhost:5001/");

           var registrarUsuarioViewModelInputJson = JsonConvert.SerializeObject(registrarUsuarioViewModelInput);
            var httpContent = new StringContent(registrarUsuarioViewModelInputJson, Encoding.UTF8, "application/json");

            var httpPost = httpClient.PostAsync("/api/v1/user/register", httpContent).GetAwaiter().GetResult();
            
            if(httpPost.StatusCode == System.Net.HttpStatusCode.Created)
            {
                                ModelState.AddModelError("", "Os dados foram cadastrados com sucesso");
            }
            else
            {
                                ModelState.AddModelError("", "Erro ao cadastrar");

            }
            return View();
        }

        public IActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return View();
        }
    }
}
