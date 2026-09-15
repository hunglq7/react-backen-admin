using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Donvitinh;

namespace WebApi.Services
{
    public interface IDonvitinhService
    {
        Task<List<DonvitinhVm>> GetDonvitinh();
        Task<ApiResult<int>> UpdateMultipleDonvitinh(List<DonViTinh> donvitinhs);
        Task<ApiResult<int>> DeleteMutipleDonvitinh(List<DonViTinh> donvitinhs);
        Task<bool> Add([FromBody] DonViTinh Request);
        Task<bool> Update([FromBody] DonViTinh Request);
        Task<bool> Delete(int id);
    }
    public class DonvitinhService : IDonvitinhService
    {

        private readonly ThietbiDbContext _thietbiDbContext;
        public DonvitinhService(ThietbiDbContext thietbiDbContext)
        {

            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutipleDonvitinh(List<DonViTinh> donvitinhs)
        {
            var ids = donvitinhs.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
               return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
          
            var exitDonvitinh = _thietbiDbContext.DonViTinhs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
           
            var newdonvitinhs = exitDonvitinh.Select(x => x.Id).ToList();
            var deff = ids.Except(newdonvitinhs).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitDonvitinh);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<DonvitinhVm>> GetDonvitinh()
        {
            var query = from c in _thietbiDbContext.DonViTinhs.Where(x => x.TrangThai == true)
                        select c;
            return await query.Select(x => new DonvitinhVm()
            {
                Id = x.Id,
                TenDonViTinh = x.TenDonViTinh,
                TrangThai = x.TrangThai,

            }).ToListAsync();
        }
        public async Task<bool> Add([FromBody] DonViTinh Request)
        {
            if (Request == null)
            {
                return false;
            }
            var newItems = new DonViTinh()
            {
                Id = Request.Id,
                TenDonViTinh = Request.TenDonViTinh,
                TrangThai = Request.TrangThai,
             
            };
            await _thietbiDbContext.DonViTinhs.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultipleDonvitinh(List<DonViTinh> donvitinhs)
        {
            var ids = donvitinhs.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitDonvitinh = _thietbiDbContext.DonViTinhs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitDonvitinh.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(donvitinhs);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.DonViTinhs.Where(x => ids.Contains(x.Id)).ToList();
          
            return new ApiSuccessResult<int>(count);
        }

        public async Task<bool> Update([FromBody] DonViTinh Request)
        {
            var items = await _thietbiDbContext.DonViTinhs.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }         
            items.TenDonViTinh = Request.TenDonViTinh;
            items.TrangThai = Request.TrangThai;         
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.DonViTinhs.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.DonViTinhs.Remove(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
