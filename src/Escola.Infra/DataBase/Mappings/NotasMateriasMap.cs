

using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Database.Mappings {

    public class NotasMateriasMap : IEntityTypeConfiguration<NotasMaterias> {

        public void Configure(EntityTypeBuilder<NotasMaterias> builder){
            
            builder.ToTable("NOTAS_MATERIAS");

            builder.HasKey("Id")
                   .HasName("PK_NotasMateriasId");

            builder.Property(nm => nm.Id)
                   .HasColumnName("ID")
                   .HasColumnType("int");

            builder.Property(nm => nm.Nota)
                   .HasColumnName("NOTA")
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne<Boletim>(nm => nm.Boletim)
                   .WithMany(b => b.NotasMaterias)
                   .HasForeignKey(nm => nm.BoletimId);

            builder.HasOne<Materia>(nm => nm.Materia)
                   .WithMany(m => m.NotasMaterias)
                   .HasForeignKey(nm => nm.MateriaId);
                    
        }
    }
}