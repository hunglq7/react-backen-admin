using Api.Models.Tonghopmayxuc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Common;
using WebApi.Models.Tonghopmayxuc;
using WebApi.Models.Tonghopthietbi;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopmayxucController : ControllerBase
    {
        private readonly ITonghopmayxucService _tonghopmayxucService;
        public TonghopmayxucController(ITonghopmayxucService tonghopmayxucService)
        {
            _tonghopmayxucService = tonghopmayxucService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTonghopmayxuc()
        {
            var mayxuc = await _tonghopmayxucService.GetTonghopmayxuc();
            if (mayxuc == null)
            {
                return NotFound();
            }
            return Ok(mayxuc);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddTonghopmayxuc([FromBody] MayxucCreateRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopmayxucService.AddTonghopmayxuc(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var mayxuc = await _tonghopmayxucService.GetById(Id);
            return Ok(mayxuc);
        }

        [HttpGet("DatailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var mayxuc = await _tonghopmayxucService.getDatailById(Id);
            return Ok(mayxuc);
        }
        [HttpGet("sumTonghopmayxuc")]

        public async Task<ActionResult> SumTonghopmayxuc()
        {
            var query = await _tonghopmayxucService.SumTonghopmayxuc();
            return Ok(query);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateTonghopmayxuc([FromBody] MayxucUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopmayxucService.UpdateTonghopmayxuc(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteTonghopmayxuc(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopmayxucService.DeleteTonghopmayxuc(id);
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] GetManagerTonghopMayxucPagingRequest request)
        {
            var query = await _tonghopmayxucService.GetAllPaging(request);
            return Ok(query);

        }

         [HttpGet("QueryParametersPaging")]
        public async Task<IActionResult> QueryParametersPaging([FromQuery] QueryParameters request)
        {
            var query = await _tonghopmayxucService.GetQueryParametersPaging(request);
            return Ok(query);

        }


        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return BadRequest("Danh sách ID rỗng");

            var result = await _tonghopmayxucService.DeleteMutiple(ids);

            if (result == null || result.Count == 0)
                return NotFound("Không xóa được bản ghi nào");

            return Ok(new { deleted = result.Count });
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchTongHopRequest request)
        {
            var result = await _tonghopmayxucService.SearchAsync(request);
            return Ok(result);
        }
        [HttpGet("queryParametetsPage")]
        public async Task<IActionResult> QueryParametersPage([FromQuery] QueryParametersPage request)
        {
            var result = await _tonghopmayxucService.QueryAsync(request);
            return Ok(result);
        }

    }
}
