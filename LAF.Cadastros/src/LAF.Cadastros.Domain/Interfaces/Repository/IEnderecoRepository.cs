﻿using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository
    {
        Task <IEnumerable<Endereco>> ObterTodos();
        Task<Endereco> ObterPorId(Guid id);
        Task<IEnumerable<Endereco>> Buscar(Expression<Func<Endereco, bool>> where);
        Task Adicionar(Endereco endereco);
        Task Alterar(Endereco endereco);
        Task Deletar(Endereco endereco);
    
    }
}
