using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucgiacotthuylucController : ControllerBase
    {
        public readonly IDanhmucgiacotthuylucService _danhmucgiacotthuylucService;
        public DanhmucgiacotthuylucController(IDanhmucgiacotthuylucService danhmucgiacotthuylucService)
        {
            _danhmucgiacotthuylucService = danhmucgiacotthuylucService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucgiacotthuylucService.GetAll();
            return Ok(query);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<Danhmucgiacotthuyluc> response)
        {
            var query = await _danhmucgiacotthuylucService.UpdateMultiple(response);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<Danhmucgiacotthuyluc> response)
        {
            var query = await _danhmucgiacotthuylucService.DeleteMultiple(response);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);
        }
    }
}