using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.Nhanvien;
using WebApi.Models.Upload;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly INhanvienService _nhanvienService;
        private const string NHANVIEN_IMAGE_FOLDER_NAME = "Images/NhanVien";
        public NhanvienController(INhanvienService service)
        {
            _nhanvienService = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetNhanvien()
        {
            var nhanvien= await _nhanvienService.GetNhanvien();
            if(nhanvien== null)
            {
                return BadRequest();
            }
            return Ok(nhanvien);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var nhanvien= await _nhanvienService.GetById(id);
            if(nhanvien==null)
            {
                return NotFound();
            }
            return Ok(nhanvien);
        }

        [HttpPost]
        public async Task<ActionResult> AddNhanvien([FromBody] NhanvienCreateRequest nhanVien)
        {
            if(nhanVien==null)
            {
                return BadRequest();
            }
            await _nhanvienService.AddNhanvien(nhanVien);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateNhanvien([FromBody] NhanvienUpdateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _nhanvienService.UpdateNhanvien(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNhanvien(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            await _nhanvienService.DeleteNhanvien(id);
            return Ok();
        }

        
        [HttpPost("{nhanvienId}/images")]
        public async Task<IActionResult> CreateImage(int nhanvienId, [FromForm] NhanvienImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _nhanvienService.AddImage(nhanvienId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _nhanvienService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }
        [HttpGet("{nhanvienId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById( int imageId)
        {
            var image = await _nhanvienService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Không tìm thấy nhân viên nào");
            return Ok(image);
        }

        [HttpPost("uploadfile"),DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadModel model)
        {
            
            if (model.Name == null && model.File!.Length! == 0)
            {
                return BadRequest("file không hợp lệ");
            }

            var folderName = Path.Combine("Images", "NhanVien");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            var fileName =  model.File!.FileName;
            var fullPath = Path.Combine(pathToSave, fileName);
         
            if (System.IO.File.Exists(fullPath))
            {
               return BadRequest("Tập tin đã tồn tại");
            }
            using (var strem = new FileStream(fullPath, FileMode.Create))
            {
                model.File.CopyTo(strem);
            }
            return Ok("/" + NHANVIEN_IMAGE_FOLDER_NAME + "/" + fileName);
        }
    }
}
