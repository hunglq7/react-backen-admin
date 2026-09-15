namespace WebApi.Models.Upload
{
    public class FileUploadModel
    {
        public IFormFile? File { get; set; }
        public string? Name { get; set; }
       
    }
}
