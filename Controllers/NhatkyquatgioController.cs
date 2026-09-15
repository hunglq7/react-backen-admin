using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkyquatgioController : ControllerBase
    {
        private readonly INhatkyquatgioService _nhatkyquatgioService;
        public NhatkyquatgioController(INhatkyquatgioService nhatkyquatgioService)
        {
            _nhatkyquatgioService = nhatkyquatgioService;

        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _nhatkyquatgioService.GetAll();
            return Ok(query);
        }
        [HttpGet("DatailById/{Id}")]
        public async Task<ActionResult> GetDetailById(int Id)
        {
            var items = await _nhatkyquatgioService.getDatailById(Id);
            return Ok(items);
        }
        [HttpGet("tonghopquatgioId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _nhatkyquatgioService.GetByTonghopquatgioId(id);
            return Ok(ApiResponse<List<NhatKyQuatGio>>.Ok(data));
        }
        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<NhatKyQuatGio> request)
        {
            var query = await _nhatkyquatgioService.UpdateMultiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query.Count);

        }

        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<NhatKyQuatGio> request)
        {
            var query = await _nhatkyquatgioService.DeleteMutiple(request);
            if (query.Count == 0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query.Count);
        }


        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] NhatKyQuatGio request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _nhatkyquatgioService.Add(request);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] NhatKyQuatGio request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _nhatkyquatgioService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _nhatkyquatgioService.Delete(id);
            return Ok();
        }
        [HttpPost("DeleteSelect")]
        public async Task<IActionResult> DeleteMultiple(List<int> ids)
        {
            var count = await _nhatkyquatgioService.DeleteSelect(ids);
            return Ok(ApiResponse<int>.Ok(count, "Xóa nhiều dòng thành công"));
        }
    }
}
