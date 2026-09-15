using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmuckhoan;

namespace WebApi.Services
{

    public interface IDanhmucKhoanService
    {
        Task<List<DanhMucKhoanVm>> GetAll();
        Task<ApiResult<int>> Add(DanhMucKhoan request);
        Task<ApiResult<int>> Update(DanhMucKhoan request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<int>> UpdateMultiple(List<DanhMucKhoan> response);
        Task<ApiResult<int>> DeleteMultiple(List<int> ids);
    }
    public class DanhmucKhoanService : IDanhmucKhoanService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public DanhmucKhoanService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<List<DanhMucKhoanVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhMucKhoans
                        select c;

            return await query.Select(x => new DanhMucKhoanVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> Add(DanhMucKhoan request)
        {
            _thietbiDbContext.DanhMucKhoans.Add(request);
            var result = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(result);
        }

        public async Task<ApiResult<int>> Update(DanhMucKhoan request)
        {
            _thietbiDbContext.DanhMucKhoans.Update(request);
            var result = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(result);
        }

        public async Task<ApiResult<int>> Delete(int id)
        {
            var entity = await _thietbiDbContext.DanhMucKhoans.FindAsync(id);
            if (entity == null)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi");
            }
            _thietbiDbContext.DanhMucKhoans.Remove(entity);
            var result = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(result);
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhMucKhoan> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhMucKhoans.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!existingItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }

            _thietbiDbContext.UpdateRange(response);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<int> ids)
        {
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhMucKhoans.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (existingItems.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }

            _thietbiDbContext.RemoveRange(existingItems);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }
}