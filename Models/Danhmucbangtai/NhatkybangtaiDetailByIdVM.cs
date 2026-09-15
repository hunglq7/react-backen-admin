namespace WebApi.Models.Danhmucbangtai
{
    public class NhatkybangtaiDetailByIdVM
    {
        public int Id { get; set; }
        public int BangTaiId { get; set; }
        public string? TenThietBi { get; set; }
        public DateTime Ngay { get; set; }
        public string? NoiDung { get; set; }
        public string? GhiChu { get; set; }
    }
}