using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Services;
using PostAppApi.Comunicacao.ModelViews.User;
using Serilog;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _manager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserManager manager, ILogger<AuthController> logger)
        {
            _manager = manager;
            _logger = logger;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserLoginRequestBody user)
        {
            Log.Information("Requisição:POST para api/Auth");
            var userLogin = await _manager.GetByLogin(user);
            if (userLogin == null)
            {
                Log.Error("Usuario não encontrado");
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
            try
            {
                Log.Information("Requisição:GET para api/Auth");
                return Ok("Logado com sucesso!");
            } catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return Unauthorized(ex.Message);
            }
        }
    }
}
