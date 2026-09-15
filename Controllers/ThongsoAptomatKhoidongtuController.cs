using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.AptomatKhoidongtu.ThongsoAptomatKhoidongtu;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongsoAptomatKhoidongtuController : ControllerBase
    {
        private readonly IThongsoAptomatKhoidongtuService _thongsoAptomatKhoidongtuService;

        public ThongsoAptomatKhoidongtuController(IThongsoAptomatKhoidongtuService thongsoAptomatKhoidongtuService)
        {
            _thongsoAptomatKhoidongtuService = thongsoAptomatKhoidongtuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _thongsoAptomatKhoidongtuService.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] ThongsoAptomatKhoidongtuPagingRequest request)
        {
            var query = await _thongsoAptomatKhoidongtuService.GetAllPaging(request);
            return Ok(query);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ThongsoAptomatKhoidongtuEdit request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _thongsoAptomatKhoidongtuService.Add(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            var items = await _thongsoAptomatKhoidongtuService.GetById(Id);
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _thongsoAptomatKhoidongtuService.GetDetailById(Id);
            return Ok(items);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] ThongsoAptomatKhoidongtuEdit request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _thongsoAptomatKhoidongtuService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _thongsoAptomatKhoidongtuService.Delete(id);
            return Ok();
        }
    }
}