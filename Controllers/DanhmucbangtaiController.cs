using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucbangtaiController : ControllerBase
    {
        private readonly IDanhmucbangtaiService _danhmucbangtaiService;
        public DanhmucbangtaiController(IDanhmucbangtaiService danhmucbangtaiService)
        {
            _danhmucbangtaiService = danhmucbangtaiService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DanhmucbangtaiVM>>> GetAll()
        {
            var result = await _danhmucbangtaiService.GetAll();
            return Ok(result);
        }

        [HttpPost("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<DanhMucBangTai> response)
        {
            var result = await _danhmucbangtaiService.UpdateMultiple(response);
            if(result.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(result.Count);
        }

        [HttpPost("DeleteMultipale")]
        public async Task<IActionResult> DeleteMutiple([FromBody] List<DanhMucBangTai> response)
        {
            var result = await _danhmucbangtaiService.DeleteMutiple(response);
            if(result.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(result.Count);
        }
    }
}