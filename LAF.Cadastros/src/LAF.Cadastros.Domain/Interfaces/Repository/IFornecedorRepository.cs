using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        Fornecedor ObterPorId(Guid id);
        IEnumerable<Fornecedor>ObterTodos();
        IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor, bool>> where);
        void Adicionar(Fornecedor fornecedor);
        void Alterar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);


    }
}
