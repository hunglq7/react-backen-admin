using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.KhoanBalang
{
    public class TonghopKhoanBalangVm
    {
        public int Id { get; set; }

        public int KhoanBalangId { get; set; }
        public string? TenThietBi { get; set; }
        public int DonViId { get; set; }
        public string? TenDonVi { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public string? TinhTrangKyThuat { get; set; }
        public string? LoaiThietBi { get; set; }
        public Boolean DuPhong { get; set; }
        public string? GhiChu { get; set; }

    }
}