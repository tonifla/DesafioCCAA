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
    public class FornecedorController : Controller
    {
        private FornecedorBusiness business;

        public FornecedorController()
        {
            business = new FornecedorBusiness();
        }

        // GET: Fornecedor
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(FornecedorCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Fornecedor fornecedor = Mapper.Map<Fornecedor>(model);

                    business.CadastrarFornecedor(fornecedor);

                    TempData["Mensagem"] = $"Fornecedor '{model.Nome}', cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }

        public ActionResult Consulta()
        {
            List<FornecedorConsultaViewModel> lista = new List<FornecedorConsultaViewModel>();

            try
            {
                lista = Mapper.Map<List<FornecedorConsultaViewModel>>(business.ConsultarFornecedor());
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(lista);
        }

        public ActionResult Edicao(int id)
        {
            FornecedorEdicaoViewModel model = new FornecedorEdicaoViewModel();

            try
            {
                model = Mapper.Map<FornecedorEdicaoViewModel>(business.ConsultarFornecedorPorId(id));
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(FornecedorEdicaoViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Fornecedor fornecedor = Mapper.Map<Fornecedor>(model);

                    business.AtualizarFornecedor(fornecedor);

                    TempData["Mensagem"] = $"Fornecedor '{model.Nome}', atualizado com sucesso.";

                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            return View();
        }

        public ActionResult Exclusao(int id)
        {
            try
            {
                business.ExcluirFornecedor(id);
                TempData["Mensagem"] = "Fornecedor excluído com sucesso.";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return RedirectToAction("Consulta");
        }
    }
}