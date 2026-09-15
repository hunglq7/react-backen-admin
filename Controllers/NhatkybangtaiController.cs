using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhatkybangtaiController : ControllerBase
    {
        private readonly INhatkybangtaiService _nhatkybangtaiService;
        public NhatkybangtaiController(INhatkybangtaiService nhatkybangtaiService)
        {
            _nhatkybangtaiService = nhatkybangtaiService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _nhatkybangtaiService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<NhatkybangtaiDetailByIdVM>>> GetById(int id)
        {
            var result = await _nhatkybangtaiService.getDatailById(id);
            return Ok(result);
        }

        [HttpPost("UpdateMultiple")]
        public async Task<ActionResult<ApiResult<int>>> UpdateMultiple([FromBody] List<NhatKyBangTai> response)
        {
            var result = await _nhatkybangtaiService.UpdateMultiple(response);
            return Ok(result);
        }

        [HttpPost("DeleteMutiple")]
        public async Task<ActionResult<ApiResult<int>>> DeleteMutiple([FromBody] List<NhatKyBangTai> response)
        {
            var result = await _nhatkybangtaiService.DeleteMutiple(response);
            return Ok(result);
        }
    }
}