using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Instance
    {
        public int Id { get; set; }
        [Required] public int BookId { get; set; }
        [Required] public int StatusId { get; set; } = 1;

        #region ForeignKey
        public virtual Book? Book { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
        #endregion
    }
}
