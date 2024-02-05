using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Comunicacao.ModelViews.Rating;
using PostAppApi.Domain.Models;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingManager _manager;

        public RatingsController(IRatingManager manager)
        {
            _manager = manager;
        }

        // GET: api/Ratings
        [HttpGet]
        public async Task<ActionResult> GetRatings()
        {
            return Ok(await _manager.GetAllAsync());
        }

        [HttpGet("Post-User")]
        public async Task<IActionResult> GetRatingsOfPost([FromQuery(Name = "postId")] int postId, [FromQuery(Name = "userId")] int userId)
        {
            return Ok(await _manager.GetRatingOfPost(postId, userId));
        }

        [HttpGet("Post-RateStatus")]
        public async Task<IActionResult> getGetRatingsNumeric([FromQuery(Name = "postId")] int postId, [FromQuery(Name = "rateStatus")] int rateStatus)
        {
            return Ok(await _manager.GetRatingsNumeric(postId, rateStatus));
        }

        // GET: api/Ratings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetRatings(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // PUT: api/Ratings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutRating(Rating rating)
        {
            var entityUpdate = await _manager.UpdateAsync(rating);
            if (entityUpdate == null)
            {
                return NotFound();
            }
            return Ok(entityUpdate);
        }

        // POST: api/Ratings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(PostRatingRequestBody rating)
        {
            var entityInsert = await _manager.InsertAsync(rating);
            return CreatedAtAction(nameof(GetRatings), new { id = entityInsert.Id }, entityInsert);
        }

        // DELETE: api/Ratings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }
    }
}
