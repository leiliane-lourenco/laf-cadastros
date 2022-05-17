using Newtonsoft.Json;
using System;


namespace LAF.Cadastros.API.ViewModel
{
    public class FornecedorPostiViewModel
    {
        [JsonProperty("nome")]
        public String Nome { get; set; }

        [JsonProperty("documento")]
        public String Documento { get; set; }

        [JsonProperty("tipo_fornecedor")]
        public int TipoFornecedor { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
