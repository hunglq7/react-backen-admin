using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Mayxuc;
using WebApi.Models.ThongsokythuatMayXuc;

namespace WebApi.Services
{
    public interface IMayXucService
    {
        Task<List<MayXucVM>> GetMayXuc();
        Task<ApiResult<int>> UpdateMultipleMayXuc(List<MayXuc> listMayxuc);
        Task<ApiResult<int>> DeleteMutipleMayXuc(List<MayXuc> listMayxuc);
        Task<bool> Add([FromBody] MayXuc Request);
        Task<bool> Update([FromBody] MayXuc Request);
        Task<bool> Delete(int id);
        Task<ApiResult<int>> DeleteMutiple(List<int> ids);
    }
    public class MayXucService : IMayXucService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

      
        public MayXucService(ThietbiDbContext thietbiDbContext)
        {

            _thietbiDbContext = thietbiDbContext;
        }

      

        public async Task<bool> Add([FromBody] MayXuc Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newItems = new MayXuc()
            {             
                MaTaiSan = Request.MaTaiSan,
                TenThietBi = Request.TenThietBi,
                LoaiThietBi = Request.LoaiThietBi,
                TinhTrang = Request.TinhTrang,
                NamSanXuat = Request.NamSanXuat,
                HangSanXuat = Request.HangSanXuat,
                GhiChu = Request.GhiChu,

            };
            await _thietbiDbContext.MayXucs.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.MayXucs.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.MayXucs.Remove(items);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách id rỗng");
            }

            // Lấy các bản ghi tồn tại theo ids
            var existItems = await _thietbiDbContext.MayXucs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (existItems.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào để xóa");
            }

            // Kiểm tra id không tồn tại
            var existIds = existItems.Select(x => x.Id).ToList();
            var invalidIds = ids.Except(existIds).ToList();

            if (invalidIds.Any())
            {
                return new ApiErrorResult<int>(
                    $"Các ID không tồn tại: {string.Join(", ", invalidIds)}"
                );
            }

            _thietbiDbContext.MayXucs.RemoveRange(existItems);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<ApiResult<int>> DeleteMutipleMayXuc(List<MayXuc> listMayxuc)
        {
            var ids = listMayxuc.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }

            var exitMayXuc = _thietbiDbContext.MayXucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newMayxucs = exitMayXuc.Select(x => x.Id).ToList();
            var deff = ids.Except(newMayxucs).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Xóa không hợp lệ");
            }
            _thietbiDbContext.RemoveRange(exitMayXuc);
            var count = await _thietbiDbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<MayXucVM>> GetMayXuc()
        {
            var query = from c in _thietbiDbContext.MayXucs
                        select c;
            return await query.Select(x => new MayXucVM()
            {
                Id = x.Id, 
                MaTaiSan = x.MaTaiSan,
                TenThietBi=x.TenThietBi,
                LoaiThietBi=x.LoaiThietBi,               
                TinhTrang=x.TinhTrang,
               NamSanXuat=x.NamSanXuat,
               HangSanXuat=x.HangSanXuat,
                GhiChu=x.GhiChu,

            }).ToListAsync();
        }

       

        public async Task<bool> Update([FromBody] MayXuc Request)
        {
            var items = await _thietbiDbContext.MayXucs.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.MaTaiSan = Request.MaTaiSan;
            items.TenThietBi = Request.TenThietBi;
               items.LoaiThietBi = Request.LoaiThietBi;
            items.TinhTrang = Request.TinhTrang;
            items.NamSanXuat = Request.NamSanXuat;
            items.HangSanXuat = Request.HangSanXuat;
            items.GhiChu = Request.GhiChu;
          
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> UpdateMultipleMayXuc(List<MayXuc> listMayxuc)
        {
            var ids = listMayxuc.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");

            }
            var exitMayXuc = _thietbiDbContext.MayXucs.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitMayXuc.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật bản ghi không hợp lệ");
            }
            _thietbiDbContext.UpdateRange(listMayxuc);
            var count = await _thietbiDbContext.SaveChangesAsync();
            var UpdateMuliple = _thietbiDbContext.MayXucs.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(count);
        }
    }
}
