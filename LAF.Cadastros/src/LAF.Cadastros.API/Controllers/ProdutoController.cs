using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;
        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_produtoApplication.ObterTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            Produto produto = _produtoApplication.ObterPorId(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }
        [HttpGet("filtros/{nome}")]
        public IActionResult Buscar(string nome)
        {
            return Ok(_produtoApplication.Buscar(produto => produto.Nome == nome));
        }
        [HttpPost]
        public IActionResult Adicionar(ProdutoPostViewModel produtoPostViewModel)
        {
            Produto produto = new Produto()
            {
                FornecedorId = produtoPostViewModel.FornecedorId,
                Nome = produtoPostViewModel.Nome,
                Descricao = produtoPostViewModel.Descricao,
                Valor = produtoPostViewModel.Valor,
                Ativo = produtoPostViewModel.Ativo,

            };

            _produtoApplication.Adicionar(produto);

            return Ok(produto);
        }
        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] ProdutoPutViewModel produtoPutViewModel)
        {
            Produto produto = new Produto()
            {
                Id = id,
                FornecedorId = produtoPutViewModel.FornecedorId,
                Nome = produtoPutViewModel.Nome,
                Descricao = produtoPutViewModel.Descricao,
                Valor = produtoPutViewModel.Valor,
                Ativo = produtoPutViewModel.Ativo

            };
            _produtoApplication.Alterar(produto);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            Produto produto = new Produto()
            {
                Id = id,

            };
            _produtoApplication.Deletar(produto);
            return NoContent();


        }
    }
}
