using LAF.Cadastros.Domain.Entities;

namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);

        void Alterar(Endereco endereco);
        void Deletar(Endereco endereco);
    }
}
