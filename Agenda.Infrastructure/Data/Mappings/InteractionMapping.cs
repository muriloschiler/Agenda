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
    public class InteractionMapping : BaseRegisterMapping<Interaction>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Interaction> builder)
        {
            builder.ToTable("Interacoes");
            builder.Property(it=>it.Message).HasColumnType("Char(22)").IsRequired();
        }
    }
}