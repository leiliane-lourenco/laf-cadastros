using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IFornecedorApplication
    {
        Fornecedor ObterPorId(Guid id);
        IEnumerable<Fornecedor> ObterTodos();
        IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor, bool>> where);
        void Adicionar(Fornecedor fornecedor);
        void Alterar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);
    }
}
