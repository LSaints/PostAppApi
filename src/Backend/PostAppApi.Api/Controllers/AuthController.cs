using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Services;
using PostAppApi.Comunicacao.ModelViews.User;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _manager;
        public AuthController(IUserManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserLoginRequestBody user)
        {
            var userLogin = await _manager.GetByLogin(user);
            if (userLogin == null)
            {
                return NotFound(new { message = "Usuario não encontrado"});
            }
            var token = TokenServices.GenerateToken(user);
            return new
            {
                userLogin,
                token = token,
            };
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> Authenticate()
        {
            return Ok("Logado com sucesso!");
        }
    }
}
