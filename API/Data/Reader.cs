using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    [Table("Reader")]
    public class Reader
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "NewName";
        public string Email { get; set; } = "";
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
