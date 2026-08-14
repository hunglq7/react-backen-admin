using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Loaithietbi;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Services
{
    public interface ILoaithietbiService
    {
        Task<List<LoaithietbiVm>> GetLoaithietbi();
        Task<ApiResult<int>> UpdateMultipleLoaithietbi(List<LoaiThietBi> loaithietbis);
        Task<ApiResult<int>> DeleteMutipleLoaithietbi(List<LoaiThietBi> loaithietbis);
        Task<ApiResult<int>> DeleteSelectedLoaithietbi(List<int> ids);
         Task<bool> Add([FromBody] LoaiThietBi Request);
        Task<bool> Update([FromBody] LoaiThietBi Request);
        Task<bool> Delete(int id);
    }
    public class LoaithietbiService : ILoaithietbiService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public LoaithietbiService(ThietbiDbContext thietbiDbContext)
        {

            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutipleLoaithietbi(List<LoaiThietBi> loaithietbis)
        {
            var ids = loaithietbis.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
           
            var exitLoaithietbi = _thietbiDbContext.LoaiThietBis.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
         
            var newLoaithietbis = exitLoaithietbi.Select(x => x.Id).ToList();
            var deff = ids.Except(newLoaithietbis).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitLoaithietbi);
            var count=  await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<LoaithietbiVm>> GetLoaithietbi()
        {
            var query = from c in _thietbiDbContext.LoaiThietBis.Where(x => x.TrangThai == true)
                        select c;
            return await query.Select(x => new LoaithietbiVm()
            {
                Id = x.Id,
                TenLoai = x.TenLoai,
                TrangThai = x.TrangThai,

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultipleLoaithietbi(List<LoaiThietBi> loaithietbis)
        {
            var ids = loaithietbis.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitLoaithietbi = _thietbiDbContext.LoaiThietBis.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitLoaithietbi.All(x => ids.Contains(x.Id)))
            {
                throw new Exception("Tất cả id không tồn tại trong database");
            }
            _thietbiDbContext.UpdateRange(loaithietbis);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.LoaiThietBis.Where(x => ids.Contains(x.Id)).ToList();
        
            return new ApiSuccessResult<int>(count);
        }

         public async Task<bool> Add([FromBody] LoaiThietBi Request)
        {
            if (Request == null)
            {
                return false;
            }
            var newItems = new LoaiThietBi()
            {
                TenLoai = Request.TenLoai,
                TrangThai = Request.TrangThai,

            };
            await _thietbiDbContext.LoaiThietBis.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
         public async Task<bool> Update([FromBody] LoaiThietBi Request)
        {
            var items = await _thietbiDbContext.LoaiThietBis.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.TenLoai = Request.TenLoai;
            items.TrangThai = Request.TrangThai;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.LoaiThietBis.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.LoaiThietBis.Remove(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
         public async Task<ApiResult<int>> DeleteSelectedLoaithietbi(List<int> ids){
 if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDbContext.LoaiThietBis.AsNoTracking()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDbContext.LoaiThietBis.RemoveRange(items);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
         }
    }
}
