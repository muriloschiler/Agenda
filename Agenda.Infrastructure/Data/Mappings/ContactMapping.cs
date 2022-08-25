using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain;
using Agenda.Infrastructure.Data.Mappings.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Data.Mappings
{
    public class ContactMapping : BaseRegisterMapping<Contact>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contatos");
            builder.HasKey(co=>co.Id);

            builder.Property(co=>co.Name).HasColumnType("Varchar(100)").IsRequired();

            builder
                .HasMany(co=>co.Phones)
                .WithOne(ph=>ph.Contact)
                .HasForeignKey(ph=>ph.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}