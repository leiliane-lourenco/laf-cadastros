using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LAF.Cadastros.Application
{
    public class EnderecoApplication : IEnderecoApplication
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoApplication (IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public IEnumerable<Endereco> ObterTodos()
        {
            return _enderecoRepository.ObterTodos();
        }
        public Endereco ObterPorId(Guid id)
        {
            return _enderecoRepository.ObterPorId(id);
        }
        public IEnumerable<Endereco> Buscar(Expression<Func<Endereco, bool>> where)
        {
            return (_enderecoRepository.Buscar(where));
        }
        public void Adicionar(Endereco endereco)
        {
            _enderecoRepository.Adicionar(endereco);
        }
        public void Alterar(Endereco endereco)
        {
            _enderecoRepository.Alterar(endereco);
        }
        public void Deletar(Endereco endereco)
        {
            _enderecoRepository.Deletar(endereco);
        }
    }
}
