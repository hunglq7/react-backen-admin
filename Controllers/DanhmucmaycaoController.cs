using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucmaycaoController : ControllerBase
    {
        public readonly IDanhmucMayCaoService _danhmucMayCaoService;
        public DanhmucmaycaoController(IDanhmucMayCaoService danhmucMayCaoService)
        {
            _danhmucMayCaoService = danhmucMayCaoService;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucMayCaoService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        [Authorize]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucMayCao> reponse)
        {

            var query = await _danhmucMayCaoService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]
        [Authorize]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var query = await _danhmucMayCaoService.DeleteMultiple(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
        [HttpPost("Add")]
        [Authorize]
        public async Task<ActionResult> Add([FromBody] DanhmucMayCao request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _danhmucMayCaoService.Add(request);
            return Ok();
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] DanhmucMayCao request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _danhmucMayCaoService.Update(request);
            return Ok();
        }
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<ActionResult> DeleteById(int Id)
        {
            var items = await _danhmucMayCaoService.Delete(Id);
            return Ok(items);
        }
    }
}

