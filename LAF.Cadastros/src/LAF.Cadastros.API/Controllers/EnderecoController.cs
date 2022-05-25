﻿using LAF.Cadastros.API.ViewModel;
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
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_enderecoApplication.ObterTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            return Ok(_enderecoApplication.ObterPorId(id));
        }

        [HttpGet("filtros/{logradouro}")]
        public IActionResult ObterPorLogradouro(string logradouro)
        {
            return Ok(_enderecoApplication.Buscar(endereco => endereco.Logradouro == logradouro));
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
        public IActionResult Deletar (Guid id)
        {
            Endereco endereco = new Endereco()
            {
                Id = id,
                
            };
            _enderecoApplication.Deletar(endereco);

            return NoContent();

           
        }
    }
    
}
