using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Danhmucbangtai
{
    public class NhatkybangtaiVM
    {
        public int Id { get; set; }
        public int TongHopBangTaiId { get; set; }
        public string Ngaythang { get; set; } = string.Empty;
        public string DonVi { get; set; } = string.Empty;
        public string ViTri { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}