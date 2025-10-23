using Microsoft.AspNetCore.Mvc;
using System.Net;
using Totvs.TesteFullStack.API.Entities;
using Totvs.TesteFullStack.API.Infrastructure;
using Totvs.TesteFullStack.API.Repositories;
using Totvs.TesteFullStack.API.Services;

namespace Totvs.TesteFullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController(IProdutoService produtoService) : ControllerBase
    {
        private readonly IProdutoService _produtoService = produtoService;

        [HttpGet]
        [Route("/buscarProdutosCadastrados")]
        public async Task<IActionResult> BuscarProdutosCadastrados()
        {
            var (retorno, response) = await _produtoService.BuscarProdutosCadastradosAsync();

            if (!retorno.ResultadoOperacao)
            {
                return retorno.Codigo switch
                {
                    404 => NotFound(retorno),
                    500 => StatusCode((int)HttpStatusCode.InternalServerError, retorno),
                    _ => BadRequest(retorno)
                };
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("/{id}/buscarProdutoPeloId")]
        public async Task<IActionResult> BuscarProdutoPeloId(int id)
        {
            if (id < 0)
            {
                return BadRequest(new Retorno(false, 400, "Id inválido"));
            }

            var (retorno, response) = await _produtoService.BuscarProdutoPeloIdAsync(id);

            if (!retorno.ResultadoOperacao)
            {
                return retorno.Codigo switch
                {
                    404 => NotFound(retorno),
                    500 => StatusCode((int)HttpStatusCode.InternalServerError, retorno),
                    _ => BadRequest(retorno)
                };
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("/novoProduto")]
        public async Task<IActionResult> NovoProduto([FromBody] Produtos produto)
        {
            var retorno = await _produtoService.NovoProdutoAsync(produto);

            if (!retorno.ResultadoOperacao)
            {
                return retorno.Codigo switch
                {
                    500 => StatusCode((int)HttpStatusCode.InternalServerError, retorno),
                    _ => BadRequest(retorno)
                };
            }

            return Ok(retorno);
        }

        [HttpPut]
        [Route("/atualizarProduto")]
        public async Task<IActionResult> AtualizarProduto([FromBody] Produtos produto)
        {
            var retorno = await _produtoService.AtualizarProdutoAsync(produto);

            if (!retorno.ResultadoOperacao)
            {
                return retorno.Codigo switch
                {
                    500 => StatusCode((int)HttpStatusCode.InternalServerError, retorno),
                    _ => BadRequest(retorno)
                };
            }

            return Ok(retorno);
        }

        [HttpDelete]
        [Route("/{id}/removerProduto")]
        public async Task<IActionResult> RemoverProduto(int id)
        {
            if (id < 0)
            {
                return BadRequest(new Retorno(false, 400, "Id inválido"));
            }

            var retorno = await _produtoService.RemoverProdutoAsync(id);

            if (!retorno.ResultadoOperacao)
            {
                return retorno.Codigo switch
                {
                    404 => NotFound(retorno),
                    500 => StatusCode((int)HttpStatusCode.InternalServerError, retorno),
                    _ => BadRequest(retorno)
                };
            }

            return Ok(retorno);
        }
    }
}
