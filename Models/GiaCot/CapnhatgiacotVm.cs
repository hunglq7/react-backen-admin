using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.GiaCot
{
    public class CapnhatgiacotVm
    {
        public int CapNhatId { get; set; }
        public string? TenDonVi { get; set; }
        public int DonViId { get; set; }
        public string? TenLoaiThietBi { get; set; }
        public string? ViTriSuDung { get; set; }
        public int LoaiThietBiId { get; set; }
        public int SoLuongDangQuanLy { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}