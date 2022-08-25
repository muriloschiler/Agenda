using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain;
using Agenda.Domain.Core;
using Agenda.Domain.Domain;
using Agenda.Domain.Domain.Enumerations;
using Agenda.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Data
{
    public class AgendaDbContext: DbContext
    {
        public DbSet<User> Users { get; set;}
        public DbSet<Contact> Contacts { get; set;}
        public DbSet<Phone> Phones { get; set;}
        public DbSet<Interaction> Interactions { get; set;}
        
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QRDH7PI;Initial Catalog=Agenda;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
        
            modelBuilder
                .Entity<UserRole>()
                .HasData(Enumeration.GetAll<UserRole>());
        
            modelBuilder
                .Entity<PhoneType>()
                .HasData(Enumeration.GetAll<PhoneType>());

            modelBuilder
                .Entity<InteractionType>()
                .HasData(Enumeration.GetAll<InteractionType>());

            modelBuilder
                .Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "adminSenha",
                    Email = "admin@email.com",
                    Name = "Admin",
                    CreatedAt = DateTime.ParseExact("03/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    UserRoleId = UserRole.Admin.Id
                });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null || entry.Entity.GetType().GetProperty("UpdatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    entry.Property("UpdatedAt").CurrentValue = null;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}