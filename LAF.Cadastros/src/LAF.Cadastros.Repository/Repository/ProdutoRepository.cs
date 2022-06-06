using Dommel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LAF.Cadastros.Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";
        public async Task<Produto> ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return  await db.GetAsync<Produto>(id);
                //retorna fornecedor com base no ID que passei
            }
        }
        public async Task<IEnumerable<Produto>> Buscar(Expression<Func<Produto, bool>> where)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.SelectAsync<Produto>(where);
            }
        }
        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return  await db.GetAllAsync<Produto>();
            }
        }    

        public async Task Adicionar(Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.InsertAsync(produto);
            }
        }
        public async Task Alterar(Produto produto)
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
               await db.UpdateAsync(produto);
            }
        }
        public async Task Deletar (Produto produto)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.DeleteAsync(produto);
            }
        }

    }
}
