using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.BLL;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoBusiness business;

        public ProdutoController()
        {
            business = new ProdutoBusiness();
        }

        // GET: Produto
        public ActionResult Cadastro()
        {
            //enviando uma instancia da classe Model
            return View(new ProdutoCadastroViewModel());
        }

        [HttpPost]
        public ActionResult Cadastro(ProdutoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produto = new Produto();
                    produto.Nome = model.Nome;
                    produto.Descricao = model.Descricao;
                    produto.DataValidade = model.DataValidade;
                    produto.DataFabricacao = model.DataFabricacao;
                    produto.Preco = model.Preco;
                    produto.IdCategoria = model.IdCategoria;
                    produto.IdFornecedor = model.IdFornecedor;

                    business.CadastrarProduto(produto);

                    TempData["Mensagem"] = $"Produto '{produto.Nome}', cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View(new ProdutoCadastroViewModel());
        }

        public ActionResult Consulta()
        {
            List<ProdutoConsultaViewModel> lista = new List<ProdutoConsultaViewModel>();

            try
            {
                foreach (Produto produto in business.ConsultarProdutos())
                {
                    ProdutoConsultaViewModel model = new ProdutoConsultaViewModel();
                    model.IdProduto = produto.IdProduto;
                    model.Nome = produto.Nome;
                    model.Descricao = produto.Descricao;
                    model.DataValidade = produto.DataValidade;
                    model.DataFabricacao = produto.DataFabricacao;
                    model.Preco = produto.Preco;
                    model.IdCategoria = produto.IdCategoria;
                    model.IdFornecedor = produto.IdFornecedor;

                    lista.Add(model);
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(lista);
        }

        public ActionResult Edicao(int id)
        {
            ProdutoEdicaoViewModel model = new ProdutoEdicaoViewModel();

            try
            {
                Produto produto = business.ConsultarProdutoPorId(id);

                model.IdProduto = produto.IdProduto;
                model.Nome = produto.Nome;
                model.Descricao = produto.Descricao;
                model.DataValidade = produto.DataValidade;
                model.DataFabricacao = produto.DataFabricacao;
                model.Preco = produto.Preco;
                model.IdCategoria = produto.IdCategoria;
                model.IdFornecedor = produto.IdFornecedor;
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(ProdutoEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produto = new Produto();
                    produto.IdProduto = model.IdProduto;
                    produto.Nome = model.Nome;
                    produto.Descricao = model.Descricao;
                    produto.DataValidade = model.DataValidade;
                    produto.DataFabricacao = model.DataFabricacao;
                    produto.Preco = model.Preco;
                    produto.IdCategoria = model.IdCategoria;
                    produto.IdFornecedor = model.IdFornecedor;

                    business.AtualizarProduto(produto);

                    TempData["Mensagem"] = $"Produto '{produto.Nome}', atualizado com sucesso.";

                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            return View(new ProdutoEdicaoViewModel());
        }

        public ActionResult Exclusao(int id)
        {
            try
            {
                business.ExcluirProduto(id);
                TempData["Mensagem"] = "Produto excluído com sucesso.";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return RedirectToAction("Consulta");
        }
    }
}