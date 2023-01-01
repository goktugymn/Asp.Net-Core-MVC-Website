using static ARTICLE.Models.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ARTICLE.Models
{
    
        public class Context : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=DbCoreBook; integrated security=True;");

            }
            public DbSet<Book> Books { get; set; }
            public DbSet<Category> Categories { get; set; }
        }
    }

