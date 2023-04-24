using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace API.Data
{
    public class Loan
    {
        public int Id { get; set; }
        [Required] public int InstanceId { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public DateTime BorrowedDate { get; set; } = DateTime.Now;
        [AllowNull] public DateTime ReturnedDate { get; set; }

        #region ForeignKey
        [AllowNull] public virtual Instance? Instance { get; set; }
        [AllowNull] public virtual User? User { get; set; }
        #endregion
    }
}
