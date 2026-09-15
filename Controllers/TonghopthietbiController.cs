using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Tonghopthietbi;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopthietbiController : ControllerBase
    {
        private readonly ITonghopthietbiService _tonghopthietbiService;
        public TonghopthietbiController(ITonghopthietbiService tonghopthietbiService)
        {
            _tonghopthietbiService = tonghopthietbiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTonghopthietbi()
        {
            var thietbi = await _tonghopthietbiService.GetTonghopthietbi();
            if (thietbi == null)
            {
                return NotFound();
            }
            return Ok(thietbi);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] TonghopthietbiPagingRequest request)
        {
            var query = await _tonghopthietbiService.GetAllPaging(request);
            return Ok(query);

        }
        [HttpPost]
        public async Task<ActionResult> AddTonghopthietbi([FromBody] ThietbiCreateRequest tongHopThietBi)
        {
            if (tongHopThietBi == null)
            {
                return BadRequest();
            }
            await _tonghopthietbiService.AddTonghopthietbi(tongHopThietBi);
            return Ok();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var thietbi = await _tonghopthietbiService.GetById(Id);
            return Ok(thietbi);
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateTonghopthietbi([FromBody] ThietbiUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopthietbiService.UpdateTonghopthietbi(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteTonghopthietbi(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopthietbiService.DeleteTonghopthietbi(id);
            return Ok();
        }
    }
}
