using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Totvs.TesteFullStack.API.Entities;

namespace Totvs.TesteFullStack.API.Infrastructure
{
    public class CatalogoDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Produtos> Produto => Set<Produtos>();
    }
}
