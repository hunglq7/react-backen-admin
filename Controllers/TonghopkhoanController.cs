using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.TonghopKhoan;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopKhoanController : ControllerBase
    {
        private readonly ITonghopKhoanService _tonghopKhoanService;

        public TonghopKhoanController(ITonghopKhoanService tonghopKhoanService)
        {
            _tonghopKhoanService = tonghopKhoanService;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TongHopKhoan request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _tonghopKhoanService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var entity = await _tonghopKhoanService.GetById(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var entity = await _tonghopKhoanService.GetDetailById(Id);
            if (entity == null || entity.Count == 0)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] TongHopKhoan request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _tonghopKhoanService.Update(request);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _tonghopKhoanService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] KhoanPagingRequest request)
        {
            var query = await _tonghopKhoanService.GetAllPaging(request);
            return Ok(query);
        }
        [HttpGet("sum")]
        public async Task<ActionResult> Sum()
        {
            var query = await _tonghopKhoanService.Sum();
            return Ok(query);
        }
    }
}