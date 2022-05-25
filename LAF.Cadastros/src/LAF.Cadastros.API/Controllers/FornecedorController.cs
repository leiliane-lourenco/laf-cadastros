using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/fornecedores")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplication _fornecedorApplication;

        public FornecedorController(IFornecedorApplication fornecedorApplication)
        {
            _fornecedorApplication = fornecedorApplication;
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            Fornecedor fornecedor = _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }
        [HttpGet]
        public IActionResult ObterTodos(Guid id)
        {
            return Ok(_fornecedorApplication.ObterTodos());

        }
        [HttpGet("filtros/{documento}")]
        public IActionResult ObterPorDocumento(string documento)
        {
            return Ok(_fornecedorApplication.Buscar(fornecedor => fornecedor.Documento == documento));
        }

        [HttpPost]
        public IActionResult Adicionar(FornecedorPostViewModel fornecedorPostViewModel)
        {
            Fornecedor fornecedor = _fornecedorApplication.Buscar(fornecedor => fornecedor.Documento ==
                                                                  fornecedorPostViewModel.Documento).FirstOrDefault();
            if (fornecedor != null)
                return BadRequest("Fornecedor já cadastrado");

            fornecedor = new Fornecedor()
            {
                Documento = fornecedorPostViewModel.Documento,
                Ativo = fornecedorPostViewModel.Ativo,
                Nome = fornecedorPostViewModel.Nome,
                TipoFornecedor = fornecedorPostViewModel.TipoFornecedor

            };
            if (String.IsNullOrWhiteSpace(fornecedorPostViewModel.Documento))
            return BadRequest("Campo Documento deve estar preenchido!");

            if (String.IsNullOrEmpty(fornecedorPostViewModel.Nome)) 
            return BadRequest("Campo Nome deve estar preenchido!");

            if (fornecedorPostViewModel.TipoFornecedor != 1 || fornecedorPostViewModel.TipoFornecedor != 2) 
            return BadRequest("Informe 1-Pessoa Jurídica ou 2-Pessoa Física");

            _fornecedorApplication.Adicionar(fornecedor);
            return Ok(fornecedor);

        }

        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] FornecedorPutViewModel fornecedorPutViewModel)
        {
            Fornecedor fornecedor = _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null) return NotFound("Fornecedor não encontrado!");

            fornecedor.Nome = fornecedorPutViewModel.Nome;
            fornecedor.TipoFornecedor = fornecedorPutViewModel.TipoFornecedor;
            fornecedor.Ativo = fornecedorPutViewModel.Ativo;

            _fornecedorApplication.Alterar(fornecedor);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Id = id,

            };

            _fornecedorApplication.Deletar(fornecedor);

            return Ok();
        }
    }
}
