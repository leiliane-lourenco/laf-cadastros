using LAF.Cadastros.Domain.Entities;


namespace LAF.Cadastros.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Deletar(Produto produto);
    }
}
