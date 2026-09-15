using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu;
using WebApi.Models.Common;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TonghopaptomatkhoidongtuController : ControllerBase
    {
        protected readonly ITonghopaptomatkhoidongtuService _tonghopaptomatkhoidongtuService;
        public TonghopaptomatkhoidongtuController(ITonghopaptomatkhoidongtuService tonghopaptomatkhoidongtuService)
        {
            _tonghopaptomatkhoidongtuService = tonghopaptomatkhoidongtuService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _tonghopaptomatkhoidongtuService.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _tonghopaptomatkhoidongtuService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] TonghopaptomatkhoidongtuCreateRequest request)
        {
            var result = await _tonghopaptomatkhoidongtuService.Create(request);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] TonghopaptomatkhoidongtuUpdateRequest request)
        {
            var result = await _tonghopaptomatkhoidongtuService.Update(request);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tonghopaptomatkhoidongtuService.Delete(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("Delete-Multiple")]
        public async Task<IActionResult> DeleteMany(List<int> ids)
        {
            var result = await _tonghopaptomatkhoidongtuService.DeleteMany(ids);
            if (result == null || result.Count == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] TonghopaptomatkhoidongduPagingRequest request)
        {
            var data = await _tonghopaptomatkhoidongtuService.GetAllPaging(request);
            return Ok(data);
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetAllSearchPaging([FromQuery] SearchTongHopRequest request)
        {
            var data = await _tonghopaptomatkhoidongtuService.GetAllSearchPaging(request);
            return Ok(data);
        }
    }
}