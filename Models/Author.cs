using System.Collections.Generic;
namespace Uyen_LeThiPhuong_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => FirstName + " " + LastName; // Tiện cho việc hiển thị
        public ICollection<Book>? Books { get; set; }
    }
}
