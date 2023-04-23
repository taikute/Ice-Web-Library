﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int InstanceId { get; set; }
        public int UserId { get; set; }
        public virtual Instance? Instance { get; set; }
        public virtual User? User { get; set; }
        public DateTime BorrowedDate { get; set; } = DateTime.Now;
        public DateTime? ReturnedDate { get; set; } = null;
    }
}