using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace WEB.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [Required] public int RoleId { get; set; } = 1;
        [Required] public bool IsActived { get; set; } = true;
        [Required] public bool IsOnline { get; set; } = false;
        [StringLength(30, ErrorMessage = "30 characters limited!")] public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address!"), StringLength(100, ErrorMessage = "100 character limited!")] public string? Email { get; set; }
        [Required, RegularExpression("^[a-z0-9]+$", ErrorMessage = "Only lowercase letters and numbers are allowed.")] public string Username { get; set; } = "";
        [Required] public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
