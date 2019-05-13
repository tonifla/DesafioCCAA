using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class FornecedorConsultaViewModel
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }
        public int QuantidadeDeFornecedores { get; set; }
    }
}