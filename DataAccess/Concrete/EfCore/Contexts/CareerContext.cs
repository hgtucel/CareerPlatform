using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EfCore.Contexts
{
    public class CareerContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; initial catalog=CareerDb; integrated security=true");
        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Recourse> Recourses { get; set; }
    }
}
