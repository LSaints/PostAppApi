using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostManager _manager;

        public PostsController(IPostManager manager)
        {
            _manager = manager;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            return Ok(await _manager.GetAllAsync());
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutPost(PostPutRequestBody post)
        {
            var entityUpdate = await _manager.UpdateAsync(post);
            if (entityUpdate == null)
            {
                return NotFound();
            }
            return Ok(entityUpdate);
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(PostPostRequestBody post)
        {
            var entityInsert = await _manager.InsertAsync(post);
            return CreatedAtAction(nameof(GetPosts), new { id = entityInsert.Id }, entityInsert);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }

    }
}
