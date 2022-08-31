using Microsoft.EntityFrameworkCore;
using Escola.Domain.Models;
using Escola.Infra.Database.Mappings;

namespace Escola.Infra.Database {
    
    public class EscolaDbContexto : DbContext {
        public DbSet<Aluno> Alunos {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer("Password=YourStrong@Password;Persist Security Info=True;User ID=sa;Initial Catalog=EscolaDB;Data Source=tcp:localhost,1433");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }
    }
}