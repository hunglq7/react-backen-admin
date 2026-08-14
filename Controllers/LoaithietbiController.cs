using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaithietbiController : ControllerBase
    {
        private readonly ILoaithietbiService _loaithietbiService;
        public LoaithietbiController(ILoaithietbiService loaithietbiService)
        {
            _loaithietbiService = loaithietbiService;
        }
        [HttpGet]
        public async Task<ActionResult> GetLoaithietbi()
        {
            var loaithietbi = await _loaithietbiService.GetLoaithietbi();
            return Ok(loaithietbi);
        }
        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<LoaiThietBi> loaithietbi)
        {
            var loaithietbis = await _loaithietbiService.UpdateMultipleLoaithietbi(loaithietbi);
            if (loaithietbis.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(loaithietbis.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<LoaiThietBi> loaithietbi)
        {
            var loathietbis = await _loaithietbiService.DeleteMutipleLoaithietbi(loaithietbi);
            if (loathietbis.Count == 0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(loathietbis.Count);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] LoaiThietBi request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _loaithietbiService.Add(request);
            return Ok();
        }

         [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] LoaiThietBi request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _loaithietbiService.Update(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _loaithietbiService.Delete(id);
            return Ok();
        }

         [HttpPost("DeleteSelected")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var loaithietbi = await _loaithietbiService.DeleteSelectedLoaithietbi(ids);
            if( loaithietbi.Count==0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(loaithietbi.Count);
        }

    }
}
