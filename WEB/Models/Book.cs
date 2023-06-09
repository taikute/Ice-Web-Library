﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WEB.Models
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book
    {
        [DisplayName("Book Id")]
        public int Id { get; set; }
        [Required] public int AuthorId { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public int PublisherId { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "ISBN must be exactly 12 characters long!")]
        public string ISBN { get; set; } = "123456789012";

        [Required]
        [DisplayName("Page Count")]
        [Range(1, int.MaxValue)]
        public int PageCount { get; set; } = 99;

        [Required]
        [DisplayName("Price (VND)")]
        [Range(50000, 200000)]
        public int Price { get; set; } = 100000;

        [Required]
        [Range(0, 1000)]
        public int Quantity { get; set; } = 0;

        [Required]
        [DisplayName("Book Title")]
        [StringLength(50)]
        public string Title { get; set; } = "NewTitle";

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Publish Year")]
        [StringLength(4)]
        public string PublishYear { get; set; } = "2023";

        [DisplayName("Book Cover")]
        public string CoverImagePath { get; set; } = "~/1.jpg";

        [Required]
        [StringLength(30)]
        public string Language { get; set; } = "English";

        [Required]
        [StringLength(30)]
        public string Edition { get; set; } = "Edition 1";

        #region ForeignKey
        public virtual Author? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<Instance>? Instance { get; set; }
        #endregion
    }
}
