using Totvs.TesteFullStack.API.Entities;
using Totvs.TesteFullStack.API.Repositories;

namespace Totvs.TesteFullStack.API.Services
{
    public class ProdutoService(IProdutoRepository produtoRepository) : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;


        public async Task<(Retorno retorno, IEnumerable<Produtos>? produtos)> BuscarProdutosCadastradosAsync()
        {
            return await _produtoRepository.BuscarProdutosCadastradosAsync();
        }

        public async Task<(Retorno retorno, Produtos? produto)> BuscarProdutoPeloIdAsync(int id)
        {
            return await _produtoRepository.BuscarProdutoPeloIdAsync(id);
        }

        public async Task<Retorno> NovoProdutoAsync(Produtos produto)
        {
            return await _produtoRepository.NovoProdutoAsync(produto);
        }

        public async Task<Retorno> AtualizarProdutoAsync(Produtos produto)
        {
            return await _produtoRepository.AtualizarProdutoAsync(produto);
        }

        public async Task<Retorno> RemoverProdutoAsync(int id)
        {
            return await _produtoRepository.RemoverProdutoAsync(id);
        }






    }
}
