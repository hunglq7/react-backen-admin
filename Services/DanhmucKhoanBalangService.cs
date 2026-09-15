using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.KhoanBalang;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public interface IDanhmucKhoanBalangService
    {
        Task<List<DanhmucKhoanBalangVm>> GetAll();
        Task<ApiResult<int>> DeleteMultiple(List<int> ids);
        Task<bool> Add(DanhmucKhoanBalang request);
        Task<bool> Update(DanhmucKhoanBalang request);
        Task<bool> Delete(int id);
    }
    public class DanhmucKhoanBalangService : IDanhmucKhoanBalangService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public DanhmucKhoanBalangService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }

        public Task<bool> Add(DanhmucKhoanBalang request)
        {
            if (request == null)
            {
                return Task.FromResult(false);
            }
            var entity = new DanhmucKhoanBalang()
            {
                TenThietBi = request.TenThietBi,
                GhiChu = request.GhiChu
            };
            _thietbiDbContext.DanhmucKhoanBalangs.Add(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }



        public Task<bool> Delete(int id)
        {
            var entity = _thietbiDbContext.DanhmucKhoanBalangs.Find(id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            _thietbiDbContext.DanhmucKhoanBalangs.Remove(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public Task<ApiResult<int>> DeleteMultiple(List<int> ids)
        {
            if (ids.Count == 0)
            {
                return Task.FromResult<ApiResult<int>>(new ApiErrorResult<int>("Không tìm thấy bản ghi nào"));
            }
            var entities = _thietbiDbContext.DanhmucKhoanBalangs.Where(x => ids.Contains(x.Id)).ToList();
            if (entities.Count == 0)
            {
                return Task.FromResult<ApiResult<int>>(new ApiErrorResult<int>("Không tìm thấy bản ghi nào"));
            }
            _thietbiDbContext.DanhmucKhoanBalangs.RemoveRange(entities);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => (ApiResult<int>)new ApiSuccessResult<int>(t.Result));
        }

        public Task<List<DanhmucKhoanBalangVm>> GetAll()
        {
            var query = from c in _thietbiDbContext.DanhmucKhoanBalangs
                        select c;

            return query.Select(x => new DanhmucKhoanBalangVm()
            {
                Id = x.Id,
                TenThietBi = x.TenThietBi,
                GhiChu = x.GhiChu
            }).ToListAsync();
        }

        public Task<bool> Update(DanhmucKhoanBalang request)
        {
            var entity = _thietbiDbContext.DanhmucKhoanBalangs.Find(request.Id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            entity.TenThietBi = request.TenThietBi;
            entity.GhiChu = request.GhiChu;
            _thietbiDbContext.DanhmucKhoanBalangs.Update(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
    }
}