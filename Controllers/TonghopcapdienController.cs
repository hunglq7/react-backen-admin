using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.TonghopBomnuc;
using WebApi.Models.Tonghopcapdien;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopcapdienController : ControllerBase
    {
        public readonly ITonghopcapdienService _tonghopcapdienService;
        public TonghopcapdienController(ITonghopcapdienService tonghopcapdienService)
        {
            _tonghopcapdienService = tonghopcapdienService;
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Tonghopcapdien request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopcapdienService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var entity = await _tonghopcapdienService.GetById(Id);
            return Ok(entity);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var entity = await _tonghopcapdienService.getDatailById(Id);
            return Ok(entity);
        }


        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] Tonghopcapdien request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopcapdienService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopcapdienService.Delete(id);
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] TonghopcapdienPagingRequest request)
        {
            var query = await _tonghopcapdienService.GetAllPaging(request);
            return Ok(query);

        }
        [HttpGet("sum")]
        public async Task<ActionResult> Sum()
        {
            var query = await _tonghopcapdienService.Sum();
            return Ok(query);
        }

    }
}
