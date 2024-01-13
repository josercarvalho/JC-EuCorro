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
    [ClaimsAuthorize("Operador", "True")]
    public class TipoEventoController : Controller
    {
        private readonly ITipoEventoApp _tipEvent;

        public TipoEventoController(ITipoEventoApp tipoEvento)
        {
            _tipEvent = tipoEvento;
        }

        // GET: Admin/TipoEvento
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

            var tipoEvento = _tipEvent.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                tipoEvento = tipoEvento.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    tipoEvento = tipoEvento.OrderByDescending(s => s.Nome);
                    break;
                //case "Data":
                //    fornecedores = fornecedores.OrderBy(s => s.Email);
                //    break;
                //case "Data_desc":
                //    fornecedores = fornecedores.OrderByDescending(s => s.Email);
                //    break;
                default:
                    tipoEvento = tipoEvento.OrderBy(s => s.Nome);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(tipoEvento.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TipoEvento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TipoEvento/Create
        [HttpPost]
        public ActionResult Create(EventoTipo tipoEvento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tipoEvento);
                }
                _tipEvent.Add(tipoEvento);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TipoEvento/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EventoTipo tipoEvento = _tipEvent.GetById(id);
            if (tipoEvento == null)
            {
                return HttpNotFound();
            }

            return View(tipoEvento);
        }

        // POST: Admin/TipoEvento/Edit/5
        [HttpPost]
        public ActionResult Edit(EventoTipo tipoEvento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tipEvent.Update(tipoEvento);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/TipoEvento/Delete/5
        [HttpPost]
        public JsonResult DeleteTipoEvento(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                EventoTipo tipoEvento = _tipEvent.GetById(id);
                _tipEvent.Remove(tipoEvento);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}