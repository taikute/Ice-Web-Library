﻿using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        [StringLength(30, ErrorMessage = "30 characters limited")]
        public string PublisherName { get; set; } = "Unknow";
        [StringLength(100, ErrorMessage = "100 characters limited")]
        public string Description { get; set; } = "Unknow";
        public virtual ICollection<Book>? Books { get; set; }
    }
}