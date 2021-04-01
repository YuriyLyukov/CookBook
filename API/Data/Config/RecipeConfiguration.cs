using API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Left).IsRequired();
            builder.Property(p => p.Right).IsRequired();
            builder.Property(p => p.DepthLevel).IsRequired();
            builder.Property(p => p.TreeId).IsRequired();
        }
    }
}