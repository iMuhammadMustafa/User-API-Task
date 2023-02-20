namespace User_API.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
