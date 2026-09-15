using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Giacotthuyluc.Tonghopgiacotthuyluc;
using WebApi.Services;
using WebApi.Data.Entites;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonghopgiacotthuylucController : ControllerBase
    {
        private readonly ITonghopgiacotthuylucService _tonghopgiacotthuylucService;
        public TonghopgiacotthuylucController(ITonghopgiacotthuylucService tonghopgiacotthuylucService)
        {
            _tonghopgiacotthuylucService = tonghopgiacotthuylucService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TonghopgiacotthuylucCreateRequest request)
        {
            var result = await _tonghopgiacotthuylucService.Create(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TonghopgiacotthuylucUpdateRequest request)
        {
            var result = await _tonghopgiacotthuylucService.Update(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tonghopgiacotthuylucService.Delete(id);
            return Ok(result);
        }

        [HttpGet("sum")]
        public async Task<IActionResult> SumTonghopgiacotthuyluc()
        {
            var result = await _tonghopgiacotthuylucService.SumTonghopgiacotthuyluc();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tonghopgiacotthuylucService.GetById(id);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] TonghopgiacotthuylucPagingRequest request)
        {
            var result = await _tonghopgiacotthuylucService.GetAllPaging(request);
            return Ok(result);
        }
    }
}