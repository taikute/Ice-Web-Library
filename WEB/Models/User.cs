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
        [AllowNull, StringLength(30, ErrorMessage = "30 characters limited!")] public string Name { get; set; }
        [AllowNull, EmailAddress(ErrorMessage = "Invalid email address!"), StringLength(100, ErrorMessage = "100 character limited!")] public string Email { get; set; }
        [Required, RegularExpression("^[a-z0-9]+$", ErrorMessage = "Only lowercase letters and numbers are allowed.")] public string Username { get; set; } = "";
        [Required] public string Password { get => _password; set => _password = HashPassword(value); }

        [AllowNull] public virtual Role Role { get; set; }
        [AllowNull] public virtual ICollection<Loan> Loans { get; set; }

        //PasswordHash
        [AllowNull] string _password;
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
