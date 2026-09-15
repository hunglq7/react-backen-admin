using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.ThongsoBomnuoc;
using WebApi.Models.ThongsoQuatgio;

namespace WebApi.Services
{
    public interface IThongsobomnuocService
    {
        Task<List<ThongsoBomnuocVm>> GetAll();
        Task<PagedResult<ThongsoBomnuocVm>> GetAllPaging(ThongsoBomnuocPagingRequest request);
        Task<ThongSoBomNuoc> GetById(int id);
        Task<List<ThongsoBomnuocVm>> getDatailById(int id);
        Task<bool> Add([FromBody] ThongSoBomNuoc Request);
        Task<bool> Update([FromBody] ThongSoBomNuoc Request);
        Task<bool> Delete(int id);
        Task<List<int>> DeleteMutiple(List<int> ids);
    }
    public class ThongsobomnuocService : IThongsobomnuocService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public ThongsobomnuocService(ThietbiDbContext thietbiDbContext)

        {
            _thietbiDbContext = thietbiDbContext;
        }
        public async Task<bool> Add([FromBody] ThongSoBomNuoc Request)
        {
            if (Request == null)
            {
                return false;
            }

            var newItems = new ThongSoBomNuoc()
            {
                Id = Request.Id,
                BomNuocId = Request.BomNuocId,
                NoiDung = Request.NoiDung,
                DonViTinh = Request.DonViTinh,
                ThongSo = Request.ThongSo,

            };
            await _thietbiDbContext.ThongSoBomNuocs.AddAsync(newItems);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var items = await _thietbiDbContext.ThongSoBomNuocs.FindAsync(id);
            if (items == null)
            {
                return false;
            }
            _thietbiDbContext.ThongSoBomNuocs.Remove(items);
            _thietbiDbContext.SaveChanges();
            return true;
        }

        public async Task<List<int>> DeleteMutiple(List<int> ids)
        {
            var items = await _thietbiDbContext.ThongSoBomNuocs
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (!items.Any())
                return new List<int>();

            _thietbiDbContext.ThongSoBomNuocs.RemoveRange(items);
            await _thietbiDbContext.SaveChangesAsync();

            return items.Select(x => x.Id).ToList();
        }

        public async Task<List<ThongsoBomnuocVm>> GetAll()
        {
            var query = from t in _thietbiDbContext.ThongSoBomNuocs.Include(x => x.DanhmucBomnuoc)
                        select t;
            return await query.Select(x => new ThongsoBomnuocVm()
            {
                Id = x.Id,
                TenThietBi = x.DanhmucBomnuoc.TenThietBi,
                BomNuocId = x.BomNuocId,
                NoiDung = x.NoiDung,
                DonViTinh = x.DonViTinh,
                ThongSo = x.ThongSo,
            }).ToListAsync();
        }

        public async Task<PagedResult<ThongsoBomnuocVm>> GetAllPaging(ThongsoBomnuocPagingRequest request)
        {
            var query = from t in _thietbiDbContext.ThongSoBomNuocs.Include(x => x.DanhmucBomnuoc)
                        select t;
            if (request.thietbiId > 0)
            {
                query = query.Where(x => x.BomNuocId == request.thietbiId);
            }


            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ThongsoBomnuocVm()
                {
                    Id = x.Id,
                    TenThietBi = x.DanhmucBomnuoc!.TenThietBi,
                    NoiDung = x.NoiDung,
                    DonViTinh = x.DonViTinh,
                    ThongSo = x.ThongSo,

                }).ToListAsync();
            var pagedResult = new PagedResult<ThongsoBomnuocVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }
        public async Task<ThongSoBomNuoc> GetById(int id)
        {
            var items = await _thietbiDbContext.ThongSoBomNuocs.FindAsync(id);
            if (items == null)
            {
                items = new ThongSoBomNuoc()
                {
                    Id = 0,
                    BomNuocId = 1,
                    NoiDung = "",
                    DonViTinh = "",
                    ThongSo = ""
                }
                     ;
            }

            return items;
        }

        public async Task<List<ThongsoBomnuocVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDbContext.ThongSoBomNuocs.Where(x => x.BomNuocId == id)
                        join m in _thietbiDbContext.DanhmucBomnuocs on t.BomNuocId equals m.Id


                        select new { t, m };
            return await Query.Select(x => new ThongsoBomnuocVm
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                NoiDung = x.t.NoiDung,
                DonViTinh = x.t.DonViTinh,
                ThongSo = x.t.ThongSo,
            }).ToListAsync();
        }

        public async Task<bool> Update([FromBody] ThongSoBomNuoc Request)
        {
            var items = await _thietbiDbContext.ThongSoBomNuocs.FindAsync(Request.Id);
            if (items == null)
            {
                return false;
            }
            items.Id = Request.Id;
            items.BomNuocId = Request.BomNuocId;
            items.NoiDung = Request.NoiDung;
            items.DonViTinh = Request.DonViTinh;
            items.ThongSo = Request.ThongSo;
            _thietbiDbContext.Update(items);
            await _thietbiDbContext.SaveChangesAsync();
            return true;
        }
    }
}
