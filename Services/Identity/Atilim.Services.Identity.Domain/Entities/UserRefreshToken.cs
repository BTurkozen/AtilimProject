namespace Atilim.Services.Identity.Domain.Entities
{
    public class UserRefreshToken
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
