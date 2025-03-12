using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntitiesConfiguration
{
    public class EntityBaseConfiguration : IEntityTypeConfiguration<EntityBase>
    {
        public void Configure(EntityTypeBuilder<EntityBase> builder)
        {
            /*
            builder.HasKey(t => t.Id);

            //configura o tamanho máximo das propriedades que irão gerar colunas com tamanho correspondentes 
            builder.Property(p => p.NomeDaCategoria).HasMaxLength(80).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Autor).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Editora).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Formato).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Cor).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Origem).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Imagem).HasMaxLength(250).IsRequired();

            builder.Entity<EntityBase>().Property(p => p.Preco).HasPrecision(10, 2);
            */
        }
    }
}
