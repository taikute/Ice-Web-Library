﻿using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PublishYear { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public byte[]? CoverImage { get; set; }
        public string? ContentType { get; set; }
        public string? ISBN { get; set; }
        public string? Language { get; set; }
        public int PageCount { get; set; }
        public string? Edition { get; set; }
    }
}
