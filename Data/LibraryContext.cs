using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uyen_LeThiPhuong_Lab2.Models;

namespace Uyen_LeThiPhuong_Lab2.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext (DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Uyen_LeThiPhuong_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Uyen_LeThiPhuong_Lab2.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Uyen_LeThiPhuong_Lab2.Models.Genre> Genre { get; set; } = default!;
        public DbSet<Uyen_LeThiPhuong_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Uyen_LeThiPhuong_Lab2.Models.Order> Order { get; set; } = default!;
    }

}

