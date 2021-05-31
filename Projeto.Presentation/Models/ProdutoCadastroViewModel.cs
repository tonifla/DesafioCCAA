using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Projeto.BLL;
using Projeto.Entities;

namespace Projeto.Presentation.Models
{
    public class ProdutoCadastroViewModel
    {
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime DataFabricacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IdFornecedor { get; set; }

        public List<SelectListItem> ListagemDeCategorias
        {
            get
            {
                CategoriaBusiness business = new CategoriaBusiness();
                List<Categoria> consulta = business.ConsultarCategoria();
                
                List<SelectListItem> lista = new List<SelectListItem>();
                foreach (Categoria categoria in consulta)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = categoria.IdCategoria.ToString();
                    item.Text = categoria.Nome;
                    lista.Add(item);
                }
                return lista;
            }
        }

        public List<SelectListItem> ListagemDeFornecedores
        {
            get
            {
                FornecedorBusiness business = new FornecedorBusiness();
                List<Fornecedor> consulta = business.ConsultarFornecedor();

                List<SelectListItem> lista = new List<SelectListItem>();
                foreach (Fornecedor fornecedor in consulta)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = fornecedor.IdFornecedor.ToString();
                    item.Text = fornecedor.Nome;
                    lista.Add(item);
                }
                return lista;
            }
        }
    }
}