
using Api.Data.Entites;
using Api.Models.Thongsokythuattoitruc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Models.Common;
using WebApi.Models.Thongsokythuattoitruc;
using WebApi.Models.ThongsoQuatgio;

namespace Api.Services
{
    public interface IThongsokythuattoitrucService
    {
        Task<List<ThongsokythuattoitrucVm>> GetAll();
        Task<PagedResult<ThongsokythuattoitrucVm>> GetAllPaging(ThongsotoitrucPagingRequest request);
        Task<ThongsokythuatToitruc> GetById(int id);
        Task<List<ThongsokythuattoitrucVm>> getDetailById(int id);
        Task<bool> Add(ThongsokythuattoitrucEdit Request);
        Task<bool> Update(ThongsokythuattoitrucEdit Request);
        Task<bool> Delete(int id);
        Task<List<int>> DeleteMutiple(List<int> ids);

    }
    public class ThongsokythuattoitrucService : IThongsokythuattoitrucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public ThongsokythuattoitrucService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(ThongsokythuattoitrucEdit Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newItems = new ThongsokythuatToitruc()
            {
                Id = Request.Id,
                DanhmuctoitrucId = Request.DanhmuctoitrucId,
                NoiDung = Request.NoiDung,
                DonViTinh = Request.DonViTinh,
                ThongSo = Request.ThongSo,

            };
            await _thietbiDbContext.ThongsokythuatToitrucs.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ThongsokythuatToitrucs.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ThongsokythuatToitrucs.Remove(items);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<List<int>> DeleteMutiple(List<int> ids)
        {
            var items = await _thietbiDbContext.ThongsokythuatToitrucs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (!items.Any())
                return new List<int>();

            _thietbiDbContext.ThongsokythuatToitrucs.RemoveRange(items);
            await _thietbiDbContext.SaveChangesAsync();

            return items.Select(x => x.Id).ToList();
        }

        public async Task<List<ThongsokythuattoitrucVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongsokythuatToitrucs.Include(x => x.Danhmuctoitruc)
                        select t;
            return await query.Select(x => new ThongsokythuattoitrucVm()
            {
                Id = x.Id,
                DanhmuctoitrucId = x.DanhmuctoitrucId,
                TenToiTruc = x.Danhmuctoitruc.TenThietBi,
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo,
            }).ToListAsync();
        }

        public async Task<PagedResult<ThongsokythuattoitrucVm>> GetAllPaging(ThongsotoitrucPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongsokythuatToitrucs.Include(x => x.Danhmuctoitruc)
                        select t;
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.DanhmuctoitrucId == request.thietbiId);
            }


            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsokythuattoitrucVm()
                {
                    Id = x.Id,
                    TenToiTruc = x.Danhmuctoitruc!.TenThietBi,
                    NoiDung = x.NoiDung,
                    DonViTinh = x.DonViTinh,
                    ThongSo = x.ThongSo,

                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsokythuattoitrucVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<ThongsokythuatToitruc> GetById(int id)
        {
            var items = await _thietbiDbContext.ThongsokythuatToitrucs.FindAsync(id);
            if (items == null)
            {
                items = new ThongsokythuatToitruc()
                {
                    Id = 0,
                    DanhmuctoitrucId = 1,
                    NoiDung = "",
                    DonViTinh = "",
                    ThongSo = ""
                }
                     ;
            }

            return items;
        }

        public async Task<List<ThongsokythuattoitrucVm>> getDetailById(int id)
        {
            var Query = from t in _thietbiDbContext.ThongsokythuatToitrucs.Where(x => x.DanhmuctoitrucId == id)
                        join m in _thietbiDbContext.Danhmuctoitrucs on t.DanhmuctoitrucId equals m.Id

                        select new { t, m };
            return await Query.Select(x => new ThongsokythuattoitrucVm
            {
                Id = x.t.Id,
                TenToiTruc = x.m.TenThietBi,
                DanhmuctoitrucId = x.m.Id,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo,
            }).ToListAsync();
        }

        public async Task<bool> Update(ThongsokythuattoitrucEdit Request)
        {
            if (Request == null)
                return false;

            var items = await _thietbiDbContext.ThongsokythuatToitrucs.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.Id = Request.Id;
            items.DanhmuctoitrucId = Request.DanhmuctoitrucId;
            items.NoiDung = Request.NoiDung;
            items.DonViTinh = Request.DonViTinh;
            items.ThongSo = Request.ThongSo;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

    }
}