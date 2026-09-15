using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.ThongsoQuatgio;

namespace WebApi.Services
{
    public interface IThongsoquatgioService
    {
        Task<List<ThongsoQuatgioVm>> GetAll();
        Task<PagedResult<ThongsoQuatgioVm>> GetAllPaging(ThongsoquatgioPagingRequest request);
        Task<ThongsoQuatgio> GetById(int id);
        Task<List<ThongsoQuatgioVm>> getDatailById(int id);
        Task<bool> Add([FromBody] ThongsoQuatgio Request);
        Task<bool> Update([FromBody] ThongsoQuatgio Request);
        Task<bool> Delete(int id);
        Task<ApiResult<int>> DeleteMutiple(List<ThongsoQuatgio> request);
        Task<List<int>> DeleteSelect(List<int> ids);
    }
    public class ThongsoquatgioService : IThongsoquatgioService
    {

        private readonly ThietbiDbContext _thietbiDbContext;
        public ThongsoquatgioService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] ThongsoQuatgio Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newItems = new ThongsoQuatgio()
            {
                Id = Request.Id,
                QuatgioId = Request.QuatgioId,
                NoiDung = Request.NoiDung,
                DonViTinh = Request.DonViTinh,
                ThongSo = Request.ThongSo,

            };
            await _thietbiDbContext.ThongsoQuatgios.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ThongsoQuatgios.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ThongsoQuatgios.Remove(items);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<ThongsoQuatgio> request)
        {

            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitEntity = _thietbiDbContext.ThongsoQuatgios.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newEntity = exitEntity.Select(x => x.Id).ToList();
            var deff = ids.Except(newEntity).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitEntity);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<int>> DeleteSelect(List<int> ids)
        {
            var items = await _thietbiDbContext.ThongsoQuatgios
                 .Where(x => ids.Contains(x.Id))
                 .ToListAsync();

            if (!items.Any())
                return new List<int>();

            _thietbiDbContext.ThongsoQuatgios.RemoveRange(items);
            await _thietbiDbContext.SaveChangesAsync();

            return items.Select(x => x.Id).ToList();
        }

        public async Task<List<ThongsoQuatgioVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongsoQuatgios.Include(x => x.DanhmucQuatgio)
                        select t;
            return await query.Select(x => new ThongsoQuatgioVm()
            {
                Id = x.Id,
                TenThietBi = x.DanhmucQuatgio!.TenThietBi,
                QuatGioId = x.QuatgioId,
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo,
            }).ToListAsync();
        }

        public async Task<PagedResult<ThongsoQuatgioVm>> GetAllPaging(ThongsoquatgioPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongsoQuatgios.Include(x => x.DanhmucQuatgio)
                        select t;
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.QuatgioId == request.thietbiId);
            }


            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsoQuatgioVm()
                {
                    Id = x.Id,
                    TenThietBi = x.DanhmucQuatgio!.TenThietBi,
                    NoiDung = x.NoiDung,
                    DonViTinh = x.DonViTinh,
                    ThongSo = x.ThongSo,

                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsoQuatgioVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<ThongsoQuatgio> GetById(int id)
        {
            var items = await _thietbiDbContext.ThongsoQuatgios.FindAsync(id);
            if (items == null)
            {
                items = new ThongsoQuatgio()
                {
                    Id = 0,
                    QuatgioId = 1,
                    NoiDung = "",
                    DonViTinh = "",
                    ThongSo = ""
                }
                     ;
            }

            return items;
        }

        public async Task<List<ThongsoQuatgioVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.ThongsoQuatgios.Where(x => x.QuatgioId == id)
                        join m in _thietbiDbContext.DanhmucQuatgios on t.QuatgioId equals m.Id


                        select new { t, m };
            return await Query.Select(x => new ThongsoQuatgioVm
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo,
            }).ToListAsync();
        }

        public async Task<bool> Update([FromBody] ThongsoQuatgio Request)
        {
            var items = await _thietbiDbContext.ThongsoQuatgios.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.Id = Request.Id;
            items.QuatgioId = Request.QuatgioId;
            items.NoiDung = Request.NoiDung;
            items.DonViTinh = Request.DonViTinh;
            items.ThongSo = Request.ThongSo;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
