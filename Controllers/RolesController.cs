using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Entites;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AppRole role)
        {
            if (role == null)
            {
                return BadRequest("Thêm bản ghi thất bại");
            }
            await _roleService.Create(role);
            return Ok();
        }


        [HttpPost("DeleteMultipale")]

        public async Task<IActionResult> DeleteMultiple([FromBody] List<AppRole> response)
        {
            var roles = await _roleService.DeleteMutipleRole(response);
            if (roles.Count == 0)
            {
                return BadRequest("Xóa thất bại");
            }
            return Ok(roles.Count);
        }

        [HttpPut("UpdateMultiple")]
        public async Task<IActionResult> UpdateMuliple([FromBody] List<AppRole> reponsse)
        {
            var roles = await _roleService.UpdateMultipleRole(reponsse);
            if (roles.Count == 0)
            {
                return BadRequest("Cập nhật thất bại");
            }
            return Ok(roles.Count);

        }
    }
}