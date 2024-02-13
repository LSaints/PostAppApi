using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Comunicacao.ModelViews.Rating;
using PostAppApi.Domain.Models;
using Serilog;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingManager _manager;
        private readonly ILogger<RatingsController> _logger;

        public RatingsController(IRatingManager manager, ILogger<RatingsController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        // GET: api/Ratings
        [HttpGet]
        public async Task<ActionResult> GetRatings()
        {
            try
            {
                Log.Information("Requisição:GET para api/Ratings");
                return Ok(await _manager.GetAllAsync());
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Post-User")]
        public async Task<IActionResult> GetRatingsOfPost([FromQuery(Name = "postId")] int postId, [FromQuery(Name = "userId")] int userId)
        {
            try
            {
                Log.Information("Requisição:GET para api/Ratings/Post-User");
                return Ok(await _manager.GetRatingOfPost(postId, userId));
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Post-RateStatus")]
        public async Task<IActionResult> getGetRatingsNumeric([FromQuery(Name = "postId")] int postId, [FromQuery(Name = "rateStatus")] int rateStatus)
        {
            try
            {
                Log.Information("Requisição:GET para api/Ratings/Post-RateStatus");
                return Ok(await _manager.GetRatingsNumeric(postId, rateStatus));
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // GET: api/Ratings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetRatings(int id)
        {
            try
            {
                Log.Information("Requisição:GET para api/Ratings");
                return Ok(await _manager.GetByIdAsync(id));
            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Ratings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutRating(Rating rating)
        {
            try
            {
                Log.Information("Requisição:PUT para api/Ratings");
                var entityUpdate = await _manager.UpdateAsync(rating);
                return Ok(entityUpdate);

            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // POST: api/Ratings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(PostRatingRequestBody rating)
        {
            try
            {
                Log.Information("Requisição:POST para api/Ratings");
                var entityInsert = await _manager.InsertAsync(rating);
                return CreatedAtAction(nameof(GetRatings), new { id = entityInsert.Id }, entityInsert);

            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Ratings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            try
            {
                Log.Information("Requisição:DELETE para api/Ratings");
                await _manager.DeleteAsync(id);
                return NoContent();

            } catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
