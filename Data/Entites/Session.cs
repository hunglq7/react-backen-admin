using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    public class Session
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public DateTime? RevokedAt { get; set; }

        [NotMapped]
        public bool IsActive => RevokedAt == null && ExpiresAt > DateTime.UtcNow;

        public AppUser? User { get; set; }
    }
}
