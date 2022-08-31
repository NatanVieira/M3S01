

using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Database.Mappings {

    public class MateriaMap : IEntityTypeConfiguration<Materia> {

        public void Configure(EntityTypeBuilder<Materia> builder){
            
            builder.ToTable("MATERIA");

            builder.HasKey("Id")
                   .HasName("PK_MateriaID");
            
            builder.Property(m => m.Id)
                   .HasColumnName("ID")
                   .HasColumnType("int");
            
            builder.Property(m => m.Nome)
                   .HasColumnName("NOME")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();
        }
    }
}