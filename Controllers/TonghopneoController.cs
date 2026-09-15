using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Neo.TongHopNeo;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopneoController : ControllerBase
    {
        private readonly ITonghopneoService _tonghopneoService;

        public TonghopneoController(ITonghopneoService tonghopneoService)
        {
            _tonghopneoService = tonghopneoService;
        }

        [HttpGet("paging")]
        public async Task<ActionResult<PagedResult<TongHopNeoVm>>> GetAllPaging([FromQuery] TongHopNeoPagingRequest request)
        {
            var result = await _tonghopneoService.GetAllPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TongHopNeo>> GetById(int id)
        {
            var result = await _tonghopneoService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<List<TongHopNeoVm>>> GetDetailById(int id)
        {
            var result = await _tonghopneoService.GetDetailById(id);
            return Ok(result);
        }

        [HttpGet("sum")]
        public async Task<ActionResult<int>> GetSum()
        {
            var result = await _tonghopneoService.Sum();
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<TongHopNeoVm>>> GetAll()
        {
            var result = await _tonghopneoService.GetAll();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> Add([FromBody] TongHopNeo request)
        {
            var result = await _tonghopneoService.Add(request);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<bool>> Update([FromBody] TongHopNeo request)
        {
            var result = await _tonghopneoService.Update(request);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _tonghopneoService.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
        [HttpPost("Delete-Multiple")]
        public async Task<ActionResult<ApiResult<int>>> DeleteMultiple([FromBody] List<int> ids)
        {
            var result = await _tonghopneoService.DeleteMultiple(ids);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
    }
}