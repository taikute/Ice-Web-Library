using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [Required] public int InstanceId { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public DateTime BorrowedDate { get; set; } = DateTime.Now;
        public DateTime? ReturnedDate { get; set; } = null;
        public int StatusId { get; set; } = 1;
        //1: Waiting for the book to be picked up
        //2: Book on loan
        //3: Book has been returned
        //-1: Past due book pickup
        //-2: Past due book return

        #region ForeignKey
        public virtual Instance? Instance { get; set; }
        public virtual User? User { get; set; }
        #endregion
    }
}
