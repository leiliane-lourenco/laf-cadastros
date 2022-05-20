using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IFornecedorApplication
    {
        void Adicionar(Fornecedor fornecedor);
        void Alterar(Fornecedor fornecedor);
     
    }
}
