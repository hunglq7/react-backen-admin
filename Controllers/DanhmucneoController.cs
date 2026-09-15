using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucneoController : ControllerBase
    {
        public readonly IDanhmucNeoService _danhmucNeoService;
        public DanhmucneoController(IDanhmucNeoService danhmucNeoService)
        {
            _danhmucNeoService = danhmucNeoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucNeoService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucNeo> reponse)
        {

            var query = await _danhmucNeoService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] DanhmucNeo reponse)
        {
            var result = await _danhmucNeoService.Add(reponse);
            if (!result)
            {
                return BadRequest(ModelState);
            }
            return Ok(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DanhmucNeo reponse)
        {
            var result = await _danhmucNeoService.Update(reponse);
            if (!result)
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhmucNeoService.Delete(id);
            if (!result)
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }
        [HttpPost("Delete-Multiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var result = await _danhmucNeoService.DeleteMultiple(ids);
            if (result == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }
    }
}

