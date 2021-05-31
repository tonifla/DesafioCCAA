using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class FornecedorBusiness
    {
        private FornecedorRepository repository;

        public FornecedorBusiness()
        {
            repository = new FornecedorRepository();
        }

        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            repository.Insert(fornecedor);
        }

        public void AtualizarFornecedor(Fornecedor fornecedor)
        {
            repository.Update(fornecedor);
        }

        public void ExcluirFornecedor(int id)
        {
            if (repository.SumQuantidadeProdutos(id) == 0)
            {
                repository.Delete(id);
            }
            else
            {
                throw new Exception("Não é permitido excluir um fornecedor que contenha produto associado.");
            }
        }

        public List<Fornecedor> ConsultarFornecedor()
        {
            return repository.SelectAll();
        }

        public Fornecedor ConsultarFornecedorPorId(int id)
        {
            return repository.SelectById(id);
        }

        public int ObterSomaDeQuantidadeDeProdutos(int id)
        {
            return repository.SumQuantidadeProdutos(id);
        }
    }
}
