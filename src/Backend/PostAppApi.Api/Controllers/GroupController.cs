using Microsoft.AspNetCore.Mvc;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Comunicacao.ModelViews.Group;
using PostAppApi.Domain.Models;
using PostAppApi.Exceptions.PostExceptions;
using Serilog;

namespace PostAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private readonly IGroupManager _manager;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupManager manager, ILogger<GroupController> logger)
        {
            _manager = manager;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult> GetGroups()
        {
            try
            {
                Log.Information("Requisição:GET para api/Groups");
                return Ok(await _manager.GetAllAsync());
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetGroup(int id)
        {
            try
            {
                Log.Information($"Requisição:GET para api/group/{id}");
                return Ok(await _manager.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutGroup(GroupPutRequestBody group)
        {
            try
            {
                Log.Information("Requisição:PUT para api/group");
                var entityUpdate = await _manager.UpdateAsync(group);
                return Ok(entityUpdate);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostGroup(GroupPostRequestBody group)
        {
            try
            {
                Log.Information("Requisição:POST para api/group");
                var entityInsert = await _manager.InsertAsync(group);
                return CreatedAtAction(nameof(GetGroups), new { id = entityInsert.Id }, entityInsert);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        [Route("add/user={UserId}group={GroupId}")]
        public async Task<ActionResult> AddUserToGroup(int UserId, int GroupId)
        {
            try
            {
                Log.Information("Requisição:POST para api/group");
                var entityInsert = await _manager.AddUserToGroup(UserId, GroupId);
                return CreatedAtAction(nameof(GetGroups), entityInsert);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                Log.Information("Requisição:DELETE para api/group");
                await _manager.DeleteAsync(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

    }
}
