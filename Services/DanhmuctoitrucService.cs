using Api.Data.Entites;
using Api.Models.Danhmuctoitruc;
using WebApi.Data.EF;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Common;
namespace Api.Services
{
    public interface IDanhmuctoitrucService
    {
        Task<List<DanhmuctoitrucVm>> GetAll();
        Task<ApiResult<int>> UpdateMultiple(List<Danhmuctoitruc> response);
        Task<ApiResult<int>> DeleteMutiple(List<int> ids);
        Task<bool> Add(Danhmuctoitruc request);
        Task<bool> Update(Danhmuctoitruc request);
        Task<bool> Delete(int id);

    }
    public class DanhmuctoitrucService : IDanhmuctoitrucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public DanhmuctoitrucService(ThietbiDbContext thietbiDb)

        {
            _thietbiDbContext = thietbiDb;
        }

        public async Task<bool> Add(Danhmuctoitruc request)
        {
            if (request == null) return false;
            var newItems = new Danhmuctoitruc()
            {
                TenThietBi = request.TenThietBi,
                LoaiThietBi = request.LoaiThietBi,
                NamSanXuat = request.NamSanXuat,
                HangSanXuat = request.HangSanXuat,
                TinhTrang = request.TinhTrang,
                GhiChu = request.GhiChu
            };
            await _thietbiDbContext.Danhmuctoitrucs.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.Danhmuctoitrucs.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _thietbiDbContext.Danhmuctoitrucs.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDbContext.Danhmuctoitrucs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDbContext.Danhmuctoitrucs.RemoveRange(items);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DanhmuctoitrucVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.Danhmuctoitrucs
                        select c;
            return await query.Select(x => new DanhmuctoitrucVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                LoaiThietBi = x.LoaiThietBi,
                TinhTrang = x.TinhTrang,
                NamSanXuat = x.NamSanXuat,
                HangSanXuat = x.HangSanXuat,
                GhiChu = x.GhiChu,

            }).ToListAsync();
        }

        public async Task<bool> Update(Danhmuctoitruc request)
        {
            var existingItem = _thietbiDbContext.Danhmuctoitrucs.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.TenThietBi = request.TenThietBi;
            existingItem.LoaiThietBi = request.LoaiThietBi;
            existingItem.NamSanXuat = request.NamSanXuat;
            existingItem.HangSanXuat = request.HangSanXuat;
            existingItem.TinhTrang = request.TinhTrang;
            existingItem.GhiChu = request.GhiChu;
            _thietbiDbContext.Danhmuctoitrucs.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<Danhmuctoitruc> reponse)
        {
            var ids = reponse.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitItems = _thietbiDbContext.Danhmuctoitrucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(reponse);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.Danhmuctoitrucs.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(count);
        }
    }
}