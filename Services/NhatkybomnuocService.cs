using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.NhatkyBomnuoc;

namespace WebApi.Services
{
    public interface INhatkybomnuocService
    {
        Task<List<NhatkyBomnuocVm>> GetAll();
        Task<List<NhatKyBomNuoc>> getDatailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatKyBomNuoc> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatKyBomNuoc> request);
        Task<int> Add(NhatKyBomNuoc request);
        Task<bool> Update(NhatKyBomNuoc request);
        Task<bool> Delete(int id);
        Task<int> DeleteSelect(List<int> ids);
    }
    public class NhatkybomnuocService : INhatkybomnuocService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkybomnuocService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<int> Add(NhatKyBomNuoc request)
        {
            if (request == null)
                throw new Exception("Request null");

            if (request.TongHopBomNuocId <= 0)
                throw new Exception("Thiếu TongHopBomNuocId");

            if (request.Ngaythang == default)
                throw new Exception("Ngày tháng không hợp lệ");

            var newItem = new NhatKyBomNuoc
            {
                TongHopBomNuocId = request.TongHopBomNuocId,
                Ngaythang = request.Ngaythang,
                DonVi = request.DonVi,
                ViTri = request.ViTri,
                TrangThai = request.TrangThai,
                GhiChu = request.GhiChu
            };

            await _thietbiDbContext.NhatKyBomNuocs.AddAsync(newItem);
            await _thietbiDbContext.SaveChangesAsync();

            return newItem.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.NhatKyBomNuocs.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _thietbiDbContext.NhatKyBomNuocs.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<NhatKyBomNuoc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitEntity = _thietbiDbContext.NhatKyBomNuocs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

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

        public async Task<int> DeleteSelect(List<int> ids)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentException("Danh sách id rỗng");

            var entities = await _thietbiDbContext.NhatKyBomNuocs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
            if (!entities.Any())
                throw new KeyNotFoundException("Không có bản ghi nào để xóa");
            _thietbiDbContext.NhatKyBomNuocs.RemoveRange(entities);
            await _thietbiDbContext.SaveChangesAsync();
            return entities.Count;
        }

        public async Task<List<NhatkyBomnuocVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatKyBomNuocs
                        select c;
            return await query.Select(x => new NhatkyBomnuocVm()
            {
                Id = x.Id,
                TongHopBomNuocId = x.TongHopBomNuocId,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu,

            }).ToListAsync();
        }

        public async Task<List<NhatKyBomNuoc>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatKyBomNuocs.Where(x => x.TongHopBomNuocId == id)
                        select t;
            return await Query.Select(x => new NhatKyBomNuoc()
            {
                Id = x.Id,
                TongHopBomNuocId = id,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update(NhatKyBomNuoc request)
        {
            var existingItem = _thietbiDbContext.NhatKyBomNuocs.AsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.TongHopBomNuocId = request.TongHopBomNuocId;
            existingItem.Ngaythang = request.Ngaythang;
            existingItem.DonVi = request.DonVi;
            existingItem.ViTri = request.ViTri;
            existingItem.TrangThai = request.TrangThai;
            existingItem.GhiChu = request.GhiChu;
            _thietbiDbContext.NhatKyBomNuocs.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatKyBomNuoc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitEntity = _thietbiDbContext.NhatKyBomNuocs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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
