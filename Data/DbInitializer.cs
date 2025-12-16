using Microsoft.EntityFrameworkCore;
using Uyen_LeThiPhuong_Lab2.Models;


namespace Uyen_LeThiPhuong_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                // Kiểm tra xem đã có sách nào chưa
                if (context.Book.Any())
                {
                    return; // Đã có dữ liệu, không làm gì cả
                }

                // Thêm Genres (Thể loại)
                context.Genre.AddRange(
                    new Genre { Name = "Roman" },
                    new Genre { Name = "Nuvela" },
                    new Genre { Name = "Poezie" }
                );

                // Thêm Books (Sách)
                context.Book.AddRange(
                    new Book { Title = "Baltagul", Price = Decimal.Parse("22") },
                    new Book { Title = "Enigma Otiliei", Price = Decimal.Parse("18") },
                    new Book { Title = "Maytrei",  Price = Decimal.Parse("27") }
                );

                // Thêm Customers (Khách hàng)
                context.Customer.AddRange(
                    new Customer { Name = "Popescu Marcela", Adress = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                    new Customer { Name = "Mihailescu Cornel", Adress = "Str. Bucuresti, nr. 45, ap. 2", BirthDate = DateTime.Parse("1969-07-08") }
                );

                // Lưu thay đổi vào Database
                context.SaveChanges();
            }
        }
    }
}


