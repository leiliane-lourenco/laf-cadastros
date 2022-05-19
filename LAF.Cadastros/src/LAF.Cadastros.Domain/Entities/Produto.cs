using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public Produto()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
        
    }
}
