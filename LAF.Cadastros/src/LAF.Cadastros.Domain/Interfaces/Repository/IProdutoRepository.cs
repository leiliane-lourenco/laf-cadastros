using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Produto ObterPorId(Guid id);
        IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> where);
        IEnumerable<Produto> ObterTodos();
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Deletar(Produto produto);
    }
}
