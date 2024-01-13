using EuCorro.Domain.Models;
using EuCorro.App.Interface;
using EuCorro.Security.Filters;
using EuCorro.Service;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Areas.Admin.Controllers
{
    [ClaimsAuthorize("Admin", "True")]
    public class EmpresaController : Controller
    {
        #region Global declaration

        private readonly IEmpresaApp _empresa;

        #endregion Global declaration

        #region Constructor

        public EmpresaController(IEmpresaApp empresa)
        {
            _empresa = empresa;
        }

        #endregion Constructor

        #region Views Evento

        // GET: Admin/Empresa
        //public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    var empresa = _empresa.GetAll();
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        empresa = empresa.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "Nome_desc":
        //            empresa = empresa.OrderByDescending(s => s.Nome);
        //            break;
        //        //case "Data":
        //        //    fornecedores = fornecedores.OrderBy(s => s.Email);
        //        //    break;
        //        //case "Data_desc":
        //        //    fornecedores = fornecedores.OrderByDescending(s => s.Email);
        //        //    break;
        //        default:
        //            empresa = empresa.OrderBy(p => p.EmpresaId);
        //            break;
        //    }

        //    const int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    return View(empresa.ToPagedList(pageNumber, pageSize));
        //}

        // GET: Admin/Empresa/Details/5
        public ActionResult Details()
        {
            var empresa = new Empresa();
            empresa = _empresa.GetAll().FirstOrDefault();
            if (empresa != null)
            {
                ViewBag.EstadoEmpresa = _empresa.BuscarEstados().First(p => p.EstadoId.Equals(empresa.EstadoId)).Nome;
                ViewBag.CidadeEmpresa = _empresa.BuscarPorEstado(empresa.EstadoId).First(p => p.CidadeId.Equals(empresa.CidadeId)).Nome;
            }
            return View(empresa);
        }

        // GET: Admin/Empresa/Create
        public ActionResult Create()
        {
            ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();

            return View();
        }

        // POST: Admin/Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa, HttpPostedFileBase file)
        {
            var cnpj = empresa.CNPJ;

            if (Functions.ValidaCNPJ(cnpj) == false)
                ModelState.AddModelError("CNPJ", "CNPJ Inválido...");

            if (!ModelState.IsValid)
            {
                ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();

                return View(empresa);
            }

            var post = Request.Files[0];
            if (post == null)
            {
                ModelState.AddModelError("Avatar", "Foto do Atleta inválida ou vazia, tente novamente !!!");
                ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
                return View();
            }

            if (post.FileName != "")
            {
                var arquivoDel = Path.Combine(Server.MapPath("~/Uploads"), (string)post.FileName);

                if (System.IO.File.Exists(@arquivoDel))
                {
                    try
                    {
                        System.IO.File.Delete(@arquivoDel);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
                        return View(empresa);
                    }
                }
            }

            try
            {
                // TODO: Add insert logic here
                var fileName = new FileInfo(post.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName.Name);

                empresa.Avatar = fileName.Name;
                post.SaveAs(path);
                empresa.PaisId = 1;

                _empresa.Add(empresa);

                return RedirectToAction("Details");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
                return View(empresa);
            }
        }

        // GET: Admin/Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            Empresa empresa = _empresa.GetById(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }

            ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _empresa.BuscarPorEstado(empresa.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();
            Session["Arquivo"] = empresa.Avatar ?? "";
            ViewBag.PastaUpload = "/Uploads/";

            return View(empresa);
        }

        // POST: Admin/Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa empresa, HttpPostedFileBase file)
        {
            string mensagemErro = "Registros Salvos com Sucesso!";
            var post = Request.Files[0];

            var cnpj = empresa.CNPJ;
            if (Functions.ValidaCNPJ(cnpj) == false) ModelState.AddModelError("CNPJ", "CNPJ Inválido...");

            if (!ModelState.IsValid)
            {
                ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
                ViewBag.Cidade = _empresa.BuscarPorEstado(empresa.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();
                return View(empresa);
            }

            if (post == null)
            {
                mensagemErro = "Faltando Imagem Obrigatória ou inválida, tente novamente !!!";

                ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
                ViewBag.Cidade = _empresa.BuscarPorEstado(empresa.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();
                return View(empresa);
            }

            if (post.FileName != "")
            {
                var arquivoDel = Path.Combine(Server.MapPath("~/Uploads"), (string)Session["Arquivo"]);

                if (System.IO.File.Exists(@arquivoDel))
                {
                    try
                    {
                        System.IO.File.Delete(@arquivoDel);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    }
                }
            }

            try
            {
                // TODO: Add update logic here
                var fileName = new FileInfo(post.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName.Name);

                empresa.Avatar = fileName.Name;
                post.SaveAs(path);

                //empresa.PaisId = 1;
                _empresa.Update(empresa);

                return RedirectToAction("Details");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            ViewBag.Estado = _empresa.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _empresa.BuscarPorEstado(empresa.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();
            return View(empresa);
        }

        // post: Admin/Empresa/Delete/5
        [HttpPost]
        public JsonResult DeleteCategoria(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                Empresa empresa = _empresa.GetById(id);
                var avatar = Path.Combine(Server.MapPath("~/Uploads"), empresa.Avatar);
                _empresa.Remove(empresa);

                if (System.IO.File.Exists(avatar))
                {
                    try
                    {
                        System.IO.File.Delete(avatar);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }

        #endregion Views

        #region Private Methods

        #endregion Private Methods
    }
}
