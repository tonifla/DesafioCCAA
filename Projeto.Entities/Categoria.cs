using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }

        public List<Produto> Produtos { get; set; }

        public Categoria()
        {

        }

        public Categoria(int idCategoria, string nome)
        {
            IdCategoria = idCategoria;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id: {IdCategoria}, Nome: {Nome}";
        }
    }
}
