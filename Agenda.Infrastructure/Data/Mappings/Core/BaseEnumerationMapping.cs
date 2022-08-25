using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Data.Mappings.Core
{
    public abstract class BaseEnumerationMapping<T> : IEntityTypeConfiguration<T>
    where T : Enumeration
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(en => en.Id);
            builder.Property(en=> en.Name).HasColumnType("Varchar(30)").IsRequired();
            ConfigureOtherProperties(builder);
        }

        public abstract void ConfigureOtherProperties(EntityTypeBuilder<T> builder);
    }
}