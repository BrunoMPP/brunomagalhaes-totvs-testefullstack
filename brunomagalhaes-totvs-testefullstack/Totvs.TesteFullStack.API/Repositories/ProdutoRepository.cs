using Microsoft.EntityFrameworkCore;
using System;
using Totvs.TesteFullStack.API.Entities;
using Totvs.TesteFullStack.API.Infrastructure;

namespace Totvs.TesteFullStack.API.Repositories
{
    public class ProdutoRepository(CatalogoDbContext catalogoDbContext) : IProdutoRepository
    {
        private readonly CatalogoDbContext _context = catalogoDbContext;


        public async Task<(Retorno retorno, IEnumerable<Produtos>? produtos)> BuscarProdutosCadastradosAsync()
        {
            try
            {
                var lista = await _context.Produto.ToListAsync();

                if (!lista.Any())
                {
                    return (new Retorno(false, 404, "Nenhum produto cadastrado."), null);
                }

                return (new Retorno(true, 200, "Sucesso."), lista);
            }
            catch (Exception ex)
            {
                return (new Retorno(false, 500, $"Erro ao buscar produtos cadastrados. {ex.Message}"), null);
            }
        }

        public async Task<(Retorno retorno, Produtos? produto)> BuscarProdutoPeloIdAsync(int id)
        {
            try
            {
                var produto = await _context.Produto.FindAsync(id);

                if (produto == null)
                {
                    return (new Retorno(false, 404, "Produto não encontrado."), null);
                }

                return (new Retorno(true, 200, "Sucesso."), produto);
            }
            catch (Exception ex)
            {
                return (new Retorno(false, 500, $"Erro ao buscar produto pelo id. {ex.Message}"), null);
            }
        }

        public async Task<Retorno> NovoProdutoAsync(Produtos produto)
        {
            try
            {
                await _context.Produto.AddAsync(produto);
                await _context.SaveChangesAsync();


                return (new Retorno(true, 200, "Sucesso."));
            }
            catch (Exception ex)
            {
                return (new Retorno(false, 500, $"Erro ao criar novo produto. {ex.Message}"));
            }
        }

        public async Task<Retorno> AtualizarProdutoAsync(Produtos produto)
        {
            try
            {
                _context.Produto.Update(produto);
                await _context.SaveChangesAsync();

                return (new Retorno(true, 200, "Sucesso."));
            }
            catch (Exception ex)
            {
                return (new Retorno(false, 500, $"Erro ao atualizar produto. {ex.Message}"));
            }
        }

        public async Task<Retorno> RemoverProdutoAsync(int id)
        {
            try
            {
                var produto = await _context.Produto.FindAsync(id);
                if (produto == null)
                    return new Retorno(false, 404, "Id não encontrado.");


                _context.Produto.Remove(produto);
                await _context.SaveChangesAsync();

                return (new Retorno(true, 200, "Sucesso."));
            }
            catch (Exception ex)
            {
                return (new Retorno(false, 500, $"Erro ao remover produto. {ex.Message}"));
            }
        }
    }
}
