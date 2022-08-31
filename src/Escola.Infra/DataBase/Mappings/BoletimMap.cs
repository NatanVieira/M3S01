

using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Database.Mappings {

    public class BoletimMap : IEntityTypeConfiguration<Boletim> {
        
        public void Configure(EntityTypeBuilder<Boletim> builder){
            
            builder.ToTable("BOLETIM");

            builder.HasKey("Id")
                   .HasName("PK_BoletimID");
            
            builder.Property(x => x.Id)
                   .HasColumnName("ID")
                   .HasColumnType("int");

            builder.Property(x => x.OrderDate)
                   .HasColumnName("ORDE_DATE")
                   .HasColumnType("DATE");
            
            builder.HasOne<Aluno>(b => b.Aluno)
                   .WithMany(a => a.Boletins)
                   .HasForeignKey(b => b.AlunoId); 
        }
    }
}