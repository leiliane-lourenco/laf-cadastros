using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAF.Cadastros.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        public ProdutoApplication(
            IProdutoRepository produtoRepository, 
            IFornecedorRepository fornecedorRepository )
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
        }
        public async Task<Produto> ObterPorId(Guid id)
        {
            return  await _produtoRepository.ObterPorId(id);
        }
        public async Task<IEnumerable<Produto>> Buscar(Expression<Func<Produto, bool>> where)
        {
            return await _produtoRepository.Buscar(where);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.ObterTodos();
        }
        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }
        public async Task Alterar(Produto produto)
        {
             await _produtoRepository.Alterar(produto);
        }
        public async Task Deletar(Produto produto)
        {
            await _produtoRepository.Deletar(produto);
        }
    }

}
