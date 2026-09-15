using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.TonghopBomnuc;
using WebApi.Models.Tonghopquatgio;


namespace WebApi.Services
{
    public interface ITonghopbomnuocService
    {

        Task<bool> Add([FromBody] TonghopbomnuocCreateRequest Request);
        Task<TongHopBomNuoc> GetById(int id);
        Task<int> Sum();
        Task<List<TongHopBomNuoc>> getDatailById(int id);
        Task<bool> Update([FromBody] TonghopbomnuocUpdateRequest Request);
        Task<bool> Delete(int id);
        Task<List<int>> DeleteMutiple(List<int> ids);
        Task<List<TonghopBomnuocVm>> GetAll();
        Task<PagedResult<TonghopBomnuocVm>> GetAllPaging(TonghopbomnuocPagingRequest request);
        Task<PagedResult<TonghopBomnuocVm>> SearchAsync(SearchTongHopRequest request);
    }
    public class TonghopbomnuocService : ITonghopbomnuocService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopbomnuocService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] TonghopbomnuocCreateRequest Request)
        {
            try
            {
                if (Request == null)
                {
                    return false;
                }

                var items = new TongHopBomNuoc()
                {
                    MaQuanLy = Request.MaQuanLy ?? string.Empty,
                    BomNuocId = Request.BomNuocId,
                    DonViId = Request.DonViId,
                    ViTriLapDat = Request.ViTriLapDat ?? string.Empty,
                    NgayLap = Request.NgayLap != default(DateTime) ? Request.NgayLap : DateTime.Now,
                    SoLuong = Request.SoLuong > 0 ? Request.SoLuong : 1,
                    TinhTrangThietBi = Request.TinhTrangThietBi ?? string.Empty,
                    DuPhong = Request.DuPhong,
                    GhiChu = Request.GhiChu ?? string.Empty,
                };
                await _thietbiDbContext.TongHopBomNuocs.AddAsync(items);
                await _thietbiDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log the exception here if you have logging configured
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDbContext.TongHopBomNuocs.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDbContext.TongHopBomNuocs.Remove(query);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<int>> DeleteMutiple(List<int> ids)
        {
            var items = await _thietbiDbContext.TongHopBomNuocs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (!items.Any())
                return new List<int>();

            _thietbiDbContext.TongHopBomNuocs.RemoveRange(items);
            await _thietbiDbContext.SaveChangesAsync();

            return items.Select(x => x.Id).ToList();
        }

        public async Task<List<TonghopBomnuocVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.TongHopBomNuocs.Include(x => x.DanhmucBomnuoc).Include(x => x.PhongBan)
                        select t;
            return await query.Select(x => new TonghopBomnuocVm()
            {
                Id = x.Id,
                MaQuanLy = x.MaQuanLy ?? string.Empty,
                TenThietBi = x.DanhmucBomnuoc != null ? x.DanhmucBomnuoc.TenThietBi ?? string.Empty : string.Empty,
                TenDonVi = x.PhongBan != null ? x.PhongBan.TenPhong ?? string.Empty : string.Empty,
                ViTriLapDat = x.ViTriLapDat ?? string.Empty,
                NgayLap = x.NgayLap,
                SoLuong = x.SoLuong,
                TinhTrangThietBi = x.TinhTrangThietBi ?? string.Empty,
                DuPhong = x.DuPhong,
                GhiChu = x.GhiChu ?? string.Empty
            }).ToListAsync();
        }

        public async Task<PagedResult<TonghopBomnuocVm>> GetAllPaging(TonghopbomnuocPagingRequest request)
        {
            try
            {
                var query = from t in _thietbiDbContext.TongHopBomNuocs.Include(x => x.DanhmucBomnuoc).Include(x => x.PhongBan)
                            select t;

                if (request.duPhong != null && request.duPhong == true)
                {
                    query = query.Where(x => x.DuPhong == request.duPhong);
                }
                else if (request.thietbiId > 0 && request.donviId > 0)
                {
                    query = query.Where(x => x.BomNuocId == request.thietbiId && x.DonViId == request.donviId);
                }
                else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
                {
                    query = query.Where(x => x.BomNuocId == request.thietbiId);
                }
                else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
                {
                    query = query.Where(x => x.DonViId == request.donviId);
                }

                int totalRow = await query.CountAsync();

                var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .Select(x => new TonghopBomnuocVm()
                    {
                        Id = x.Id,
                        MaQuanLy = x.MaQuanLy ?? string.Empty,
                        TenThietBi = x.DanhmucBomnuoc != null ? x.DanhmucBomnuoc.TenThietBi ?? string.Empty : string.Empty,
                        TenDonVi = x.PhongBan != null ? x.PhongBan.TenPhong ?? string.Empty : string.Empty,
                        ViTriLapDat = x.ViTriLapDat ?? string.Empty,
                        NgayLap = x.NgayLap,
                        SoLuong = x.SoLuong,
                        TinhTrangThietBi = x.TinhTrangThietBi ?? string.Empty,
                        DuPhong = x.DuPhong,
                        GhiChu = x.GhiChu ?? string.Empty
                    }).ToListAsync();

                var pagedResult = new PagedResult<TonghopBomnuocVm>()
                {
                    TotalRecords = totalRow,
                    Items = data,
                    PageIndex = request.PageIndex,
                    PageSize = request.PageSize
                };
                return pagedResult;
            }
            catch (Exception)
            {
                // Log the exception here if you have logging configured
                return new PagedResult<TonghopBomnuocVm>
                {
                    TotalRecords = 0,
                    Items = new List<TonghopBomnuocVm>(),
                    PageIndex = request?.PageIndex ?? 1,
                    PageSize = request?.PageSize ?? 10
                };
            }
        }

        public async Task<TongHopBomNuoc> GetById(int id)
        {
            try
            {
                var query = await _thietbiDbContext.TongHopBomNuocs.FindAsync(id);
                if (query == null)
                {
                    query = new TongHopBomNuoc()
                    {
                        Id = 0,
                        BomNuocId = 0,
                        NgayLap = DateTime.Now,
                        SoLuong = 1
                    };
                }

                return query;
            }
            catch (Exception)
            {
                // Log the exception here if you have logging configured
                return new TongHopBomNuoc()
                {
                    Id = 0,
                    BomNuocId = 0,
                    NgayLap = DateTime.Now,
                    SoLuong = 1
                };
            }
        }

        public async Task<List<TongHopBomNuoc>> getDatailById(int id)
        {
            try
            {
                var Query = from t in _thietbiDbContext.TongHopBomNuocs.Where(x => x.Id == id)
                            join p in _thietbiDbContext.PhongBans on t.DonViId equals p.Id
                            join m in _thietbiDbContext.DanhmucBomnuocs on t.BomNuocId equals m.Id
                            select new { t, p, m };

                return await Query.Select(x => new TongHopBomNuoc
                {
                    Id = x.t.Id,
                    MaQuanLy = x.t.MaQuanLy ?? string.Empty,
                    BomNuocId = x.m.Id,
                    DonViId = x.p.Id,
                    ViTriLapDat = x.t.ViTriLapDat ?? string.Empty,
                    TinhTrangThietBi = x.t.TinhTrangThietBi ?? string.Empty,
                    NgayLap = x.t.NgayLap,
                    SoLuong = x.t.SoLuong,
                    DuPhong = x.t.DuPhong,
                    GhiChu = x.t.GhiChu ?? string.Empty
                }).ToListAsync();
            }
            catch (Exception)
            {
                // Log the exception here if you have logging configured
                return new List<TongHopBomNuoc>();
            }
        }

        public async Task<PagedResult<TonghopBomnuocVm>> SearchAsync(SearchTongHopRequest request)
        {
            var query = from t in _thietbiDbContext.TongHopBomNuocs.Include(x => x.DanhmucBomnuoc).Include(x => x.PhongBan)
                        select t;

            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                query = query.Where(x =>
                    x.DanhmucBomnuoc.TenThietBi.Contains(request.Keyword) ||
                    x.GhiChu.Contains(request.Keyword) ||
                    x.ViTriLapDat.Contains(request.Keyword) ||
                    x.MaQuanLy.Contains(request.Keyword) ||
                    x.PhongBan.TenPhong.Contains(request.Keyword)
                    );

            }
            // ✅ Lọc theo trạng thái true / false
            if (request.DuPhong.HasValue)
            {
                query = query.Where(x => x.DuPhong == request.DuPhong.Value);
            }

            // 📅 Từ ngày
            if (request.TuNgay.HasValue)
            {
                query = query.Where(x => x.NgayLap >= request.TuNgay.Value.Date);
            }

            // 📅 Đến ngày (<= 23:59:59)
            if (request.DenNgay.HasValue)
            {
                var denNgay = request.DenNgay.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.NgayLap <= denNgay);
            }
            var totalRecords = await query.CountAsync();
            var items = await query
        .OrderByDescending(x => x.NgayLap)
        .Skip((request.PageIndex - 1) * request.PageSize)
        .Take(request.PageSize)
         .Select(x => new TonghopBomnuocVm()
         {
             Id = x.Id,
             MaQuanLy = x.MaQuanLy,
             TenThietBi = x.DanhmucBomnuoc.TenThietBi,
             BomNuocId = x.BomNuocId,
             TenDonVi = x.PhongBan.TenPhong,
             DonViId = x.DonViId,
             ViTriLapDat = x.ViTriLapDat,
             NgayLap = x.NgayLap,
             SoLuong = x.SoLuong,
             TinhTrangThietBi = x.TinhTrangThietBi,
             DuPhong = x.DuPhong,
             GhiChu = x.GhiChu
         })
        .ToListAsync();
            return new PagedResult<TonghopBomnuocVm>
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRecords,
                Items = items
            };
        }

        public async Task<int> Sum()
        {
            try
            {
                var query = from s in _thietbiDbContext.TongHopBomNuocs
                            select s;
                var sum = await query.SumAsync(x => x.SoLuong);
                return sum;
            }
            catch (Exception)
            {
                // Log the exception here if you have logging configured
                return 0;
            }
        }

        public async Task<bool> Update([FromBody] TonghopbomnuocUpdateRequest Request)
        {
            try
            {
                if (Request == null || Request.Id <= 0)
                {
                    return false;
                }

                var entity = await _thietbiDbContext.TongHopBomNuocs.FindAsync(Request.Id);
                if (entity == null)
                {
                    return false;
                }

                // Update properties with null-safe assignments
                entity.MaQuanLy = Request.MaQuanLy ?? string.Empty;
                entity.BomNuocId = Request.BomNuocId;
                entity.DonViId = Request.DonViId;
                entity.ViTriLapDat = Request.ViTriLapDat ?? string.Empty;
                entity.NgayLap = Request.NgayLap != default(DateTime) ? Request.NgayLap : DateTime.Now;
                entity.SoLuong = Request.SoLuong > 0 ? Request.SoLuong : 1;
                entity.TinhTrangThietBi = Request.TinhTrangThietBi ?? string.Empty;
                entity.DuPhong = Request.DuPhong;
                entity.GhiChu = Request.GhiChu ?? string.Empty;

                _thietbiDbContext.Update(entity);
                await _thietbiDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log the exception here if you have logging configured
                return false;
            }


        }
    }
}
