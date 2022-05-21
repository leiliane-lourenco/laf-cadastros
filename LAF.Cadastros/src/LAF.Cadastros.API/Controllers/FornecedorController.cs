using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpPost]
        public IActionResult Adicionar(FornecedorPostViewModel fornecedorPostViewModel)
        {
            //checar se estão todos preenchidos

            Fornecedor fornecedor = new Fornecedor()
            {
                Documento = fornecedorPostViewModel.Documento,
                Ativo = fornecedorPostViewModel.Ativo,
                Nome = fornecedorPostViewModel.Nome,
                TipoFornecedor = fornecedorPostViewModel.TipoFornecedor

            };

            _fornecedorApplication.Adicionar(fornecedor);

            return Ok(fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] FornecedorPutViewModel fornecedorPutViewModel)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Id = id,
                Nome = fornecedorPutViewModel.Nome,
                Documento = fornecedorPutViewModel.Documento,
                TipoFornecedor = fornecedorPutViewModel.TipoFornecedor,
                Ativo = fornecedorPutViewModel.Ativo
            };

            _fornecedorApplication.Alterar(fornecedor);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id, FornecedorDeleteViewModel fornecedorDeleteViewModel)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Id = id,
                Nome = fornecedorDeleteViewModel.Nome,
                Documento = fornecedorDeleteViewModel.Documento,
                TipoFornecedor = fornecedorDeleteViewModel.TipoFornecedor,
                Ativo = fornecedorDeleteViewModel.Ativo
            };

            _fornecedorApplication.Deletar(fornecedor);

            return NoContent();
        }
    }
}
