using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//Registra o serviço de banco de dados na aplicação
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options => 
    options.AddPolicy("Acesso Total", 
        configs => configs
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
);

var app = builder.Build();

//EndPoints - Funcionalidades
//POST: http://localhost:5217/pages/aluno/cadastrar
//CADASTRO DE ALUNO
app.MapPost("/pages/aluno/cadastrar",
    ([FromBody] Academia academia,
    [FromServices] AppDataContext ctx) =>
{
    //Validação dos atributos do produto
    List<ValidationResult> erros = new
        List<ValidationResult>();
    if (!Validator.TryValidateObject(
        academia, new ValidationContext(academia),
        erros, true))
    {
        return Results.BadRequest(erros);
    }

    //RN: Não permitir produtos com o mesmo nome
    Academia? procuraUsuario = ctx.Academias.
        FirstOrDefault(x => x.Nome == academia.Nome);
    if (procuraUsuario is not null)
    {
        return Results.
            BadRequest("Já existe um produto com o mesmo nome!");
    }

    academia.Aluno = ctx.Alunos.
        Find(academia.AlunoId);
    //Adicionar o produto dentro do banco de dados
    ctx.Academias.Add(academia);
    ctx.SaveChanges();
    return Results.Created("", academia);
});

//POST: http://localhost:5217/pages/imc/cadastrar
//CADASTRO DO IMC
app.MapPost("/pages/imc/cadastrar",
    ([FromBody] Aluno aluno,
    [FromServices] AppDataContext ctx) =>
{

    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created("", aluno);
});

//GET: http://localhost:5217/pages/imc/listar
//LISTAR IMC
app.MapGet("/pages/imc/listar",
    ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Alunos.Any())
    {
        return Results.Ok(ctx.Alunos.ToList());
    }
    return Results.NotFound("Tabela vazia!");
});

//GET: http://localhost:5217/pages/imc/listarporaluno
//LISTAR IMC POR ALUNO
app.MapGet("/pages/imc/listarporaluno",
    ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Academias.Any())
    {
        return Results.Ok(ctx.Academias.ToList());
    }
    return Results.NotFound("Tabela vazia!");
});

//PUT: http://localhost:5217/pages/imc/alterar/id_do_produto
//ALTERAR IMC 
app.MapPut("/pages/imc/alterar/{id}",
    ([FromRoute] string id,
    [FromBody] Academia alterarAluno,
    [FromServices] AppDataContext ctx) =>
{
    Academia? academia = ctx.Academias.Find(id);
    if (academia is null)
    {
        return Results.
            NotFound("Produto não encontrado!");
    }
    academia.Nome = alterarAluno.Nome;
    academia.Idade = alterarAluno.Idade;
    academia.Peso = alterarAluno.Peso;
    academia.Altura = alterarAluno.Altura;

    ctx.Academias.Update(academia);
    ctx.SaveChanges();
    return Results.
        Ok("IMC alterado com sucesso!");
});



app.UseCors("Acesso Total");
app.Run();
