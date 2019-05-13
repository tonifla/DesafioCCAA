using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class ProdutoBusiness
    {
        private ProdutoRepository repository;

        public ProdutoBusiness()
        {
            repository = new ProdutoRepository();
        }

        public void CadastrarProduto(Produto produto)
        {
            repository.Insert(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            repository.Update(produto);
        }

        public void ExcluirProduto(int id)
        {
            repository.Delete(id);
        }

        public List<Produto> ConsultarProdutos()
        {
            return repository.SelectAll();
        }

        public Produto ConsultarProdutoPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
