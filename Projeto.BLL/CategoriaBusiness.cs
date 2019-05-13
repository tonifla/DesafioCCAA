using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class CategoriaBusiness
    {
        private CategoriaRepository repository;

        public CategoriaBusiness()
        {
            repository = new CategoriaRepository();
        }

        public void CadastrarCategoria(Categoria categoria)
        {
            repository.Insert(categoria);
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            repository.Update(categoria);
        }

        public void ExcluirCategoria(int id)
        {
            if (repository.SumQuantidadeProdutos(id) == 0)
            {
                repository.Delete(id);
            }
            else
            {
                throw new Exception("Não é permitido excluir uma categoria que contenha produto associado.");
            }
        }

        public List<Categoria> ConsultarCategoria()
        {
            return repository.SelectAll();
        }

        public Categoria ConsultarCategoriaPorId(int id)
        {
            return repository.SelectById(id);
        }

        public int ObterSomaDeQuantidadeDeProdutos(int id)
        {
            return repository.SumQuantidadeProdutos(id);
        }
    }
}
