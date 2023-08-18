using System.ComponentModel.DataAnnotations;

namespace Template.WebAPI.DTO
{
    public class RegisterUserDTO
    {
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [MaxLength(6)]
        public string Gender { get; set; } = null!;
        public string? StreetAddress { get; set; }
    }
}
