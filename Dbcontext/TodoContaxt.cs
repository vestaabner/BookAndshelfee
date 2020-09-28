using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication13.Models
{
    public class TodoContaxt : IdentityDbContext<User>
    {
        public TodoContaxt(DbContextOptions<TodoContaxt> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                /// primery key 
                b.HasKey(u => u.Id);

                //// maps to the Aspnetuser table
                b.ToTable("AspNetUsers");

            }
            );
            modelBuilder.Entity<Booke>(e =>
            {
                e.HasKey(x => x.ID);



                e.ToTable("Bookes");
            });
            modelBuilder.Entity<Shelve>(e =>
            { e.HasKey(x => x.id);
                e.ToTable("Shelves");
            });
            modelBuilder.Entity<BookAndShelvecs>(e => 
            { e.HasKey(X => X.Id);
                e.HasOne(x => x.shelve).WithMany(z => z.bookAndShelvecs).HasForeignKey(c => c.IdShelf);

                
                e.HasOne(x => x.Booke).WithMany(z => z.bookAndShelvecs).HasForeignKey(c => c.IdBook);

                e.ToTable("BookAndShelves"); 
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Booke> Bookes { get; set; }
        public DbSet<Shelve> Shelves { get; set; }
        public DbSet<BookAndShelvecs> BookAndShelvecs { get; set; }
    }
}
