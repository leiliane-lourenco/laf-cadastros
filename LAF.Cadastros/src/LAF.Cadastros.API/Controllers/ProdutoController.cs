using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Application;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _produtoApplication.ObterTodos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Produto produto =  await _produtoApplication.ObterPorId(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }
        [HttpGet("filtros/{nome}")]
        public async Task<IActionResult> Buscar(string nome)
        {
            return Ok(await _produtoApplication.Buscar(produto => produto.Nome == nome));
        }
        [HttpPost]
        public async Task<IActionResult> Adicionar(ProdutoPostViewModel produtoPostViewModel)
        {

            IEnumerable<Produto> produtos = await _produtoApplication.Buscar
                (produto => produto.Nome == produtoPostViewModel.Nome);

            Produto produto = produtos.FirstOrDefault();
            
            if (produto != null)
                return BadRequest("Produto já cadastrado");

            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(produtoPostViewModel.FornecedorId);

            if (fornecedor == null)
                return BadRequest("Fornecedor não cadastrado!");

            if (string.IsNullOrWhiteSpace(produtoPostViewModel.Nome))
                return BadRequest("Campo nome deve estar preenchido!");

            if (string.IsNullOrWhiteSpace(produtoPostViewModel.Descricao))
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

            await _produtoApplication.Adicionar(produto);

            return Ok(produto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] ProdutoPutViewModel produtoPutViewModel)
        {
            Produto produto =  await _produtoApplication.ObterPorId(id);

            if (id == null)
                return BadRequest("Produto não existe no banco de dados!");

            if(string.IsNullOrWhiteSpace(produtoPutViewModel.Nome))
                return BadRequest("O campo nome deve ser preenchido!");

            if (string.IsNullOrWhiteSpace(produtoPutViewModel.Descricao))
                return BadRequest("O campo descricão deve ser preenchido!");

            if (produtoPutViewModel.Valor <= 0)
                return BadRequest("O valor do produto deve ser maior que zero!");

            produto = new Produto()
            {
                Nome = produtoPutViewModel.Nome,
                Descricao = produtoPutViewModel.Descricao,
                Valor = produtoPutViewModel.Valor,

            };

             await _produtoApplication.Alterar(produto);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            Produto produto = new Produto()
            {
                Id = id,
            };

            await _produtoApplication.Deletar(produto);
            return NoContent();
           

        }
    }
}
