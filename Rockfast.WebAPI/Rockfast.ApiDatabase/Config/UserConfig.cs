using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rockfast.ApiDatabase.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(t => t.Todos)
                .WithOne()
                .HasForeignKey(t => t.UserId);
        }
    }
}
