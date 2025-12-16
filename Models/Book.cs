using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Uyen_LeThiPhuong_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public int? AuthorID { get; set; } // Khóa ngoại
        public Author? Author { get; set; } // Navigation property
        public decimal Price { get; set; }
        public int? GenreID { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
