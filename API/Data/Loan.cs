using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    public class Loan
    {
        public int Id { get; set; }
        public int InstanceId { get; set; }
        public virtual Instance? Instance { get; set; }
        public int ReaderId { get; set; }
        public virtual Reader? Reader { get; set; }
        public DateTime BorrowedDate { get; set; } = DateTime.Now;
        public DateTime? ReturnedDate { get; set; } = null;
    }
}
