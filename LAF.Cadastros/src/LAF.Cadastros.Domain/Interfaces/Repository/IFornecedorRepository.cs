using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        IEnumerable<Fornecedor>ObterTodos();
        Fornecedor ObterPorId(Guid id);
        IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor, bool>> where);
        void Adicionar(Fornecedor fornecedor);
        void Alterar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);


    }
}
