using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Tonghopkhoan;
using WebApi.Models.TonghopKhoan;

namespace WebApi.Services
{
    public interface ITonghopKhoanService
    {
        Task<bool> Add(TongHopKhoan request);
        Task<TongHopKhoan> GetById(int id);
        Task<int> Sum();
        Task<List<TongHopKhoanVm>> GetDetailById(int id);
        Task<bool> Update(TongHopKhoan request);
        Task<bool> Delete(int id);
        Task<PagedResult<TongHopKhoanVm>> GetAllPaging(KhoanPagingRequest request);
    }
    public class TonghopKhoanService : ITonghopKhoanService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public TonghopKhoanService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(TongHopKhoan request)
        {
            if (request == null) return false;

            await _thietbiDbContext.TongHopKhoans.AddAsync(request);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TongHopKhoan> GetById(int id)
        {
            return await _thietbiDbContext.TongHopKhoans.FindAsync(id) ?? new TongHopKhoan();
        }

        public async Task<int> Sum()
        {
            return await _thietbiDbContext.TongHopKhoans.SumAsync(x => x.SoLuong);
        }

        public async Task<List<TongHopKhoanVm>> GetDetailById(int id)
        {
            var query = from t in _thietbiDbContext.TongHopKhoans.Where(x => x.Id == id)
                        join d in _thietbiDbContext.PhongBans on t.DonViId equals d.Id
                        join k in _thietbiDbContext.DanhMucKhoans on t.KhoanId equals k.Id
                        select new { t, d, k };

            return await query.Select(x => new TongHopKhoanVm
            {
                Id = x.t.Id,
                TenThietBi = x.k.TenThietBi,
                TenDonVi = x.d.TenPhong,
                NgayLap = x.t.NgayLap,
                DonViTinh = x.t.DonViTinh,
                SoLuong = x.t.SoLuong,
                ViTriLapDat = x.t.ViTriLapDat,
                TinhTrangKyThuat = x.t.TinhTrangKyThuat,
                duPhong= x.t.duPhong,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update(TongHopKhoan request)
        {
            var entity = await _thietbiDbContext.TongHopKhoans.FindAsync(request.Id);
            if (entity == null) return false;

            entity.KhoanId = request.KhoanId;
            entity.DonViId = request.DonViId;
            entity.NgayLap = request.NgayLap;
            entity.DonViTinh = request.DonViTinh;
            entity.SoLuong = request.SoLuong;
            entity.ViTriLapDat = request.ViTriLapDat;
            entity.TinhTrangKyThuat = request.TinhTrangKyThuat;
            entity.duPhong = request.duPhong;
            entity.GhiChu = request.GhiChu;

            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _thietbiDbContext.TongHopKhoans.FindAsync(id);
            if (entity == null) return false;

            _thietbiDbContext.TongHopKhoans.Remove(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<TongHopKhoanVm>> GetAllPaging(KhoanPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopKhoans.Include(x => x.DanhMucKhoan).Include(x => x.PhongBan)
                        select t;

            if (request.ThietBiId.HasValue && request.ThietBiId > 0)
                query = query.Where(x => x.KhoanId == request.ThietBiId);

            if (request.DonViId.HasValue && request.DonViId > 0)
                query = query.Where(x => x.DonViId == request.DonViId);

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.DanhMucKhoan.TenThietBi.Contains(request.Keyword));

            int totalRecords = await query.CountAsync();
            int sumRecodes = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                  .Take(request.PageSize)
                                  .Select(x => new TongHopKhoanVm
                                  {
                                      Id = x.Id,
                                      TenThietBi = x.DanhMucKhoan.TenThietBi,
                                      TenDonVi = x.PhongBan.TenPhong,
                                      NgayLap = x.NgayLap,
                                      DonViTinh = x.DonViTinh,
                                      SoLuong = x.SoLuong,
                                      ViTriLapDat = x.ViTriLapDat,
                                      TinhTrangKyThuat = x.TinhTrangKyThuat,
                                      duPhong= x.duPhong,
                                      GhiChu = x.GhiChu
                                  }).ToListAsync();

            return new PagedResult<TongHopKhoanVm>
            {
                TotalRecords = totalRecords,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                SumRecords = sumRecodes
            };
        }
    }
}