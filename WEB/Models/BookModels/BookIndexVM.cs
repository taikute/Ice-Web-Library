﻿namespace WEB.Models.BookModels
{
    public class BookIndexVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public byte[]? CoverImage { get; set; }
        public string? ContentType { get; set; }
    }
}
