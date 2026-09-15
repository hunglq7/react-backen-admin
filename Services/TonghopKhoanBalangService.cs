using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.KhoanBalang;
using WebApi.Models.Common;

namespace WebApi.Services
{
    public interface ITonghopKhoanBalangService
    {
        // Define methods for the service here
        Task<List<TonghopKhoanBalangVm>> GetAll();
        Task<ApiResult<int>> DeleteMultiple(List<int> ids);
        Task<bool> Add(TongHopKhoanBalang request);
        Task<bool> Update(TongHopKhoanBalang request);
        Task<bool> Delete(int id);

    }
    public class TonghopKhoanBalangService : ITonghopKhoanBalangService
    {
        private readonly ThietbiDbContext _thietbiDbContext;
        public TonghopKhoanBalangService(ThietbiDbContext thietbiDbContext)
        {
            _thietbiDbContext = thietbiDbContext;
        }
        public Task<bool> Add(TongHopKhoanBalang request)
        {
            if (request == null)
            {
                return Task.FromResult(false);
            }
            var entity = new TongHopKhoanBalang()
            {
                KhoanBalangId = request.KhoanBalangId,
                DonViId = request.DonViId,
                ViTriLapDat = request.ViTriLapDat,
                NgayLap = request.NgayLap,
                SoLuong = request.SoLuong,
                TinhTrangKyThuat = request.TinhTrangKyThuat,
                LoaiThietBi = request.LoaiThietBi,
                DuPhong = request.DuPhong,
                GhiChu = request.GhiChu
            };
            _thietbiDbContext.TongHopKhoanBalangs.Add(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
        public Task<bool> Delete(int id)
        {
            var entity = _thietbiDbContext.TongHopKhoanBalangs.Find(id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            _thietbiDbContext.TongHopKhoanBalangs.Remove(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
        public Task<List<TonghopKhoanBalangVm>> GetAll()
        {
            var query = from tb in _thietbiDbContext.TongHopKhoanBalangs
                        join dm in _thietbiDbContext.DanhmucKhoanBalangs on tb.KhoanBalangId equals dm.Id
                        join dv in _thietbiDbContext.PhongBans on tb.DonViId equals dv.Id
                        select new TonghopKhoanBalangVm()
                        {
                            Id = tb.Id,
                            KhoanBalangId = tb.KhoanBalangId,
                            TenThietBi = dm.TenThietBi,
                            DonViId = tb.DonViId,
                            TenDonVi = dv.TenPhong,
                            ViTriLapDat = tb.ViTriLapDat,
                            NgayLap = tb.NgayLap,
                            SoLuong = tb.SoLuong,
                            TinhTrangKyThuat = tb.TinhTrangKyThuat,
                            LoaiThietBi = tb.LoaiThietBi,
                            DuPhong = tb.DuPhong,
                            GhiChu = tb.GhiChu
                        };
            return Task.FromResult(query.ToList());
        }
        public Task<bool> Update(TongHopKhoanBalang request)
        {
            var entity = _thietbiDbContext.TongHopKhoanBalangs.Find(request.Id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            entity.KhoanBalangId = request.KhoanBalangId;
            entity.DonViId = request.DonViId;
            entity.ViTriLapDat = request.ViTriLapDat;
            entity.NgayLap = request.NgayLap;
            entity.SoLuong = request.SoLuong;
            entity.TinhTrangKyThuat = request.TinhTrangKyThuat;
            entity.LoaiThietBi = request.LoaiThietBi;
            entity.DuPhong = request.DuPhong;
            entity.GhiChu = request.GhiChu;

            _thietbiDbContext.TongHopKhoanBalangs.Update(entity);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }
        public Task<ApiResult<int>> DeleteMultiple(List<int> ids)
        {
            var entities = _thietbiDbContext.TongHopKhoanBalangs.Where(e => ids.Contains(e.Id)).ToList();
            if (entities.Count == 0)
            {
                return Task.FromResult(new ApiResult<int> { IsSuccessed = false, Message = "Không tìm thấy bản ghi nào để xóa", ResultObj = 0 });
            }
            _thietbiDbContext.TongHopKhoanBalangs.RemoveRange(entities);
            return _thietbiDbContext.SaveChangesAsync().ContinueWith(t =>
            {
                if (t.Result > 0)
                {
                    return new ApiResult<int> { IsSuccessed = true, Message = "Xóa thành công", ResultObj = t.Result };
                }
                else
                {
                    return new ApiResult<int> { IsSuccessed = false, Message = "Xóa thất bại", ResultObj = 0 };
                }
            });
        }
    }
}