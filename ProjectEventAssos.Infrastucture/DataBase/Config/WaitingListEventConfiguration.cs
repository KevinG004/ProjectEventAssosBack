using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.DataBase.Config
{
    public class WaitingListEventConfiguration : IEntityTypeConfiguration<WaitingListEvent>
    {
        public void Configure(EntityTypeBuilder<WaitingListEvent> builder)
        {
            builder.HasKey(w => new {w.EventId, w.UserId});

            builder.Property(w => w.InscriptionDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
