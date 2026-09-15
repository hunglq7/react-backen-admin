using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.MayCao.ThongsokythuatMayCao;
using WebApi.Models.ThongsokythuatMayXuc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongsokythuatmaycaoController : ControllerBase
    {
        public readonly IThongsokythuatmaycaoService _thongsokythuatmaycaoService;
        public ThongsokythuatmaycaoController(IThongsokythuatmaycaoService thongsokythuatmaycaoService)
        {
            _thongsokythuatmaycaoService = thongsokythuatmaycaoService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _thongsokythuatmaycaoService.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongsomaycaoPagingRequest request)
        {
            var query = await _thongsokythuatmaycaoService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ThongSoKyThuatMayCao request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsokythuatmaycaoService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items = await _thongsokythuatmaycaoService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _thongsokythuatmaycaoService.GetDetailById(Id);
            return Ok(items);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ThongSoKyThuatMayCao request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsokythuatmaycaoService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsokythuatmaycaoService.Delete(id);
            return Ok();
        }

     
        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return BadRequest("Danh sách ID rỗng");

            var result = await _thongsokythuatmaycaoService.DeleteMultiple(ids);

            if (result == null || result.Count == 0)
                return NotFound("Không xóa được bản ghi nào");

            return Ok(new { deleted = result.Count });
        }

    }
}
