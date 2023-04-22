using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace API.Data
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
        public string Password
        {
            get => _password;
            set => _password = HashPassword(value);
        }
        [Required]
        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
        [AllowNull]
        string _password;

        static string HashPassword(string password)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
        public bool VerifyPassword(string password)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hashedPassword = Convert.ToBase64String(hashedBytes);
            return hashedPassword == _password;
        }
    }
}
