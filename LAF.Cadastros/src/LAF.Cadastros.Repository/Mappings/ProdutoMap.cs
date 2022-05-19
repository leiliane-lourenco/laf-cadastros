using Dapper.FluentMap.Dommel.Mapping;
using LAF.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Repository.Mappings
{
    public class ProdutoMap : DommelEntityMap<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produtos");

            Map(produto => produto.Id).ToColumn("Id");
            Map(produto => produto.Nome).ToColumn("Nome");
            Map(produto => produto.Descricao).ToColumn("Descricao");
            Map(produto => produto.Valor).ToColumn("Valor");
            Map(produto => produto.DataCadastro).ToColumn("DataCadastro");
            Map(produto => produto.Ativo).ToColumn("Ativo");
        }

    }
}
