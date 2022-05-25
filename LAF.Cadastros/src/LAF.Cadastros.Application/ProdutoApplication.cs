using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LAF.Cadastros.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoApplication(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public Produto ObterPorId(Guid id)
        {
            return _produtoRepository.ObterPorId(id);
        }
        public IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> where)
        {
            return _produtoRepository.Buscar(where);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtoRepository.ObterTodos();
        }
        public void Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }
        public void Alterar(Produto produto)
        {
            _produtoRepository.Alterar(produto);
        }
        public void Deletar(Produto produto)
        {
            _produtoRepository.Deletar(produto);
        }
    }

}
