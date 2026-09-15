using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucquatgioController : ControllerBase
    {
        private readonly IDanhmucquatgioService _danhmucquatgioService;
        public DanhmucquatgioController(IDanhmucquatgioService danhmucquatgioService)
        {
            _danhmucquatgioService = danhmucquatgioService;

        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucquatgioService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucQuatgio> reponse)
        {

            var query = await _danhmucquatgioService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucQuatgio> reponse)
        {
            var query = await _danhmucquatgioService.DeleteMutiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] DanhmucQuatgio request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _danhmucquatgioService.Add(request);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] DanhmucQuatgio request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _danhmucquatgioService.Update(request);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _danhmucquatgioService.Delete(Id);
            return Ok(items);
        }
        [HttpPost("DeleteSelect")]

        public async Task<IActionResult> DeleteSelect([FromBody] List<int> ids)
        {
            var query = await _danhmucquatgioService.DeleteSelect(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
    }
}
