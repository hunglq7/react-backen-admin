using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;

namespace WebApi.Services
{
    public interface IDanhmucbangtaiService
    {
        Task<List<DanhmucbangtaiVM>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhMucBangTai> response);
        Task<ApiResult<int>> DeleteMutiple(List<DanhMucBangTai> response);
    }
    public class DanhmucbangtaiService : IDanhmucbangtaiService
    {
        public readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucbangtaiService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutiple(List<DanhMucBangTai> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhMucBangTais.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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
        public async Task<List<DanhmucbangtaiVM>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhMucBangTais
                        select c;
            return await query.Select(x => new DanhmucbangtaiVM()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }
        public async Task<ApiResult<int>> UpdateMultiple(List<DanhMucBangTai> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitItems = _thietbiDbContext.DanhMucBangTais.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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