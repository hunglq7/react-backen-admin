using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.User;


namespace WebApi.Services
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
        Task<bool> Create([FromBody] AppRole reponse);
        Task<ApiResult<int>> UpdateMultipleRole(List<AppRole> response);
        Task<ApiResult<int>> DeleteMutipleRole(List<AppRole> response);
    }
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ThietbiDbContext _dbContext;
        public RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, ThietbiDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<bool> Create([FromBody] AppRole role)
        {
            if (role == null)
            {
                return false;
            }
            var newRole = (new AppRole()
            {
                Id = Guid.NewGuid(),
                Name = role.Name,
                NormalizedName = role.NormalizedName,
                Description = role.Description,
            });
            await _roleManager.CreateAsync(newRole);
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutipleRole(List<AppRole> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào ");

            }
            var exitRole = _dbContext.Roles.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newRole = exitRole.Select(x => x.Id).ToList();
            var deff = ids.Except(newRole).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Dữ liệu không hợp lệ ");
            }
            _dbContext.RemoveRange(exitRole);
            var count = await _dbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<RoleVm>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();

            return roles;
        }

        public async Task<ApiResult<int>> UpdateMultipleRole(List<AppRole> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy id nào");

            }
            var exitRole = _dbContext.Roles.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitRole.All(x => ids.Contains(x.Id)))
            {
                return new ApiErrorResult<int>("Cập nhật không hợp lệ");
            }
            _dbContext.UpdateRange(response);
            var Count = await _dbContext.SaveChangesAsync();
            var UpdateMuliple = _dbContext.Roles.Where(x => ids.Contains(x.Id)).ToList();

            return new ApiSuccessResult<int>(Count);
        }
    }
}
