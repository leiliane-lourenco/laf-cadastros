using Dommel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace LAF.Cadastros.Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";
        public Produto ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.Get<Produto>(id);
                //retorna fornecedor com base no ID que passei
            }
        }
        public IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> where)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.Select<Produto>(where);
            }
        }
        public IEnumerable<Produto> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.GetAll<Produto>();
            }
        }    

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
