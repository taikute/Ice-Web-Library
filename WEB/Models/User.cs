using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace WEB.Models
{
    public class User
    {
        public int UserId { get; set; }
        public bool IsActived { get; set; } = true;
        public bool IsOnline { get; set; } = false;
        [AllowNull]
        public string Name { get; set; }
        [AllowNull]
        public string Email { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }

    }
}
