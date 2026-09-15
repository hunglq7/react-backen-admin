using Api.Data.Entites;
using Api.Models.Danhmuctoitruc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.GiaCot;

namespace WebApi.Services
{
    public interface IDanhmucgiacotService
    {
        Task<List<DanhmucgiacotVm>> GetAll();
        Task<ApiResult<int>> DeleteMutiple(List<int> ids);
        Task<bool> Add(DanhmucGiaCot request);
        Task<bool> Update(DanhmucGiaCot request);
        Task<bool> Delete(int id);
    }
    public class DanhmucgiacotService : IDanhmucgiacotService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucgiacotService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add(DanhmucGiaCot request)
        {
            if (request == null) return false;
            var newItems = new DanhmucGiaCot()
            {
                MaLoai = request.MaLoai,
                TenLoai = request.TenLoai,
                MoTa = request.MoTa,
            };
            await _thietbiDbContext.DanhmucGiaCots.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.DanhmucGiaCots.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _thietbiDbContext.DanhmucGiaCots.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDbContext.DanhmucGiaCots
                .Where(x => ids.Contains(x.LoaiThietBiId))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDbContext.DanhmucGiaCots.RemoveRange(items);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DanhmucgiacotVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucGiaCots
                        select c;
            return await query.Select(x => new DanhmucgiacotVm()
            {
                LoaiThietBiId = x.LoaiThietBiId,
                MaLoai = x.MaLoai,
                TenLoai = x.TenLoai,
                MoTa = x.MoTa,
            }).ToListAsync();
        }

        public async Task<bool> Update(DanhmucGiaCot request)
        {
            var existingItem = _thietbiDbContext.DanhmucGiaCots.AsNoTracking().FirstOrDefault(x => x.LoaiThietBiId == request.LoaiThietBiId);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.MaLoai = request.MaLoai;
            existingItem.TenLoai = request.TenLoai;
            existingItem.MoTa = request.MoTa;
            _thietbiDbContext.DanhmucGiaCots.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
