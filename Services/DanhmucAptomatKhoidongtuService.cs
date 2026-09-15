using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.AptomatKhoidongtu.DanhmucAptomatKhoidongtu;

namespace WebApi.Services
{
    public interface IDanhmucAptomatKhoidongtuService
    {
        Task<List<DanhmucAptomatKhoidongtuVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhmucAptomatKhoidongtu> response);
        Task<ApiResult<int>> DeleteMultiple(List<DanhmucAptomatKhoidongtu> response);
        Task<bool> Create(DanhmucAptomatKhoidongtu request);
        Task<bool> Update(DanhmucAptomatKhoidongtu request);
        Task<bool> Delete(int id);
        Task<ApiResult<int>> DeleteMultipleByIds(List<int> ids);
    }
    public class DanhmucAptomatKhoidongtuService : IDanhmucAptomatKhoidongtuService
    {
        public readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucAptomatKhoidongtuService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public Task<bool> Create(DanhmucAptomatKhoidongtu request)
        {
            if (request == null)
            {
                return Task.FromResult(false);
            }
            var entity = new DanhmucAptomatKhoidongtu()
            {
                TenThietBi = request.TenThietBi,
                LoaiThietBi = request.LoaiThietBi,
                GhiChu = request.GhiChu
            };
            _thietbiDbContext.DanhmucAptomatKhoidongtus.Add(entity);
            var result = _thietbiDbContext.SaveChanges();
            return Task.FromResult(result > 0);

        }

        public Task<bool> Delete(int id)
        {
            var entity = _thietbiDbContext.DanhmucAptomatKhoidongtus.Find(id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            _thietbiDbContext.DanhmucAptomatKhoidongtus.Remove(entity);
            var result = _thietbiDbContext.SaveChanges();
            return Task.FromResult(result > 0);
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<DanhmucAptomatKhoidongtu> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhmucAptomatKhoidongtus.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            var newItems = exitItems.Select(x => x.Id).ToList();
            var deff = ids.Except(newItems).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitItems);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public Task<ApiResult<int>> DeleteMultipleByIds(List<int> ids)
        {
            if (ids.Count == 0)
            {
                return Task.FromResult<ApiResult<int>>(new ApiErrorResult<int>("Không tìm thấy bản ghi nào"));
            }
            var entities = _thietbiDbContext.DanhmucAptomatKhoidongtus.Where(x => ids.Contains(x.Id)).ToList();
            if (entities.Count == 0)
            {
                return Task.FromResult<ApiResult<int>>(new ApiErrorResult<int>("Không tìm thấy bản ghi nào"));
            }
            _thietbiDbContext.DanhmucAptomatKhoidongtus.RemoveRange(entities);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => (ApiResult<int>)new ApiSuccessResult<int>(t.Result));

        }

        public async Task<List<DanhmucAptomatKhoidongtuVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucAptomatKhoidongtus
                        select c;
            return await query.Select(x => new DanhmucAptomatKhoidongtuVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public Task<bool> Update(DanhmucAptomatKhoidongtu request)
        {
            if (request == null)
            {
                return Task.FromResult(false);
            }

            var entity = _thietbiDbContext.DanhmucAptomatKhoidongtus.Find(request.Id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            entity.TenThietBi = request.TenThietBi;
            entity.LoaiThietBi = request.LoaiThietBi;
            entity.GhiChu = request.GhiChu;
            
            _thietbiDbContext.DanhmucAptomatKhoidongtus.Update(entity);
            var result = _thietbiDbContext.SaveChanges();
            return Task.FromResult(result > 0);
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhmucAptomatKhoidongtu> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhmucAptomatKhoidongtus.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(response);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }
    }
}