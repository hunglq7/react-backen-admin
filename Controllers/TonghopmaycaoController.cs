using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.MayCao.Tonghopmaycao;
using WebApi.Models.TonghopBomnuc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopmaycaoController : ControllerBase
    {
        public readonly ITonghopmaycaoService _tonghopmaycaoService;
        public TonghopmaycaoController(ITonghopmaycaoService tonghopmaycaoService)
        {
            _tonghopmaycaoService = tonghopmaycaoService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] TongHopMayCao request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopmaycaoService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var entity = await _tonghopmaycaoService.GetById(Id);
            return Ok(entity);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var entity = await _tonghopmaycaoService.GetDetailById(Id);
            return Ok(entity);
        }
        [HttpGet("sum")]

        public async Task<ActionResult> Sum()
        {
            var query = await _tonghopmaycaoService.Sum();
            return Ok(query);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TongHopMayCao request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopmaycaoService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopmaycaoService.Delete(id);
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] TonghopmaycaoPagingRequest request)
        {
            var query = await _tonghopmaycaoService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetMaycao()
        {
            var maycao = await _tonghopmaycaoService.GetMaycao();
            return Ok(maycao);
        }
        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return BadRequest("Danh sách ID rỗng");

            var result = await _tonghopmaycaoService.DeleteMutiple(ids);

            if (result == null || result.Count == 0)
                return NotFound("Không xóa được bản ghi nào");

            return Ok(new { deleted = result.Count });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchTongHopRequest request)
        {
            var result = await _tonghopmaycaoService.SearchAsync(request);
            return Ok(result);
        }
    }
}
