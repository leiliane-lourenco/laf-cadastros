using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;


namespace LAF.Cadastros.Application
{
    public class FornecedorApplication : IFornecedorApplication
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorApplication(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public void Adicionar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Adicionar(fornecedor);
        }
    }

        
}
