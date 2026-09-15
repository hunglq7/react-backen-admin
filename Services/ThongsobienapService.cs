using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Bienap.Thongsokythuatbienap;

namespace WebApi.Services
{
    public interface IThongsobienapService
    {
        Task<List<ThongsoBienapVm>> GetAll();
        Task<PagedResult<ThongsoBienapVm>> GetAllPaging(ThongsoBienapPagingRequest request);
        Task<ThongSoKyThuatBienAp> GetById(int id);
        Task<List<ThongsoBienapVm>> getDatailById(int id);
        Task<bool> Add([FromBody] ThongSoKyThuatBienAp Request);
        Task<bool> Update([FromBody] ThongSoKyThuatBienAp Request);
        Task<bool> Delete(int id);
    }
    public class ThongsobienapService : IThongsobienapService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public ThongsobienapService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] ThongSoKyThuatBienAp Request)
        {
            if (Request == null)
            {
                return false;
            }
            var newItems = new ThongSoKyThuatBienAp()
            {
                Id = Request.Id,
                BienApId = Request.BienApId,
                NoiDung = Request.NoiDung,
                DonViTinh = Request.DonViTinh,
                ThongSo = Request.ThongSo,
            };
            await _thietbiDbContext.ThongSoKyThuatBienAps.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ThongSoKyThuatBienAps.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ThongSoKyThuatBienAps.Remove(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<ThongsoBienapVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongSoKyThuatBienAps.Include(x => x.DanhmucBienap)
                        select t;
            return await query.Select(x => new ThongsoBienapVm()
            {
                Id = x.Id,
                TenThietBi = x.DanhmucBienap.TenThietBi,
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo,
            }).ToListAsync();
        }
        public async Task<PagedResult<ThongsoBienapVm>> GetAllPaging(ThongsoBienapPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongSoKyThuatBienAps.Include(x => x.DanhmucBienap)
                        select t;
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.BienApId == request.thietbiId);
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsoBienapVm()
                {
                    Id = x.Id,
                    TenThietBi = x.DanhmucBienap.TenThietBi,
                    NoiDung = x.NoiDung,
                    DonViTinh = x.DonViTinh,
                    ThongSo = x.ThongSo,
                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsoBienapVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }
        public async Task<ThongSoKyThuatBienAp> GetById(int id)
        {
            var items = await _thietbiDbContext.ThongSoKyThuatBienAps.FindAsync(id);
            if (items == null)
            {
                items = new ThongSoKyThuatBienAp()
                {
                    Id = 0,
                    BienApId = 1,
                    NoiDung = string.Empty,
                    DonViTinh = string.Empty,
                    ThongSo = string.Empty
                };
            }
            return items;
        }
        public async Task<List<ThongsoBienapVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.ThongSoKyThuatBienAps.Where(x => x.BienApId == id)
                        join m in _thietbiDbContext.DanhmucBienaps on t.BienApId equals m.Id
                        select new { t, m };
            return await Query.Select(x => new ThongsoBienapVm
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo,
            }).ToListAsync();
        }
        public async Task<bool> Update([FromBody] ThongSoKyThuatBienAp Request)
        {
            var items = await _thietbiDbContext.ThongSoKyThuatBienAps.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.Id = Request.Id;
            items.BienApId = Request.BienApId;
            items.NoiDung = Request.NoiDung;
            items.DonViTinh = Request.DonViTinh;
            items.ThongSo = Request.ThongSo;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}