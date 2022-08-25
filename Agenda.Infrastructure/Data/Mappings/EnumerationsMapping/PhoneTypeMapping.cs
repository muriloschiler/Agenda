using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Domain.Domain.Enumerations;
using Agenda.Infrastructure.Data.Mappings.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Data.Mappings.EnumerationsMapping
{
    public class PhoneTypeMapping : BaseEnumerationMapping<PhoneType>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<PhoneType> builder)
        {}
    }
}