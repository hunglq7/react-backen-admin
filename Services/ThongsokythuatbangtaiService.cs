using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;

namespace WebApi.Services
{
    public interface IThongsokythuatbangtaiService
    {
        Task<List<ThongsokythuatbangtaiVM>> GetAll();
        Task<PagedResult<ThongsokythuatbangtaiVM>> GetAllPaging(ThongSoKyThuatBangTaiPagingRequest request);
        Task<ThongSoKyThuatBangTai> GetById(int id);
        Task<List<ThongsokythuatbangtaiDetailByIdVM>> getDatailById(int id);
        Task<bool> Add([FromBody] ThongSoKyThuatBangTaiEdit Request);
        Task<bool> Update([FromBody] ThongSoKyThuatBangTaiEdit Request);
        Task<bool> Delete(int id);
    }
    public class ThongsokythuatbangtaiService : IThongsokythuatbangtaiService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public ThongsokythuatbangtaiService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] ThongSoKyThuatBangTaiEdit Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newItems = new ThongSoKyThuatBangTai()
            {
                Id = Request.Id,
                BangTaiId = Request.BangTaiId,
                NoiDung = Request.NoiDung,
                DonViTinh = Request.DonViTinh,
                ThongSo = Request.ThongSo,
            };
            await _thietbiDbContext.ThongSoKyThuatBangTais.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ThongSoKyThuatBangTais.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ThongSoKyThuatBangTais.Remove(items);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<List<ThongsokythuatbangtaiVM>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongSoKyThuatBangTais.Include(x => x.DanhMucBangTai)
                        select t;
            return await query.Select(x => new ThongsokythuatbangtaiVM()
            {
                Id = x.Id,
                BangTaiId = x.BangTaiId,
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo,
            }).ToListAsync();
        }

        public async Task<PagedResult<ThongsokythuatbangtaiVM>> GetAllPaging(ThongSoKyThuatBangTaiPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongSoKyThuatBangTais.Include(x => x.DanhMucBangTai)
                        select t;
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.BangTaiId == request.thietbiId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsokythuatbangtaiVM()
                {
                    Id = x.Id,
                    BangTaiId = x.BangTaiId,
                    TenThietBi = x.DanhMucBangTai.TenThietBi,
                    NoiDung = x.NoiDung,
                    DonViTinh = x.DonViTinh,
                    ThongSo = x.ThongSo,
                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsokythuatbangtaiVM>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<ThongSoKyThuatBangTai> GetById(int id)
        {
            var items = await _thietbiDbContext.ThongSoKyThuatBangTais.FindAsync(id);
            if (items == null)
            {
                items = new ThongSoKyThuatBangTai()
                {
                    Id = 0,
                    BangTaiId = 1,
                    NoiDung = "",
                    DonViTinh = "",
                    ThongSo = ""
                };
            }

            return items;
        }

        public async Task<List<ThongsokythuatbangtaiDetailByIdVM>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.ThongSoKyThuatBangTais.Where(x => x.BangTaiId == id)
                        join m in _thietbiDbContext.DanhMucBangTais on t.BangTaiId equals m.Id
                        select new { t, m };
            return await Query.Select(x => new ThongsokythuatbangtaiDetailByIdVM
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo,
            }).ToListAsync();
        }

        public async Task<bool> Update([FromBody] ThongSoKyThuatBangTaiEdit Request)
        {
            var items = await _thietbiDbContext.ThongSoKyThuatBangTais.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.Id = Request.Id;
            items.BangTaiId = Request.BangTaiId;
            items.NoiDung = Request.NoiDung;
            items.DonViTinh = Request.DonViTinh;
            items.ThongSo = Request.ThongSo;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}