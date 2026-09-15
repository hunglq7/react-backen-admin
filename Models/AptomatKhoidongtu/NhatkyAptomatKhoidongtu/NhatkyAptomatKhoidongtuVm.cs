using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.AptomatKhoidongtu.NhatkyAptomatKhoidongtu
{
    public class NhatkyAptomatKhoidongtuVm
    {
        public int Id { get; set; }
        public int ThietBiId { get; set; }
        public string NgayThang { get; set; } = string.Empty;
        public string DonVi { get; set; } = string.Empty;
        public string ViTri { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}