using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Tonghopmayxuc
{
    public class TonghopmayDetailByIdVm
    {
          public int Id { get; set; }
        public string MaQuanLy { get; set; } = string.Empty;
        public  string TenMay{ get; set; }=string.Empty;
        public string LoaiThietBi { get; set; } = string.Empty;
        public string TenPhong { get; set; }=string.Empty;      
        
        public string ViTriLapDat { get; set; } = string.Empty;
        public  DateTime NgayLapDat { get; set; }

        public string TinhTrang { get; set; } = string.Empty;
        public int SoLuong { get; set; }
     
        public string GhiChu { get; set; } = string.Empty;
        public bool DuPhong { get; set; } 

    }
}