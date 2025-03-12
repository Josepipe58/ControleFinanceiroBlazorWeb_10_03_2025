using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    public class AnoConfiguration : IEntityTypeConfiguration<Ano>
    {
        public void Configure(EntityTypeBuilder<Ano> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.AnoDoCadastro).IsRequired();
        }
    }
}
