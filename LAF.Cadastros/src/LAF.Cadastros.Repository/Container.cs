using Dapper.FluentMap;
using LAF.Cadastros.Repository.Mappings;

namespace LAF.Cadastros.Repository
{
    public static class Container //registro das dependecias do Dapper
    {
        public static void RegistrarMapeamentosDapper()
        {
            //para o sistema entender o mapeamento 
            //informando pro dapper que eu tenho uma classe fornecedor com essas propriedades 
            FluentMapper.Initialize(Configurar => 
            {
                Configurar.AddMap(new FornecedorMap());
            });
        }
    }
}
