using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Chucvu;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucvuController : ControllerBase
    {
        private readonly IChucvuService _chucvuService;
        private readonly ThietbiDbContext _thietbiDbContext;
        public ChucvuController(ThietbiDbContext thietbiDbContext,IChucvuService chucvuService)
        {
            _thietbiDbContext = thietbiDbContext;
            _chucvuService = chucvuService;
        }


        [HttpGet]  
        public async Task<ActionResult> GetChucvu ()
        {
            var chucvu = await _chucvuService.GetChucvu();
            return Ok(chucvu);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<ChucVu> chucvu)
        {
            var chucvus= await _chucvuService.UpdateMultipleChucvu(chucvu);
            if(chucvus.Count==0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(chucvus.Count);
            
        }
        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var chucvu = await _chucvuService.DeleteMutipleChucvu(ids);
            if( chucvu.Count==0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(chucvu.Count);
        }
        [HttpPost("AddMultiple")]
        public async Task<bool> AddMultiple([FromBody] List<ChucVu> chucvu)
        {
           
            try
            {
                await _thietbiDbContext.AddRangeAsync(chucvu);
               _thietbiDbContext.SaveChanges();
                return true;

            }
            catch {
                return false;
            }
             
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ChucVu request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _chucvuService.Add(request);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ChucVu request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _chucvuService.Update(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _chucvuService.Delete(id);
            return Ok();
        }


    }
}
