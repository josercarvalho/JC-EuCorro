using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using EuCorro.App.Interface;
using EuCorro.Domain.Models;
using EuCorro.MVC.Site.ViewModels;
using EuCorro.Service;
using PagedList;
using EuCorro.Security.Filters;

namespace EuCorro.MVC.Site.Areas.Admin.Controllers
{
    [ClaimsAuthorize("Operador", "True")]
    public class AtletaController : Controller
    {
        private readonly IUsuarioApp _userServ;

        public AtletaController(IUsuarioApp userServ)
        {
            _userServ = userServ;
        }

        // GET: Admin/Atleta
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

            var atleta = _userServ.BuscarAtletas();
            if (!String.IsNullOrEmpty(searchString))
            {
                atleta = atleta.Where(s => s.UserName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    atleta = atleta.OrderByDescending(s => s.UserName);
                    break;
                //case "Data":
                //    fornecedores = fornecedores.OrderBy(s => s.Email);
                //    break;
                //case "Data_desc":
                //    fornecedores = fornecedores.OrderByDescending(s => s.Email);
                //    break;
                default:
                    atleta = atleta.OrderBy(s => s.UserName);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(atleta.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Atleta/Create
        public ActionResult Create()
        {
            if (SessionManager.IsAuthenticated == false) return RedirectToAction("Login", "Account");

            ViewBag.Estado = _userServ.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();

            return View();
        }

        // POST: Admin/Atleta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CadastroViewModel cadastroViewModel)
        {
            if (_userServ.IsExistEmail(cadastroViewModel.Email))
                ModelState.AddModelError("Email", "E-mail cadastrado, tente outro...");

            var cpf = cadastroViewModel.CPF;
            if (Functions.ValidaCpf(cpf) == false)
                ModelState.AddModelError("CPF", "CPF Inválido...");

            var post = Request.Files[0];

            if (post == null)
            {
                ModelState.AddModelError("Foto", "Foto do Atleta inválida ou vazia, tente novamente !!!");
                return View();
            }

            if (post.FileName != "")
            {
                var arquivoDel = Path.Combine(Server.MapPath("~/Uploads/Atletas"), (string)Session["Arquivo"]);

                if (System.IO.File.Exists(@arquivoDel))
                {
                    try
                    {
                        System.IO.File.Delete(@arquivoDel);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        return View();
                    }
                }
            }

            if (ModelState.IsValid)
            {
                var cliente = new Usuario();

                if (post.FileName != "")
                {
                    var file = new FileInfo(post.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/Atletas"), file.Name);

                    cliente.Foto = file.Name;
                    post.SaveAs(path);
                }

                cliente.PerfilUsuarioId = 3;
                cliente.Email = cadastroViewModel.Email;
                cliente.Senha = cadastroViewModel.Senha;
                cliente.UserName = cadastroViewModel.Nome.ToUpper();
                cliente.Numero = cadastroViewModel.Numero;
                cliente.DataNascimento = cadastroViewModel.DataNascimento;
                cliente.Idade = DateTime.Now.Year - cadastroViewModel.DataNascimento.Year;
                cliente.CPF = cadastroViewModel.CPF;
                cliente.Camiseta = cadastroViewModel.Camiseta;
                cliente.Brasileiro = cadastroViewModel.Brasileiro;
                cliente.Sexo = cadastroViewModel.Sexo;
                cliente.Contato = cadastroViewModel.Contato;
                cliente.FoneContato = cadastroViewModel.FoneContato;
                cliente.Endereco = cadastroViewModel.Endereco;
                cliente.Complemento = cadastroViewModel.Complemento;
                cliente.Bairro = cadastroViewModel.Bairro;
                cliente.CEP = cadastroViewModel.CEP;
                cliente.PaisId = 1;
                cliente.CidadeId = cadastroViewModel.CidadeId;
                cliente.EstadoId = cadastroViewModel.EstadoId;
                cliente.Telefone = cadastroViewModel.Telefone;
                cliente.Celular = cadastroViewModel.Celular;
                cliente.WhatsApp = cadastroViewModel.WhatsApp;
                _userServ.CadastraUsuario(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.Estado = _userServ.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();

            return View(cadastroViewModel);
        }

        // GET: Admin/Atleta/Edit/5
        public ActionResult Edit(string id)
        {
            Usuario usuario = _userServ.GetAll().Where(p=>p.Id.Equals(id)).FirstOrDefault();
            if (usuario == null)
            {
                return HttpNotFound();
            }

            ViewBag.Estado = _userServ.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _userServ.BuscarPorEstado(usuario.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();
            Session["Arquivo"] = usuario.Foto ?? "";
            ViewBag.PastaUpload = "/Uploads/Atletas/";

            return View(usuario);
        }

        // POST: Admin/Atleta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (SessionManager.IsAuthenticated == false) return RedirectToAction("Login", "Account");

            var cpf = usuario.CPF;
            if (Functions.ValidaCpf(cpf) == false)
                ModelState.AddModelError("CPF", "CPF Inválido...");

            var post = Request.Files[0];

            if (post == null)
            {
                ModelState.AddModelError("Foto", "Foto do Atleta inválida ou vazia, tente novamente !!!");
                return View();
            }

            if (post.FileName != "")
            {
                var arquivoDel = Path.Combine(Server.MapPath("~/Uploads/Atletas"), (string)Session["Arquivo"]);

                if (System.IO.File.Exists(@arquivoDel))
                {
                    try
                    {
                        System.IO.File.Delete(@arquivoDel);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        return View();
                    }
                }
            }

            if (ModelState.IsValid)
            {
                if (post.FileName != "")
                {
                    var file = new FileInfo(post.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/Atletas"), file.Name);

                    usuario.Foto = file.Name;
                    post.SaveAs(path);
                }

                usuario.UserName = usuario.UserName.ToUpper();
                usuario.Idade = DateTime.Now.Year - usuario.DataNascimento.Year;
                _userServ.CadastraUsuario(usuario);
                return RedirectToAction("Index");
            }
            ViewBag.Estado = _userServ.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _userServ.BuscarPorEstado(usuario.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();

            return View(usuario);
        }

        // GET: Admin/Atleta/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Atleta/Delete/5
        [HttpPost]
        public JsonResult DeleteUsuario(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                Usuario usuario = _userServ.GetById(id);
                _userServ.Remove(usuario);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}