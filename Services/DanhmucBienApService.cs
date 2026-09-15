using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.BienAp;
using WebApi.Models.Common;

namespace WebApi.Services
{
    public interface IDanhmucBienApService
    {
        Task<List<DanhmucBienApVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhmucBienap> response);
        Task<ApiResult<int>> DeleteMultiple(List<DanhmucBienap> response);
        Task<bool> Add(DanhmucBienap request);
        Task<bool> Update(DanhmucBienap request);
        Task<bool> Delete(int id);
        Task<ApiResult<int>> DeleteSelect(List<int> ids);
    }
    public class DanhmucBienApService : IDanhmucBienApService
    {
        public readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucBienApService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(DanhmucBienap request)
        {
            if (request == null) return false;
            var newItems = new DanhmucBienap()
            {
                TenThietBi = request.TenThietBi,
                LoaiThietBi = request.LoaiThietBi,
                GhiChu = request.GhiChu
            };
            await _thietbiDbContext.DanhmucBienaps.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.DanhmucBienaps.FindAsync(id);
            if (item == null)
            {
                return false;
            }
            _thietbiDbContext.DanhmucBienaps.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<DanhmucBienap> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhmucBienaps.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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

        public async Task<ApiResult<int>> DeleteSelect(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDbContext.DanhmucBienaps
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDbContext.DanhmucBienaps.RemoveRange(items);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DanhmucBienApVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucBienaps
                        select c;
            return await query.Select(x => new DanhmucBienApVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update(DanhmucBienap request)
        {
            var existingItem = _thietbiDbContext.DanhmucBienaps.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.TenThietBi = request.TenThietBi;
            existingItem.LoaiThietBi = request.LoaiThietBi;
            existingItem.GhiChu = request.GhiChu;
            _thietbiDbContext.DanhmucBienaps.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhmucBienap> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhmucBienaps.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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