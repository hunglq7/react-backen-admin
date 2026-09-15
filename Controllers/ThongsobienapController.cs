using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Bienap.Thongsokythuatbienap;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongsobienapController : ControllerBase
    {
        private readonly IThongsobienapService _thongsobienapService;
        public ThongsobienapController(IThongsobienapService thongsobienapService)
        {
            _thongsobienapService = thongsobienapService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _thongsobienapService.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _thongsobienapService.GetById(id);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] ThongsoBienapPagingRequest request)
        {
            var query = await _thongsobienapService.GetAllPaging(request);
            return Ok(query);
        }

        [HttpGet("DetailById/{id}")]
        public async Task<ActionResult> GetDetailById(int id)
        {
            var items = await _thongsobienapService.getDatailById(id);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ThongSoKyThuatBienAp request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsobienapService.Add(request);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ThongSoKyThuatBienAp request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsobienapService.Update(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsobienapService.Delete(id);
            return Ok();
        }
    }
}