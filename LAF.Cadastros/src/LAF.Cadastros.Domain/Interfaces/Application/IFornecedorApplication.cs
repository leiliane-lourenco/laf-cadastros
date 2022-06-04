using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IFornecedorApplication
    {
        Task <Fornecedor>  ObterPorId(Guid id);
        Task <IEnumerable<Fornecedor>> ObterTodos();
        Task <IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>> where);
        Task Adicionar(Fornecedor fornecedor);
        Task Alterar(Fornecedor fornecedor);
        Task Deletar(Fornecedor fornecedor);
    }
}
