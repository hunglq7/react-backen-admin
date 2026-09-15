
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapdienController : ControllerBase
    {
        private ICapdienService _CapdienService;
        public CapdienController( ICapdienService capdienService)
        {
            _CapdienService = capdienService;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _CapdienService.GetAll();
            return Ok(query);
        }
        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _CapdienService.getDetailById(Id);
            return Ok(items);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<Capdien> request)
        {
            var query = await _CapdienService.UpdateMultiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<Capdien> request)
        {
            var query = await _CapdienService.DeleteMutiple(request);
            if (query.Count== 0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query.Count);
        }
    }
}
