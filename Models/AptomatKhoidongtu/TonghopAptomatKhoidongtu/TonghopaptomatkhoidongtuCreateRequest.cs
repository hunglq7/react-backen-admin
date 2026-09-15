using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu
{
    public class TonghopaptomatkhoidongtuCreateRequest
    {
        public int Id { get; set; }
        public int aptomatkhoidongtuId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime? NgayKiemDinh { get; set; }
        public DateTime? NamSanXuat { get; set; }
        public string? DienApSuDung { get; set; }
        public string? Idm { get; set; }
        public string? DienApDieuKhien { get; set; }
        public string? CheDoLamViec { get; set; }
        public string? ThongGio { get; set; }
        public bool NoiDat { get; set; }
        public bool KheHoPhongNo { get; set; }
        public bool NapMoNhanh { get; set; }
        public bool TayDao { get; set; }
        public string? BitCoCap { get; set; }
        public string? CapPhongNo { get; set; }
        public string? TinhTrangThietBi { get; set; }
        public bool DuPhong { get; set; }
        public string? GhiChu { get; set; }

    }
}