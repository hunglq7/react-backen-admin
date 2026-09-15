using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapnhatgiacotController : ControllerBase
    {
        private readonly ICapnhatgiacotService _service;
        public CapnhatgiacotController(ICapnhatgiacotService capnhatgiacotService)
        {
            _service = capnhatgiacotService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _service.GetAll();
            return Ok(query);

        }
        [HttpPost("DeleteSelect")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var query = await _service.DeleteMutiple(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] CapNhatGiaCot request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _service.Add(request);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] CapNhatGiaCot request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteById(int Id)
        {
            var items = await _service.Delete(Id);
            return Ok(items);
        }
    }

}
