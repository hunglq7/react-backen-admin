using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ToiTruc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToitrucController : ControllerBase
    {
        private readonly IToitrucService _toitrucService;
        public ToitrucController(IToitrucService toitrucService)
        {
            _toitrucService = toitrucService;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery]GetManagerToitrucPagingRequest request)
        {
            var toitrucs = await _toitrucService.GetAllPaging(request);
            return Ok(toitrucs);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var query= await _toitrucService.GetAll();
            return Ok(query);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var toitruc = await _toitrucService.GetById(id);
            return Ok(toitruc);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ToitrucCreateRequest request)
        {
            var newToitruc = await _toitrucService.Create(request);
            return Ok(newToitruc);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ToitrucUpdateRequest toitruc)
        {
            var updateToitruc = await _toitrucService.Update(toitruc);
            return Ok(updateToitruc);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteToitruc = await _toitrucService.Delete(id);
            return Ok(deleteToitruc);
        }
    }
}
