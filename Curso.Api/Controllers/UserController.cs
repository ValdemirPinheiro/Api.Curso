using curso.Api.Business.Entities;
using curso.Api.Business.Repositories;
using curso.Api.Configurations;
using curso.Api.Filters;
using curso.Api.Infraestruture.Data;
using curso.Api.Infraestruture.Data.Repositories;
using curso.Api.Models;
using curso.Api.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace curso.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserController(

            IUserRepository userRepository,
            IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {

           var user = _userRepository.ObterUser(loginViewModelInput.Login);

            if (user == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            //if(user.Password != loginViewModel.Password.GerarSenhaCriptografada())
           // {
           //     return BadRequest("Houve um erro ao tentar acessar.");
           // }
            var userViewModelOutput = new UserViewModelOutput()
            {
                Codigo = user.Codigo,
                Login = loginViewModelInput.Login,
                Email = user.Email
            };

            var token = _authenticationService.GerarToken(userViewModelOutput);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        /// <summary>
        /// Este serviço permite cadastrar um usuário cadastrado não existente
        /// </summary>
        /// <param name="loginViewModelInput">View model do registro de login</param>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("register")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Register(LoginViewModelInput loginViewModelInput)
        {


            // var migracoesPendentes = contexto.Database.GetPendingMigrations();
            //  if (migracoesPendentes.Count() > 0)
            // {
            //     contexto.Database.Migrate();
            // }



            var user = new User();
            user.Login = loginViewModelInput.Login;
            user.Password = loginViewModelInput.Password;
            user.Email = loginViewModelInput.Email;
            _userRepository.Adicionar(user);
            _userRepository.Commit();

            return Created("", loginViewModelInput);
        }
    }


}
