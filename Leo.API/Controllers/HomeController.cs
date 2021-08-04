using Leo.Core.Models;
using Leo.Core.Repository;
using Leo.Service.Password;
using Leo.Service.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Leo.API.Controllers
{
    [Route("api/v1")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("token")]
        [AllowAnonymous]
        public string Token() => TokenService.GenerateToken();

        [HttpGet]
        [Authorize]
        [Route("createpassword")]
        public string CreatePassword() => PasswordService.New();

        [HttpGet]
        [Authorize]
        [Route("validatepassword")]        
        public bool ValidatePassword(string password) => PasswordService.Validate(password);

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            //Mock
            var user = MockUserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário/Senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = String.Empty;
            return new
            {
                user = user,
                token = token,
                validatetoken = DateTime.Now.AddMinutes(5)
            };
        }
    }
}
