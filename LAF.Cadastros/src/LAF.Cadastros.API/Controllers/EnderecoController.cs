using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpPost]
        public IActionResult Adicionar(EnderecoPostViewModel enderecoPostViewModel)
        {
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

            _enderecoApplication.Adicionar(endereco);

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
        public IActionResult Deletar (Guid id, EnderecoDeleteViewModel enderecoDeleteViewModel)
        {
            Endereco endereco = new Endereco()
            {
                Id = id,
                FornecedorId = enderecoDeleteViewModel.FornecedorId,
                Logradouro = enderecoDeleteViewModel.Logradouro,
                Numero = enderecoDeleteViewModel.Numero,
                Complemento = enderecoDeleteViewModel.Complemento,
                Cep = enderecoDeleteViewModel.Cep,
                Bairro = enderecoDeleteViewModel.Bairro,
                Cidade = enderecoDeleteViewModel.Cidade,
                Estado = enderecoDeleteViewModel.Estado,

            };
            _enderecoApplication.Deletar(endereco);

            return NoContent();

           
        }
    }
    
}
