using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Entites
{
    public class ViTri
    {
        public int Id { get; set; }
        public string TenViTri { get; set; }

        public ICollection<XuatNhapVatTu> XuatNhapVatTus { get; set; }
    }
}