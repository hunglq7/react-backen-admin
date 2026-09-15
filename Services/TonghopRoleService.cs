using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.Tonghopcapdien;
using WebApi.Models.TonghopRole;

namespace WebApi.Services
{
    public interface ITonghopRoleService
    {
        // Define methods for the TonghopRoleService here
        Task<bool> Add(TongHopRole role);
        Task<List<TonghopRoleVm>> GetAll();
        Task<TongHopRole> GetById(int id);
        Task<int> Sum();
        Task<List<TonghopRoleVm>> getDatailById(int id);
        Task<bool> Update([FromBody] TongHopRole Request);
        Task<bool> Delete(int id);
        Task<ApiResult<int>> DeleteSelect(List<int> ids);
        Task<PagedResult<TonghopRoleVm>> GetAllPaging(TonghopRolePagingRequest request);
    }
    public class TonghopRoleService : ITonghopRoleService
    {
        private readonly ThietbiDbContext _thietbiDb;

        public TonghopRoleService(ThietbiDbContext thietbiDb)
        {
            _thietbiDb = thietbiDb;
        }

        // Implement the methods defined in the interface here
        public async Task<bool> Add(TongHopRole Request)
        {
            if (Request == null)
            {
                return false;
            }
            var items = new TongHopRole()
            {
                RoleId = Request.RoleId,
                PhongBanId = Request.PhongBanId,
                ViTriLapDat = Request.ViTriLapDat,
                NgayLap = Request.NgayLap,
                SoLuong = Request.SoLuong,
                TinhTrangThietBi = Request.TinhTrangThietBi,
                DuPhong = Request.DuPhong,
                GhiChu = Request.GhiChu
            };
            await _thietbiDb.TongHopRoles.AddAsync(items);
            await _thietbiDb.SaveChangesAsync();
            return true;

        }

        public async Task<TongHopRole> GetById(int id)
        {
            var query = await _thietbiDb.TongHopRoles.FindAsync(id);
            if (query == null)
            {
                query = new TongHopRole()
                {
                    Id = 0,
                    RoleId = 0,
                    NgayLap = DateTime.Now,

                }
                     ;
            }

            return query;
        }

        public Task<int> Sum()
        {
            return _thietbiDb.TongHopRoles.CountAsync();
        }

        public async Task<List<TonghopRoleVm>> getDatailById(int id)
        {
            var Query = from t in _thietbiDb.TongHopRoles.Where(x => x.Id == id)
                        join p in _thietbiDb.PhongBans on t.PhongBanId equals p.Id
                        join m in _thietbiDb.DanhMucRoles on t.RoleId equals m.Id


                        select new { t, p, m };
            return await Query.Select(x => new TonghopRoleVm
            {
                Id = x.t.Id,
                TenThietBi = x.m.TenThietBi,
                TenPhong = x.p.TenPhong,
                ViTriLapDat = x.t.ViTriLapDat,
                NgayLap = x.t.NgayLap,
                SoLuong = x.t.SoLuong,
                TinhTrangThietBi = x.t.TinhTrangThietBi,
                DuPhong = x.t.DuPhong,
                GhiChu = x.t.GhiChu
            }).ToListAsync();
        }

        public async Task<bool> Update([FromBody] TongHopRole Request)
        {
            var entity = await _thietbiDb.TongHopRoles.FindAsync(Request.Id);
            if (entity == null)
            {
                return false;
            }
            entity.Id = Request.Id;
            entity.RoleId = Request.RoleId;
            entity.PhongBanId = Request.PhongBanId;
            entity.ViTriLapDat = Request.ViTriLapDat;
            entity.NgayLap = Request.NgayLap;
            entity.SoLuong = Request.SoLuong;
            entity.TinhTrangThietBi = Request.TinhTrangThietBi;
            entity.DuPhong = Request.DuPhong;
            entity.GhiChu = Request.GhiChu;
            _thietbiDb.Update(entity);
            await _thietbiDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var query = await _thietbiDb.TongHopRoles.FindAsync(id);
            if (query == null)
            {
                return false;
            }
            _thietbiDb.TongHopRoles.Remove(query);
            _thietbiDb.SaveChanges();
            return true;
        }

        public async Task<PagedResult<TonghopRoleVm>> GetAllPaging(TonghopRolePagingRequest request)
        {
            var query = from t in _thietbiDb.TongHopRoles.Include(x => x.PhongBan).Include(x => x.DanhmucRole)
                        select t;

            if (request.duPhong != null && request.duPhong == true)
            {
                query = query.Where(x => x.DuPhong == request.duPhong);
            }
            else if (request.roleId > 0 && request.donViId > 0)
            {
                query = query.Where(x => x.RoleId == request.roleId && x.PhongBanId == request.donViId);
            }
            else if (request.roleId > 0 && (request.donViId == 0 || request.donViId == null))
            {
                query = query.Where(x => x.RoleId == request.roleId);
            }
            else if ((request.roleId == 0 || request.roleId == null) && request.donViId > 0)
            {
                query = query.Where(x => x.PhongBanId == request.donViId);
            }

            int totalRow = await query.CountAsync();
            int sumSoluong = await query.SumAsync(x => x.SoLuong);
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TonghopRoleVm()
                {
                    Id = x.Id,
                    TenThietBi = x.DanhmucRole.TenThietBi,
                    TenPhong = x.PhongBan.TenPhong,
                    ViTriLapDat = x.ViTriLapDat,
                    NgayLap = x.NgayLap,
                    SoLuong = x.SoLuong,
                    TinhTrangThietBi = x.TinhTrangThietBi,
                    DuPhong = x.DuPhong,
                    GhiChu = x.GhiChu
                }).ToListAsync();

            var pagedResult = new PagedResult<TonghopRoleVm>()
            {
                TotalRecords = totalRow,
                SumRecords = sumSoluong,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<List<TonghopRoleVm>> GetAll()
        {
            var query = _thietbiDb.TongHopRoles.Include(x => x.DanhmucRole).Include(x => x.PhongBan);
            return await query.Select(x => new TonghopRoleVm()
            {
                Id = x.Id,
                TenThietBi = x.DanhmucRole.TenThietBi,
                RoleId = x.RoleId,
                TenPhong = x.PhongBan.TenPhong,
                PhongBanId = x.PhongBanId,
                ViTriLapDat = x.ViTriLapDat,
                NgayLap = x.NgayLap,
                SoLuong = x.SoLuong,
                TinhTrangThietBi = x.TinhTrangThietBi,
                DuPhong = x.DuPhong,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public async Task<ApiResult<int>> DeleteSelect(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new ApiErrorResult<int>("Danh sách ID rỗng");
            }

            var items = await _thietbiDb.TongHopRoles
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Count != ids.Count)
            {
                return new ApiErrorResult<int>("Một số bản ghi không tồn tại");
            }

            _thietbiDb.TongHopRoles.RemoveRange(items);
            var count = await _thietbiDb.SaveChangesAsync();

            return new ApiSuccessResult<int>(count);
        }
    }


}
