using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.ThongsokythuatMayXuc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MayxucController : ControllerBase
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        private readonly IMayXucService _mayXucService;
        public MayxucController(IMayXucService mayXucService,ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext=thietbiDbContext;
            _mayXucService=mayXucService;

            
        }
        [HttpGet]
        public async Task<ActionResult> GetMayxuc()
        {
            var mayxuc = await _mayXucService.GetMayXuc();
            return Ok(mayxuc);

        }
        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<MayXuc> mayXucs)
        {

            var response = await _mayXucService.UpdateMultipleMayXuc(mayXucs);
            if (response.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(response.Count);
        }
        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<MayXuc> mayXucs)
        {
            var response = await _mayXucService.DeleteMutipleMayXuc(mayXucs);
            if (response.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(response.Count);

        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] MayXuc request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _mayXucService.Add(request);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] MayXuc request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _mayXucService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _mayXucService.Delete(id);
            return Ok();
        }
        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var result = await _mayXucService.DeleteMutiple(ids);
            return Ok(result);
        }
    }
}
