
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Phongban;
using WebApi.Utilities.Exceptions;

namespace WebApi.Services
{
    public interface IPhongbanService
    {
        Task<List<PhongbanVm>> GetPhongban();
        Task<int> CreatePhongban(PhongbanCreateRequest request);
        //Task<PhongbanVm> GetById(int id);
        Task<int> Delete(PhongbanVm phongban);
        Task<ApiResult<int>> UpdateMultiple(List<PhongBan> response);
        Task<ApiResult<int>> DeleteMutiple(List<PhongBan> response);
        Task<ApiResult<int>> DeleteSelect(List<int> ids);
        Task<bool> Add([FromBody] PhongBan Request);
        Task<bool> Update([FromBody] PhongBan Request);
        Task<bool> Delete(int id);

    }
    public class PhongbanService : IPhongbanService
    {
        private readonly ThietbiDbContext _dbContext;
        public PhongbanService(ThietbiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreatePhongban(PhongbanCreateRequest request)
        {
            if (request == null)
            {
                return 0;
            }
            var phongban = new PhongBan()
            {
                TenPhong = request.TenPhong,
                TrangThai = request.TrangThai,
            };
            _dbContext.PhongBans.Add(phongban);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(PhongbanVm phongban)
        {
            var phong = await _dbContext.PhongBans.Where(x => x.Id == phongban.Id).FirstOrDefaultAsync();
            if (phong == null)
            {
                throw new ThietbiException($"Cannot find a phongban");
            }
            _dbContext.Remove(phong);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<ApiResult<int>> DeleteMutiple(List<PhongBan> response)
        {
            try
            {
                var ids = response.Select(x => x.Id).ToList();
                if (ids.Count() == 0)
                {
                    return new ApiErrorResult<int>("B?n chua ch?n b?n ghi c?n xóa");

                }
                if (ids.Any(x => x <= 0))
                {
                    return new ApiErrorResult<int>("Th?c hi?n xóa không h?p l?");
                }
                var exitPhongban = _dbContext.PhongBans.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

                var phongbans = exitPhongban.Select(x => x.Id).ToList();
                var deff = ids.Except(phongbans).ToList();
                if (deff.Count > 0)
                {
                    throw new Exception("id không h?p l?");
                }
                _dbContext.RemoveRange(exitPhongban);
                var count = await _dbContext.SaveChangesAsync();

                return new ApiSuccessResult<int>(count);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>("L?i k?t n?i máy ch? " + ex);
            }
        }



        public async Task<List<PhongbanVm>> GetPhongban()
        {
            var query = from p in _dbContext.PhongBans
                        select p;
            return await query.Select(x => new PhongbanVm()
            {
                Id = x.Id,
                TenPhong = x.TenPhong,
                TrangThai = x.TrangThai,

            }).ToListAsync();

        }

        public async Task<ApiResult<int>> UpdateMultiple(List<PhongBan> response)
        {
            try
            {
                var ids = response.Select(x => x.Id).ToList();
                if (ids.Count() == 0)
                {
                    return new ApiErrorResult<int>("B?n chua ch?n b?n ghi c?n c?p nh?t");

                }
                var exitPhongban = _dbContext.PhongBans.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

                if (!exitPhongban.All(x => ids.Contains(x.Id)))
                {
                    return new ApiErrorResult<int>("B?n chua ch?n b?n ghi c?n c?p nh?t");
                }
                _dbContext.UpdateRange(response);
                var count = await _dbContext.SaveChangesAsync();
                var UpdateMuliple = _dbContext.PhongBans.Where(x => ids.Contains(x.Id)).ToList();

                return new ApiSuccessResult<int>(count);

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>("L?i k?t n?i h? th?ng " + ex);
            }
        }

        public async Task<bool> Add([FromBody] PhongBan Request)
        {
            if (Request == null)
            {
                return false;
            }
            var newItems = new PhongBan()
            {
                TenPhong = Request.TenPhong,
                TrangThai = Request.TrangThai,

            };
            await _dbContext.PhongBans.AddAsync(newItems);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update([FromBody] PhongBan Request)
        {
            var items = await _dbContext.PhongBans.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.TenPhong = Request.TenPhong;
            items.TrangThai = Request.TrangThai;
            _dbContext.Update(items);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var items = await _dbContext.PhongBans.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _dbContext.PhongBans.Remove(items);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteSelect(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID r?ng");
            }

            var items = await _dbContext.PhongBans
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("M?t s? b?n ghi không t?n t?i");
            }

            _dbContext.PhongBans.RemoveRange(items);
            var count = await _dbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }
}
