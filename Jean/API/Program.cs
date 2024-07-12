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
//GET: http://localhost: /api/





app.UseCors("Acesso Total");
app.Run();
