using Dommel;
using LAF.Cadastros.Domain.Entities;
using LAF.Cadastros.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LAF.Cadastros.Repository.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private string _connection = @"Data Source=Leiliane-PC\SQL2019;Initial Catalog=LAJFCadastroProdutosDB;User ID=sa;Password=123";

        public void Adicionar(Endereco endereco)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Insert(endereco);

            }
        }
        public void Alterar(Endereco endereco)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Update(endereco);
            }
        }
        public void Deletar(Endereco endereco)
        {
            using (SqlConnection db = new SqlConnection(_connection))
            {
                db.Delete(endereco);

            }
        }
    }
}



