using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace API.Models;

public class Academia{
    public Academia(){
         Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    public Academia(string nome, string idade){
        Nome = nome;
        Idade = idade;
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? Idade { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }

    public DateTime CriadoEm { get; set; }
    public string? AlunoId { get; set; }
    public Aluno? Aluno { get; set; }
}