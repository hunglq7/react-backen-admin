using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Data.Entites;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TonghopKhoanBalangController : ControllerBase
    {
        private readonly ITonghopKhoanBalangService _tonghopKhoanBalangService;
        public TonghopKhoanBalangController(ITonghopKhoanBalangService tonghopKhoanBalangService)
        {
            _tonghopKhoanBalangService = tonghopKhoanBalangService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTonghopKhoanBalangs()
        {
            var result = await _tonghopKhoanBalangService.GetAll();
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> CreateTonghopKhoanBalang([FromBody] TongHopKhoanBalang dto)
        {
            var result = await _tonghopKhoanBalangService.Add(dto);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTonghopKhoanBalang([FromBody] TongHopKhoanBalang dto)
        {
            var result = await _tonghopKhoanBalangService.Update(dto);
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTonghopKhoanBalang(int id)
        {
            var result = await _tonghopKhoanBalangService.Delete(id);
            return Ok(result);
        }
        [HttpPost("Delete-Multiple")]
        public async Task<IActionResult> DeleteMultipleTonghopKhoanBalangs([FromBody] List<int> ids)
        {
            var result = await _tonghopKhoanBalangService.DeleteMultiple(ids);
            return Ok(result);
        }
    }
}