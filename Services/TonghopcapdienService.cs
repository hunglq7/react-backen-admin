using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Donvitinh;
using WebApi.Models.Tonghopcapdien;
using WebApi.Models.Tonghopquatgio;

namespace WebApi.Services
{
    public interface ITonghopcapdienService
    {
        Task<bool> Add([FromBody] Tonghopcapdien Request);
        Task<Tonghopcapdien> GetById(int id);
        Task<int> Sum();
        Task<List<TonghopcapdienVm>> getDatailById(int id);
        Task<bool> Update([FromBody] Tonghopcapdien Request);
        Task<bool> Delete(int id);
        Task<PagedResult<TonghopcapdienVm>> GetAllPaging(TonghopcapdienPagingRequest request);
    }
    public class TonghopcapdienService : ITonghopcapdienService
    {
        public readonly ThietbiDbContext _thietbiDb;
        public TonghopcapdienService(ThietbiDbContext thietbiDb)
        {
            _thietbiDb = thietbiDb;
        }
        public async Task<bool> Add([FromBody] Tonghopcapdien Request)
        {
            if (Request == null)
            {
                return false;
            }

            var items = new Tonghopcapdien()
            {
                Id = Request.Id,
                Maquanly = Request.Maquanly,
                CapdienId = Request.CapdienId,
                DonviId = Request.DonviId,
                Ngaythang = Request.Ngaythang,
                Donvitinh = Request.Donvitinh,
                Tondauthang = Request.Tondauthang,
                Nhaptrongky = Request.Nhaptrongky,
                Xuattrongky = Request.Xuattrongky,
                Toncuoithang = Request.Toncuoithang,
                Dangsudung = Request.Dangsudung,
                Duphong = Request.Duphong,
                Ghichu = Request.Ghichu,

            };
            await _thietbiDb.Tonghopcapdiens.AddAsync(items);
            await _thietbiDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDb.Tonghopcapdiens.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDb.Tonghopcapdiens.Remove(query);
            _thietbiDb.SaveChanges();
            return true;
        }

        public async Task<PagedResult<TonghopcapdienVm>> GetAllPaging(TonghopcapdienPagingRequest request)
        {
            var query = from t in _thietbiDb.Tonghopcapdiens.Include(x => x.Capdien).Include(x => x.PhongBan)
                        select t;
            if (request.thietbiId > 0 && request.donviId > 0)
            {
                query = query.Where(x => x.CapdienId == request.thietbiId && x.DonviId == request.donviId);
            }
            else if (request.thietbiId > 0 && (request.donviId == 0 || request.donviId == null))
            {
                query = query.Where(x => x.CapdienId == request.thietbiId);
            }
            else if ((request.thietbiId == 0 || request.thietbiId == null) && request.donviId > 0)
            {
                query = query.Where(x => x.DonviId == request.donviId);
            }


            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopcapdienVm()
                {
                    Id = x.Id,
                    Maquanly = x.Maquanly,
                    TenThietBi = x.Capdien.Tenthietbi,
                    TenDonVi = x.PhongBan.TenPhong,
                    Ngaythang = x.Ngaythang,
                    Donvitinh = x.Donvitinh,
                    Tondauthang = x.Tondauthang,
                    Nhaptrongky = x.Nhaptrongky,
                    Xuattrongky = x.Xuattrongky,
                    Toncuoithang = x.Toncuoithang,
                    Dangsudung = x.Dangsudung,
                    Duphong = x.Duphong

                }).ToListAsync();
            var pagedResult = new PagedResult<TonghopcapdienVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<Tonghopcapdien> GetById(int id)
        {
            var query = await _thietbiDb.Tonghopcapdiens.FindAsync(id);
            if (query == null)
            {
                query = new Tonghopcapdien()
                {
                    Id = 0,
                    CapdienId = 0,
                    Ngaythang = DateTime.Now,

                }
                     ;
            }

            return query;
        }

        public async Task<List<TonghopcapdienVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDb.Tonghopcapdiens.Where(x => x.Id == id)
                        join p in _thietbiDb.PhongBans on t.DonviId equals p.Id
                        join m in _thietbiDb.Capdiens on t.CapdienId equals m.Id


                        select new { t, p, m };
            return await Query.Select(x => new TonghopcapdienVm
            {
                Id = x.t.Id,
                Maquanly = x.t.Maquanly,
                TenThietBi = x.m.Tenthietbi,
                TenDonVi = x.p.TenPhong,
                Ngaythang = x.t.Ngaythang,
                Donvitinh = x.t.Donvitinh,
                Tondauthang = x.t.Tondauthang,
                Nhaptrongky = x.t.Nhaptrongky,
                Xuattrongky = x.t.Xuattrongky,
                Toncuoithang = x.t.Toncuoithang,
                Dangsudung = x.t.Dangsudung,
                Duphong = x.t.Duphong
            }).ToListAsync();
        }

        public Task<int> Sum()
        {
            return _thietbiDb.Tonghopcapdiens.CountAsync();
        }

        public async Task<bool> Update([FromBody] Tonghopcapdien Request)
        {
            var entity = await _thietbiDb.Tonghopcapdiens.FindAsync(Request.Id);
            if (entity == null)
            {
                return false;
            }

            entity.Id = Request.Id;
            entity.Maquanly = Request.Maquanly;
            entity.CapdienId = Request.CapdienId;
            entity.DonviId = Request.DonviId;
            entity.Ngaythang = Request.Ngaythang;
            entity.Donvitinh = Request.Donvitinh;
            entity.Tondauthang = Request.Tondauthang;
            entity.Nhaptrongky = Request.Nhaptrongky;
            entity.Xuattrongky = Request.Xuattrongky;
            entity.Toncuoithang = Request.Toncuoithang;
            entity.Dangsudung = Request.Dangsudung;
            entity.Duphong = Request.Duphong;
            entity.Ghichu = Request.Ghichu;
            _thietbiDb.Update(entity);
            await _thietbiDb.SaveChangesAsync();
            return true;
        }
    }
}
