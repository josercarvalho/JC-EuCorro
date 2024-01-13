using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using EuCorro.MVC.Site.Aolication.MvcExtensions;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Areas.Clientes.Controllers
{
    [ClienteAuth]
    public class DependenteController : Controller
    {
        private readonly IDependenteService _dependenteServ;

        public DependenteController(IDependenteService dependenteServ)
        {
            _dependenteServ = dependenteServ;
        }

        // GET: Clientes/Dependente
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.Tela = "Dependentes";
            ViewBag.Area = "DADOS DO DEPENDENTE";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var dependentes = _dependenteServ.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                dependentes = dependentes.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    dependentes = dependentes.OrderByDescending(s => s.Nome);
                    break;
                //case "Data":
                //    fornecedores = fornecedores.OrderBy(s => s.Email);
                //    break;
                //case "Data_desc":
                //    fornecedores = fornecedores.OrderByDescending(s => s.Email);
                //    break;
                default:
                    dependentes = dependentes.OrderBy(s => s.Nome);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(dependentes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Clientes/Dependente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Dependente/Create
        public ActionResult Create()
        {
            ViewBag.Tela = "Inclusão";
            ViewBag.Area = "DADOS DO DEPENDENTE";
            return View();
        }

        // POST: Clientes/Dependente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Dependente/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Tela = "Editar";
            ViewBag.Area = "DADOS DO DEPENDENTE";
            return View();
        }

        // POST: Clientes/Dependente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Dependente/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Tela = "Exclusão";
            ViewBag.Area = "DADOS DO DEPENDENTE";
            return View();
        }

        // POST: Clientes/Dependente/Delete/5
        [HttpPost]
        public JsonResult DeleteDependente(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                Dependentes usuario = _dependenteServ.GetById(id);
                _dependenteServ.Remove(usuario);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}
