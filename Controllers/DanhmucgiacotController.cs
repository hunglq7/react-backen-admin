using Api.Data.Entites;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucgiacotController : ControllerBase
    {
        private readonly IDanhmucgiacotService _service;
        public DanhmucgiacotController(IDanhmucgiacotService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _service.GetAll();
            return Ok(query);

        }
        [HttpPost("DeleteSelect")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var query = await _service.DeleteMutiple(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] DanhmucGiaCot request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _service.Add(request);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] DanhmucGiaCot request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteById(int Id)
        {
            var items = await _service.Delete(Id);
            return Ok(items);
        }
    }
}
