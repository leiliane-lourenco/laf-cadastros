using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoApplication _enderecoApplication;
        private readonly IFornecedorApplication _fornecedorApplication;
        public EnderecoController(
            IEnderecoApplication enderecoApplication, 
            IFornecedorApplication fornecedorApplication)
        {
            _enderecoApplication = enderecoApplication;
            _fornecedorApplication = fornecedorApplication;
        }
        [HttpGet]
        public async Task<IActionResult>  ObterTodos()
        {
            return Ok(await _enderecoApplication.ObterTodos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await _enderecoApplication.ObterPorId(id));
        }

        [HttpGet("filtros/{logradouro}")]
        public async Task<IActionResult> ObterPorLogradouro(string logradouro)
        {
            return Ok( await _enderecoApplication.Buscar(endereco => endereco.Logradouro == logradouro));
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(EnderecoPostViewModel enderecoPostViewModel)
        {
            IEnumerable<Endereco> enderecos = await _enderecoApplication.Buscar
                   (endereco => endereco.FornecedorId == enderecoPostViewModel.FornecedorId);

            Endereco endereco = enderecos.FirstOrDefault();

            if (endereco != null)
                return BadRequest("Fornecedor já possui um  endereço cadastrado");

            Fornecedor fornecedor = await _fornecedorApplication.ObterPorId(enderecoPostViewModel.FornecedorId);

            if (fornecedor == null)
                return BadRequest("Fornecedor não cadastrado!");

            if (string.IsNullOrWhiteSpace(enderecoPostViewModel.Logradouro))
                return BadRequest("Campo Logradouro deve estar preenchido");

            if (enderecoPostViewModel.Numero < 1)
                return BadRequest("Campo Numero deve estar preenchido");

            if (string.IsNullOrWhiteSpace(enderecoPostViewModel.Cep))
                return BadRequest("Campo Cep deve estar preenchido");

            if (string.IsNullOrWhiteSpace(enderecoPostViewModel.Bairro))
                return BadRequest("Campo Bairro deve estar preenchido");

            if (string.IsNullOrWhiteSpace(enderecoPostViewModel.Cidade))
                return BadRequest("Campo Cidade deve estar preenchido");

            if (string.IsNullOrWhiteSpace(enderecoPostViewModel.Estado))
                return BadRequest("Campo Estado deve estar preenchido");


            endereco = new Endereco()
            {
                FornecedorId = enderecoPostViewModel.FornecedorId,
                Logradouro = enderecoPostViewModel.Logradouro,
                Numero = enderecoPostViewModel.Numero,
                Complemento = enderecoPostViewModel.Complemento,
                Cep = enderecoPostViewModel.Cep,
                Bairro = enderecoPostViewModel.Bairro,
                Cidade = enderecoPostViewModel.Cidade,
                Estado = enderecoPostViewModel.Estado,

            };

            await _enderecoApplication.Adicionar(endereco);

            return Ok(endereco);
        }
        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, [FromBody] EnderecoPutViewModel enderecoPutViewModel)
        {
            Endereco endereco = new Endereco()
            {
                Id = id,
                FornecedorId = enderecoPutViewModel.FornecedorId,
                Logradouro = enderecoPutViewModel.Logradouro,
                Numero = enderecoPutViewModel.Numero,
                Complemento = enderecoPutViewModel.Complemento,
                Cep = enderecoPutViewModel.Cep,
                Bairro = enderecoPutViewModel.Bairro,
                Cidade = enderecoPutViewModel.Cidade,
                Estado = enderecoPutViewModel.Estado,

            };
            _enderecoApplication.Alterar(endereco);

            return Ok(endereco);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar (Guid id)
        {
            Endereco endereco = new Endereco()
            {
                Id = id,
                
            };
             await _enderecoApplication.Deletar(endereco);

            return NoContent();

           
        }
    }
    
}
