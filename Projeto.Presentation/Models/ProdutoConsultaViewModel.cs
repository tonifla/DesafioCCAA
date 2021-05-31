using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class ProdutoConsultaViewModel
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public Decimal Preco { get; set; }
        public int IdCategoria { get; set; }
        public int IdFornecedor { get; set; }
        public int QuantidadeDeProdutos { get; set; }
    }
}