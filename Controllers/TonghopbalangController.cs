using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.TonghopBalang;
using WebApi.Models.Tonghopcapdien;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopbalangController : ControllerBase
    {
        private readonly ITonghopbalangService _tonghopbalangService;
        public TonghopbalangController(ITonghopbalangService tonghopbalangService)
        {
            _tonghopbalangService = tonghopbalangService;
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TonghopBalang request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopbalangService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var entity = await _tonghopbalangService.GetById(Id);
            return Ok(entity);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var entity = await _tonghopbalangService.getDatailById(Id);
            return Ok(entity);
        }


        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TonghopBalang request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopbalangService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopbalangService.Delete(id);
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] BalangPagingRequest request)
        {
            var query = await _tonghopbalangService.GetAllPaging(request);
            return Ok(query);

        }
        [HttpGet("sum")]
        public async Task<ActionResult> Sum()
        {
            var query = await _tonghopbalangService.Sum();
            return Ok(query);
        }
    }
}
