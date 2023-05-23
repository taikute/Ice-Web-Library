using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Data
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; } = 1;
        public bool IsLocked { get; set; } = false;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get => _password; set => _password = HashPassword(value ?? "Password123"); }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }

        //PasswordHash
        string? _password;
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
