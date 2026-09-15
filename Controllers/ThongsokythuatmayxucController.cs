using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ThongsokythuatMayXuc;
using WebApi.Models.ThongsoQuatgio;
using WebApi.Models.Tonghopmayxuc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongsokythuatmayxucController : ControllerBase
    {
        public readonly IThongsokythuatmayxucService _thongsokythuatmayxucService;

        public ThongsokythuatmayxucController( IThongsokythuatmayxucService thongsokythuatmayxucService)
        {
            _thongsokythuatmayxucService = thongsokythuatmayxucService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _thongsokythuatmayxucService.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongsomayxucPagingRequest request)
        {
            var query = await _thongsokythuatmayxucService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ThongsokythuatEdit request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsokythuatmayxucService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items= await _thongsokythuatmayxucService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items= await _thongsokythuatmayxucService.getDatailById(Id);
            return Ok(items);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ThongsokythuatEdit request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsokythuatmayxucService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsokythuatmayxucService.Delete(id);
            return Ok();
        }
        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var result = await _thongsokythuatmayxucService.DeleteMutiple(ids);
            return Ok(result);
        }
    }
}
