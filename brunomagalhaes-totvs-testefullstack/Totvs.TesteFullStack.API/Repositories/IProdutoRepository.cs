using Totvs.TesteFullStack.API.Entities;

namespace Totvs.TesteFullStack.API.Repositories
{
    public interface IProdutoRepository
    {
        Task<(Retorno retorno, IEnumerable<Produtos>? produtos)> BuscarProdutosCadastradosAsync();
        Task<(Retorno retorno, Produtos? produto)> BuscarProdutoPeloIdAsync(int id);
        Task<Retorno> NovoProdutoAsync(Produtos produto);
        Task<Retorno> AtualizarProdutoAsync(Produtos produto);
        Task<Retorno> RemoverProdutoAsync(int id);
    }
}
