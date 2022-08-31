

using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Database.Mappings {

    public class TurmaMap : IEntityTypeConfiguration<Turma> {

        public void Configure (EntityTypeBuilder<Turma> builder) {
            
            builder.ToTable("TURMA");

            builder.HasKey("Id")
                   .HasName("PK_TurmaId");

            builder.Property(t => t.Id)
                   .HasColumnType("int");

            builder.Property(t => t.Curso)
                   .HasColumnName("CURSO")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasMany<Aluno>(t => t.Alunos)
                   .WithMany(a => a.Turmas); 
        }
    }
}