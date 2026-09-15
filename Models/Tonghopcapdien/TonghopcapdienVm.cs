namespace WebApi.Models.Tonghopcapdien
{
    public class TonghopcapdienVm
    {
        public int Id { get; set; }
        public string? Maquanly { get; set; }
        public string? TenDonVi{ get; set; }
        public DateTime Ngaythang { get; set; }
        public string? TenThietBi { get; set; }
        public string? Donvitinh { get; set; }
        public int Tondauthang { get; set; }
        public int Nhaptrongky { get; set; }
        public int Xuattrongky { get; set; }
        public int Toncuoithang { get; set; }
        public int Dangsudung { get; set; }
        public int Duphong { get; set; }
    }
}
