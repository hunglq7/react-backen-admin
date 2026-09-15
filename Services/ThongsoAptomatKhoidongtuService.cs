using Api.Data.Entites;
using WebApi.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Models.Common;
using WebApi.Data.Entites;
using Api.Models.AptomatKhoidongtu.ThongsoAptomatKhoidongtu;
namespace WebApi.Services
{
    public interface IThongsoAptomatKhoidongtuService
    {
        Task<List<ThongsoAptomatKhoidongtuVm>> GetAll();
        Task<ThongsoAptomatKhoidongtu> GetById(int id);
        Task<List<ThongsoAptomatKhoidongtuVm>> GetDetailById(int id);
        Task<bool> Add(ThongsoAptomatKhoidongtuEdit Request);
        Task<bool> Update(ThongsoAptomatKhoidongtuEdit Request);
        Task<bool> Delete(int id);
        Task<PagedResult<ThongsoAptomatKhoidongtuVm>> GetAllPaging(ThongsoAptomatKhoidongtuPagingRequest request);
    }

    public class ThongsoAptomatKhoidongtuService : IThongsoAptomatKhoidongtuService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public ThongsoAptomatKhoidongtuService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(ThongsoAptomatKhoidongtuEdit Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newItems = new ThongsoAptomatKhoidongtu()
            {
                Id = Request.Id,
                DanhmucaptomatKhoidongtuId = Request.DanhmucaptomatkhoidongtuId,
                NoiDung = Request.NoiDung,
                DonViTinh = Request.DonViTinh,
                ThongSo = Request.ThongSo,
            };
            await _thietbiDbContext.ThongsoAptomatKhoidongtus.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ThongsoAptomatKhoidongtus.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ThongsoAptomatKhoidongtus.Remove(items);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<List<ThongsoAptomatKhoidongtuVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongsoAptomatKhoidongtus.Include(x => x.DanhmucAptomatKhoidongtu)
                        select t;
            return await query.Select(x => new ThongsoAptomatKhoidongtuVm()
            {
                Id = x.Id,
                TenThietBi = x.DanhmucAptomatKhoidongtu.TenThietBi,
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo,
            }).ToListAsync();
        }

        public async Task<PagedResult<ThongsoAptomatKhoidongtuVm>> GetAllPaging(ThongsoAptomatKhoidongtuPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongsoAptomatKhoidongtus.Include(x => x.DanhmucAptomatKhoidongtu)
                        select t;
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.DanhmucaptomatKhoidongtuId == request.thietbiId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsoAptomatKhoidongtuVm()
                {
                    Id = x.Id,
                    TenThietBi = x.DanhmucAptomatKhoidongtu!.TenThietBi,
                    NoiDung = x.NoiDung,
                    DonViTinh = x.DonViTinh,
                    ThongSo = x.ThongSo,
                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsoAptomatKhoidongtuVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<ThongsoAptomatKhoidongtu> GetById(int id)
        {
            var items = await _thietbiDbContext.ThongsoAptomatKhoidongtus.FindAsync(id);
            if (items == null)
            {
                items = new ThongsoAptomatKhoidongtu()
                {
                    Id = 0,
                    DanhmucaptomatKhoidongtuId = 1,
                    NoiDung = "",
                    DonViTinh = "",
                    ThongSo = ""
                };
            }

            return items;
        }

        public async Task<List<ThongsoAptomatKhoidongtuVm>> GetDetailById(int id)
        {
            var Query = from t in _thietbiDbContext.ThongsoAptomatKhoidongtus.Where(x => x.DanhmucaptomatKhoidongtuId == id)
                        join m in _thietbiDbContext.DanhmucAptomatKhoidongtus on t.DanhmucaptomatKhoidongtuId equals m.Id
                        select new { t, m };
            return await Query.Select(x => new ThongsoAptomatKhoidongtuVm
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo,
            }).ToListAsync();
        }

        public async Task<bool> Update(ThongsoAptomatKhoidongtuEdit Request)
        {
            if (Request == null)
                return false;

            var items = await _thietbiDbContext.ThongsoAptomatKhoidongtus.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.Id = Request.Id;
            items.DanhmucaptomatKhoidongtuId = Request.DanhmucaptomatkhoidongtuId;
            items.NoiDung = Request.NoiDung;
            items.DonViTinh = Request.DonViTinh;
            items.ThongSo = Request.ThongSo;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}