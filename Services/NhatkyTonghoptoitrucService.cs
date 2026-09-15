using Microsoft.EntityFrameworkCore;
using WebApi.Models.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.NhatkyTonghoptoitruc;
using WebApi.Models.Nhatkymayxuc;



namespace WebApi.Services
{
    public interface INhatkyTonghoptoitrucService
    {
        Task<List<NhatkyTonghoptoitrucVm>> GetAll();
        Task<List<NhatkyTonghoptoitruc>> getDetailById(int id);
        Task<ApiResult<int>> UpdateMultiple(List<NhatkyTonghoptoitruc> request);
        Task<ApiResult<int>> DeleteMutiple(List<NhatkyTonghoptoitruc> request);

        Task<List<NhatkyTonghoptoitrucVm>> GetByTonghopAsync(int tonghoptoidienId);

        Task<int> CreateAsync(NhatkyToitrucCreateDto dto);

        Task<bool> UpdateAsync(NhatkyToitrucUpdateDto dto);

        Task<bool> DeleteAsync(int id);

        Task<int> DeleteMultipleAsync(List<int> ids);
    }
    public class NhatkyTonghoptoitrucService:INhatkyTonghoptoitrucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public NhatkyTonghoptoitrucService( ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext=thietbiDbContext;
            
        }

        public async Task<int> CreateAsync(NhatkyToitrucCreateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.TonghoptoitrucId <= 0)
                throw new ArgumentException("TonghoptoitrucId không hợp lệ");

            var entity = new NhatkyTonghoptoitruc
            {
                TonghoptoitrucId = dto.TonghoptoitrucId,
                Ngaythang = dto.Ngaythang,
                DonVi = dto.DonVi,
                ViTri = dto.ViTri,
                TrangThai = dto.TrangThai,
                GhiChu = dto.GhiChu
            };

            _thietbiDbContext.NhatkyTonghoptoitrucs.Add(entity);
            await _thietbiDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id không hợp lệ");

            var entity = await _thietbiDbContext.NhatkyTonghoptoitrucs.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Không tìm thấy bản ghi");

          _thietbiDbContext.NhatkyTonghoptoitrucs.Remove(entity);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> DeleteMultipleAsync(List<int> ids)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentException("Danh sách id rỗng");

            var entities = await _thietbiDbContext.NhatkyTonghoptoitrucs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (!entities.Any())
                throw new KeyNotFoundException("Không có bản ghi nào để xóa");

            _thietbiDbContext.NhatkyTonghoptoitrucs.RemoveRange(entities);
            await _thietbiDbContext.SaveChangesAsync();

            return entities.Count;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<NhatkyTonghoptoitruc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }

            var exitNhatky = _thietbiDbContext.NhatkyTonghoptoitrucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newNhatky = exitNhatky.Select(x => x.Id).ToList();
            var deff = ids.Except(newNhatky).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa dữ liệu không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitNhatky);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<NhatkyTonghoptoitrucVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.NhatkyTonghoptoitrucs
                        select c;
            return await query.Select(x => new NhatkyTonghoptoitrucVm()
            {
                Id = x.Id,
                TonghoptoitrucId = x.TonghoptoitrucId,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu,

            }).ToListAsync();
        }

        public async Task<List<NhatkyTonghoptoitrucVm>> GetByTonghopAsync(int tonghoptoidienId)
        {
            if (tonghoptoidienId <= 0)
                throw new ArgumentException("TonghopmayxucId không hợp lệ");

            return await _thietbiDbContext.NhatkyTonghoptoitrucs
                .Where(x => x.TonghoptoitrucId == tonghoptoidienId)
                .OrderByDescending(x => x.Ngaythang)
                .Select(x => new NhatkyTonghoptoitrucVm
                {
                    Id = x.Id,
                    TonghoptoitrucId = x.TonghoptoitrucId,
                    Ngaythang = x.Ngaythang,
                    DonVi = x.DonVi,
                    ViTri = x.ViTri,
                    TrangThai = x.TrangThai,
                    GhiChu = x.GhiChu
                })
                .ToListAsync();
        }

        public async Task<List<NhatkyTonghoptoitruc>> getDetailById(int id)
        {
            var Query = from t in _thietbiDbContext.NhatkyTonghoptoitrucs.Where(x => x.TonghoptoitrucId == id)
                        select t;

            return await Query.Select(x => new NhatkyTonghoptoitruc()
            {
                Id = x.Id,
                TonghoptoitrucId = id,
                Ngaythang = x.Ngaythang,
                DonVi = x.DonVi,
                ViTri = x.ViTri,
                TrangThai = x.TrangThai,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> UpdateAsync(NhatkyToitrucUpdateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = await _thietbiDbContext.NhatkyTonghoptoitrucs
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                throw new KeyNotFoundException("Không tìm thấy bản ghi");

            entity.TonghoptoitrucId = dto.TonghoptoitrucId;
            entity.Ngaythang = dto.Ngaythang;
            entity.DonVi = dto.DonVi;
            entity.ViTri = dto.ViTri;
            entity.TrangThai = dto.TrangThai;
            entity.GhiChu = dto.GhiChu;

            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultiple(List<NhatkyTonghoptoitruc> request)
        {
            var ids = request.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không timg thấy bản ghi nào");

            }
            var exitNhatky = _thietbiDbContext.NhatkyTonghoptoitrucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitNhatky.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật dữ liệu không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(request);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.Cameras.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(count);
        }
    }
}
