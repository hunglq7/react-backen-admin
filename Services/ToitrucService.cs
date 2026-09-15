using Microsoft.EntityFrameworkCore;
using WebApi.Models.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.ToiTruc;

namespace WebApi.Services
{
    public interface IToitrucService
    {
        Task<int> Create(ToitrucCreateRequest request);
        Task<int> Update(ToitrucUpdateRequest request);
        Task<int> Delete(int id);
        Task<ToiTruc> GetById(int id);
        Task<List<ToitrucVm>> GetAll();
        Task<PagedResult<ToitrucVm>> GetAllPaging(GetManagerToitrucPagingRequest request);


    }
    public class ToitrucService:IToitrucService
    {
        private readonly ThietbiDbContext _dbcontext;
        public ToitrucService(ThietbiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Create(ToitrucCreateRequest request)
        {
            if (request == null)
            {
                return 0;
            }
            var items= new ToiTruc()
            {
                MaQuanLy = request.MaQuanLy,
                MaHieu = request.MaHieu,
                TenLoai = request.TenLoai,
                NuocSX = request.NuocSX,
                HangSX = request.HangSX,
                NamSX = request.NamSX,
                CongSuat = request.CongSuat,
                DienAp = request.DienAp,
                SoVongQuay = request.SoVongQuay,
                LucKeo = request.LucKeo,
                TocDoKeoCham = request.TocDoKeoCham,
                TocDoKeoNhanh = request.TocDoKeoNhanh,
                TrongLuongToi = request.TrongLuongToi,
                KichThuocNgoaiHinh = request.KichThuocNgoaiHinh,
                DuongKinhCap = request.DuongKinhCap,
                ChieuDaiCapQuan = request.ChieuDaiCapQuan,
                ApLucKhiNen = request.ApLucKhiNen,
                LuongKhiNenTieuHao = request.LuongKhiNenTieuHao,
                GiChu = request.GiChu
            };
            await _dbcontext.ToiTrucs.AddAsync(items);
            var count = _dbcontext.SaveChanges();
            return count;

        }

        public async Task<int> Delete(int id)
        {
            var query = _dbcontext.ToiTrucs.Find(id);
            if (query == null)
            {
                return 0;
            }
            _dbcontext.ToiTrucs.Remove(query);
            var count = await _dbcontext.SaveChangesAsync();
            return count;
        }

        public async Task<List<ToitrucVm>> GetAll()
        {
            var query = from t in _dbcontext.ToiTrucs
                        select t;
            return await query.Select(x=>new ToitrucVm()
            {
                Id= x.Id,
                MaQuanLy=x.MaQuanLy,
                MaHieu=x.MaHieu,
                TenLoai=x.TenLoai,
                NuocSX=x.NuocSX,
                HangSX=x.HangSX,
                NamSX=x.NamSX
            }).ToListAsync();
        }

        public async Task<PagedResult<ToitrucVm>> GetAllPaging(GetManagerToitrucPagingRequest request)
        {
            var query = from t in _dbcontext.ToiTrucs
                        select new { t };
            if(!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.t.MaQuanLy.Contains(request.Keyword) || 
                x.t.MaHieu.Contains(request.Keyword) || 
                x.t.TenLoai.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ToitrucVm()
                {
                    Id = x.t.Id,
                    MaQuanLy = x.t.MaQuanLy,
                    MaHieu = x.t.MaHieu,
                    TenLoai = x.t.TenLoai,
                    NuocSX = x.t.NuocSX,
                    HangSX = x.t.HangSX,
                    NamSX = x.t.NamSX,                   
                }).ToListAsync();
            var pagedResult = new PagedResult<ToitrucVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<ToiTruc> GetById(int id)
        {
            var query = await _dbcontext.ToiTrucs.FindAsync(id);
            if (query == null)
            {
                query= new ToiTruc()
                {
                    Id = 0
                };
            }
            return query;
        }

        public async Task<int> Update(ToitrucUpdateRequest request)
        {
            
            var query = _dbcontext.ToiTrucs.Find(request.Id);
            if(query == null)
            {
                return 0;
            }
            query.MaQuanLy = request.MaQuanLy;
            query.MaHieu = request.MaHieu;
            query.TenLoai = request.TenLoai;
            query.NuocSX = request.NuocSX;
            query.HangSX = request.HangSX;
            query.NamSX = request.NamSX;
            query.CongSuat = request.CongSuat;
            query.DienAp = request.DienAp;
            query.SoVongQuay = request.SoVongQuay;
            query.LucKeo = request.LucKeo;
            query.TocDoKeoCham = request.TocDoKeoCham;
            query.TocDoKeoNhanh = request.TocDoKeoNhanh;
            query.TrongLuongToi = request.TrongLuongToi;
            query.KichThuocNgoaiHinh = request.KichThuocNgoaiHinh;
            query.DuongKinhCap = request.DuongKinhCap;
            query.ChieuDaiCapQuan = request.ChieuDaiCapQuan;
            query.ApLucKhiNen = request.ApLucKhiNen;
            query.LuongKhiNenTieuHao = request.LuongKhiNenTieuHao;
            query.GiChu = request.GiChu;
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
