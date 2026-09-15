using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucKhoanBaLangController : ControllerBase
    {
        private readonly IDanhmucKhoanBalangService _danhmucBalangService;
        public DanhmucKhoanBaLangController(IDanhmucKhoanBalangService danhmucKhoanBalangService)
        {
            _danhmucBalangService = danhmucKhoanBalangService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDanhmucKhoanBalangs()
        {
            var result = await _danhmucBalangService.GetAll();
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> CreateDanhmucKhoanBalang([FromBody] DanhmucKhoanBalang dto)
        {
            var result = await _danhmucBalangService.Add(dto);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDanhmucKhoanBalang([FromBody] DanhmucKhoanBalang dto)
        {
            var result = await _danhmucBalangService.Update(dto);
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDanhmucKhoanBalang(int id)
        {
            var result = await _danhmucBalangService.Delete(id);
            return Ok(result);
        }
        [HttpPost("Delete-Multiple")]
        public async Task<IActionResult> DeleteMultipleDanhmucKhoanBalangs([FromBody] List<int> ids)
        {
            var result = await _danhmucBalangService.DeleteMultiple(ids);
            return Ok(result);
        }
    }
}