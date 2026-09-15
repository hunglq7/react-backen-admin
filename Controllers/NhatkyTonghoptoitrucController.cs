using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Nhatkymayxuc;
using WebApi.Models.NhatkyTonghoptoitruc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkyTonghoptoitrucController : ControllerBase
    {
        private readonly INhatkyTonghoptoitrucService _service;
        public NhatkyTonghoptoitrucController(INhatkyTonghoptoitrucService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _service.GetAll();
            return Ok(query);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _service.getDetailById(Id);
            return Ok(items);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<NhatkyTonghoptoitruc> request)
        {
            var query = await _service.UpdateMultiple(request);
            if (query == null)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<NhatkyTonghoptoitruc> request)
        {
            var query = await _service.DeleteMutiple(request);
            if (query == null)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query);
        }

        [HttpGet("tonghop/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByTonghopAsync(id);
            return Ok(ApiResponse<List<NhatkyTonghoptoitrucVm>>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(NhatkyToitrucCreateDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Ok(ApiResponse<int>.Ok(id, "Thêm mới thành công"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NhatkyToitrucUpdateDto dto)
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
