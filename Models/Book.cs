﻿namespace BookMVCYayin.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public int KategoriId { get; set; }

    }
}
