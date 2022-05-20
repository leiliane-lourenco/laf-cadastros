using Dapper.FluentMap.Dommel.Mapping;
using LAF.Cadastros.Domain.Entities;

namespace LAF.Cadastros.Repository.Mappings
{
    public class EnderecoMap : DommelEntityMap<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Enderecos");

            Map(endereco => endereco.Id).ToColumn("Id").IsKey();
            Map(endereco => endereco.Logradouro).ToColumn("Logradouro");
            Map(endereco => endereco.Numero).ToColumn("Numero");
            Map(endereco => endereco.Complemento).ToColumn("Complemento");
            Map(endereco => endereco.Cep).ToColumn("Cep");
            Map(endereco => endereco.Bairro).ToColumn("Bairro");
            Map(endereco => endereco.Cidade).ToColumn("Cidade");
            Map(endereco => endereco.Estado).ToColumn("Estado");

        }
    }
}
