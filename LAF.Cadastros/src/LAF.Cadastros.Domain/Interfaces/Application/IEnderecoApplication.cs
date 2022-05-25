using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IEnderecoApplication
    {
        IEnumerable<Endereco> ObterTodos();
        Endereco ObterPorId(Guid id);
        IEnumerable<Endereco> Buscar(Expression<Func<Endereco, bool>> where);
        void Adicionar(Endereco endereco);
        void Alterar(Endereco endereco);
        void Deletar(Endereco endereco);
    }
}
