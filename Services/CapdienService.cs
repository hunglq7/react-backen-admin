using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Capdien;
using WebApi.Models.Common;

namespace WebApi.Services
{
    public interface ICapdienService
    {
        Task<List<CapdienVm>> GetAll();
        Task<List<CapdienVm>> getDetailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<Capdien> request);
        Task<ApiResult<int>> DeleteMutiple(List<Capdien> request);
    }
    public class CapdienService : ICapdienService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public CapdienService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<Capdien> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitEntity = _thietbiDbContext.Capdiens.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newEntity = exitEntity.Select(x => x.Id).ToList();
            var deff = ids.Except(newEntity).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitEntity);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<CapdienVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.Capdiens
                        select c;
            return await query.Select(x => new CapdienVm()
            {
                Id = x.Id,
               Tenthietbi=x.Tenthietbi,
               Ghichu=x.Ghichu

            }).ToListAsync();
        }

        public async Task<List<CapdienVm>> getDetailById(int id)
        {
            var Query = from t in _thietbiDbContext.Capdiens.Where(x => x.Id == id)
                        select t;

            return await Query.Select(x => new CapdienVm()
            {
                Id=x.Id,
                Tenthietbi=x.Tenthietbi,
                Ghichu=x.Ghichu
               
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<Capdien> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitEntity = _thietbiDbContext.Capdiens.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitEntity.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }
}
