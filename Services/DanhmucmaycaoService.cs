using WebApi.Models.Common;
using WebApi.Data.Entites;
using WebApi.Models.MayCao.Danhmucmaycao;
using WebApi.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public interface IDanhmucMayCaoService
    {
        Task<List<DanhmucMayCaoVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<DanhmucMayCao> response);
        Task<ApiResult<int>> DeleteMultiple(List<int> ids);
        Task<bool> Add(DanhmucMayCao request);
        Task<bool> Update(DanhmucMayCao request);
        Task<bool> Delete(int id);
    }
    public class DanhmucMayCaoService : IDanhmucMayCaoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public DanhmucMayCaoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<List<DanhmucMayCaoVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucMayCaos
                        select c;

            return await query.Select(x => new DanhmucMayCaoVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<DanhmucMayCao> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.DanhmucMayCaos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDbContext.DanhmucMayCaos
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDbContext.DanhmucMayCaos.RemoveRange(items);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<bool> Add(DanhmucMayCao request)
        {
            if (request == null) return false;
            var newItems = new DanhmucMayCao()
            {
                TenThietBi = request.TenThietBi,
                LoaiThietBi = request.LoaiThietBi,            
                GhiChu = request.GhiChu
            };
            await _thietbiDbContext.DanhmucMayCaos.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(DanhmucMayCao request)
        {
            var existingItem = _thietbiDbContext.DanhmucMayCaos.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.TenThietBi = request.TenThietBi;
            existingItem.LoaiThietBi = request.LoaiThietBi;      
            
            existingItem.GhiChu = request.GhiChu;
            _thietbiDbContext.DanhmucMayCaos.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.DanhmucMayCaos.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _thietbiDbContext.DanhmucMayCaos.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}