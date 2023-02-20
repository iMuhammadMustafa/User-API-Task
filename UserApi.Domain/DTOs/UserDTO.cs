namespace User_API.UserApi.Domain.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
