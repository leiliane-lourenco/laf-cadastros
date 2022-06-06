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
    public class EnderecoRepository : IEnderecoRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";

        public async Task<Endereco> ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAsync<Endereco>(id);
                //retorna fornecedor com base no ID que passei
            }
        }
        public async Task<IEnumerable<Endereco>> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.GetAllAsync<Endereco>();
            }
        }
        public async Task<IEnumerable<Endereco>>  Buscar(Expression<Func<Endereco, bool>> where)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return await db.SelectAsync<Endereco>(where);
            }
        }

        public async Task Adicionar(Endereco endereco)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.InsertAsync(endereco);

            }
        }
        public async Task Alterar(Endereco endereco)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.UpdateAsync(endereco);
            }
        }
        public async Task Deletar(Endereco endereco)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                await db.DeleteAsync(endereco);

            }
        }
    }
}



