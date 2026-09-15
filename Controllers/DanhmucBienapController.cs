using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucBienapController : ControllerBase
    {
        public readonly IDanhmucBienApService _danhmucBienApService;
        public DanhmucBienapController(IDanhmucBienApService danhmucBienApService)
        {
            _danhmucBienApService = danhmucBienApService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucBienApService.GetAll();
            return Ok(query);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<DanhmucBienap> response)
        {
            var query = await _danhmucBienApService.UpdateMultiple(response);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucBienap> response)
        {
            var query = await _danhmucBienApService.DeleteMultiple(response);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] DanhmucBienap request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _danhmucBienApService.Add(request);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] DanhmucBienap request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _danhmucBienApService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteById(int Id)
        {
            var items = await _danhmucBienApService.Delete(Id);
            return Ok(items);
        }
        [HttpPost("DeleteSelect")]

        public async Task<IActionResult> DeleteSelect([FromBody] List<int> ids)
        {
            var query = await _danhmucBienApService.DeleteSelect(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
    }
}