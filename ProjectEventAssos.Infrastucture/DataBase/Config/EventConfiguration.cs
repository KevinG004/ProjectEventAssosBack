using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEventAssos.Domain.Enum;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.DataBase.Config
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable(E => {
                E.HasCheckConstraint("CK_Event_MinParticipant","[MinParticipants] >= 1");
                E.HasCheckConstraint("CK_Event_MaxParticipant", "[MaxParticipants] <=200");
                E.HasCheckConstraint("CK_Event_MinMaxParticipant", "[MinParticipants] <= [MaxParticipants]");
                E.HasCheckConstraint("CK_Event_DateFinishStart", "[DateTimeFinish] > [DateTimeStart]");
                E.HasCheckConstraint("CK_Event_DateLimite", "[DateLimiteInscription] <= [DateTimeStart]");
                });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired();

            builder.Property(e => e.Place)
                .HasMaxLength(128);

            builder.Property(e => e.DateTimeStart)
                .IsRequired();

            builder.Property(e => e.DateTimeFinish)
                .IsRequired();

            builder.Property(e => e.MinParticipants)
                .IsRequired();

            builder.Property(e => e.MaxParticipants)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValue(StatusEvent.EnAttente);

            builder.Property(e => e.WaitList)
                .IsRequired();

            builder.Property(e => e.DateLimiteInscription)
                .IsRequired();

            builder.Property(e => e.CreationDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.MajDate) 
                .IsRequired();

            builder.Property(e => e.CoverImage)
                .HasColumnType("varbinary(max)");

            builder.HasOne(e => e.Categorie)
                .WithMany(e => e.Events)
                .HasForeignKey(e => e.CategorieId);

            builder.HasMany(e => e.Participants)
                .WithOne(p => p.Event)
                .HasForeignKey(p => p.EventId);

            builder.HasMany(e => e.ListWait)
                .WithOne(w => w.Event)
                .HasForeignKey(w => w.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
