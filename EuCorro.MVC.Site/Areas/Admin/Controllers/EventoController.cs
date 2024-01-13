using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EuCorro.App.Interface;
using EuCorro.Domain.Models;
using EuCorro.MVC.Site.ViewModels;
using EuCorro.Security.Filters;
using EuCorro.Service;
using PagedList;

namespace EuCorro.MVC.Site.Areas.Admin.Controllers
{
    [ClaimsAuthorize("Evento", "True")]
    public class EventoController : Controller
    {
        #region Global declaration

        private readonly IEventoApp _evento;

        #endregion Global declaration

        #region Constructor

        public EventoController(IEventoApp evento)
        {
            _evento = evento;
        }

        #endregion Constructor

        #region Views Evento

        // GET: Admin/Evento
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

            var evento = _evento.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                evento = evento.Where(s => s.Nome.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    evento = evento.OrderByDescending(s => s.Nome);
                    break;
                //case "Data":
                //    fornecedores = fornecedores.OrderBy(s => s.Email);
                //    break;
                //case "Data_desc":
                //    fornecedores = fornecedores.OrderByDescending(s => s.Email);
                //    break;
                default:
                    evento = evento.OrderByDescending(p => p.DataEvento);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(evento.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Evento/Create
        public ActionResult Create()
        {
            ViewBag.TipoEvento = _evento.ListarTipoEvento().Select(x => new { x.EventoTipoId, x.Nome }).ToList();
            ViewBag.Modalidade = _evento.ListarModalidades().Select(x => new { x.ModalidadeId, x.Nome }).ToList();
            ViewBag.ModalidadeEvento = _evento.ListarModalidadeEvento(0);
            ViewBag.Estado = _evento.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.NovoEvento = 0;

            return View();
        }

        // POST: Admin/Evento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento model, IEnumerable<HttpPostedFileBase> file)
        {
            string mensagemErro = "Registros Salvos com Sucesso!";
            var post = Request.Files[1];

            if (post == null)
            {
                mensagemErro = "Faltando Imagem Obrigatória ou inválida, tente novamente !!!";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    var pastaBanner = Server.MapPath("~/Uploads/Banners");
                    model.PastaFiles = model.TituloEvento.Replace(" ", "");
                    var pastaEvento = Path.Combine(pastaBanner, model.PastaFiles);
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase arquivo = Request.Files[i];
                        string fileName = arquivo.FileName;
                        string extensao = Path.GetExtension(arquivo.FileName);
                        if (i.Equals(0))
                        {
                            fileName = "Regulamento_" + model.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            model.Regulamento = model.Regulamento != null ? fileName : null;
                        }
                        if (i.Equals(1))
                        {
                            fileName = "Banner_" + model.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            model.BannerEvento = model.BannerEvento != null ? fileName : null;
                        }
                        if (i.Equals(2))
                        {
                            fileName = "Patrocinio_" + model.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            model.BannerPatrocinio = model.BannerPatrocinio != null ? fileName : null;
                        }
                        if (i.Equals(3))
                        {
                            fileName = "Kit_" + model.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            model.ImagemKit = model.ImagemKit != null ? fileName : null;
                        }
                    }

                    _evento.CadastraEvento(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                }
            }
            else
            {
                mensagemErro = "Erro ao tentar salvar o regostro. persistindo o erro comunique ao Suporte.";
            }

            ViewBag.TipoEvento = _evento.ListarTipoEvento().Select(x => new { x.EventoTipoId, x.Nome }).ToList();
            ViewBag.Modalidade = _evento.ListarModalidades().Select(x => new { x.ModalidadeId, x.Nome }).ToList();
            ViewBag.ModalidadeEvento = _evento.ListarModalidadeEvento(0);
            ViewBag.Estado = _evento.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();

            TempData["SuccessMessage"] = mensagemErro;

            return View(model);
        }

        // GET: Admin/Evento/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Evento evento = _evento.GetById(id);
            if (evento == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoEvento = _evento.ListarTipoEvento().Select(x => new { x.EventoTipoId, x.Nome }).ToList();
            ViewBag.Estado = _evento.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _evento.BuscarPorEstado(evento.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();

            Session["Banner"] = evento.BannerEvento;
            Session["Kit"] = evento.ImagemKit;
            Session["Patrocinio"] = evento.BannerPatrocinio;

            return View(evento);
        }

        // POST: Admin/Evento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evento evento, IEnumerable<HttpPostedFileBase> file)
        {
            string mensagemErro = "Registros Salvos com Sucesso!";
            var post = Request.Files[1];

            if (post == null)
            {
                mensagemErro = "Faltando Imagem Obrigatória ou inválida, tente novamente !!!";

                ViewBag.TipoEvento = _evento.ListarTipoEvento().Select(x => new { x.EventoTipoId, x.Nome }).ToList();
                ViewBag.Estado = _evento.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
                ViewBag.Cidade = _evento.BuscarPorEstado(evento.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();
                return View(evento);
            }

            if (evento.BannerEvento == null)
            {
                mensagemErro = "Faltando Imagem Obrigatória ou inválida, tente novamente !!!";
                ModelState.AddModelError("BannerEvento", "Campo Banner do Evento é obrigatório");


                ViewBag.TipoEvento = _evento.ListarTipoEvento().Select(x => new { x.EventoTipoId, x.Nome }).ToList();
                ViewBag.Estado = _evento.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
                ViewBag.Cidade = _evento.BuscarPorEstado(evento.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();
                return View(evento);
            }

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var arquivoDel = Path.Combine(Server.MapPath("~/Uploads/Banners"), (string)Session["Banner"]);
                    if (System.IO.File.Exists(@arquivoDel))
                    {
                        try
                        {
                            System.IO.File.Delete(@arquivoDel);
                        }
                        catch (IOException ex)
                        {
                            mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                            return View();
                        }
                    }

                    var imagemKit = (string)Session["Kit"];
                    if (imagemKit != null)
                    {
                        arquivoDel = Path.Combine(Server.MapPath("~/Uploads/Banners"), imagemKit);
                        if (System.IO.File.Exists(@arquivoDel))
                        {
                            try
                            {
                                System.IO.File.Delete(@arquivoDel);
                            }
                            catch (IOException ex)
                            {
                                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                                return View();
                            }
                        }
                    }

                    var imgPatrocinio = (string)Session["Patrocinio"];
                    if (imgPatrocinio!= null)
                    {
                        arquivoDel = Path.Combine(Server.MapPath("~/Uploads/Banners"), imgPatrocinio);
                        if (System.IO.File.Exists(@arquivoDel))
                        {
                            try
                            {
                                System.IO.File.Delete(@arquivoDel);
                            }
                            catch (IOException ex)
                            {
                                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                                return View();
                            }
                        }
                    }

                    var pastaBanner = Server.MapPath("~/Uploads/Banners");
                    evento.PastaFiles = evento.TituloEvento.Replace(" ", "");
                    var pastaEvento = Path.Combine(pastaBanner, evento.PastaFiles);
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase arquivo = Request.Files[i];
                        string fileName = arquivo.FileName;
                        string extensao = Path.GetExtension(arquivo.FileName);
                        if (i.Equals(0))
                        {
                            fileName = "Regulamento_" + evento.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            evento.Regulamento = evento.Regulamento != null ? fileName : null;
                        }
                        if (i.Equals(1))
                        {
                            fileName = "Banner_" + evento.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            evento.BannerEvento = evento.BannerEvento != null ? fileName : null;
                        }
                        if (i.Equals(2))
                        {
                            fileName = "Patrocinio_" + evento.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            evento.BannerPatrocinio = evento.BannerPatrocinio != null ? fileName : null;
                        }
                        if (i.Equals(3))
                        {
                            fileName = "Kit_" + evento.PastaFiles + extensao;
                            arquivo.SaveAs(Path.Combine(pastaBanner, fileName));
                            evento.ImagemKit = evento.ImagemKit != null ? fileName : null;
                        }
                    }

                    _evento.Update(evento);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }

            ViewBag.TipoEvento = _evento.ListarTipoEvento().Select(x => new { x.EventoTipoId, x.Nome }).ToList();
            ViewBag.Estado = _evento.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _evento.BuscarPorEstado(evento.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();

            return View(evento);
        }

        // POST: Painel/Evento/Delete/5
        [HttpPost]
        public JsonResult DeleteEvento(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                Evento evento = _evento.GetById(id);
                _evento.RemoveEvento(id);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }

        #endregion

        #region Views Modalidade do Evento

        // GET: Admin/Evento/Modalidades/5
        public ActionResult Modalidades(int id, string nomeEvento)
        {
            var modalidade = new EventoViewModel();
            modalidade.Evento = new Evento();
            modalidade.Evento.EventoId = id;
            modalidade.Evento.Nome = nomeEvento;
            //modalidade.Modalidades = _evento.ListarModalidadeEvento(id);

            SessionManager.EventoModalidade = _evento.GetById(id);

            ViewBag.Modalidade = _evento.ListarModalidades().Select(x => new { x.ModalidadeId, x.Nome }).ToList();

            return View("indexModalidades", modalidade);
        }

        // POST: Admin/Evento/Modalidades/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modalidades(int id, FormCollection collection)
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

        public ActionResult AddModalidade(int id,string nome)
        {
            var obj = new ModalidadeEventoViewModel();
            obj.NomeEvento = nome;
            obj.ModalidadeEventoId = id;

            ViewBag.Modalidade = _evento.ListarModalidades().Select(x => new { x.ModalidadeId, x.Nome }).ToList();

            return View(obj);
        }

        /// <summary>
        /// Get Profile by profile id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetEventoById()
        {
            var id = SessionManager.EventoModalidade.EventoId;
            var profile = _evento.ListarModalidadeEvento(id).ToList();
            return Json(profile, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Delete Modalidade Evento by Evento id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelModalidade(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                ModalidadeEvento modalidade = _evento.BuscarModalidade(id);
                _evento.RemoveModalidade(modalidade);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// Create a new Modalidade
        /// </summary>
        /// <param name="modalidade"></param>
        /// <returns>ModalidadeEvento</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveModalidade(ModalidadeEvento modalidade, ModalidadePreco[] modalidadePrecos, CategoriaViewModel[] modalidadeCategorias)
        {
            try
            {
                var modalidadeEvento = new ModalidadeEvento
                {
                    EventoId = SessionManager.EventoModalidade.EventoId,
                    ModalidadeId = modalidade.ModalidadeId,
                    Reverzamento = modalidade.Reverzamento,
                    AtletasPorEquipe = modalidade.AtletasPorEquipe,
                    Vagas = modalidade.Vagas,
                    NumeroInicial = modalidade.NumeroInicial,
                    NumeroFinal = modalidade.NumeroFinal,
                    IdadeMax = modalidade.IdadeMax,
                    IdadeMin = modalidade.IdadeMin,
                    Percurso = modalidade.Percurso
                };

                //Salva itens da modalidade
                _evento.IncluirModalidade(modalidadeEvento);

                foreach (var item in modalidadePrecos)
                {
                    var preco = new ModalidadePreco
                    {
                        ModalidadeEventoId = modalidadeEvento.ModalidadeEventoId,
                        TipoIncricao = 1,
                        DtInicial = item.DtInicial,
                        DtFinal = item.DtFinal,
                        HoraIni = item.HoraIni,
                        HoraFin = item.HoraFin,
                        Valor = item.Valor,
                        Desconto = item.Desconto,
                        ValorDesconto = item.ValorDesconto,
                        ValidadeDesconto = item.ValidadeDesconto,
                        CodigoDesconto = item.CodigoDesconto
                    };

                    //Salva preços da Modalidade
                    _evento.IncluirPrecoModalidade(preco);
                }

                if (modalidadeCategorias != null)
                {
                    foreach (var item in modalidadeCategorias)
                    {
                        var categoria = new ModalidadeCategoria
                        {
                            ModalidadeEventoId = modalidadeEvento.ModalidadeEventoId,
                            Descricao = item.CategoriaDescricao,
                            Desconto = item.CategoriaDesconto,
                        };

                        //Salva categorias da Modalidade
                        _evento.IncluirCategoriaModalidade(categoria);
                    }
                }                
            }
            catch (DbEntityValidationException e)
            {
                foreach (var error in e.EntityValidationErrors)
                {
                    Console.WriteLine(
                        "Entidade do tipo \"{0} \" no estado \"{1} \" tem os seguintes erros de validação:",
                        error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var ve in error.ValidationErrors)
                    {
                        Console.WriteLine("-Propriedade: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return Json(modalidade);
        }

        /// <summary>
        /// Update an existing profile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profileDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpStatusCodeResult UpdateProfileInformation(int id, Evento profileDTO)
        {
            _evento.Update(profileDTO);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult AddModalidade(ModalidadeEvento modalidade)
        {
            var obj = new ModalidadeEvento();
            ViewBag.Modalidade = _evento.ListarModalidades().Select(x => new { x.ModalidadeId, x.Nome }).ToList();

            return PartialView("_Modalidade", obj);
        }

        public ActionResult Modalidade(int id)
        {
            var obj = new EventoViewModel();
            //obj.Modalidades = _evento.ListarModalidadeEvento(id);

            ViewBag.Modalidade = _evento.ListarModalidades().Select(x => new { x.ModalidadeId, x.Nome }).ToList();
            ViewBag.ModalidadeEvento = new ModalidadeEvento();

            return PartialView("_indexModalidade", obj);
        }

        public PartialViewResult KitEvento()
        {
            return PartialView();
        }

        #endregion Views

        #region Private Methods

        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }

        #endregion
    }
}