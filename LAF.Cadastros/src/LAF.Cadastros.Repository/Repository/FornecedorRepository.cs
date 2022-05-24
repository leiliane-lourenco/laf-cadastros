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
    public class FornecedorRepository : IFornecedorRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";

        public Fornecedor ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                 return db.Get<Fornecedor>(id);
                //retorna fornecedor com base no ID que passei
            }
        }
        public IEnumerable<Fornecedor> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.GetAll <Fornecedor>();
                //retorna fornecedor com base no ID que passei
            }
        }
        public IEnumerable<Fornecedor> Buscar(Expression<Func<Fornecedor,bool>> where)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                return db.Select<Fornecedor>(where);
            }
        }
        public void Adicionar(Fornecedor fornecedor)
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                db.Insert(fornecedor);

            }
        }
        public void Alterar(Fornecedor fornecedor)
        {
            using(SqlConnection db = new SqlConnection(_connection))
            {
                db.Update(fornecedor);
            }          
        }
        public void Deletar(Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Delete(fornecedor);
            }
        }

    }
}
