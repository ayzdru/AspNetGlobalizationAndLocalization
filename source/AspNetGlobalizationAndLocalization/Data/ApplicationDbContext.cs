using System;
using System.Collections.Generic;
using System.Text;
using AspNetGlobalizationAndLocalization.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetGlobalizationAndLocalization.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Book> Books { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Culture>().HasData(
                new Culture
                {
                    Id = 1,
                    Name = "en"
                }
            );
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Id = 1,CultureId = 1, Key = "Veritabanından Merhaba", Value = "Hello From Database" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "{\"tr\":\"Küçük Prens\", \"en\":\"The Little Prince\"}", Description = "{\"tr\":\"Küçük Prens, Fransız yazar ve pilot Antoine de Saint-Exupéry tarafından yazılan ve 1943'te yayımlanan masal. Dünyanın en çok satan ve okunan kitaplarından biridir. Eserde bir çocuğun gözünden büyüklerin dünyası anlatılır.\", \"en\":\"After being stranded in a desert after a crash, a pilot comes in contact with a captivating little prince who recounts his journey from planet to planet and his search for what is most important in life.\"}" }
            );


        }
    }
}
