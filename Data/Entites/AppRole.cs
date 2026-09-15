using Microsoft.AspNetCore.Identity;

namespace WebApi.Data.Entites
{
    public class AppRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
