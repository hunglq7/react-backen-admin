using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Drawing;
using WebApi.Data.Entites;

namespace WebApi.Data.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            const string roleConcurrencyStamp = "static-admin-role-concurrency-stamp";
            const string adminConcurrencyStamp = "static-admin-user-concurrency-stamp";
            const string adminSecurityStamp = "static-admin-security-stamp";

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                ConcurrencyStamp = roleConcurrencyStamp,
                Description = "Administrator role"
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "hunglq7@gmail.com",
                NormalizedEmail = "hunglq7@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEASnD4B6vtzojn8VQQSRAc5WpLbaxBGhYIfoggNxDV9XJTb1LAHhfQPUBbNWc5mUgg==",
                SecurityStamp = adminSecurityStamp,
                ConcurrencyStamp = adminConcurrencyStamp,
                FirstName = "Hùng",
                LastName = "Lê",
                FullName = "Lê Quang Hùng",
                Dob = new DateTime(1979, 02, 16)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

        }
    }
}
