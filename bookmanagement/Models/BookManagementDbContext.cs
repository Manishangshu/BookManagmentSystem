using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bookmanagement.Models
{
    public class BookManagementDbContext : DbContext

    {
        public BookManagementDbContext() : base("dbcon"){
        }
        public DbSet<Book> Books { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet <Author> Author { get; set;}   
        public DbSet<Genre> Genres { get; set;}
        public DbSet<Order> Order { get; set;}
        public DbSet<Payment> Payment { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.id);
            modelBuilder.Entity<Author>().HasIndex(a => a.id).IsUnique();
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasMaxLength(255);
            modelBuilder.Entity<Author>().HasIndex(a=>a.AuthorName).IsUnique();
            base.OnModelCreating(modelBuilder); 
        }
    }
}