using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;
using Serilog;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _manager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserManager manager, ILogger<UsersController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                Log.Information($"Requisição:GET para api/Users");
                return Ok(await _manager.GetAllAsync());
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Users/username
        [HttpGet]
        [Route("username")]
        public async Task<ActionResult<User>> GetByUsername(string username)
        {
            try
            {
                Log.Information("Requisição:GET para api/Users/");
                var user = await _manager.GetByUsername(username);
                return Ok(user);
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // GET: api/Users/email
        [HttpGet]
        [Route("email")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            try
            {
                Log.Information("Requisição:GET para api/Users/");
                return Ok(await _manager.GetByEmailAsync(email));
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                Log.Information($"Requisição:GET para api/Users/{id}");
                return Ok(await _manager.GetByIdAsync(id));
            } catch (Exception ex)
            {
                Log.Error($"{ex.Message}");
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] UserPutRequestBody user)
        {
           try
           {
                Log.Information("Requisição:PUT para api/Users");
                var entityUpdate = await _manager.UpdateAsync(user);
                return Ok(entityUpdate);
           } catch (Exception ex)
           {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
           }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserPostRequestBody user)
        {
            try
            {
                Log.Information("Requisição:POST para api/Users");
                var entityInsert = await _manager.InsertAsync(user);
                return CreatedAtAction(nameof(GetUsers), new { id = entityInsert.Id }, entityInsert);
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try {
                Log.Information($"Requisição:DELETE para api/Users/{id}");
                await _manager.DeleteAsync(id);
                return NoContent();
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
            }
        }

    }
}
