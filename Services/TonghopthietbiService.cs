using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Tonghopthietbi;

namespace WebApi.Services
{
    public interface ITonghopthietbiService
    {
        Task<List<TonghopthietbiVm>> GetTonghopthietbi();
        Task<PagedResult<TonghopthietbiVm>> GetAllPaging(TonghopthietbiPagingRequest request);
        Task<bool> AddTonghopthietbi([FromBody] ThietbiCreateRequest tongHopThietBi);
        Task<TongHopThietBi> GetById(int id);
        Task<bool> UpdateTonghopthietbi([FromBody] ThietbiUpdateRequest tongHopThietBi);
        Task<bool> DeleteTonghopthietbi(int id);

    }
    public class TonghopthietbiService : ITonghopthietbiService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopthietbiService(ThietbiDbContext thetbiDbContext)
        {
            _thietbiDbContext = thetbiDbContext;
        }

        public async Task<bool> AddTonghopthietbi([FromBody] ThietbiCreateRequest tongHopThietBi)
        {
            if (tongHopThietBi == null)
            {
                return false;
            }

            var newthietbi = new TongHopThietBi()
            {

                MaThietBi = tongHopThietBi.maThietBi,
                TrangThai = tongHopThietBi.trangThai,
                HinhAnh = tongHopThietBi.hinhAnh,
                TenThietBi = tongHopThietBi.tenThietBi,
                DonViTinhId = tongHopThietBi.donViTinhId,
                SoLuong = tongHopThietBi.soLuong,
                LoaiThietBiId = tongHopThietBi.loaiThietBiId,
                NgaySuDung = tongHopThietBi.ngaySuDung,
                TinhTrangThietBi = tongHopThietBi.tinhTrangThietBi,
                PhongBanId = tongHopThietBi.phongBanId,
                NhanVienId = tongHopThietBi.nhanVienId,
                GhiChu = tongHopThietBi.ghiChu
            };
            await _thietbiDbContext.TongHopThietBis.AddAsync(newthietbi);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTonghopthietbi(int id)
        {
            var thietbi = await _thietbiDbContext.TongHopThietBis.FindAsync(id);
            if (thietbi == null)
            {
                return false;
            }
            _thietbiDbContext.TongHopThietBis.Remove(thietbi);
            _thietbiDbContext.SaveChanges();
            return true;
        }



        public async Task<TongHopThietBi> GetById(int Id)
        {
            var thietbi = await _thietbiDbContext.TongHopThietBis.FindAsync(Id);
            if (thietbi == null)
            {
                thietbi = new TongHopThietBi()
                {
                    Id = 0,
                    MaThietBi = "",
                    NgaySuDung = DateTime.Now,
                    SoLuong = 1,
                    TrangThai = true
                }
                    ;
            }

            return thietbi;
        }

        public async Task<List<TonghopthietbiVm>> GetTonghopthietbi()
        {
            var query = from t in _thietbiDbContext.TongHopThietBis.Include(x => x.PhongBan).Include(x => x.NhanVien).Include(x => x.DonViTinh).Include(x => x.LoaiThietBi)
                       .Where(x => x.TrangThai == true)
                        select t;
            var maytinh = from m in _thietbiDbContext.TongHopThietBis.Where(x => x.LoaiThietBiId == 2)
                          select m;
            var mayin = from i in _thietbiDbContext.TongHopThietBis.Where(x => x.LoaiThietBiId == 1)
                        select i;
            var TongTb = maytinh.Sum(x => x.SoLuong);
            var TongMi = mayin.Sum(x => x.SoLuong);
            return await query.Select(x => new TonghopthietbiVm()
            {
                Id = x.Id,
                MaThietBi = x.MaThietBi,
                HinhAnh = x.HinhAnh,
                TenThietBi = x.TenThietBi,
                TenDonViTinh = x.DonViTinh!.TenDonViTinh,
                TenLoai = x.LoaiThietBi!.TenLoai,
                SoLuong = x.SoLuong,
                NgaySuDung = x.NgaySuDung,
                TenPhong = x.PhongBan!.TenPhong,
                TenNhanvien = x.NhanVien!.TenNhanVien,
                TongMT = TongTb,
                TongMI = TongMi
            }).ToListAsync();
        }

        public async Task<PagedResult<TonghopthietbiVm>> GetAllPaging(TonghopthietbiPagingRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopThietBis
                        .Include(x => x.PhongBan)
                        .Include(x => x.NhanVien)
                        .Include(x => x.DonViTinh)
                        .Include(x => x.LoaiThietBi)
                        .Where(x => x.TrangThai == true)
                        select t;

            if (request.nhanVienId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.NhanVienId == request.nhanVienId && x.PhongBanId == request.donviId);
            }
            else if (request.nhanVienId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.NhanVienId == request.nhanVienId);
            }
            else if ((request.nhanVienId == 0 || request.nhanVienId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.PhongBanId == request.donviId);
            }

            var totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopthietbiVm()
                {
                    Id = x.Id,
                    MaThietBi = x.MaThietBi,
                    HinhAnh = x.HinhAnh,
                    TenThietBi = x.TenThietBi,
                    TenDonViTinh = x.DonViTinh!.TenDonViTinh,
                    TenLoai = x.LoaiThietBi!.TenLoai,
                    SoLuong = x.SoLuong,
                    NgaySuDung = x.NgaySuDung,
                    TenPhong = x.PhongBan!.TenPhong,
                    TenNhanvien = x.NhanVien!.TenNhanVien
                }).ToListAsync();

            var pagedResult = new PagedResult<TonghopthietbiVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return pagedResult;
        }

        public async Task<bool> UpdateTonghopthietbi([FromBody] ThietbiUpdateRequest tongHopThietBi)
        {
            var thietbi = await _thietbiDbContext.TongHopThietBis.FindAsync(tongHopThietBi.id);
            if (thietbi == null)
            {
                return false;
            }
            thietbi.MaThietBi = tongHopThietBi.maThietBi;
            thietbi.TenThietBi = tongHopThietBi.tenThietBi;
            thietbi.HinhAnh = tongHopThietBi.hinhAnh;
            thietbi.DonViTinhId = tongHopThietBi.donViTinhId;
            thietbi.LoaiThietBiId = tongHopThietBi.loaiThietBiId;
            thietbi.SoLuong = tongHopThietBi.soLuong;
            thietbi.NgaySuDung = tongHopThietBi.ngaySuDung;
            thietbi.PhongBanId = tongHopThietBi.phongBanId;
            thietbi.NhanVienId = tongHopThietBi.nhanVienId;
            thietbi.TinhTrangThietBi = tongHopThietBi.tinhTrangThietBi;
            thietbi.GhiChu = tongHopThietBi.ghiChu;
            _thietbiDbContext.Update(thietbi);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
