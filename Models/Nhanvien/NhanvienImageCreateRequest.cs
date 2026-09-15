namespace WebApi.Models.Nhanvien
{
    public class NhanvienImageCreateRequest
    {
        public string? Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
