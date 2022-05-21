﻿using Newtonsoft.Json;
using System;


namespace LAF.Cadastros.API.ViewModel
{
    public class FornecedorPostViewModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("documento")]
        public string Documento { get; set; }

        [JsonProperty("tipo_fornecedor")]
        public int TipoFornecedor { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
