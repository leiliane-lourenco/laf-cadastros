using LAF.Cadastros.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Entities
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public bool Ativo { get; set; }

        public Fornecedor()
        {
            Id = Guid.NewGuid();
            Ativo = false;
        }
    }
}
