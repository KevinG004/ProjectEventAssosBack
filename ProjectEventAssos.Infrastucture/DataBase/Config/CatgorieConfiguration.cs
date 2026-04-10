using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.DataBase.Config
{
    public class CatgorieConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(512);

            builder.HasData(
                new Categorie { Id = 1, Name = "Concert" },
                new Categorie { Id = 2, Name = "Conférence" },
                new Categorie { Id = 3, Name = "Atelier" },
                new Categorie { Id = 4, Name = "Jazz" },
                new Categorie { Id = 5, Name = "Rock" },
                new Categorie { Id = 6, Name = "Classique" },
                new Categorie { Id = 7, Name = "Théâtre" },
                new Categorie { Id = 8, Name = "Comédie" },
                new Categorie { Id = 9, Name = "Danse" },
                new Categorie { Id = 10, Name = "Cinéma" },
                new Categorie { Id = 11, Name = "Exposition" },
                new Categorie { Id = 12, Name = "Photographie" },
                new Categorie { Id = 13, Name = "Gastronomie" },
                new Categorie { Id = 14, Name = "Sport" },
                new Categorie { Id = 15, Name = "Yoga" },
                new Categorie { Id = 16, Name = "Randonnée" },
                new Categorie { Id = 17, Name = "Jeux" },
                new Categorie { Id = 18, Name = "Littérature" },
                new Categorie { Id = 19, Name = "Musique" },
                new Categorie { Id = 20, Name = "Bien-être" }
            );
        }
    }
}
