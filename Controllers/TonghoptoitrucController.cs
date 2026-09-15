using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Tonghoptoitruc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghoptoitrucController : ControllerBase
    {
        private readonly ITonghoptoitrucService _service;
        public TonghoptoitrucController(ITonghoptoitrucService service)
        {
            _service = service;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] TonghoptoitrucCreateRequest request)
        {
            var query = await _service.Create(request);
            return Ok(query);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(TonghoptoitrucUpdateRequest request)
        {
            var query = await _service.Update(request);
            return Ok(query);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = await _service.Delete(id);
            return Ok(query);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = await _service.GetById(id);
            return Ok(query);

        }
        [HttpGet("paging")]

        public async Task<IActionResult> Get([FromQuery] GetManagerTonghoptoitrucPagingRequest request)
        {
            var query = await _service.GetAllPaging(request);
            return Ok(query);

        }
        [HttpGet("sumTonghoptoitruc")]

        public async Task<ActionResult> SumTonghopmayxuc()
        {
            var query = await _service.SumTonghoptoitruc();
            return Ok(query);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var toitruc = await _service.GetAll();
            return Ok(toitruc);
        }


        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return BadRequest("Danh sách ID rỗng");

            var result = await _service.DeleteMutiple(ids);

            if (result == null || result.Count == 0)
                return NotFound("Không xóa được bản ghi nào");

            return Ok(new { deleted = result.Count });
        }
        [HttpGet("search")]
public async Task<IActionResult> Search([FromQuery] SearchTongHopRequest request)
{
    var result = await _service.SearchAsync(request);
    return Ok(result);
}

    }
}
