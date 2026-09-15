namespace WebApi.Models.User
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

    public class AuthTokenResponse
    {
        public Guid UserId { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
