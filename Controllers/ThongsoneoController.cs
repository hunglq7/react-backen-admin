using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.MayCao.ThongsokythuatMayCao;
using WebApi.Models.Neo.ThongsoNeo;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongsoneoController : ControllerBase
    {
        public readonly IThongsoNeoService _thongsoNeoService;
        public ThongsoneoController(IThongsoNeoService thongsoNeoService)
        {
            _thongsoNeoService = thongsoNeoService;
        }
     

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongsoNeoPagingRequest request)
        {
            var query = await _thongsoNeoService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ThongsoNeo request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsoNeoService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items = await _thongsoNeoService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _thongsoNeoService.GetDetailById(Id);
            return Ok(items);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ThongsoNeo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsoNeoService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsoNeoService.Delete(id);
            return Ok();
        }
    }
}
