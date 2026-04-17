using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Models.Common;
using WebApi.Models.User;

namespace WebApi.Services
{

    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);
        Task<List<UserVm>> GetUser();

        Task<ApiResult<UserVm>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        Task<ApiResult<int>> DeleteMutipleUser(List<AppUser> response);
        Task<ApiResult<int>> UpdateMultipleUser(List<AppUser> response);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ThietbiDbContext _dbContext;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager,
           SignInManager<AppUser> signInManager,
           RoleManager<AppRole> roleManager,
            ThietbiDbContext dbContext,
           IConfiguration config)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
            _config = config;
        }
        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return new ApiErrorResult<string>("Email không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, true, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Tên Đăng nhập hoặc mật khẩu không đúng");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("mail",user.Email!),
                new Claim("name",user.FirstName!),
                new Claim("role", string.Join(",",roles)),
                //new Claim(ClaimTypes.Name, user.FullName!),
                new Claim("fullName", user.FullName!)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSetting:SecurityKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JWTSetting:ValiAudience"],
                _config["JWTSetting:ValiAudience"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            var reult = await _userManager.DeleteAsync(user);
            if (reult.Succeeded)
                return new ApiSuccessResult<bool>();

            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserVm>("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = new UserVm()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                Dob = user.Dob,
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName,
                Roles = roles
            };
            return new ApiSuccessResult<UserVm>(userVm);
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName!.Contains(request.Keyword)
                 || x.PhoneNumber!.Contains(request.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserVm()
                {
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    LastName = x.LastName
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<List<UserVm>> GetUser()
        {
            var user = from x in _userManager.Users
                       select x;
            return await user.Select(x => new UserVm()
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Dob = x.Dob,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,

            }).ToListAsync();

        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email!);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại");
            }


            user = new AppUser()
            {

                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                FullName = request.FirstName + " " + request.LastName,
                PhoneNumber = request.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, request.Password!);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }
            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName!) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName!);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles!);

            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName!) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName!);
                }
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user!.Dob = request.Dob;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<int>> DeleteMutipleUser(List<AppUser> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy bản ghi nào ");

            }
            var exitUser = _dbContext.Users.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();

            var newUser = exitUser.Select(x => x.Id).ToList();
            var deff = ids.Except(newUser).ToList();
            if (deff.Count > 0)
            {
                return new ApiErrorResult<int>("Dữ liệu không hợp lệ ");
            }
            _dbContext.RemoveRange(exitUser);
            var count = await _dbContext.SaveChangesAsync();
            return new ApiSuccessResult<int>(count);
        }

        public async Task<ApiResult<int>> UpdateMultipleUser(List<AppUser> response)
        {
            var ids = response.Select(x => x.Id).ToList();
            if (ids.Count() == 0)
            {
                return new ApiErrorResult<int>("Không tìm thấy id nào");

            }
            var exitUser = _dbContext.Users.AsNoTracking().Where(x => ids.Contains(x.Id)).ToList();
            if (!exitUser.All(x => ids.Contains(x.Id)))
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
