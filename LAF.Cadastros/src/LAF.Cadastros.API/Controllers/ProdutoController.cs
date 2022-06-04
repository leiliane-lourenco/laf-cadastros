using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Application;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;
        private readonly IFornecedorApplication _fornecedorApplication;
        public ProdutoController(
            IProdutoApplication produtoApplication, 
            IFornecedorApplication fornecedorApplication)
        {
            _produtoApplication = produtoApplication;
            _fornecedorApplication = fornecedorApplication;
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

            Produto produto = _produtoApplication.Buscar(produto => produto.Nome == produtoPostViewModel.Nome).FirstOrDefault();
            if (produto != null)
                return BadRequest("Produto já cadastrado");

            Fornecedor fornecedor = _fornecedorApplication.ObterPorId(produtoPostViewModel.FornecedorId);

            if (fornecedor == null)
                return BadRequest("Fornecedor não cadastrado!");

            if (String.IsNullOrWhiteSpace(produtoPostViewModel.Nome))
                return BadRequest("Campo nome deve estar preenchido!");

            if (String.IsNullOrWhiteSpace(produtoPostViewModel.Descricao))
                return BadRequest("Campor descrição deve estar preenchido");

            if (produtoPostViewModel.Valor < 1)
                return BadRequest("O valor do produto deve ser maior que zero");

            produto = new Produto()
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
            Produto produto = _produtoApplication.ObterPorId(id);

            if (id == null)
                return BadRequest("Produto não existe no banco de dados!");

            produto = new Produto()
            {
                Id = id,
                FornecedorId = produtoPutViewModel.FornecedorId,
                Nome = produtoPutViewModel.Nome,
                Descricao = produtoPutViewModel.Descricao,
                Valor = produtoPutViewModel.Valor,
                Ativo = produtoPutViewModel.Ativo

            };

            if(String.IsNullOrWhiteSpace(produtoPutViewModel.Nome))
                return BadRequest("O campo nome deve ser preenchido!");

            if (String.IsNullOrWhiteSpace(produtoPutViewModel.Descricao))
                return BadRequest("O campo descricão deve ser preenchido!");

            if (produtoPutViewModel.Valor <= 0)
                return BadRequest("O valor do produto deve ser maior que zero!");

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
