
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Nhatkymayxuc;



namespace WebApi.Services
{
    public interface INhatkymayxucService
    {
        Task<List<NhatkymayxucVm>> GetByTonghopAsync(int tonghopmayxucId);

        Task<int> CreateAsync(NhatkyMayxucCreateDto dto);

        Task<bool> UpdateAsync(NhatkyMayxucUpdateDto dto);

        Task<bool> DeleteAsync(int id);

        Task<int> DeleteMultipleAsync(List<int> ids);
    }
    public class NhatkymayxucService : INhatkymayxucService
    {
        private readonly ThietbiDbContext _context;

        public NhatkymayxucService(ThietbiDbContext context)
        {
            _context = context;
        }

        // ================= GET =================
        public async Task<List<NhatkymayxucVm>> GetByTonghopAsync(int tonghopmayxucId)
        {
            if (tonghopmayxucId <= 0)
                throw new ArgumentException("TonghopmayxucId không hợp lệ");

            return await _context.NhatkyMayxucs
                .Where(x => x.TonghopmayxucId == tonghopmayxucId)
                .OrderByDescending(x => x.Ngaythang)
                .Select(x => new NhatkymayxucVm
                {
                    Id = x.Id,
                    TonghopmayxucId = x.TonghopmayxucId,
                    Ngaythang = x.Ngaythang,
                    DonVi = x.DonVi,
                    ViTri = x.ViTri,
                    TrangThai = x.TrangThai,
                    GhiChu = x.GhiChu
                })
                .ToListAsync();
        }

        // ================= CREATE =================
        public async Task<int> CreateAsync(NhatkyMayxucCreateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.TonghopmayxucId <= 0)
                throw new ArgumentException("TonghopmayxucId không hợp lệ");

            var entity = new NhatkyMayxuc
            {
                TonghopmayxucId = dto.TonghopmayxucId,
                Ngaythang = dto.Ngaythang,
                DonVi = dto.DonVi,
                ViTri = dto.ViTri,
                TrangThai = dto.TrangThai,
                GhiChu = dto.GhiChu
            };

            _context.NhatkyMayxucs.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        // ================= UPDATE =================
        public async Task<bool> UpdateAsync(NhatkyMayxucUpdateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = await _context.NhatkyMayxucs
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null)
                throw new KeyNotFoundException("Không tìm thấy bản ghi");

            entity.TonghopmayxucId = dto.TonghopmayxucId;
            entity.Ngaythang = dto.Ngaythang;
            entity.DonVi = dto.DonVi;
            entity.ViTri = dto.ViTri;
            entity.TrangThai = dto.TrangThai;
            entity.GhiChu = dto.GhiChu;

            await _context.SaveChangesAsync();
            return true;
        }

        // ================= DELETE ONE =================
        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id không hợp lệ");

            var entity = await _context.NhatkyMayxucs.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Không tìm thấy bản ghi");

            _context.NhatkyMayxucs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // ================= DELETE MULTIPLE =================
        public async Task<int> DeleteMultipleAsync(List<int> ids)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentException("Danh sách id rỗng");

            var entities = await _context.NhatkyMayxucs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (!entities.Any())
                throw new KeyNotFoundException("Không có bản ghi nào để xóa");

            _context.NhatkyMayxucs.RemoveRange(entities);
            await _context.SaveChangesAsync();

            return entities.Count;
        }
    }
}
