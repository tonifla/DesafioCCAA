using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        public List<Produto> Produtos { get; set; }

        public Fornecedor()
        {

        }

        public Fornecedor(int idFornecedor, string nome, string email, string telefone, string cnpj)
        {
            IdFornecedor = idFornecedor;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cnpj = cnpj;
        }

        public override string ToString()
        {
            return $"Id: {IdFornecedor}, Nome: {Nome}, Email: {Email}, Telefone: {Telefone}, Cnpj: {Cnpj}";
        }
    }
}
