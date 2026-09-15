using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.TonghopCamera;


namespace WebApi.Services
{
    public interface ITonghopcameraService
    {
        Task<List<TonghopCameraVm>> GetAll();
        Task<bool> Add([FromBody] TonghopCamera request);
        Task<TonghopCamera> GetById(int id);
        Task<bool> Update([FromBody] TonghopCamera request);
        Task<bool> Delete(int id);

    }
    public class TonghopcameraService : ITonghopcameraService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopcameraService( ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] TonghopCamera request)
        {
            if (request == null)
            {
                return false;
            }

            var newCamera = new TonghopCamera()
            {
                MaQuanLy = request.MaQuanLy,
                TenThietBiId = request.TenThietBiId,
                LoaiThietBiId = request.LoaiThietBiId,
                DiaChiIP = request.DiaChiIP,
                DonViTinhId = request.DonViTinhId,
                SoLuong = request.SoLuong,
                NgayLap = request.NgayLap,
                DonViQuanLyId = request.DonViQuanLyId,
                KhuVucLapDat = request.KhuVucLapDat,
                ViTriLapDat = request.ViTriLapDat,
                TinhTrangThietBi = request.TinhTrangThietBi,
                GhiChu = request.GhiChu
            };
            
            _thietbiDbContext.Add(newCamera);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDbContext.TonghopCameras.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDbContext.TonghopCameras.Remove(query);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<List<TonghopCameraVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.TonghopCameras.Include(x => x.PhongBan).Include(x => x.DonViTinh).Include(x => x.LoaiThietBi).Include(x=>x.Camera)
                       
                        select t;
            var TongTb = query.Sum(x => x.SoLuong);
            return await query.Select(x => new TonghopCameraVm()
            {
                Id = x.Id,
                MaQuanLy=x.MaQuanLy,
                TenThietBi=x.Camera!.TenThietBI,
               TenLoaiThietBi=x.LoaiThietBi!.TenLoai,
               DiaChiIP=x.DiaChiIP,
               TenDonViTinh=x.DonViTinh!.TenDonViTinh,
               SoLuong=x.SoLuong,
               NgayLap=x.NgayLap,
               TenDonViQuanLy=x.PhongBan!.TenPhong,
               KhuVucLapDat=x.KhuVucLapDat,
               ViTriLapDat=x.ViTriLapDat,
               TinhTrangThietBi=x.TinhTrangThietBi,
               GhiChu=x.GhiChu,
               TongTb=TongTb
            }).ToListAsync();
        }

        public async Task<TonghopCamera> GetById(int id)
        {
            var query = await _thietbiDbContext.TonghopCameras.FindAsync(id);
            if (query == null)
            {
                query= new TonghopCamera()
                {
                    Id = 0,
                    MaQuanLy="",
                    NgayLap=new DateTime()
                }
                    ;
            }

            return query;
        }

        public async Task<bool> Update([FromBody] TonghopCamera request)
        {
            var query = await _thietbiDbContext.TonghopCameras.FindAsync(request.Id);
            if(query==null)
            {
                return false;
            } 
           query.MaQuanLy = request.MaQuanLy;
            query.TenThietBiId = request.TenThietBiId;
               query.LoaiThietBiId=request.LoaiThietBiId;
            query.DiaChiIP=request.DiaChiIP;
            query.DonViTinhId=request.DonViTinhId;
            query.SoLuong=request.SoLuong;
            query.NgayLap=request.NgayLap;
            query.DonViQuanLyId=request.DonViQuanLyId;
            query.KhuVucLapDat=request.KhuVucLapDat;
            query.ViTriLapDat=request.ViTriLapDat;
            query.TinhTrangThietBi=request.TinhTrangThietBi;
            query.GhiChu=request.GhiChu;
            _thietbiDbContext.Update(query);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
