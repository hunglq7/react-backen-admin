using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.AptomatKhoidongtu.ThongsoAptomatKhoidongtu
{
    public class ThongsoAptomatKhoidongtuVm
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public string ThongSo { get; set; } = string.Empty;
    }
}