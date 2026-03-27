

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEventAssos.Domain.Models;

namespace ProjectEventAssos.Infrastucture.DataBase.Config
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(t =>
                t.HasCheckConstraint("CK_User_Email_Format", "Email LIKE '%_@%_.%_'"));

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Role)
                .IsRequired();

            builder.Property<DateOnly?>(u => u.BirthDate);

            builder.Property(u => u.UserName)
                .HasMaxLength(50);

            builder.Property(u => u.Gender)
                .HasMaxLength(1);

            builder.HasData(
                new User {Id = Guid.NewGuid(),RoleId = 1, Email = "Madame.Dupont@gmail.com",UserName = "MadameDupont",Password = "test1234=",BirthDate = new DateOnly(2000,07,25),Gender = 'F'}
                );
        }
    }

}
