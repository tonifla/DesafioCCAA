using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public Decimal Preco { get; set; }
        public int IdCategoria { get; set; }
        public int IdFornecedor { get; set; }

        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Produto()
        {

        }

        public Produto(int idProduto, string nome, string descricao, DateTime dataValidade, DateTime dataFabricacao, decimal preco)
        {
            IdProduto = idProduto;
            Nome = nome;
            Descricao = descricao;
            DataValidade = dataValidade;
            DataFabricacao = dataFabricacao;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Id: {IdProduto}, Nome: {Nome}, Descricao: {Descricao}, DataValidade: {DataValidade}, DataFabricacao: {DataFabricacao}, Preco: {Preco}";
        }
    }
}
