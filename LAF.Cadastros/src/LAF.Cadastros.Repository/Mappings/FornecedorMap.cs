using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using LAF.Cadastros.Domain.Entities;

namespace LAF.Cadastros.Repository.Mappings
{
    public class FornecedorMap : DommelEntityMap<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable("Fornecedores");

            Map(fornecedor => fornecedor.Id).ToColumn("Id");
            Map(fornecedor => fornecedor.Nome).ToColumn("Nome");
            Map(fornecedor => fornecedor.Documento).ToColumn("Documento");
            Map(fornecedor => fornecedor.TipoFornecedor).ToColumn("TipoFornecedor");
            Map(fornecedor => fornecedor.Ativo).ToColumn("Ativo");
        }
    }
}
