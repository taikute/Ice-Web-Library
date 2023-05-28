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
        public string? CitizenIdentificationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int LoanLeft { get; set; } = 1;

        //PasswordHash
        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                if (!string.IsNullOrEmpty(value) && value != _password)
                {
                    _password = HashPassword(value);
                }
            }
        }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }

        // Hash mật khẩu
        private static string HashPassword(string password)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        // Xác thực mật khẩu
        public bool VerifyPassword(string password)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hashedPassword = Convert.ToBase64String(hashedBytes);
            return hashedPassword == _password;
        }
    }
}
