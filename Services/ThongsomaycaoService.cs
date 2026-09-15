using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.MayCao.ThongsokythuatMayCao;


namespace WebApi.Services
{
    public interface IThongsokythuatmaycaoService
    {
        Task<List<ThongsokythuatmaycaoVm>> GetAll();
        Task<PagedResult<ThongsokythuatmaycaoVm>> GetAllPaging(ThongsomaycaoPagingRequest request);
        Task<ThongSoKyThuatMayCao> GetById(int id);
        Task<List<ThongsokythuatmaycaoVm>> GetDetailById(int id);
        Task<bool> Add(ThongSoKyThuatMayCao request);
        Task<bool> Update(ThongSoKyThuatMayCao request);
        Task<bool> Delete(int id);
        Task<List<int>> DeleteMultiple(List<int> ids);
    }

    public class ThongsokythuatmaycaoService : IThongsokythuatmaycaoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public ThongsokythuatmaycaoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<List<ThongsokythuatmaycaoVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongSoKyThuatMayCaos.Include(x => x.DanhmucMayCao)
                        select t;

            return await query.Select(x => new ThongsokythuatmaycaoVm()
            {
                Id = x.Id,
                MayCaoId=x.MayCaoId,
                TenThietBi = x.DanhmucMayCao.TenThietBi,                
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo
            }).ToListAsync();
        }

        public async Task<PagedResult<ThongsokythuatmaycaoVm>> GetAllPaging(ThongsomaycaoPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongSoKyThuatMayCaos.Include(x => x.DanhmucMayCao)
                        select t;

            if (request.thietbiId.HasValue && request.thietbiId > 0)
            {
                query = query.Where(x => x.MayCaoId == request.thietbiId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                  .Take(request.PageSize)
                                  .Select(x => new ThongsokythuatmaycaoVm()
                                  {
                                      Id = x.Id,
                                      TenThietBi = x.DanhmucMayCao.TenThietBi,
                                      NoiDung = x.NoiDung,
                                      DonViTinh = x.DonViTinh,
                                      ThongSo = x.ThongSo
                                  }).ToListAsync();

            return new PagedResult<ThongsokythuatmaycaoVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
        }

        public async Task<ThongSoKyThuatMayCao> GetById(int id)
        {
            var item = await _thietbiDbContext.ThongSoKyThuatMayCaos.FindAsync(id);
            return item ?? new ThongSoKyThuatMayCao();
        }

        public async Task<List<ThongsokythuatmaycaoVm>> GetDetailById(int id)
        {
            var query = from t in _thietbiDbContext.ThongSoKyThuatMayCaos.Where(x => x.MayCaoId == id)
                        join m in _thietbiDbContext.DanhmucMayCaos on t.MayCaoId equals m.Id
                        select new { t, m };

            return await query.Select(x => new ThongsokythuatmaycaoVm()
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo
            }).ToListAsync();
        }

        public async Task<bool> Add(ThongSoKyThuatMayCao request)
        {
            if (request == null)
            {
                return false;
            }

            var newItem = new ThongSoKyThuatMayCao()
            {
                MayCaoId = request.MayCaoId,
                NoiDung = request.NoiDung,
                DonViTinh = request.DonViTinh,
                ThongSo = request.ThongSo
            };

            await _thietbiDbContext.ThongSoKyThuatMayCaos.AddAsync(newItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(ThongSoKyThuatMayCao request)
        {
            var item = await _thietbiDbContext.ThongSoKyThuatMayCaos.FindAsync(request.Id);
            if (item == null)
            {
                return false;
            }

            item.MayCaoId = request.MayCaoId;
            item.NoiDung = request.NoiDung;
            item.DonViTinh = request.DonViTinh;
            item.ThongSo = request.ThongSo;

            _thietbiDbContext.Update(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.ThongSoKyThuatMayCaos.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _thietbiDbContext.ThongSoKyThuatMayCaos.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<int>> DeleteMultiple(List<int> ids)
        {
            var items = await _thietbiDbContext.ThongSoKyThuatMayCaos
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (!items.Any())
                return new List<int>();

            _thietbiDbContext.ThongSoKyThuatMayCaos.RemoveRange(items);
            await _thietbiDbContext.SaveChangesAsync();

            return items.Select(x => x.Id).ToList();
        }
    }
}