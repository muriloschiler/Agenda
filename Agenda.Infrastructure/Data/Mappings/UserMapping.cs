using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Domain;
using Agenda.Infrastructure.Data.Mappings.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Data.Mappings
{
    public class UserMapping : BaseRegisterMapping<User>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(us=>us.Id);

            builder.Property(us=>us.Name).IsRequired().HasMaxLength(200);
            builder.Property(us=>us.Username).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);

            builder
                .HasMany(us=>us.Contacts)
                .WithOne(co=>co.User)
                .HasForeignKey(co=>co.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(us=>us.Interactions)
                .WithOne(it=>it.User)
                .HasForeignKey(it=>it.UserId)
                .IsRequired();

            builder
                .HasOne(us=>us.UserRole)
                .WithMany()
                .HasForeignKey(us=>us.UserRoleId)
                .IsRequired();

        }
    }
}