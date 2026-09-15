using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.GiaCot;

namespace WebApi.Services
{
    public interface ICapnhatgiacotService
    {
        Task<List<CapnhatgiacotVm>> GetAll();
        Task<ApiResult<int>> DeleteMutiple(List<int> ids);
        Task<bool> Add(CapNhatGiaCot request);
        Task<bool> Update(CapNhatGiaCot request);
        Task<bool> Delete(int id);
        Task<PagedResult<CapnhatgiacotVm>> SearchAsync(SearchTongHopRequest request);
    }

    public class CapnhatgiacotService : ICapnhatgiacotService
    {
        private readonly ThietbiDbContext _thietbiDbContext;

        public CapnhatgiacotService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }


        public async Task<bool> Add(CapNhatGiaCot request)
        {
            if (request == null) return false;
            var newItems = new CapNhatGiaCot()
            {
                DonViId = request.DonViId,
                LoaiThietBiId = request.LoaiThietBiId,
                ViTriSuDung = request.ViTriSuDung,
                SoLuongDangQuanLy = request.SoLuongDangQuanLy,
                NgayCapNhat = request.NgayCapNhat
            };
            await _thietbiDbContext.CapNhatGiaCots.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _thietbiDbContext.CapNhatGiaCots.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _thietbiDbContext.CapNhatGiaCots.Remove(item);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutiple(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDbContext.CapNhatGiaCots
                .Where(x => ids.Contains(x.CapNhatId))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDbContext.CapNhatGiaCots.RemoveRange(items);
            var count = await _thietbiDbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<CapnhatgiacotVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.CapNhatGiaCots.Include(x => x.PhongBan).Include(x => x.DanhmucGiaCot)
                        select c;
            return await query.Select(x => new CapnhatgiacotVm()
            {
                CapNhatId = x.CapNhatId,
                TenDonVi = x.PhongBan!.TenPhong,
                DonViId = x.DonViId,
                TenLoaiThietBi = x.DanhmucGiaCot!.TenLoai,
                LoaiThietBiId = x.LoaiThietBiId,
                ViTriSuDung = x.ViTriSuDung,
                SoLuongDangQuanLy = x.SoLuongDangQuanLy,
                NgayCapNhat = x.NgayCapNhat
            }).ToListAsync();
        }
        public async Task<PagedResult<CapnhatgiacotVm>> SearchAsync(SearchTongHopRequest request)
        {
            var query = from t in _thietbiDbContext.CapNhatGiaCots.Include(x => x.DanhmucGiaCot).Include(x => x.PhongBan)
                        select t;

            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                query = query.Where(x =>
                    x.DanhmucGiaCot!.TenLoai!.Contains(request.Keyword) ||
                    x.PhongBan!.TenPhong!.Contains(request.Keyword)
                    );

            }

            // 📅 Từ ngày
            if (request.TuNgay.HasValue)
            {
                query = query.Where(x => x.NgayCapNhat >= request.TuNgay.Value.Date);
            }

            // 📅 Đến ngày (<= 23:59:59)
            if (request.DenNgay.HasValue)
            {
                var denNgay = request.DenNgay.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.NgayCapNhat <= denNgay);
            }
            var totalRecords = await query.CountAsync();
            var items = await query
        .OrderByDescending(x => x.NgayCapNhat)
        .Skip((request.PageIndex - 1) * request.PageSize)
        .Take(request.PageSize)
         .Select(x => new CapnhatgiacotVm()

         {
             CapNhatId = x.CapNhatId,
             TenDonVi = x.PhongBan!.TenPhong,
             TenLoaiThietBi = x.DanhmucGiaCot!.TenLoai,
             ViTriSuDung = x.ViTriSuDung,
             SoLuongDangQuanLy = x.SoLuongDangQuanLy,
             NgayCapNhat = x.NgayCapNhat

         })
        .ToListAsync();
            return new PagedResult<CapnhatgiacotVm>
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRecords,
                Items = items
            };
        }

        public async Task<bool> Update(CapNhatGiaCot request)
        {
            var existingItem = _thietbiDbContext.CapNhatGiaCots.AsNoTracking().FirstOrDefault(x => x.CapNhatId == request.CapNhatId);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.DonViId = request.DonViId;
            existingItem.LoaiThietBiId = request.LoaiThietBiId;
            existingItem.ViTriSuDung = request.ViTriSuDung;
            existingItem.SoLuongDangQuanLy = request.SoLuongDangQuanLy;
            existingItem.NgayCapNhat = request.NgayCapNhat;
            _thietbiDbContext.CapNhatGiaCots.Update(existingItem);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}