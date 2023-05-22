using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [Required] public int RoleId { get; set; } = 1;
        [Required] public bool IsActived { get; set; } = true;
        [Required] public bool IsOnline { get; set; } = false;

        [Required]
        [StringLength(30, ErrorMessage = "30 characters limited.")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@gmail\.com$", ErrorMessage = "Invalid email.")]
        [StringLength(100, ErrorMessage = "100 character limited.")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression("^[a-z0-9]+$", ErrorMessage = "Only lowercase letters and numbers are allowed.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Length must between 5 - 10.")]
        public string Username { get; set; } = "";

        [Required]
        [RegularExpression("(?=.*[A-Z])(?=.*\\d).*",
            ErrorMessage = "Password must contain at least one uppercase letter and one digit.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Length must between 5 - 10.")]
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
