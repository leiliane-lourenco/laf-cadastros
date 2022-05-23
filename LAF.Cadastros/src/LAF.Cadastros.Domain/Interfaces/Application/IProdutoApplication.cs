using LAF.Cadastros.Domain.Entities;


namespace LAF.Cadastros.Domain.Interfaces.Application
{
    public interface IProdutoApplication
    {
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Deletar(Produto produto);

    }
}
