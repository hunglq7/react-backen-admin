using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Camera;
using WebApi.Models.Common;

namespace WebApi.Services
{
    public interface ICameraService
    {
        Task<List<CameraVm>> GetCamera();
        Task<ApiResult<int>> UpdateMultipleCamera(List<Camera> Request);
        Task<ApiResult<int>> DeleteMutipleCamera(List<Camera> Request);
    }
    public class CameraService : ICameraService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public CameraService ( ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<ApiResult<int>> DeleteMutipleCamera(List<Camera> Request)
        {
            var ids = Request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitCamera = _thietbiDbContext.Cameras.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newCamera = exitCamera.Select(x => x.Id).ToList();
            var deff = ids.Except(newCamera).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitCamera);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<CameraVm>> GetCamera()
        {
            var query = from c in _thietbiDbContext.Cameras
                        select c;
            return await query.Select(x => new CameraVm()
            {
                Id = x.Id,
               TenThietBI = x.TenThietBI,
               ThongSoKyThuat=x.ThongSoKyThuat,
               NuocSanXuat=x.NuocSanXuat,
               HangSanXuat=x.HangSanXuat,
               NamSanXuat=x.NamSanXuat,
               GhiChu=x.GhiChu

            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultipleCamera(List<Camera> Request)
        {
            var ids = Request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitCamera = _thietbiDbContext.Cameras.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitCamera.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(Request);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.Cameras.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(count);
        }
    }
}
