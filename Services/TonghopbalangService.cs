using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.TonghopBalang;
using WebApi.Models.Tonghopcapdien;


namespace WebApi.Services
{
    public interface ITonghopbalangService
    {
        Task<bool> Add([FromBody] TonghopBalang Request);
        Task<TonghopBalang> GetById(int id);
        Task<int> Sum();
        Task<List<TonghopBalangVm>> getDatailById(int id);
        Task<bool> Update([FromBody] TonghopBalang Request);
        Task<bool> Delete(int id);
        Task<PagedResult<TonghopBalangVm>> GetAllPaging(BalangPagingRequest request);
    }
    public class TonghopbalangService : ITonghopbalangService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public TonghopbalangService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] TonghopBalang Request)
        {
            if (Request == null)
            {
                return false;
            }
            var items = new TonghopBalang()
            {
                Id = Request.Id,
                BaLangId = Request.BaLangId,
                DonViId = Request.DonViId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayLap = Request.NgayLap,
                DonViTinh = Request.DonViTinh,
                SoLuong = Request.SoLuong,
                TinhTrangKyThuat = Request.TinhTrangKyThuat,
                duPhong= Request.duPhong,
                GhiChu = Request.GhiChu

            };
            await _thietbiDbContext.TonghopBalangs.AddAsync(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDbContext.TonghopBalangs.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDbContext.TonghopBalangs.Remove(query);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<PagedResult<TonghopBalangVm>> GetAllPaging(BalangPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TonghopBalangs.Include(x => x.DanhmucBaLang).Include(x => x.PhongBan)
                        select t;
            if (request.thietbiId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.BaLangId == request.thietbiId && x.DonViId == request.donviId);
            }
            else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.BaLangId == request.thietbiId);
            }
            else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.DonViId == request.donviId);
            }


            int totalRow = await query.CountAsync();
            int SumRecords = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopBalangVm()
                {
                    Id = x.Id,
                    TenThietBi = x.DanhmucBaLang.TenThietBi,
                    TenDonVi = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    DonViTinh = x.DonViTinh,
                    SoLuong = x.SoLuong,
                    TinhTrangKyThuat = x.TinhTrangKyThuat,
                    duPhong= x.duPhong,
                    GhiChu = x.GhiChu

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopBalangVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                SumRecords = SumRecords,
            };
            return pagedResult;
        }

        public async Task<TonghopBalang> GetById(int id)
        {
            var query = await _thietbiDbContext.TonghopBalangs.FindAsync(id);
            if (query == null)
            {
                query = new TonghopBalang()
                {
                    Id = 0,
                    BaLangId = 0,
                    NgayLap = DateTime.Now,

                }
                     ;
            }

            return query;
        }

        public async Task<List<TonghopBalangVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.TonghopBalangs.Where(x => x.Id == id)
                        join p in _thietbiDbContext.PhongBans on t.DonViId equals p.Id
                        join m in _thietbiDbContext.DanhmucBaLangs on t.BaLangId equals m.Id


                        select new { t, p, m };
            return await Query.Select(x => new TonghopBalangVm
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                TenDonVi = x.p.TenPhong,
                NgayLap = x.t.NgayLap,
                DonViTinh = x.t.DonViTinh,
                SoLuong = x.t.SoLuong,
                ViTriLapDat = x.t.ViTriLapDat,
                TinhTrangKyThuat = x.t.TinhTrangKyThuat,
                duPhong = x.t.duPhong,
                GhiChu = x.t.GhiChu,
            }).ToListAsync();
        }

        public async Task<int> Sum()
        {
            var query = from s in _thietbiDbContext.TonghopBalangs
                        select s;
            var sum = await query.SumAsync(x => x.SoLuong);
            return sum;
        }

        public async Task<bool> Update([FromBody] TonghopBalang Request)
        {
            var entity = await _thietbiDbContext.TonghopBalangs.FindAsync(Request.Id);
            if (entity == null)
            {
                return false;
            }

            entity.BaLangId = Request.BaLangId;
            entity.DonViId = Request.DonViId;
            entity.NgayLap = Request.NgayLap;
            entity.DonViTinh = Request.DonViTinh;
            entity.SoLuong = Request.SoLuong;
            entity.TinhTrangKyThuat = Request.TinhTrangKyThuat;
            entity.ViTriLapDat = Request.ViTriLapDat;
            entity.duPhong = Request.duPhong;
            entity.GhiChu = Request.GhiChu;
            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
