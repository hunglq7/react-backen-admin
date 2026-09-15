using Microsoft.EntityFrameworkCore;
using WebApi.Models.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Giacotthuyluc.Tonghopgiacotthuyluc;

namespace WebApi.Services
{
    public interface ITonghopgiacotthuylucService
    {
        Task<int> Create(TonghopgiacotthuylucCreateRequest request);
        Task<int> Update(TonghopgiacotthuylucUpdateRequest request);
        Task<int> Delete(int id);
        Task<int> SumTonghopgiacotthuyluc();
        Task<Tonghopgiacotthuyluc> GetById(int id);
        Task<PagedResult<TonghopgiacotthuylucVm>> GetAllPaging(TonghopgiacotthuylucPagingRequest request);
    }
    public class TonghopgiacotthuylucService : ITonghopgiacotthuylucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopgiacotthuylucService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<int> Create(TonghopgiacotthuylucCreateRequest request)
        {
            if (request == null)
            {
                return 0;
            }
            var items = new Tonghopgiacotthuyluc()
            {
                Id = request.Id,
                ThietBiId = request.ThietBiId,
                DonViId = request.DonViId,
                ViTriLapDat=request.ViTriLapDat,
                NgayLap = request.NgayLap,
                SoLuong = request.SoLuong,
                duPhong= request.duPhong,
                GhiChu = request.GhiChu
            };
            await _thietbiDbContext.Tonghopgiacotthuylucs.AddAsync(items);
            return await _thietbiDbContext.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var query = await _thietbiDbContext.Tonghopgiacotthuylucs.FindAsync(id);
            if (query == null)
            {
                return 0;
            }
            _thietbiDbContext.Tonghopgiacotthuylucs.Remove(query);
            return await _thietbiDbContext.SaveChangesAsync();
        }
        public async Task<PagedResult<TonghopgiacotthuylucVm>> GetAllPaging(TonghopgiacotthuylucPagingRequest request)
        {
            var query = from t in _thietbiDbContext.Tonghopgiacotthuylucs.Include(x => x.Danhmucgiacotthuyluc).Include(x => x.PhongBan)
                        select t;
            if (request.DonViId.HasValue && request.DonViId > 0)
            {
                query = query.Where(x => x.DonViId == request.DonViId);
            }
            int totalRow = await query.CountAsync();
            int sumSoluong = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopgiacotthuylucVm()
                {
                    Id = x.Id,
                    TenThietBi = x.Danhmucgiacotthuyluc.TenThietBi,
                    DonVi = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    SoLuong = x.SoLuong,
                    duPhong= x.duPhong,
                    GhiChu = x.GhiChu
                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopgiacotthuylucVm>()
            {
                TotalRecords = totalRow,
                SumRecords = sumSoluong,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }
        public async Task<Tonghopgiacotthuyluc> GetById(int id)
        {
            var query = await _thietbiDbContext.Tonghopgiacotthuylucs.FindAsync(id);
            if (query == null)
            {
                query = new Tonghopgiacotthuyluc()
                {
                    ThietBiId = 0,
                    DonViId = 0,
                    NgayLap = new DateTime(),
                    SoLuong = 1
                };
            }
            return query;
        }
        public async Task<int> SumTonghopgiacotthuyluc()
        {
            var query = from s in _thietbiDbContext.Tonghopgiacotthuylucs
                        select s;
            var sum = await query.SumAsync(x => x.SoLuong);
            return sum;
        }
        public async Task<int> Update(TonghopgiacotthuylucUpdateRequest request)
        {
            var query = await _thietbiDbContext.Tonghopgiacotthuylucs.FindAsync(request.Id);
            if (query == null)
            {
                return 0;
            }
            query.ThietBiId = request.ThietBiId;
            query.DonViId = request.DonViId;
            query.NgayLap = request.NgayLap;
            query.ViTriLapDat = request.ViTriLapDat;
            query.SoLuong = request.SoLuong;
            query.duPhong = request.duPhong;
            query.GhiChu = request.GhiChu;
            return await _thietbiDbContext.SaveChangesAsync();
        }
    }
}