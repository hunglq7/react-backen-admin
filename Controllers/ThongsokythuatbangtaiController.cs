using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;
using WebApi.Models.MayCao.ThongsokythuatMayCao;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongsokythuatbangtaiController : ControllerBase
    {
        private readonly IThongsokythuatbangtaiService _thongsokythuatbangtaiService;
        public ThongsokythuatbangtaiController(IThongsokythuatbangtaiService thongsokythuatbangtaiService)
        {
            _thongsokythuatbangtaiService = thongsokythuatbangtaiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _thongsokythuatbangtaiService.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ThongsokythuatbangtaiDetailByIdVM>>> GetById(int id)
        {
            var result = await _thongsokythuatbangtaiService.getDatailById(id);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongSoKyThuatBangTaiPagingRequest request)
        {
            var query = await _thongsokythuatbangtaiService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ThongSoKyThuatBangTaiEdit request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsokythuatbangtaiService.Add(request);
            return Ok();
        }
        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult<ThongsokythuatbangtaiDetailByIdVM>> GetDetailById(int Id)
        {
            var items = await _thongsokythuatbangtaiService.getDatailById(Id);
            return Ok(items);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ThongSoKyThuatBangTaiEdit request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsokythuatbangtaiService.Update(request);
            return Ok();
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsokythuatbangtaiService.Delete(id);
            return Ok();
        }

    }
}