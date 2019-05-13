using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.BLL;
using Projeto.Presentation.Models;
using AutoMapper;

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
                    Produto produto = Mapper.Map<Produto>(model);

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
                lista = Mapper.Map<List<ProdutoConsultaViewModel>>(business.ConsultarProdutos());
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
                model = Mapper.Map<ProdutoEdicaoViewModel>(business.ConsultarProdutoPorId(id));
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
                    Produto produto = Mapper.Map<Produto>(model);

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