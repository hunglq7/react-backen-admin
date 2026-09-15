using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucbomnuocController : ControllerBase
    {
        public readonly IDanhmucbomnuocService _danhmucbomnuocService;
        public readonly ThietbiDbContext _dbContext;
        public DanhmucbomnuocController(IDanhmucbomnuocService danhmucbomnuocService, ThietbiDbContext dbContext)
        {
            _danhmucbomnuocService = danhmucbomnuocService;
            _dbContext = dbContext;

        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = await _danhmucbomnuocService.GetAll();
            return Ok(query);

        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<DanhmucBomnuoc> reponse)
        {

            var query = await _danhmucbomnuocService.UpdateMultiple(reponse);
            if (query.Count == 0)
            {
                return BadRequest(ModelState);
            }
            return Ok(query.Count);
        }

        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<DanhmucBomnuoc> reponse)
        {
            var query = await _danhmucbomnuocService.DeleteMutiple(reponse);
            if (query.Count == 0)
            {
                return NotFound("Kh�ng x�a du?c b?n ghi n�o");
            }
            return Ok(query.Count);

        }

        [HttpPost("UploadExcelFile")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadExcelFile(IFormFile file)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                if (file == null || file.Length == 0)
                {
                    BadRequest("No file Upload");
                }
                var uploadFolder = $"{Directory.GetCurrentDirectory()}\\Uploads";
                if (Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                var filePath = Path.Combine(uploadFolder, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {

                        do
                        {
                            bool isHeaderSkipped = false;
                            if (!isHeaderSkipped)
                            {
                                isHeaderSkipped = true;
                                continue;
                            }
                            while (reader.Read())
                            {
                                DanhmucBomnuoc dmBomNuoc = new DanhmucBomnuoc();
                                dmBomNuoc.TenThietBi = reader.GetValue(1).ToString();
                                dmBomNuoc.LoaiThietBi = reader.GetValue(2).ToString();

                                _dbContext.Add(dmBomNuoc);
                                await _dbContext.SaveChangesAsync();
                            }
                        } while (reader.NextResult());


                    }

                }
                return Ok("Th�m b?n ghi th�nh c�ng");
            }
            catch (Exception ex)
            {
                StatusCode(5000, ex.Message);
            }
            return BadRequest("Th�m th?t b?i");
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] DanhmucBomnuoc request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            await _danhmucbomnuocService.Add(request);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] DanhmucBomnuoc request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _danhmucbomnuocService.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _danhmucbomnuocService.Delete(id);
            return Ok();
        }

        [HttpPost("Delete-Multiple")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var query = await _danhmucbomnuocService.DeleteMuny(ids);
            if (query.Count == 0)
            {
                return NotFound("Kh�ng x�a du?c b?n ghi n�o");
            }
            return Ok(query.Count);

        }

    }
}
