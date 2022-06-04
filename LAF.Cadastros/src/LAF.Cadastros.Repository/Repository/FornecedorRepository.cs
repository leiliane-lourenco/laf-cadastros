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
    public class FornecedorRepository : IFornecedorRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";

        public async Task <IEnumerable<Fornecedor>> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAllAsync<Fornecedor>();
                //retorna fornecedor com base no ID que passei
            }
        }
        public async Task<Fornecedor> ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                 return await db.GetAsync<Fornecedor>(id);
                //retorna fornecedor com base no ID que passei
            }
        }
        public async Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor,bool>> where)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.SelectAsync<Fornecedor>(where);
            }
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                await db.InsertAsync(fornecedor);

            }
        }
        public async Task Alterar(Fornecedor fornecedor)
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                await db.UpdateAsync (fornecedor);
            }          
        }
        public async Task Deletar(Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.DeleteAsync(fornecedor);
            }
        }
    }
}
