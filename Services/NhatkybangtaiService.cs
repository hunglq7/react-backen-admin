using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Danhmucbangtai;

namespace WebApi.Services
{
    public interface INhatkybangtaiService
    {
        Task<List<NhatkybangtaiVM>> GetAll();
        Task<List<NhatKyBangTai>> getDatailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatKyBangTai> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatKyBangTai> request);
    }
    public class NhatkybangtaiService : INhatkybangtaiService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkybangtaiService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<ApiResult<int>> DeleteMutiple(List<NhatKyBangTai> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var exitBangTai = _thietbiDbContext.NhatKyBangTais.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newBangTai = exitBangTai.Select(x => x.Id).ToList();
            var deff = ids.Except(newBangTai).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitBangTai);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<NhatkybangtaiVM>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatKyBangTais
                        select c;
            return await query.Select(x => new NhatkybangtaiVM()
            {
                Id = x.Id,
                TongHopBangTaiId = x.TongHopBangTaiId,
                 Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu,
            }).ToListAsync();
        }

        public async Task<List<NhatKyBangTai>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatKyBangTais.Where(x => x.TongHopBangTaiId == id)
                        select t;

            return await Query.Select(x => new NhatKyBangTai()
            {
                Id = x.Id,
                TongHopBangTaiId = id,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatKyBangTai> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }
            var exitBangTai = _thietbiDbContext.NhatKyBangTais.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitBangTai.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }
}