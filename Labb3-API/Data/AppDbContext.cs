using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;

namespace Labb3_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Links> Links {  get; set; }  
        public DbSet<Interest> Interests { get; set; }
        
        public DbSet<PersonInterest> PersonInterests { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, Name = "Anna Svensson", PhoneNumber = "0701234567" },
                new Person { PersonId = 2, Name = "Johan Karlsson", PhoneNumber = "0722345678" }
            );
            modelBuilder.Entity<Interest>().HasData(
                new Interest { InterestId = 1, Title = "Fotografering", Description = "Konsten att fånga ögonblick." },
                new Interest { InterestId = 2, Title = "Bergsklättring", Description = "Utmaningen att nå toppen." }
            );

            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { PersonInterestId = 1, PersonId = 1, InterestId = 1 },
                new PersonInterest { PersonInterestId = 2, PersonId = 1, InterestId = 2 },
                new PersonInterest { PersonInterestId = 3, PersonId = 2, InterestId = 1 }
            );

            modelBuilder.Entity<Links>().HasData(
                new Links { LinkId = 1, Url = "http://example.com/foto", PersonInterestId = 1 },
                new Links { LinkId = 2, Url = "http://example.com/bergsbestigning", PersonInterestId = 2 }
            );
        }

       
    }
}


       
    



