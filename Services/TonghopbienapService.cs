using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.BienAp;
using WebApi.Models.Common;
using WebApi.Models.TonghopRole;

namespace WebApi.Services
{
    public interface ITonghopbienapService
    {
        Task<TonghopBienap> Add(TonghopBienap Request);
        Task<List<TonghopbienapVm>> GetAll();
        Task<List<TonghopbienapVm>> getDatailById(int id);
        Task<TonghopBienap> Update([FromBody] TonghopBienap Request);
        Task<bool> Delete(int id);
        Task<ApiResult<int>> DeleteSelect(List<int> ids);
        Task<ApiResult<int>> totalTonghopbienap();
    }
    public class TonghopbienapService : ITonghopbienapService
    {
        private readonly ThietbiDbContext _thietbiDb;
        public TonghopbienapService(ThietbiDbContext thietbiDb)
        {
            _thietbiDb = thietbiDb;
        }
        public async Task<TonghopBienap> Add(TonghopBienap Request)
        {
            if (Request == null)
            {
                throw new ArgumentNullException(nameof(Request));
            }
            // validate referenced entities exist
            var bienapExists = await _thietbiDb.DanhmucBienaps.AnyAsync(x => x.Id == Request.BienapId);
            var phongbanExists = await _thietbiDb.PhongBans.AnyAsync(x => x.Id == Request.PhongbanId);
            if (!bienapExists || !phongbanExists)
            {
                throw new Exception("BiênAp hoặc PhòngBan không tồn tại");
            }

            var items = new TonghopBienap()
            {
                BienapId = Request.BienapId,
                PhongbanId = Request.PhongbanId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayLap = Request.NgayLap,
                DuPhong = Request.DuPhong,
                GhiChu = Request.GhiChu
            };

            await _thietbiDb.TonghopBienaps.AddAsync(items);
            await _thietbiDb.SaveChangesAsync();
            return items;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDb.TonghopBienaps.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDb.TonghopBienaps.Remove(query);
            await _thietbiDb.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteSelect(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDb.TonghopBienaps
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDb.TonghopBienaps.RemoveRange(items);
            var count = await _thietbiDb.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }


        public async Task<List<TonghopbienapVm>> GetAll()
        {
            try
            {
                // Sử dụng Include để nạp dữ liệu từ các bảng liên quan
                var result = await _thietbiDb.TonghopBienaps
                    .Include(x => x.DanhmucBienap)
                    .Include(x => x.PhongBan)
                    .AsNoTracking() // Tối ưu hiệu suất cho truy vấn chỉ đọc
                    .Select(x => new TonghopbienapVm
                    {
                        Id = x.Id,
                        BienapId = x.BienapId,
                        // Kiểm tra null cho bảng DanhmucBienap để tránh lỗi 500
                        TenThietBi = x.DanhmucBienap != null ? x.DanhmucBienap.TenThietBi : "N/A",
                        PhongbanId = x.PhongbanId,
                        // Kiểm tra null cho bảng PhongBan
                        TenPhongBan = x.PhongBan != null ? x.PhongBan.TenPhong : "N/A",
                        ViTriLapDat = x.ViTriLapDat ?? "", // Xử lý null cho chuỗi
                        NgayLap = EF.Property<DateTime?>(x, "NgayLap"),
                        DuPhong = x.DuPhong,
                        GhiChu = x.GhiChu ?? ""
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                // Ném lỗi chi tiết để dễ dàng kiểm tra trong Log
                throw new Exception($"Lỗi thực thi GetAll: {ex.Message}");
            }
        }

        public async Task<List<TonghopbienapVm>> getDatailById(int id)
        {
            var result = await _thietbiDb.TonghopBienaps
                .Where(x => x.Id == id)
                .Include(x => x.DanhmucBienap)
                .Include(x => x.PhongBan)
                .AsNoTracking()
                .Select(x => new TonghopbienapVm
                {
                    Id = x.Id,
                    TenThietBi = x.DanhmucBienap != null ? x.DanhmucBienap.TenThietBi : "Không xác định",
                    BienapId = x.BienapId,
                    TenPhongBan = x.PhongBan != null ? x.PhongBan.TenPhong : "Không xác định",
                    PhongbanId = x.PhongbanId,
                    ViTriLapDat = x.ViTriLapDat ?? "",
                    NgayLap = EF.Property<DateTime?>(x, "NgayLap"),
                    DuPhong = x.DuPhong,
                    GhiChu = x.GhiChu ?? ""
                }).ToListAsync();
            return result;
        }

        public async Task<TonghopBienap> Update([FromBody] TonghopBienap Request)
        {
            if (Request == null)
            {
                throw new ArgumentNullException(nameof(Request));
            }
            var entity = await _thietbiDb.TonghopBienaps.FindAsync(Request.Id);
            if (entity == null)
            {
                throw new Exception($"Không tìm thấy bản ghi với ID {Request.Id}");
            }
            // validate referenced entities exist
            var bienapExists = await _thietbiDb.DanhmucBienaps.AnyAsync(x => x.Id == Request.BienapId);
            var phongbanExists = await _thietbiDb.PhongBans.AnyAsync(x => x.Id == Request.PhongbanId);
            if (!bienapExists || !phongbanExists)
            {
                throw new Exception("BiênAp hoặc PhòngBan không tồn tại");
            }

            entity.BienapId = Request.BienapId;
            entity.PhongbanId = Request.PhongbanId;
            entity.ViTriLapDat = Request.ViTriLapDat;
            entity.NgayLap = Request.NgayLap;
            entity.DuPhong = Request.DuPhong;
            entity.GhiChu = Request.GhiChu;
            _thietbiDb.Update(entity);
            await _thietbiDb.SaveChangesAsync();
            return entity;
        }

        public async Task<ApiResult<int>> totalTonghopbienap()
        {
            try
            {
                var count = await _thietbiDb.TonghopBienaps.CountAsync();
                return new ApiSuccessResult<int>(count);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>($"Lỗi khi đếm tổng số bản ghi: {ex.Message}");
            }
        }
    }
}
