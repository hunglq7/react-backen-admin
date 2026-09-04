using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadNhanvienController : ControllerBase
    {

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                if (formCollection?.Files == null || formCollection.Files.Count == 0)
                    return BadRequest("No file");
                var file = formCollection.Files.First();
                var folderName = Path.Combine("wwwroot", "Images", "NhanVien");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                Directory.CreateDirectory(pathToSave);
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'));
                    var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    var dbPath = "/Images/NhanVien/" + fileName;
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"L?i m�y ch? n?i b?: {ex}");
            }
        }
        [HttpPost("Multiple"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadMutiple()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                if (formCollection?.Files == null || !formCollection.Files.Any())
                    return BadRequest("No files");
                var files = formCollection.Files;
                var folderName = Path.Combine("Images", "NhanVien");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("T?t c? c�c t?p tin du?c t?i l�n th�nh c�ng.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"L?i m�y ch? n?i b?: {ex}");
            }
        }
    }
}
