using Microsoft.EntityFrameworkCore;
namespace API.Models;

//Classe que representa o EF dentro do projeto
public class AppDataContext : DbContext
{
    //Classes que vão representar as tabelas
    //no banco de dados
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Academia> Academias { get; set; }

    
    
    //Configurando a string de conexão
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=jean.db");
    }
}
