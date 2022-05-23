using Dommel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System.Data.SqlClient;
using System.Text;

namespace LAF.Cadastros.Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";

        public void Adicionar(Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Insert(produto);
            }
        }
        public void Alterar(Produto produto)
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                db.Update(produto);
            }
        }
        public void Deletar (Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Delete(produto);
            }
        }
    }
}
