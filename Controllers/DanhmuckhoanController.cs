using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucKhoanController : ControllerBase
    {
        private readonly IDanhmucKhoanService _danhmucKhoanService;

        public DanhmucKhoanController(IDanhmucKhoanService danhmucKhoanService)
        {
            _danhmucKhoanService = danhmucKhoanService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucKhoanService.GetAll();
            return Ok(query);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<DanhMucKhoan> response)
        {
            var result = await _danhmucKhoanService.UpdateMultiple(response);
            if (result.Count == 0)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Count);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] DanhMucKhoan dto)
        {
            var result = await _danhmucKhoanService.Add(dto);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DanhMucKhoan dto)
        {
            var result = await _danhmucKhoanService.Update(dto);
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhmucKhoanService.Delete(id);
            return Ok(result);
        }
        [HttpPost("Delete-Multiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var result = await _danhmucKhoanService.DeleteMultiple(ids);
            return Ok(result);
        }
    }
}