

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectEventAssos.Domain.Models;
using ProjectEventAssos.SecurityTools.Tools;

namespace ProjectEventAssos.Infrastucture.DataBase.Config
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hash = new HashPassword();
            var hashedPassword = hash.PasswordHash("Test1234=");
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

            builder.Property<DateOnly?>(u => u.BirthDate);

            builder.Property(u => u.UserName)
                .HasMaxLength(50);

            builder.Property(u => u.Gender)
                .HasMaxLength(1);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();
        }
    }
}
