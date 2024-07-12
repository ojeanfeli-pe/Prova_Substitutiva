namespace API.Models;
public class Aluno{
    public Aluno(){
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    public string Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public DateTime CriadoEm { get; set; }
}