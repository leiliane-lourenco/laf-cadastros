using LAF.Cadastros.Domain.Entities;

namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IEnderecoApplication
    {
        void Adicionar(Endereco endereco);
        void Alterar(Endereco endereco);
    }
}
