using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Enum;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _fornecedorApplication.ObterTodos());

        }
        [HttpGet("filtros/{documento}")]
        public async Task<IActionResult> ObterPorDocumento(string documento)
        {
            return Ok(await _fornecedorApplication.Buscar(fornecedor => fornecedor.Documento == documento));
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(FornecedorPostViewModel fornecedorPostViewModel)
        {
            IEnumerable <Fornecedor> fornecedores = await _fornecedorApplication.Buscar
                (fornecedor => fornecedor.Documento == fornecedorPostViewModel.Documento);

            Fornecedor fornecedor = fornecedores.FirstOrDefault();

            if (fornecedor != null)
                return BadRequest("Fornecedor já cadastrado");

            fornecedor = new Fornecedor()
            {
                Documento = fornecedorPostViewModel.Documento,
                Ativo = fornecedorPostViewModel.Ativo,
                Nome = fornecedorPostViewModel.Nome,
                TipoFornecedor = (TipoFornecedor)fornecedorPostViewModel.TipoFornecedor
            };

            if (String.IsNullOrWhiteSpace(fornecedorPostViewModel.Documento))
                return BadRequest("Campo Documento deve estar preenchido!");

            if (String.IsNullOrEmpty(fornecedorPostViewModel.Nome))
                return BadRequest("Campo Nome deve estar preenchido!");

            if (fornecedorPostViewModel.TipoFornecedor < 1 || fornecedorPostViewModel.TipoFornecedor > 2)
                return BadRequest("Informe 1-Pessoa Jurídica ou 2-Pessoa Física");

            if (!fornecedorPostViewModel.Ativo)
                BadRequest("Para inserir um novo fornecedor o mesmo dever estar ativo!!");

            _fornecedorApplication.Adicionar(fornecedor);
            return Ok(fornecedor);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] FornecedorPutViewModel fornecedorPutViewModel)
        {
            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(id);

            if (fornecedor == null)
                return NotFound("Fornecedor não encontrado!");

            fornecedor = new Fornecedor
            {
                Nome = fornecedorPutViewModel.Nome,
                TipoFornecedor = (TipoFornecedor)fornecedorPutViewModel.TipoFornecedor,
                Ativo = fornecedorPutViewModel.Ativo

            };

            await _fornecedorApplication.Alterar(fornecedor);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Id = id,

            };

            await _fornecedorApplication.Deletar(fornecedor);

            return Ok();
        }
    }
}
