using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _manager;
        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _manager.GetAllAsync());
        }

        // GET: api/Users/username
        [HttpGet]
        [Route("username")]
        public async Task<ActionResult<User>> GetByUsername(string username)
        {
            var user = await _manager.GetByUsername(username);
            if (user == null)
            {
                return NotFound("Usuario não encontrado 404");
            }
            return Ok(user);
        }

        // GET: api/Users/email
        [HttpGet]
        [Route("email")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            return Ok(await _manager.GetByEmailAsync(email));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] UserPutRequestBody user)
        {
            var entityUpdate = await _manager.UpdateAsync(user);
            if (entityUpdate == null) 
            {
                return NotFound();
            }
            return Ok(entityUpdate);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserPostRequestBody user)
        {
            var entityInsert = await _manager.InsertAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = entityInsert.Id }, entityInsert);

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }

    }
}
