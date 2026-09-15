using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopbangtaiController : ControllerBase
    {
        private readonly ITonghopbangtaiService _tonghopbangtaiService;
        public TonghopbangtaiController(ITonghopbangtaiService tonghopbangtaiService)
        {
            _tonghopbangtaiService = tonghopbangtaiService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TonghopbangtaiVM>>> GetTonghopbangtai()
        {
            var result = await _tonghopbangtaiService.GetTonghopbangtai();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TongHopBangTai>> GetById(int id)
        {
            var result = await _tonghopbangtaiService.GetById(id);
            return Ok(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<List<TonghopbangtaiDetailByIdVM>>> GetDetailById(int id)
        {
            var result = await _tonghopbangtaiService.getDatailById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddTonghopbangtai([FromBody] TonghopbangtaiCreateRequest request)
        {
            var result = await _tonghopbangtaiService.AddTonghopbangtai(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateTonghopbangtai([FromBody] TonghopbangtaiUpdateRequest request)
        {
            var result = await _tonghopbangtaiService.UpdateTonghopbangtai(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTonghopbangtai(int id)
        {
            var result = await _tonghopbangtaiService.DeleteTonghopbangtai(id);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<ActionResult<PagedResult<TonghopbangtaiVM>>> GetAllPaging([FromQuery] GetManagerTonghopBangtaiPagingRequest request)
        {
            var result = await _tonghopbangtaiService.GetAllPaging(request);
            return Ok(result);
        }

        [HttpGet("sum")]
        public async Task<ActionResult<int>> SumTonghopbangtai()
        {
            var result = await _tonghopbangtaiService.SumTonghopbangtai();
            return Ok(result);
        }
    }
}