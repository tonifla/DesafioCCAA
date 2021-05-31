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
    public class CategoriaController : Controller
    {
        private CategoriaBusiness business;

        public CategoriaController()
        {
            business = new CategoriaBusiness();
        }

        // GET: Categoria
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(CategoriaCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Categoria categoria = Mapper.Map<Categoria>(model);

                    business.CadastrarCategoria(categoria);

                    TempData["Mensagem"] = $"Categoria '{model.Nome}', cadastrada com sucesso.";
                    ModelState.Clear();
                }
                catch(Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }

        public ActionResult Consulta()
        {
            List<CategoriaConsultaViewModel> lista = new List<CategoriaConsultaViewModel>();

            try
            {
                lista = Mapper.Map<List<CategoriaConsultaViewModel>>(business.ConsultarCategoria());
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(lista);
        }

        public ActionResult Edicao(int id)
        {
            CategoriaEdicaoViewModel model = new CategoriaEdicaoViewModel();

            try
            {
                model = Mapper.Map<CategoriaEdicaoViewModel>(business.ConsultarCategoriaPorId(id));
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(CategoriaEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Categoria categoria = Mapper.Map<Categoria>(model);

                    business.AtualizarCategoria(categoria);

                    TempData["Mensagem"] = $"Categoria '{model.Nome}', atualizada com sucesso.";

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
                business.ExcluirCategoria(id);
                TempData["Mensagem"] = "Categoria excluída com sucesso.";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return RedirectToAction("Consulta");
        }
    }
}