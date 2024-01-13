using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EuCorro.App.Interface;
using EuCorro.Domain.Models;
using PagedList;
using EuCorro.Security.Filters;

namespace EuCorro.MVC.Site.Areas.Admin.Controllers
{
    [ClaimsAuthorize("Admin", "True")]
    public class ModalidadeController : Controller
    {
        private readonly IModalidadeApp _modalidade;

        public ModalidadeController(IModalidadeApp modalidade)
        {
            _modalidade = modalidade;
        }

        // GET: Admin/Modalidade
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var modalidade = _modalidade.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                modalidade = modalidade.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    modalidade = modalidade.OrderByDescending(s => s.Nome);
                    break;
                //case "Data":
                //    fornecedores = fornecedores.OrderBy(s => s.Email);
                //    break;
                //case "Data_desc":
                //    fornecedores = fornecedores.OrderByDescending(s => s.Email);
                //    break;
                default:
                    modalidade = modalidade.OrderBy(s => s.Nome);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(modalidade.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Modalidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Modalidade/Create
        [HttpPost]
        public ActionResult Create(Modalidade model)
        {
            if (ModelState.IsValid)
            {
                _modalidade.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Admin/Modalidade/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Modalidade modalidade = _modalidade.GetById(id);
            if (modalidade == null)
            {
                return HttpNotFound();
            }

            return View(modalidade);
        }

        // POST: Admin/Modalidade/Edit/5
        [HttpPost]
        public ActionResult Edit(Modalidade modalidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _modalidade.Update(modalidade);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(modalidade);
            }
        }

        // POST: Admin/Categoria/Delete/5
        [HttpPost]
        public JsonResult DeleteModalidade(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                Modalidade modalidade = _modalidade.GetById(id);
                _modalidade.Remove(modalidade);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}