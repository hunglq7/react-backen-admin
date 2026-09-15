namespace WebApi.Models.UserRole
{
    public class UserRoleCreateRequest
    {
        public Guid UserId { get; set; } 
        public Guid RoleId { get; set; } 
    }
}
