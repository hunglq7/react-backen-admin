using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.UserRole;

namespace WebApi.Services
{
    public interface IUserRoleService
    {
        Task<List<UserRoleVm>> GetAll();
        Task<bool> Create([FromBody] UserRole reponse);
        Task<IdentityUserRole<Guid>> GetById(Guid id);
        Task<ApiResult<int>> DeleteMutipleUser(List<UserRole> response);
        Task<ApiResult<int>> UpdateMultipleUser(List<UserRole> response);
    }
    public class UserRoleService : IUserRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ThietbiDbContext _dbContext;
        public UserRoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, ThietbiDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;

        }
        public async Task<bool> Create([FromBody] UserRole reponse)
        {
            if (reponse == null)
            {
                return false;
            }
            var newUserRole = new IdentityUserRole<Guid>()
            {
                RoleId = reponse.RoleId,
                UserId = reponse.UserId,
            };
            await _dbContext.UserRoles.AddAsync(newUserRole);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<ApiResult<int>> DeleteMutipleUser(List<UserRole> response)
        {



            var idList = response.Select(u => u.UserId).ToList();
            if (idList.Count == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào");
            }

            var exitUserRole = _dbContext.UserRoles.AsNoTracking().Where(x => x.UserId == response[0].UserId & x.RoleId == response[0].RoleId).ToList();
            var newUserRole = exitUserRole.Select(x => x.UserId).ToList();
            var diff = idList.Except(newUserRole).ToList();
            if (diff.Count > 0)
            {
                return new ApiErrorResult<int>("Dũ liệu không họp lệ");
            }
            _dbContext.UserRoles.RemoveRange(exitUserRole);
            var count = await _dbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<List<UserRoleVm>> GetAll()
        {

            var query = (from a in _dbContext.UserRoles
                         join b in _dbContext.Users on a.UserId equals b.Id
                         join c in _dbContext.Roles on a.RoleId equals c.Id
                         select new
                         {
                             a.UserId,
                             a.RoleId,
                             b.UserName,
                             b.Email,
                             b.FullName,
                             c.Name
                         });


            return await query.Select(x => new UserRoleVm()
            {
                UserId = x.UserId,
                RoleId = x.RoleId,
                UserName = x.UserName,
                FullName = x.FullName,
                Email = x.Email,
                RoleName = x.Name
            }).ToListAsync();
        }



        public async Task<IdentityUserRole<Guid>> GetById(Guid id)
        {
            var userRole = await _dbContext.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                userRole = new IdentityUserRole<Guid>()
                {
                    UserId = new Guid(),
                    RoleId = new Guid(),
                };
            }

            return userRole;
        }

        public async Task<ApiResult<int>> UpdateMultipleUser(List<UserRole> response)
        {
            var ids = response.Select(x => x.UserId).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy id nào");

            }
            var exitUserRole = _dbContext.UserRoles.AsNoTracking().Where(x => ids.Contains(x.UserId)).ToList();
            if (!exitUserRole.All(x => ids.Contains(x.UserId)))
            {
                return new ApiErrorResult<int>("Cập nhật không hợp lệ");
            }
            _dbContext.UpdateRange(response);
            var Count = await _dbContext.SaveChangesAsync();

            return new ApiSuccessResult<int>(Count);
        }
    }
}
