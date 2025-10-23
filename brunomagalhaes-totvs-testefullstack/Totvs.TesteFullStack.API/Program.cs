using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Totvs.TesteFullStack.API.Entities;
using Totvs.TesteFullStack.API.Infrastructure;
using Totvs.TesteFullStack.API.Repositories;
using Totvs.TesteFullStack.API.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

builder.Services.AddControllers();
builder.Services.AddDbContext<CatalogoDbContext>(db =>
{
    db.UseSqlite(connection);
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddEndpointsApiExplorer(); // necessário mesmo com controllers
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API de Produtos",
        Version = "v1",
        Description = "Exemplo .NET 9 Web API com controllers"
    });
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200", "https://localhost:44362/", "http://localhost:5066"));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.RoutePrefix = string.Empty;
    });
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CatalogoDbContext>();
    db.Database.EnsureCreated();

    db.Produto.AddRange(
        new Produtos { Nome = "ERP", Preco = 500m },
        new Produtos { Nome = "TOTVS", Preco = 500.0m }
    );
    db.SaveChanges();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
