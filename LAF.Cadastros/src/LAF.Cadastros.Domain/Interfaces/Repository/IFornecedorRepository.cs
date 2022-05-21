using LAF.Cadastros.Domain.Entities;
using System;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        void Adicionar(Fornecedor fornecedor);
        void Alterar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);
     
    }
}
