using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.thietbi;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThietBiController : ControllerBase
    {
        public readonly IThietBiService _thietBiService;
        public ThietBiController(IThietBiService thietBiService)
        {
            _thietBiService = thietBiService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateThietBi([FromBody] ThietBiCreateResponse response)
        {
            var result = await _thietBiService.CreateThietBi(response);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateThietBi([FromBody] ThietBiUpdateResponse response)
        {
            var result = await _thietBiService.UpdateThietBi(response);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteThietBi(int id)
        {
            var result = await _thietBiService.DeleteThietBi(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var result = await _thietBiService.DeleteMultiple(ids);
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetThietBiById(int id)
        {
            var result = await _thietBiService.GetThietBiById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("search")]
        public async Task<IActionResult> SearchThietBi([FromBody] ThietBiSearch thietBiSearch)
        {
            var result = await _thietBiService.SearchThietBi(thietBiSearch);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<ThietBiDto>>> GetAll()
        {
            var result = await _thietBiService.GetAll();
            return Ok(result);
        }


    }
}