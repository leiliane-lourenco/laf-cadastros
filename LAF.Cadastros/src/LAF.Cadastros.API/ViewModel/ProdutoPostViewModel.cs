﻿using Newtonsoft.Json;
using System;

namespace LAF.Cadastros.API.ViewModel
{
    public class ProdutoPostViewModel
    {
        [JsonProperty("fornecedor_id")]
        public Guid FornecedorId { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
