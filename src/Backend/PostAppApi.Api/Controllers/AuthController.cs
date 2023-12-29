using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.ModelViews.User;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return Ok("Login realizado com sucesso.");
        }
    }
}
