using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using Api.Models.AptomatKhoidongtu.NhatkyAptomatKhoidongtu;

namespace WebApi.Services
{
    public interface INhatkyaptomatkhoidongtuService
    {
        Task<List<NhatkyAptomatKhoidongtuVm>> GetAll();
        Task<List<Nhatkyaptomatkhoidongtu>> getDatailById(int id);
        Task<ApiResult<int>> UpdateMutiple(List<Nhatkyaptomatkhoidongtu> request);
        Task<ApiResult<int>> DeleteMutiple(List<Nhatkyaptomatkhoidongtu> request);
    }

    public class NhatkyaptomatkhoidongtuService : INhatkyaptomatkhoidongtuService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public NhatkyaptomatkhoidongtuService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<Nhatkyaptomatkhoidongtu> request)
        {
            try
            {
                var ids = request.Select(x => x.Id).ToList();
                if (ids.Count == 0)
                {
                    return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
                }

                var existingEntities = await _thietbiDbContext.Nhatkyaptomatkhoidongtus
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();

                if (existingEntities.Count != ids.Count)
                {
                    return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
                }

                _thietbiDbContext.Nhatkyaptomatkhoidongtus.RemoveRange(existingEntities);
                var count = await _thietbiDbContext.SaveChangesAsync();
                return new ApiSuccessResult<int>(count);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>($"Lỗi khi xóa dữ liệu: {ex.Message}");
            }
        }

        public async Task<List<NhatkyAptomatKhoidongtuVm>> GetAll()
        {
            try
            {
                var query = from c in _thietbiDbContext.Nhatkyaptomatkhoidongtus
                            select c;
                return await query.Select(x => new NhatkyAptomatKhoidongtuVm()
                {
                    Id = x.Id,
                    ThietBiId = x.TonghopaptomatkhoidongtuId,
                    NgayThang = x.NgayThang,
                    DonVi = x.DonVi,
                    ViTri = x.ViTri,
                    TrangThai = x.TrangThai,
                    GhiChu = x.GhiChu
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy dữ liệu: {ex.Message}");
            }
        }

        public async Task<List<Nhatkyaptomatkhoidongtu>> getDatailById(int id)
        {
            try
            {
                var query = from t in _thietbiDbContext.Nhatkyaptomatkhoidongtus
                            where t.TonghopaptomatkhoidongtuId == id
                            select t;
                return await query.Select(x => new Nhatkyaptomatkhoidongtu()
                {
                    Id = x.Id,
                    TonghopaptomatkhoidongtuId = x.TonghopaptomatkhoidongtuId,
                    NgayThang = x.NgayThang,
                    DonVi = x.DonVi,
                    ViTri = x.ViTri,
                    TrangThai = x.TrangThai,
                    GhiChu = x.GhiChu
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết: {ex.Message}");
            }
        }

        public async Task<ApiResult<int>> UpdateMutiple(List<Nhatkyaptomatkhoidongtu> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitEntity = _thietbiDbContext.Nhatkyaptomatkhoidongtus.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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