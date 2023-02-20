using System.ComponentModel.DataAnnotations;

namespace User_API.UserApi.Domain.DTOs
{
    public class NewUserDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
