using Microsoft.EntityFrameworkCore;
using Escola.Domain.Models;
using Escola.Infra.Database.Mappings;

namespace Escola.Infra.Database {
    
    public class EscolaDbContexto : DbContext {
        public DbSet<Aluno> Alunos {get; set;}
        public DbSet<Boletim> Boletins {get; set;}
        public DbSet<Materia> Materias {get; set;}
        public DbSet<NotasMaterias> NotasMaterias {get; set;}
        public DbSet<Turma> Turmas {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer("Password=MyStrong@Password;Persist Security Info=True;User ID=sa;Initial Catalog=EscolaDB;Data Source=tcp:localhost,1433");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new BoletimMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());
            modelBuilder.ApplyConfiguration(new NotasMateriasMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
        }
    }
}