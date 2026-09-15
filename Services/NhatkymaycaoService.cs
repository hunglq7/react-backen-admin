using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.MayCao.Nhatkymaycao;

namespace WebApi.Services
{
    public interface INhatkyMayCaoService
    {
        Task<List<NhatkymaycaoVm>> GetAll();
        Task<List<NhatKyMayCao>> GetDetailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatKyMayCao> request);
        Task<ApiResult<int>> DeleteMultiple(List<NhatKyMayCao> request);
        Task<int> Add(NhatKyMayCao request);
        Task<bool> Update(NhatKyMayCao request);
        Task<bool> Delete(int id);
    }

    public class NhatkyMayCaoService : INhatkyMayCaoService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public NhatkyMayCaoService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<List<NhatkymaycaoVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatKyMayCaos
                        select c;

            return await query.Select(x => new NhatkymaycaoVm()
            {
                Id = x.Id,
                TonghopmaycaoId = x.TongHopMayCaoId,
                NgayThang = x.NgayThang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<List<NhatKyMayCao>> GetDetailById(int id)
        {
            var query = from t in _thietbiDbContext.NhatKyMayCaos.Where(x => x.TongHopMayCaoId == id)
                        select t;

            return await query.Select(x => new NhatKyMayCao()
            {
                Id = x.Id,
                TongHopMayCaoId = id,
                NgayThang = x.NgayThang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatKyMayCao> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.NhatKyMayCaos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!existingItems.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }

            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<ApiResult<int>> DeleteMultiple(List<NhatKyMayCao> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var existingItems = _thietbiDbContext.NhatKyMayCaos.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (existingItems.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }

            _thietbiDbContext.RemoveRange(existingItems);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<int> Add(NhatKyMayCao request)
        {
            if (request == null)
                throw new Exception("Request null");

            if (request.TongHopMayCaoId <= 0)
                throw new Exception("Thiếu TongHopMayCaoId");

            if (request.NgayThang == default)
                throw new Exception("Ngày tháng không hợp lệ");

            var newItem = new NhatKyMayCao
            {
                TongHopMayCaoId = request.TongHopMayCaoId,
                NgayThang = request.NgayThang,
                DonVi = request.DonVi,
                ViTri = request.ViTri,
                TrangThai = request.TrangThai,
                GhiChu = request.GhiChu
            };

            await _thietbiDbContext.NhatKyMayCaos.AddAsync(newItem);
            await _thietbiDbContext.SaveChangesAsync();

            return newItem.Id;
        }

        public async Task<bool> Update(NhatKyMayCao request)
        {
            var existingItem = _thietbiDbContext.NhatKyMayCaos.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.TongHopMayCaoId = request.TongHopMayCaoId;
            existingItem.NgayThang = request.NgayThang;
            existingItem.DonVi = request.DonVi;
            existingItem.ViTri = request.ViTri;
            existingItem.TrangThai = request.TrangThai;
            existingItem.GhiChu = request.GhiChu;
            _thietbiDbContext.NhatKyMayCaos.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.NhatKyMayCaos.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _thietbiDbContext.NhatKyMayCaos.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}