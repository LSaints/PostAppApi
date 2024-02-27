using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;
using PostAppApi.Exceptions.PostExceptions;
using Serilog;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostManager _manager;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostManager manager, ILogger<PostsController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            try
            {
                Log.Information("Requisição:GET para api/Posts");
                return Ok(await _manager.GetAllAsync());
            } catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }


        // GET: api/Posts/user
        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult> GetPostByUserId(int id)
        {
            try
            {
                Log.Information($"Requisição:GET para api/Posts/user/{id}");
                return Ok(await _manager.GetAllPostsByUserIdAsync(id));
            } catch (PostNotFoundException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            try
            {
                Log.Information($"Requisição:GET para api/Posts/{id}");
                return Ok(await _manager.GetByIdAsync(id));
            } catch (PostNotFoundException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutPost(PostPutRequestBody post)
        {
            try
            {
                Log.Information("Requisição:PUT para api/Posts");
                var entityUpdate = await _manager.UpdateAsync(post);
                return Ok(entityUpdate);
            } catch (UnattributedPostException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            } catch (UserPostNotFoundException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            } catch (PostNotFoundException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(PostPostRequestBody post)
        {
            try
            {
                Log.Information("Requisição:POST para api/Posts");
                var entityInsert = await _manager.InsertAsync(post);
                return CreatedAtAction(nameof(GetPosts), new { id = entityInsert.Id }, entityInsert);
            } catch (UnattributedPostException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            } catch (UserPostNotFoundException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                Log.Information("Requisição:DELETE para api/Posts");
                await _manager.DeleteAsync(id);
                return NoContent();

            } catch (PostNotFoundException ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

    }
}
