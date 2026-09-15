using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.AptomatKhoidongtu.NhatkyAptomatKhoidongtu;
using WebApi.Services;
using WebApi.Data.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhatkyaptomatkhoidongtuController : ControllerBase
    {
        private readonly INhatkyaptomatkhoidongtuService _nhatkyaptomatkhoidongtuService;

        public NhatkyaptomatkhoidongtuController(INhatkyaptomatkhoidongtuService nhatkyaptomatkhoidongtuService)
        {
            _nhatkyaptomatkhoidongtuService = nhatkyaptomatkhoidongtuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _nhatkyaptomatkhoidongtuService.GetAll();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("DetailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _nhatkyaptomatkhoidongtuService.getDatailById(Id);
            return Ok(items);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMultiple([FromBody] List<Nhatkyaptomatkhoidongtu> request)
        {
            if (request == null || !request.Any())
            {
                return BadRequest();
            }
            var result = await _nhatkyaptomatkhoidongtuService.UpdateMutiple(request);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteMultiple")]
        public async Task<ActionResult> DeleteMultiple([FromBody] List<Nhatkyaptomatkhoidongtu> request)
        {
            if (request == null || !request.Any())
            {
                return BadRequest();
            }
            var result = await _nhatkyaptomatkhoidongtuService.DeleteMutiple(request);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}