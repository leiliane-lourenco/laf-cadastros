using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LAF.Cadastros.API.Controllers
{
    [Route("api/enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoApplication _enderecoApplication;
        public EnderecoController(IEnderecoApplication enderecoApplication)
        {
            _enderecoApplication = enderecoApplication;
        }
        [HttpGet]
        public async Task<IActionResult>  ObterTodos()
        {
            return Ok(await _enderecoApplication.ObterTodos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>  ObterPorId(Guid id)
        {
            return Ok(await _enderecoApplication.ObterPorId(id));
        }

        [HttpGet("filtros/{cidade}")]
        public async Task<IActionResult>  ObterPorLogradouro(string cidade)
        {
            return Ok( await _enderecoApplication.Buscar(endereco => endereco.Cidade == cidade));
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(EnderecoPostViewModel enderecoPostViewModel)
        {
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

            Endereco endereco = new Endereco()
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
