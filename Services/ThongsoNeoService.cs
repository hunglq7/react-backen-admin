using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Neo.ThongsoNeo;

namespace WebApi.Services
{
    public interface IThongsoNeoService
    {
        Task<bool> Add(ThongsoNeo request);
        Task<ThongsoNeo> GetById(int id);
        Task<int> Sum();
        Task<List<ThongsoNeoVm>> GetDetailById(int id);
        Task<bool> Update(ThongsoNeo request);
        Task<bool> Delete(int id);
        Task<PagedResult<ThongsoNeoVm>> GetAllPaging(ThongsoNeoPagingRequest request);
    }

    public class ThongsoNeoService : IThongsoNeoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public ThongsoNeoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(ThongsoNeo request)
        {
            if (request == null) return false;

            await _thietbiDbContext.ThongsoNeos.AddAsync(request);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ThongsoNeo> GetById(int id)
        {
            return await _thietbiDbContext.ThongsoNeos.FindAsync(id) ?? new ThongsoNeo();
        }

        public async Task<int> Sum()
        {
            return await _thietbiDbContext.ThongsoNeos.CountAsync();
        }

        public async Task<List<ThongsoNeoVm>> GetDetailById(int id)
        {
            var query = from t in _thietbiDbContext.ThongsoNeos.Where(x => x.Id == id)
                        join n in _thietbiDbContext.DanhmucNeos on t.NeoId equals n.Id
                        select new { t, n };

            return await query.Select(x => new ThongsoNeoVm
            {
                Id = x.t.Id,
                TenThietBi = x.n.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo
            }).ToListAsync();
        }

        public async Task<bool> Update(ThongsoNeo request)
        {
            var entity = await _thietbiDbContext.ThongsoNeos.FindAsync(request.Id);
            if (entity == null) return false;

            entity.NeoId = request.NeoId;
            entity.NoiDung = request.NoiDung;
            entity.DonViTinh = request.DonViTinh;
            entity.ThongSo = request.ThongSo;
            _thietbiDbContext.Update(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _thietbiDbContext.ThongsoNeos.FindAsync(id);
            if (entity == null) return false;

            _thietbiDbContext.ThongsoNeos.Remove(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<ThongsoNeoVm>> GetAllPaging(ThongsoNeoPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongsoNeos.Include(x => x.DanhmucNeo)
                        select t;

            if (request.thietbiId.HasValue && request.thietbiId > 0)
            {
                query = query.Where(x => x.NeoId == request.thietbiId);
            }

            int totalRecords = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                  .Take(request.PageSize)
                                  .Select(x => new ThongsoNeoVm
                                  {
                                      Id = x.Id,
                                      TenThietBi = x.DanhmucNeo.TenThietBi,
                                      NoiDung = x.NoiDung,
                                      DonViTinh = x.DonViTinh,
                                      ThongSo = x.ThongSo
                                  }).ToListAsync();

            return new PagedResult<ThongsoNeoVm>
            {
                TotalRecords = totalRecords,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
        }
    }
}