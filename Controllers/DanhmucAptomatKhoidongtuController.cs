using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucAptomatKhoidongtuController : ControllerBase
    {
        public readonly IDanhmucAptomatKhoidongtuService _danhmucAptomatKhoidongtuService;
        public DanhmucAptomatKhoidongtuController(IDanhmucAptomatKhoidongtuService danhmucAptomatKhoidongtuService)
        {
            _danhmucAptomatKhoidongtuService = danhmucAptomatKhoidongtuService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucAptomatKhoidongtuService.GetAll();
            return Ok(query);
        }

        [HttpPost("UpdateMultiple")]
        public async Task<IActionResult> UpdateMultiple([FromBody] List<DanhmucAptomatKhoidongtu> response)
        {
            var query = await _danhmucAptomatKhoidongtuService.UpdateMultiple(response);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucAptomatKhoidongtu> response)
        {
            var query = await _danhmucAptomatKhoidongtuService.DeleteMultiple(response);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] List<DanhmucAptomatKhoidongtu> response)
        {
            // Check ModelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (response == null || response.Count == 0)
            {
                return BadRequest("Danh sách dữ liệu trống");
            }

            var successCount = 0;
            foreach (var item in response)
            {
                if (await _danhmucAptomatKhoidongtuService.Create(item))
                {
                    successCount++;
                }
            }
            return Ok(successCount);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] List<DanhmucAptomatKhoidongtu> response)
        {
            // Check ModelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (response == null || response.Count == 0)
            {
                return BadRequest("Danh sách dữ liệu trống");
            }

            var successCount = 0;
            var failedIds = new List<int>();

            foreach (var item in response)
            {
                if (item.Id <= 0)
                {
                    failedIds.Add(item.Id);
                    continue;
                }

                if (await _danhmucAptomatKhoidongtuService.Update(item))
                {
                    successCount++;
                }
                else
                {
                    failedIds.Add(item.Id);
                }
            }

            if (failedIds.Count > 0)
            {
                return BadRequest(new { message = $"Cập nhật thất bại {failedIds.Count} bản ghi. IDs: {string.Join(", ", failedIds)}", successCount });
            }

            return Ok(successCount);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteById(int Id)
        {
            var items = await _danhmucAptomatKhoidongtuService.Delete(Id);
            return Ok(items);
        }
        [HttpPost("Delete-Multiple")]
        public async Task<IActionResult> DeleteMultipleByIds([FromBody] List<int> ids)
        {
            var query = await _danhmucAptomatKhoidongtuService.DeleteMultipleByIds(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);
        }
    }
}