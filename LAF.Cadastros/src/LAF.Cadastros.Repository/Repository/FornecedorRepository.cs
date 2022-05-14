using Dommel;
using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LAF.Cadastros.Repository.Repository
{
    public class FornecedorRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";

        public void Adicionar(Fornecedor fornecedor)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Insert(fornecedor);
            }
        }
    }
}
