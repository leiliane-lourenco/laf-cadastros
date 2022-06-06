using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> Buscar(Expression<Func<Produto, bool>> where);
        Task<IEnumerable<Produto>> ObterTodos();
        Task Adicionar(Produto produto);
        Task Alterar(Produto produto);
        Task Deletar(Produto produto);
    }
}
