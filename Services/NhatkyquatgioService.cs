using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Nhatkymayxuc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApi.Services
{
    public interface INhatkyquatgioService
    {
        Task<List<NhatKyQuatGio>> GetAll();
        Task<List<NhatKyQuatGio>> getDatailById(int id);
        Task<List<NhatKyQuatGio>> GetByTonghopquatgioId(int tonghopquatgioId);
        Task<ApiResult<int>> UpdateMultiple(List<NhatKyQuatGio> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatKyQuatGio> request);
        Task<bool> Add([FromBody] NhatKyQuatGio Request);
        Task<bool> Update(NhatKyQuatGio Request);
        Task<bool> Delete(int id);
        Task<int> DeleteSelect(List<int> ids);
    }
    public class NhatkyquatgioService : INhatkyquatgioService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkyquatgioService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public async Task<bool> Add([FromBody] NhatKyQuatGio Request)
        {
            if (Request == null)
            {
                return false;
            }
            var newItems = new NhatKyQuatGio()
            {

                TonghopquatgioId = Request.TonghopquatgioId,
                Ngaythang = Request.Ngaythang,
                DonVi = Request.DonVi,
                ViTri = Request.ViTri,
                TrangThai = Request.TrangThai,
                GhiChu = Request.GhiChu,

            };
            await _thietbiDbContext.NhatKyQuatGios.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id không hợp lệ");
            var entity = await _thietbiDbContext.NhatKyQuatGios.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Không tìm thấy bản ghi");
            _thietbiDbContext.NhatKyQuatGios.Remove(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<NhatKyQuatGio> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitEntity = _thietbiDbContext.NhatKyQuatGios.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

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

            var entities = await _thietbiDbContext.NhatKyQuatGios
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (!entities.Any())
                throw new KeyNotFoundException("Không có bản ghi nào để xóa");

            _thietbiDbContext.NhatKyQuatGios.RemoveRange(entities);
            await _thietbiDbContext.SaveChangesAsync();

            return entities.Count;
        }

        public async Task<List<NhatKyQuatGio>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatKyQuatGios
                        select c;
            return await query.Select(x => new NhatKyQuatGio()
            {
                Id = x.Id,
                TonghopquatgioId = x.TonghopquatgioId,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu,

            }).ToListAsync();
        }

        public async Task<List<NhatKyQuatGio>> GetByTonghopquatgioId(int tonghopquatgioId)
        {
            if (tonghopquatgioId <= 0)
                throw new ArgumentException("tonghopquatgioId không hợp lệ");

            return await _thietbiDbContext.NhatKyQuatGios
                .Where(x => x.TonghopquatgioId == tonghopquatgioId)
                .OrderByDescending(x => x.Ngaythang)
                .Select(x => new NhatKyQuatGio
                {
                    Id = x.Id,
                    TonghopquatgioId = x.TonghopquatgioId,
                    Ngaythang = x.Ngaythang,
                    DonVi = x.DonVi,
                    ViTri = x.ViTri,
                    TrangThai = x.TrangThai,
                    GhiChu = x.GhiChu
                })
                .ToListAsync();
        }

        public async Task<List<NhatKyQuatGio>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatKyQuatGios.Where(x => x.TonghopquatgioId == id)
                        select t;
            return await Query.Select(x => new NhatKyQuatGio()
            {
                Id = x.Id,
                TonghopquatgioId = id,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update(NhatKyQuatGio Request)
        {
            if (Request == null)
                throw new ArgumentNullException(nameof(Request));

            var entity = await _thietbiDbContext.NhatKyQuatGios
                .FirstOrDefaultAsync(x => x.Id == Request.Id);

            if (entity == null)
                throw new KeyNotFoundException("Không tìm thấy bản ghi");

            entity.TonghopquatgioId = Request.TonghopquatgioId;
            entity.Ngaythang = Request.Ngaythang;
            entity.DonVi = Request.DonVi;
            entity.ViTri = Request.ViTri;
            entity.TrangThai = Request.TrangThai;
            entity.GhiChu = Request.GhiChu;
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatKyQuatGio> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitEntity = _thietbiDbContext.NhatKyQuatGios.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
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
