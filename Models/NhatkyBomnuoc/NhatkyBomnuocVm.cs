using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.NhatkyBomnuoc
{
    public class NhatkyBomnuocVm
    {
        public int Id { get; set; }
        public int TongHopBomNuocId { get; set; }
        public string Ngaythang { get; set; } = string.Empty;
    
        public string DonVi { get; set; } = string.Empty;
     
        public string ViTri { get; set; } = string.Empty;

        public string TrangThai { get; set; } = string.Empty;

        public string GhiChu { get; set; } = string.Empty;
    }
}
