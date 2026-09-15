using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Thongsokythuattoitruc;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ThongsokythuatMayXuc;
using WebApi.Models.Thongsokythuattoitruc;
using WebApi.Models.ThongsoQuatgio;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongsokythuattoitrucController : ControllerBase
    {
        private readonly IThongsokythuattoitrucService _thongsokythuattoitrucService;
        public ThongsokythuattoitrucController(IThongsokythuattoitrucService thongsokythuattoitrucService)
        {
            _thongsokythuattoitrucService = thongsokythuattoitrucService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _thongsokythuattoitrucService.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongsotoitrucPagingRequest request)
        {
            var query = await _thongsokythuattoitrucService.GetAllPaging(request);
            return Ok(query);

        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ThongsokythuattoitrucEdit request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsokythuattoitrucService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items = await _thongsokythuattoitrucService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _thongsokythuattoitrucService.getDetailById(Id);
            return Ok(items);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ThongsokythuattoitrucEdit request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsokythuattoitrucService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsokythuattoitrucService.Delete(id);
            return Ok();
        }

        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return BadRequest("Danh sách ID rỗng");

            var result = await _thongsokythuattoitrucService.DeleteMutiple(ids);

            if (result == null || result.Count == 0)
                return NotFound("Không xóa được bản ghi nào");

            return Ok(new { deleted = result.Count });
        }

    }
}