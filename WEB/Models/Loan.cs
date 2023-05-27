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
        //1: Waiting For Pickup
        //2: On Loan
        //3: Returned
        //-1: Past Due Pickup
        //-2: Past Due Return
        //-3: Cancel

        #region ForeignKey
        public virtual Instance? Instance { get; set; }
        public virtual User? User { get; set; }
        #endregion
    }
}
