using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.thietbi
{
    public class ThietBiDto
    {
        public int Id { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string Loai { get; set; }
        public string? HangSanXuat { get; set; }
        public string? Model { get; set; }
        public string? DonViTinh { get; set; }
        public int ThoiGianBaoHanh { get; set; }
    }
}