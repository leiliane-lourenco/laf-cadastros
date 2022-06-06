using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAF.Cadastros.Application
{
    public class EnderecoApplication : IEnderecoApplication
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoApplication (IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public async Task<IEnumerable<Endereco>> ObterTodos()
        {
            return await _enderecoRepository.ObterTodos();
        }
        public async Task<Endereco> ObterPorId(Guid id)
        {
            return await _enderecoRepository.ObterPorId(id);
        }
        public async Task<IEnumerable<Endereco>> Buscar(Expression<Func<Endereco, bool>> where)
        {
            return (await _enderecoRepository.Buscar(where));
        }
        public async Task Adicionar(Endereco endereco)
        {
            await _enderecoRepository.Adicionar(endereco);
        }
        public async Task Alterar(Endereco endereco)
        {
            await _enderecoRepository.Alterar(endereco);
        }
        public async Task Deletar(Endereco endereco)
        {
            await _enderecoRepository.Deletar(endereco);
        }
    }
}
