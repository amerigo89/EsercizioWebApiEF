using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioWebApiEF
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        //public virtual DbSet<UserLoan> UsersLoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibraryEF2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>() //per definire la doppia PK in tabella unione
                .HasKey(r => new { r.Id });
        }
    }
}
