using System.Collections.Generic;
namespace Uyen_LeThiPhuong_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Thuộc tính tính toán để hiển thị cả họ và tên
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        // Một tác giả có thể viết nhiều sách
        public ICollection<Book>? Books { get; set; }
    }
}
