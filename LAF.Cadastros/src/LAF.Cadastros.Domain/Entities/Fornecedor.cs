using System;
using System.Collections.Generic;
using System.Text;

namespace LAF.Cadastros.Domain.Entities
{
    public class Fornecedor
    {
        public Guid ID { get; set; }
        public String Nome { get; set; }
        public String Documento { get; set; }
        public int TipoFornecedor { get; set; }
        public bool Ativo { get; set; }

        public Fornecedor()
        {
            ID = Guid.NewGuid();
        }
    }
}
