using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucbalangController : ControllerBase
    {
        public readonly IDanhmucBalangService _danhmucBalangService;
        public DanhmucbalangController(IDanhmucBalangService danhmucBalangService)
        {
            _danhmucBalangService = danhmucBalangService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucBalangService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucBaLang> reponse)
        {

            var query = await _danhmucBalangService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucBaLang> reponse)
        {
            var query = await _danhmucBalangService.DeleteMutiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
    }
}
