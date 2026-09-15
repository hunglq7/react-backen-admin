using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Models.UserRole;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _uerRoleService;
        public UserRoleController(IUserRoleService uerRoleService)
        {
            _uerRoleService = uerRoleService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserRole createRequest)
        {
            var result = await _uerRoleService.Create(createRequest);
            if(result==false)
            {
                return NotFound("Thêm bản ghi thất bại");
            }
            return Ok();
        }
        [HttpGet("getAll")]
        public async Task<IActionResult>GetAll()
        {
            var query = await _uerRoleService.GetAll();
            if(query==null)
            {
                return NotFound("Không có bản ghi nào");

            }
            return Ok(query);
        }
        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<UserRole> response)
        {
            var users = await _uerRoleService.DeleteMutipleUser(response);
            if (users.Count == 0)
            {
                return BadRequest("Xóa thất bại");
            }
            return Ok(users.Count);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<UserRole> reponsse)
        {
            var userRole = await _uerRoleService.UpdateMultipleUser(reponsse);
            if (userRole.Count == 0)
            {
                return BadRequest("Cập nhật thất bại");
            }
            return Ok(userRole.Count);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userRole = await _uerRoleService.GetById(id);
            return Ok(userRole);
        }
    }
}
