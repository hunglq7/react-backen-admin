using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;
        private readonly ThietbiDbContext _thietbiDbContext;

        public CameraController( ICameraService cameraService, ThietbiDbContext thietbiDbContext)
        {
            _cameraService = cameraService;
            _thietbiDbContext = thietbiDbContext;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetCamera()
        {
            var query = await _cameraService.GetCamera();
            return Ok(query);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<ActionResult> UpdateMuliple([FromBody] List<Camera> request)
        {
            var query = await _cameraService.UpdateMultipleCamera(request);
            if (query.Count == 0)
            {
                return BadRequest("Cập nhật bản ghi thất bại");
            }
            return Ok(query.Count);

        }
        [HttpPost("DeleteMultipale")]

        public async Task<ActionResult> DeleteMultiple([FromBody] List<Camera> request)
        {
            var query = await _cameraService.DeleteMutipleCamera(request);
            if (query.Count == 0)
            {
                return BadRequest("Xóa bản ghi thất bại");
            }
            return Ok(query.Count);
        }
    }
}
