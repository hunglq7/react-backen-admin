namespace WebApi.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
    }
    public class FileStorageService : IStorageService
    {
        private readonly string _nhanvienContentFolder;
       
        public FileStorageService()
        {
            var folderName = Path.Combine("Images","NhanVien");
            _nhanvienContentFolder = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        }
        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_nhanvienContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
           
            {
                return $"/{_nhanvienContentFolder}/{fileName}";
            }
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_nhanvienContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
