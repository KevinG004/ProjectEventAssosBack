using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.DataBase.Config
{
    public class ParticipateEventConfiguration : IEntityTypeConfiguration<ParticipateEvent>
    {
        public void Configure(EntityTypeBuilder<ParticipateEvent> builder)
        {
            builder.HasKey(p => new { p.EventId, p.UserId });
        }
    }
}
