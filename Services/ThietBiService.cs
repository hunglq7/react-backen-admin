using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.thietbi;

namespace WebApi.Services
{
    public interface IThietBiService
    {
        Task<List<ThietBiDto>> GetAll();
        Task<bool> CreateThietBi(ThietBiCreateResponse Response);
        Task<bool> UpdateThietBi(ThietBiUpdateResponse Response);
        Task<bool> DeleteThietBi(int id);
        Task<List<int>> DeleteMultiple(List<int> ids);
        Task<ThietBiDto> GetThietBiById(int id);
        Task<PagedResult<ThietBiDto>> SearchThietBi(ThietBiSearch thietBiSearch);

    }
    public class ThietBiService : IThietBiService
    {
        public readonly ThietbiDbContext _context;
        public ThietBiService(ThietbiDbContext context)
        {
            _context = context;
        }

        public Task<bool> CreateThietBi(ThietBiCreateResponse Response)
        {
            if (string.IsNullOrEmpty(Response.MaThietBi) || string.IsNullOrEmpty(Response.TenThietBi) || string.IsNullOrEmpty(Response.Loai))
            {
                return Task.FromResult(false);
            }
            // Kiểm tra mã thiết bị đã tồn tại chưa
            var existingThietBi = _context.ThietBis.FirstOrDefault(tb => tb.MaThietBi == Response.MaThietBi);
            if (existingThietBi != null)
            {
                return Task.FromResult(false); // Mã thiết bị đã tồn tại
            }

            var thietBi = new ThietBi
            {
                MaThietBi = Response.MaThietBi,
                TenThietBi = Response.TenThietBi,
                Loai = Response.Loai,
                HangSanXuat = Response.HangSanXuat,
                Model = Response.Model,
                DonViTinh = Response.DonViTinh,
                ThoiGianBaoHanh = Response.ThoiGianBaoHanh
            };

            _context.ThietBis.Add(thietBi);
            _context.SaveChanges();

            return Task.FromResult(true);
        }

        public Task<List<int>> DeleteMultiple(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return Task.FromResult(new List<int>()); // Trả về danh sách rỗng nếu không có ID nào được cung cấp
            }
            var thietBisToDelete = _context.ThietBis.Where(tb => ids.Contains(tb.Id)).ToList();
            if (thietBisToDelete.Count == 0)
            {
                return Task.FromResult(new List<int>()); // Trả về danh sách rỗng nếu không có thiết bị nào tồn tại với các ID đã cung cấp
            }
            _context.ThietBis.RemoveRange(thietBisToDelete);
            _context.SaveChanges();
            return Task.FromResult(ids);

        }

        public Task<bool> DeleteThietBi(int id)
        {
            if (id <= 0)
            {
                return Task.FromResult(false);
            }
            var thietBi = _context.ThietBis.FirstOrDefault(tb => tb.Id == id);
            if (thietBi == null)
            {
                return Task.FromResult(false); // Thiết bị không tồn tại
            }
            _context.ThietBis.Remove(thietBi);
            _context.SaveChanges();
            return Task.FromResult(true);

        }



        public Task<List<ThietBiDto>> GetAll()
        {
            var query = from tb in _context.ThietBis
                        select new ThietBiDto()
                        {
                            MaThietBi = tb.MaThietBi,
                            TenThietBi = tb.TenThietBi,
                            Loai = tb.Loai,
                            HangSanXuat = tb.HangSanXuat,
                            Model = tb.Model,
                            DonViTinh = tb.DonViTinh,
                            ThoiGianBaoHanh = tb.ThoiGianBaoHanh
                        };
            return Task.FromResult(query.ToList());
        }


        public Task<ThietBiDto> GetThietBiById(int id)
        {
            if (id <= 0)
            {
                return Task.FromResult<ThietBiDto>(null);
            }
            var thietBi = _context.ThietBis.FirstOrDefault(tb => tb.Id == id);
            if (thietBi == null)
            {
                return Task.FromResult<ThietBiDto>(null); // Thiết bị không tồn tại
            }
            var thietBiDto = new ThietBiDto
            {
                Id = thietBi.Id,
                MaThietBi = thietBi.MaThietBi,
                TenThietBi = thietBi.TenThietBi,
                Loai = thietBi.Loai,
                HangSanXuat = thietBi.HangSanXuat,
                Model = thietBi.Model,
                DonViTinh = thietBi.DonViTinh,
                ThoiGianBaoHanh = thietBi.ThoiGianBaoHanh
            };
            return Task.FromResult(thietBiDto);
        }

        public Task<PagedResult<ThietBiDto>> SearchThietBi(ThietBiSearch thietBiSearch)
        {
            var query = from a in _context.ThietBis.AsQueryable()
                        select a;

            if (!string.IsNullOrEmpty(thietBiSearch.TenThietBi))
            {
                query = query.Where(tb => tb.TenThietBi.Contains(thietBiSearch.TenThietBi));
            }
            if (!string.IsNullOrEmpty(thietBiSearch.Loai))
            {
                query = query.Where(tb => tb.Loai.Contains(thietBiSearch.Loai));
            }
            if (!string.IsNullOrEmpty(thietBiSearch.HangSanXuat))
            {
                query = query.Where(tb => tb.HangSanXuat.Contains(thietBiSearch.HangSanXuat));
            }

            var totalItems = query.Count();
            var items = query.Skip((thietBiSearch.PageIndex - 1) * thietBiSearch.PageSize)
                             .Take(thietBiSearch.PageSize)
                             .Select(tb => new ThietBiDto
                             {
                                 Id = tb.Id,
                                 MaThietBi = tb.MaThietBi,
                                 TenThietBi = tb.TenThietBi,
                                 Loai = tb.Loai,
                                 HangSanXuat = tb.HangSanXuat,
                                 Model = tb.Model,
                                 DonViTinh = tb.DonViTinh,
                                 ThoiGianBaoHanh = tb.ThoiGianBaoHanh
                             })
                             .ToList();

            var pagedResult = new PagedResult<ThietBiDto>
            {
                Items = items,
                TotalRecords = totalItems,
                PageIndex = thietBiSearch.PageIndex,
                PageSize = thietBiSearch.PageSize
            };

            return Task.FromResult(pagedResult);

        }

        public Task<bool> UpdateThietBi(ThietBiUpdateResponse Response)
        {
            if (string.IsNullOrEmpty(Response.MaThietBi) || string.IsNullOrEmpty(Response.TenThietBi) || string.IsNullOrEmpty(Response.Loai))
            {
                return Task.FromResult(false);
            }
            // Implement the update logic here
            var thietBi = _context.ThietBis.FirstOrDefault(tb => tb.Id == Response.Id);
            if (thietBi == null)
            {
                return Task.FromResult(false); // Thiết bị không tồn tại
            }
            thietBi.MaThietBi = Response.MaThietBi;
            thietBi.TenThietBi = Response.TenThietBi;
            thietBi.Loai = Response.Loai;
            thietBi.HangSanXuat = Response.HangSanXuat;
            thietBi.Model = Response.Model;
            thietBi.DonViTinh = Response.DonViTinh;
            thietBi.ThoiGianBaoHanh = Response.ThoiGianBaoHanh;
            _context.ThietBis.Update(thietBi);
            _context.SaveChanges();
            return Task.FromResult(true);

        }
    }
}