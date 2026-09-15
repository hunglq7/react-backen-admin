using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu;
using WebApi.Models.Common;
namespace WebApi.Services
{
    public interface ITonghopaptomatkhoidongtuService
    {
        Task<List<TonghopaptomatkhoidongtuVm>> GetAll();
        Task<TongHopAptomatKhoidongtu?> GetById(int id);
        Task<bool> Create(TonghopaptomatkhoidongtuCreateRequest request);
        Task<bool> Update(TonghopaptomatkhoidongtuUpdateRequest request);
        Task<bool> Delete(int id);
        Task<List<int>> DeleteMany(List<int> ids);
        Task<PagedResult<TonghopaptomatkhoidongtuVm>> GetAllPaging(TonghopaptomatkhoidongduPagingRequest request);
        Task<PagedResult<TonghopaptomatkhoidongtuVm>> GetAllSearchPaging(SearchTongHopRequest request);

    }
    public class TonghopaptomatkhoidongtuService : ITonghopaptomatkhoidongtuService
    {
        public readonly ThietbiDbContext _context;
        public TonghopaptomatkhoidongtuService(ThietbiDbContext context)
        {
            _context = context;
        }
        public Task<bool> Create(TonghopaptomatkhoidongtuCreateRequest request)
        {
            if (request == null)
            {
                return Task.FromResult(false);
            }
            var entity = new TongHopAptomatKhoidongtu
            {
                aptomatkhoidongtuId = request.aptomatkhoidongtuId,
                DonViId = request.DonViId,
                ViTriLapDat = request.ViTriLapDat,
                NgayKiemDinh = request.NgayKiemDinh,
                NamSanXuat = request.NamSanXuat,
                DienApSuDung = request.DienApSuDung,
                Idm = request.Idm,
                DienApDieuKhien = request.DienApDieuKhien,
                CheDoLamViec = request.CheDoLamViec,
                ThongGio = request.ThongGio,
                NoiDat = request.NoiDat,
                KheHoPhongNo = request.KheHoPhongNo,
                NapMoNhanh = request.NapMoNhanh,
                TayDao = request.TayDao,
                BitCoCap = request.BitCoCap,
                CapPhongNo = request.CapPhongNo,
                TinhTrangThietBi = request.TinhTrangThietBi,
                DuPhong = request.DuPhong,
                GhiChu = request.GhiChu
            };
            _context.TongHopAptomatKhoidongtus.Add(entity);
            var result = _context.SaveChanges();
            return Task.FromResult(result > 0);
        }

