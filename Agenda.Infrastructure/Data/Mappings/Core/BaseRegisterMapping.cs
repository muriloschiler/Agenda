using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Data.Mappings.Core
{
    public abstract class BaseRegisterMapping<T> : IEntityTypeConfiguration<T>
    where T : Register
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(re=>re.Id);
            builder.Property(re=>re.CreatedAt).HasColumnType("datetime2");
            builder.Property(re=>re.UpdatedAt).HasColumnType("datetime2");
            ConfigureOtherProperties(builder);
        }
        public abstract void ConfigureOtherProperties(EntityTypeBuilder<T> builder);
    }
}