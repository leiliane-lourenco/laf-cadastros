﻿using LAF.Cadastros.API.ViewModel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

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

    }
    
}