        public Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                return Task.FromResult(false);
            }
            var entity = _context.TongHopAptomatKhoidongtus.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            _context.TongHopAptomatKhoidongtus.Remove(entity);
            var result = _context.SaveChanges();
            return Task.FromResult(result > 0);
        }

        public Task<List<int>> DeleteMany(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return Task.FromResult(new List<int>());
            }
            var entities = _context.TongHopAptomatKhoidongtus.Where(x => ids.Contains(x.Id)).ToList();
            _context.TongHopAptomatKhoidongtus.RemoveRange(entities);
            var result = _context.SaveChanges();
            return Task.FromResult(ids);

        }

        public Task<List<TonghopaptomatkhoidongtuVm>> GetAll()
        {
            var query = from a in _context.TongHopAptomatKhoidongtus
                        join b in _context.DanhmucAptomatKhoidongtus on a.aptomatkhoidongtuId equals b.Id
                        join c in _context.PhongBans on a.DonViId equals c.Id
                        select new { a, b, c };
            var data = query.Select(x => new TonghopaptomatkhoidongtuVm
            {
                Id = x.a.Id,
                aptomatkhoidongtuId = x.a.aptomatkhoidongtuId,
                TenThietBi = x.b.TenThietBi,

                DonViId = x.a.DonViId,
                TenDonVi = x.c.TenPhong,
                ViTriLapDat = x.a.ViTriLapDat,
                NgayKiemDinh = x.a.NgayKiemDinh,
                NamSanXuat = x.a.NamSanXuat,
                DienApSuDung = x.a.DienApSuDung,
                Idm = x.a.Idm,
                DienApDieuKhien = x.a.DienApDieuKhien,
                CheDoLamViec = x.a.CheDoLamViec,
                ThongGio = x.a.ThongGio,
                NoiDat = x.a.NoiDat,
                KheHoPhongNo = x.a.KheHoPhongNo,
                NapMoNhanh = x.a.NapMoNhanh,
                TayDao = x.a.TayDao,
                BitCoCap = x.a.BitCoCap,
                CapPhongNo = x.a.CapPhongNo,
                TinhTrangThietBi = x.a.TinhTrangThietBi,
                DuPhong = x.a.DuPhong,
                GhiChu = x.a.GhiChu
            }).ToList();
            return Task.FromResult(data);
        }

        public Task<PagedResult<TonghopaptomatkhoidongtuVm>> GetAllPaging(TonghopaptomatkhoidongduPagingRequest request)
        {
            var query = from a in _context.TongHopAptomatKhoidongtus
                        join b in _context.DanhmucAptomatKhoidongtus on a.aptomatkhoidongtuId equals b.Id
                        join c in _context.PhongBans on a.DonViId equals c.Id
                        select new { a, b, c };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.b.TenThietBi.Contains(request.Keyword) || x.c.TenPhong.Contains(request.Keyword));
            }
            if (request.thietbiId.HasValue)
            {
                query = query.Where(x => x.a.aptomatkhoidongtuId == request.thietbiId.Value);
            }
            if (request.donviId.HasValue)
            {
                query = query.Where(x => x.a.DonViId == request.donviId.Value);
            }
            if (request.duPhong.HasValue)
            {
                query = query.Where(x => x.a.DuPhong == request.duPhong.Value);
            }
            var totalRecords = query.Count();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize).
                        Take(request.PageSize)
                        .Select(x => new TonghopaptomatkhoidongtuVm
                        {
                            Id = x.a.Id,
                            aptomatkhoidongtuId = x.a.aptomatkhoidongtuId,
                            TenThietBi = x.b.TenThietBi,

                            DonViId = x.a.DonViId,
                            TenDonVi = x.c.TenPhong,
                            ViTriLapDat = x.a.ViTriLapDat,
                            NgayKiemDinh = x.a.NgayKiemDinh,
                            NamSanXuat = x.a.NamSanXuat,
                            DienApSuDung = x.a.DienApSuDung,
                            Idm = x.a.Idm,
                            DienApDieuKhien = x.a.DienApDieuKhien,
                            CheDoLamViec = x.a.CheDoLamViec,
                            ThongGio = x.a.ThongGio,
                            NoiDat = x.a.NoiDat,
                            KheHoPhongNo = x.a.KheHoPhongNo,
                            NapMoNhanh = x.a.NapMoNhanh,
                            TayDao = x.a.TayDao,
                            BitCoCap = x.a.BitCoCap,
                            CapPhongNo = x.a.CapPhongNo,
                            TinhTrangThietBi = x.a.TinhTrangThietBi,
                            DuPhong = x.a.DuPhong,
                            GhiChu = x.a.GhiChu
                        }).ToList();
            var pagedResult = new PagedResult<TonghopaptomatkhoidongtuVm>
            {
                TotalRecords = totalRecords,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return Task.FromResult(pagedResult);

        }

        public Task<PagedResult<TonghopaptomatkhoidongtuVm>> GetAllSearchPaging(SearchTongHopRequest request)
        {
            var query = from a in _context.TongHopAptomatKhoidongtus
                        join b in _context.DanhmucAptomatKhoidongtus on a.aptomatkhoidongtuId equals b.Id
                        join c in _context.PhongBans on a.DonViId equals c.Id
                        select new { a, b, c };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.b.TenThietBi.Contains(request.Keyword) ||
                x.c.TenPhong.Contains(request.Keyword) ||
                x.a.ViTriLapDat.Contains(request.Keyword)
                );
            }
            if (request.DuPhong.HasValue)
            {
                query = query.Where(x => x.a.DuPhong == request.DuPhong.Value);
            }
            if (request.TuNgay.HasValue)
            {
                query = query.Where(x => x.a.NgayKiemDinh >= request.TuNgay.Value);
            }
            if (request.DenNgay.HasValue)
            {
                query = query.Where(x => x.a.NgayKiemDinh <= request.DenNgay.Value);
            }

            var totalRecords = query.Count();
            var data = query.
                        OrderByDescending(x => x.a.NgayKiemDinh).
                         Skip((request.PageIndex - 1) * request.PageSize).
                        Take(request.PageSize)
                        .Select(x => new TonghopaptomatkhoidongtuVm
                        {
                            Id = x.a.Id,
                            aptomatkhoidongtuId = x.a.aptomatkhoidongtuId,
                            TenThietBi = x.b.TenThietBi,
                            DonViId = x.a.DonViId,
                            TenDonVi = x.c.TenPhong,
                            ViTriLapDat = x.a.ViTriLapDat,
                            NgayKiemDinh = x.a.NgayKiemDinh,
                            NamSanXuat = x.a.NamSanXuat,
                            DienApSuDung = x.a.DienApSuDung,
                            Idm = x.a.Idm,
                            DienApDieuKhien = x.a.DienApDieuKhien,
                            CheDoLamViec = x.a.CheDoLamViec,
                            ThongGio = x.a.ThongGio,
                            NoiDat = x.a.NoiDat,
                            KheHoPhongNo = x.a.KheHoPhongNo,
                            NapMoNhanh = x.a.NapMoNhanh,
                            TayDao = x.a.TayDao,
                            BitCoCap = x.a.BitCoCap,
                            CapPhongNo = x.a.CapPhongNo,
                            TinhTrangThietBi = x.a.TinhTrangThietBi,
                            DuPhong = x.a.DuPhong,
                            GhiChu = x.a.GhiChu
                        }).ToList();
            var pagedResult = new PagedResult<TonghopaptomatkhoidongtuVm>
            {
                TotalRecords = totalRecords,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return Task.FromResult(pagedResult);

        }

        public Task<TongHopAptomatKhoidongtu?> GetById(int id)
        {
            if (id <= 0)
            {
                return Task.FromResult<TongHopAptomatKhoidongtu?>(null);
            }
            var entity = _context.TongHopAptomatKhoidongtus.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(entity);

        }

        public Task<bool> Update(TonghopaptomatkhoidongtuUpdateRequest request)
        {
            if (request == null || request.Id <= 0)
            {
                return Task.FromResult(false);
            }
            var entity = _context.TongHopAptomatKhoidongtus.FirstOrDefault(x => x.Id == request.Id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            entity.aptomatkhoidongtuId = request.aptomatkhoidongtuId;
            entity.DonViId = request.DonViId;
            entity.ViTriLapDat = request.ViTriLapDat;
            entity.NgayKiemDinh = request.NgayKiemDinh;
            entity.NamSanXuat = request.NamSanXuat;
            entity.DienApSuDung = request.DienApSuDung;
            entity.Idm = request.Idm;
            entity.DienApDieuKhien = request.DienApDieuKhien;
            entity.CheDoLamViec = request.CheDoLamViec;
            entity.ThongGio = request.ThongGio;
            entity.NoiDat = request.NoiDat;
            entity.KheHoPhongNo = request.KheHoPhongNo;
            entity.NapMoNhanh = request.NapMoNhanh;
            entity.TayDao = request.TayDao;
            entity.BitCoCap = request.BitCoCap;
            entity.CapPhongNo = request.CapPhongNo;
            entity.TinhTrangThietBi = request.TinhTrangThietBi;
            entity.DuPhong = request.DuPhong;
            entity.GhiChu = request.GhiChu;
            _context.TongHopAptomatKhoidongtus.Update(entity);
            var result = _context.SaveChanges();
            return Task.FromResult(result > 0);
        }


    }
}