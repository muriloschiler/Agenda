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
    public class PhoneMapping : BaseRegisterMapping<Phone>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Telefones");
            builder.HasKey(co=>co.Id);

            builder.Property(ph => ph.Description).HasColumnType("Varchar(50)");
            builder.Property(ph => ph.FormattedNumber).HasColumnType("Char(15)").IsRequired();
            builder.Property(ph => ph.DDD).HasColumnType("Char(2)").IsRequired();
            builder.Property(ph=>ph.Number).HasColumnType("Char(9)").IsRequired();

            builder
                .HasOne(ph => ph.PhoneType)
                .WithMany()
                .HasForeignKey(ph => ph.PhoneTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}