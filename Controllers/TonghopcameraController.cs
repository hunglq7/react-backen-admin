using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Tonghopthietbi;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopcameraController : ControllerBase
    {
private readonly ITonghopcameraService _tonghopcameraService;
        public TonghopcameraController(ITonghopcameraService tonghopcameraService)
        {
            _tonghopcameraService = tonghopcameraService;
            
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var query = await _tonghopcameraService.GetAll();
            if (query == null)
            {
                return NotFound();
            }
            return Ok(query);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TonghopCamera request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopcameraService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var query = await _tonghopcameraService.GetById(Id);
            return Ok(query);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TonghopCamera request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tonghopcameraService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _tonghopcameraService.Delete(id);
            return Ok();
        }
    }
}
