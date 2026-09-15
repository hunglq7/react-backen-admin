using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Nhatkymayxuc;
using WebApi.Models.ThongsokythuatMayXuc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkymayxucController : ControllerBase
    {
        private readonly INhatkymayxucService _service;

        public NhatkymayxucController(INhatkymayxucService service)
        {
            _service = service;
        }

        [HttpGet("tonghop/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByTonghopAsync(id);
            return Ok(ApiResponse<List<NhatkymayxucVm>>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhatkyMayxucCreateDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(ApiResponse<int>.Ok(id, "Thêm mới thành công"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NhatkyMayxucUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest(ApiResponse<string>.Fail("Id không khớp"));

            await _service.UpdateAsync(dto);
            return Ok(ApiResponse<bool>.Ok(true, "Cập nhật thành công"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(ApiResponse<bool>.Ok(true, "Đã xóa"));
        }

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteMultiple(List<int> ids)
        {
            var count = await _service.DeleteMultipleAsync(ids);
            return Ok(ApiResponse<int>.Ok(count, "Xóa nhiều dòng thành công"));
        }
    }
}
