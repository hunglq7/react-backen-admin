using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using WebApi.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Nhanvien;

namespace WebApi.Services
{
    public interface INhanvienService
    {
        Task<List<NhanvienVm>> GetNhanvien();
        Task<bool> AddNhanvien([FromBody] NhanvienCreateRequest request);
        Task<NhanVien> GetById(int id);
        Task<bool> UpdateNhanvien([FromBody] NhanvienUpdateRequest request);
        Task<bool> DeleteNhanvien(int id);
        //Task<int> AddImage(int productId, NhanvienImageCreateRequest request);

        Task<int> RemoveImage(int imageId);
        Task<int> AddImage(int productId, NhanvienImageCreateRequest request);
        Task<int> UpdateImage(int imageId, NhanvienImageUpdateRequest request);
        Task<NhanvienImageViewModel> GetImageById(int imageId);

        Task<List<NhanvienImageViewModel>> GetListImages(int productId);
       

    }
    public class NhanvienService : INhanvienService
    {
        private readonly ThietbiDbContext _dbContext;
        private readonly IStorageService _storageService;
        private const string NHANVIEN_IMAGE_FOLDER_NAME = "Images/NhanVien";
        public NhanvienService(ThietbiDbContext dbContext, IStorageService storageService)
        {
            _dbContext = dbContext;
            _storageService = storageService;
        }

        public async Task<int> AddImage(int nhanvienId, NhanvienImageCreateRequest request)
        {
            var nhanvienImage = new NhanvienImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                NhanVienId = nhanvienId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                nhanvienImage.ImagePath = await this.SaveFile(request.ImageFile);
                nhanvienImage.FileSize = request.ImageFile.Length;
            }
           await _dbContext.NhanvienImages.AddAsync(nhanvienImage);
            await _dbContext.SaveChangesAsync();
            return nhanvienImage.Id;
        }

        public async Task<bool> AddNhanvien([FromBody] NhanvienCreateRequest request)
        {
            if(request == null)
            {
                return false;
            }
            var newNhanvien = new NhanVien()
            {
              
            SoThe = request.soThe,
            TenNhanVien = request.tenNhanVien,
            NgaySinh = request.ngaySinh,
            HinhAnh = request.hinhAnh,
            DiaChi = request.diaChi,
            DienThoai = request.dienThoai,
            PhongBanId = request.phongBanId,
            ChucVuId = request.chucVuId,
            GhiChu = request.ghiChu,
            TrangThai = request.trangThai,

        };
            _dbContext.NhanViens.Add(newNhanvien);
           await _dbContext.SaveChangesAsync();
            return true;
               
        }

        public async Task<bool> DeleteNhanvien(int id)
        {
            if(id == 0)
            {
                return false;
            }
            var nhanvien=await _dbContext.NhanViens.FindAsync(id);
            if(nhanvien == null)
            {
                throw new Exception("Không tìm thấy nhân viên");
            }
            _dbContext.NhanViens.Remove(nhanvien);
           await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<NhanVien> GetById(int id)
        {
            var nhanvien = await _dbContext.NhanViens.FindAsync(id);
           
            if(nhanvien == null)
            {
                nhanvien = new NhanVien()
                {
                    Id = 0,
                    NgaySinh = DateTime.Now,
                    TrangThai = true
                };
               
            }
            return nhanvien;
        }

        public async Task<List<NhanvienVm>> GetNhanvien()
        {
            var nhanvien= from n in _dbContext.NhanViens.Include(x=>x.PhongBan).Include(x=>x.ChucVu)
                         .Where(x=>x.TrangThai==true)
                         select n;
            return await nhanvien.Select(x => new NhanvienVm()
            {
                Id=x.Id,
                TenNhanVien=x.TenNhanVien,
                HinhAnh=x.HinhAnh,
                DienThoai=x.DienThoai,
                SoThe=x.SoThe,
                NgaySinh=x.NgaySinh,
                DiaChi=x.DiaChi,
                TenPhong=x.PhongBan!.TenPhong,
                TenChucVu=x.ChucVu!.TenChucVu,
                GiChu=x.GhiChu,
                TrangThai=x.TrangThai,

            }).ToListAsync();

        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, NhanvienImageUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateNhanvien([FromBody] NhanvienUpdateRequest request)
        {
           
            var nhavien = await _dbContext.NhanViens.FindAsync(request.id);
            if(nhavien==null)
            {
                return false;
            }
           
            nhavien.SoThe = request.soThe;
            nhavien.TenNhanVien = request.tenNhanVien;
            nhavien.NgaySinh=request.ngaySinh;
            nhavien.HinhAnh = request.hinhAnh;
            nhavien.DiaChi = request.diaChi;
            nhavien.DienThoai=request.dienThoai;
            nhavien.PhongBanId = request.phongBanId;
            nhavien.ChucVuId = request.chucVuId;
            nhavien.GhiChu = request.ghiChu;
            nhavien.TrangThai = request.trangThai;
            _dbContext.NhanViens.Update(nhavien); 
          await _dbContext.SaveChangesAsync();
            return true;


        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + NHANVIEN_IMAGE_FOLDER_NAME + "/" + fileName;
        }

        public async Task<NhanvienImageViewModel> GetImageById(int imageId)
        {
            var image = await _dbContext.NhanvienImages.FindAsync(imageId);
            if (image == null)
                throw new Exception($"Cannot find an image with id {imageId}");

            var viewModel = new NhanvienImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                NhanvienId = image.NhanVienId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }

        public async Task<List<NhanvienImageViewModel>> GetListImages(int nhanvienId)
        {
            return await _dbContext.NhanvienImages.Where(x => x.NhanVienId == nhanvienId)
               .Select(i => new NhanvienImageViewModel()
               {
                   Caption = i.Caption,
                   DateCreated = i.DateCreated,
                   FileSize = i.FileSize,
                   Id = i.Id,
                   ImagePath = i.ImagePath,
                   IsDefault = i.IsDefault,
                   NhanvienId = i.NhanVienId,
                   SortOrder = i.SortOrder
               }).ToListAsync();
        }

       
    }
}
