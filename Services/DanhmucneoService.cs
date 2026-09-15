using WebApi.Models.Common;
using WebApi.Data.Entites;
using WebApi.Models.Neo.Danhmucneo;
using WebApi.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public interface IDanhmucNeoService
    {
        Task<List<DanhmucNeoVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhmucNeo> response);
        Task<ApiResult<int>> DeleteMultiple(List<int> ids);
        Task<bool> Add(DanhmucNeo request);
        Task<bool> Update(DanhmucNeo request);
        Task<bool> Delete(int id);

    }

    public class DanhmucNeoService : IDanhmucNeoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public DanhmucNeoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public Task<bool> Add(DanhmucNeo request)
        {
            if (request == null)
            {
                return Task.FromResult(false);
            }
            var entity = new DanhmucNeo()
            {
                TenThietBi = request.TenThietBi,
                LoaiThietBi = request.LoaiThietBi,
            };
            _thietbiDbContext.DanhmucNeos.Add(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public Task<bool> Delete(int id)
        {
            var entity = _thietbiDbContext.DanhmucNeos.Find(id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            _thietbiDbContext.DanhmucNeos.Remove(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public Task<ApiResult<int>> DeleteMultiple(List<int> ids)
        {
            if (ids.Count == 0)
            {
                return Task.FromResult<ApiResult<int>>(new ApiErrorResult<int>("Không tìm thấy bản ghi nào"));
            }
            var entities = _thietbiDbContext.DanhmucNeos.Where(x => ids.Contains(x.Id)).ToList();
            if (entities.Count == 0)
            {
                return Task.FromResult<ApiResult<int>>(new ApiErrorResult<int>("Không tìm thấy bản ghi nào"));
            }
            _thietbiDbContext.DanhmucNeos.RemoveRange(entities);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => (ApiResult<int>)new ApiSuccessResult<int>(t.Result));
        }

        public async Task<List<DanhmucNeoVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucNeos
                        select c;

            return await query.Select(x => new DanhmucNeoVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi
            }).ToListAsync();
        }

        public Task<bool> Update(DanhmucNeo request)
        {
            var entity = _thietbiDbContext.DanhmucNeos.Find(request.Id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            entity.TenThietBi = request.TenThietBi;
            entity.LoaiThietBi = request.LoaiThietBi;
            _thietbiDbContext.DanhmucNeos.Update(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhmucNeo> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhmucNeos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!existingItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }

            _thietbiDbContext.UpdateRange(response);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }



    }
}