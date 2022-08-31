using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Database.Mappings {

    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("ALUNO");

            builder.HasKey(x => x.Id)
                   .HasName("PK_AlunoID");

            builder.Property(x => x.Id)
                   .HasColumnName("ID")
                   .HasColumnType("uniqueidentifier");

            builder.Property(x => x.Email)
                   .HasColumnName("EMAIL")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(200);
            
            builder.Property(x => x.Nome)
                   .HasColumnName("NOME")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(80);

            builder.Property(x => x.Sobrenome)
                   .HasColumnName("SOBRENOME")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(150);
            
            builder.Property(x => x.DataNascimento)
                   .HasColumnName("DATA_NASCIMENTO")
                   .HasColumnType("DATE");

            builder.Property(x => x.Matricula)
                   .HasColumnName("Matricula")
                   .HasColumnType("int");

            builder.HasIndex(x => x.Matricula)
                   .IsUnique();
       
        }
    }
}