namespace WebApi.Models.UserRole
{
    public class UserRoleVm
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public string? Email { get; set; }     
        public string? FullName { get; set; }
    }
}
