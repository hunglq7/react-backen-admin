using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.DanhmucRole;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public interface IDanhmucRoleService
    {
        // Define methods for the DanhmucRoleService here
        Task<List<DanhmucRoleVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhMucRole> response);
        Task<ApiResult<int>> DeleteMultiple(List<DanhMucRole> response);
        Task<bool> Add(DanhMucRole request);
        Task<bool> Update(DanhMucRole request);
        Task<bool> Delete(int id);
        Task<ApiResult<int>> DeleteSelect(List<int> ids);
    }
    public class DanhmucRoleService : IDanhmucRoleService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucRoleService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(DanhMucRole request)
        {
            if (request == null) return false;
            var newItems = new DanhMucRole()
            {
                TenThietBi = request.TenThietBi,
                LoaiThietBi = request.LoaiThietBi,
                GhiChu = request.GhiChu
            };
            await _thietbiDbContext.DanhMucRoles.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.DanhMucRoles.FindAsync(id);
            if (item == null)
            {
                return false;
            }
            _thietbiDbContext.DanhMucRoles.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<DanhMucRole> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhMucRoles.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (existingItems.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }

            _thietbiDbContext.RemoveRange(existingItems);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<ApiResult<int>> DeleteSelect(List<int> ids)
        {

            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDbContext.DanhMucRoles
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDbContext.DanhMucRoles.RemoveRange(items);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DanhmucRoleVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhMucRoles
                        select c;

            return await query.Select(x => new DanhmucRoleVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi

            }).ToListAsync();
        }

        public async Task<bool> Update(DanhMucRole request)
        {
            var existingItem = _thietbiDbContext.DanhMucRoles.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.TenThietBi = request.TenThietBi;
            existingItem.LoaiThietBi = request.LoaiThietBi;
            existingItem.GhiChu = request.GhiChu;
            _thietbiDbContext.DanhMucRoles.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhMucRole> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhMucRoles.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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
