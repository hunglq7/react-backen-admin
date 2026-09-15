using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Phongban;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongbanController : ControllerBase
    {
        private readonly IPhongbanService _phongbanService;
        private readonly ThietbiDbContext _thietbiDbContext;
        public PhongbanController(IPhongbanService phongbanService, ThietbiDbContext thietbiDbContext)
        {
            _phongbanService = phongbanService;
            _thietbiDbContext = thietbiDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetPhongban()
        {
            var phongban = await _phongbanService.GetPhongban();
            return Ok(phongban);

        }

        [HttpPost]
        public async Task<ActionResult> CreatePhongban(PhongbanCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var phongban = await _phongbanService.CreatePhongban(request);
            return Ok(phongban);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhongban(PhongbanVm phongban)
        {
            var phongBanEntity = new PhongBan
            {
                Id = phongban.Id,
                TenPhong = phongban.TenPhong,
                TrangThai = phongban.TrangThai
            };
            var Result = await _phongbanService.Update(phongBanEntity);
            if (!Result)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhongban(int id)
        {
            var result = await _phongbanService.Delete(id);
            if (!result)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<PhongBan> phongBan)
        {

            var response = await _phongbanService.UpdateMultiple(phongBan);
            if (response.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(response.Count);
        }
        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<PhongBan> phongBan)
        {
            var response = await _phongbanService.DeleteMutiple(phongBan);
            if (response.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(response.Count);

        }

        [HttpPost("DeleteSelect")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var query = await _phongbanService.DeleteSelect(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
    }
}
