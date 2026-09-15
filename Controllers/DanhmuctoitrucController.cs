
using Api.Data.Entites;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DanhmuctoitrucController : ControllerBase
    {

        private readonly IDanhmuctoitrucService _danhmuctoitrucService;
        public DanhmuctoitrucController(IDanhmuctoitrucService danhmuctoitrucService)
        {
            _danhmuctoitrucService = danhmuctoitrucService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmuctoitrucService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<Danhmuctoitruc> reponse)
        {

            var query = await _danhmuctoitrucService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var query = await _danhmuctoitrucService.DeleteMutiple(ids);
            if (query.Count == 0)
            {
                return NotFound("Không xóa được bản ghi nào");
            }
            return Ok(query.Count);

        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] Danhmuctoitruc request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _danhmuctoitrucService.Add(request);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] Danhmuctoitruc request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _danhmuctoitrucService.Update(request);
            return Ok();
        }
        [HttpDelete("DatailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _danhmuctoitrucService.Delete(Id);
            return Ok(items);
        }

    }
}