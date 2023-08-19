using System.ComponentModel.DataAnnotations;

namespace Template.WebAPI.DTO
{
    public class RegisterUserDTO
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [MaxLength(6)]
        public string Gender { get; set; } = null!;

        public string? StreetAddress { get; set; }

        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [MaxLength(50)]
        public string UserName { get; set; } = null!;
        
        public string Password { get; set; } = null!;

       
    }
}
