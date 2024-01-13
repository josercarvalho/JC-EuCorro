using System;
using System.Linq;
using System.Web.Mvc;
using EuCorro.App.Interface;
using EuCorro.Domain.Models;
using EuCorro.MVC.Site.ViewModels;
using EuCorro.Service;
using PagedList;
using EuCorro.Security.Filters;
using EuCorro.Security.Configuration;

namespace EuCorro.MVC.Site.Areas.Admin.Controllers
{
    [ClaimsAuthorize("Admin", "True")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApp _user;
        private ApplicationUserManager _userManager;

        public UsuarioController(ApplicationUserManager userManager, IUsuarioApp usuario)
        {
            _user = usuario;
            _userManager = userManager;
        }

        // GET: Admin/Úsuario
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //if (SessionManager.IsAuthenticated == false) return RedirectToAction("Login", "Account");

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var usuario = _user.GetAll().Where(x => x.PerfilUsuarioId.Equals(2));
            if (!String.IsNullOrEmpty(searchString))
            {
                usuario = usuario.Where(s => s.UserName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Nome_desc":
                    usuario = usuario.OrderByDescending(s => s.UserName);
                    break;
                //case "Data":
                //    fornecedores = fornecedores.OrderBy(s => s.Email);
                //    break;
                //case "Data_desc":
                //    fornecedores = fornecedores.OrderByDescending(s => s.Email);
                //    break;
                default:
                    usuario = usuario.OrderBy(s => s.UserName);
                    break;
            }

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(usuario.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Úsuario/Create
        public ActionResult Create()
        {
            if (SessionManager.IsAuthenticated == false) return RedirectToAction("Login", "Account");

            ViewBag.Estado = _user.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();

            return View();
        }

        // POST: Admin/Úsuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (_user.IsExistEmail(usuario.Email))
                ModelState.AddModelError("Email", "E-mail já cadastrado, tente outro...");

            var cpf = usuario.CPF;
            if (Functions.ValidaCpf(cpf) == false)
                ModelState.AddModelError("CPF", "CPF Inválido...");

            if (ModelState.IsValid)
            {
                var cliente = new Usuario();
                cliente.PerfilUsuarioId = 2;
                cliente.Email = usuario.Email;
                cliente.Senha = "@Senha2017";
                cliente.UserName = usuario.Nome.ToUpper();
                cliente.Numero = usuario.Numero;
                cliente.DataNascimento = usuario.DataNascimento;
                cliente.CPF = usuario.CPF;
                cliente.Brasileiro = 0;
                cliente.Sexo = usuario.Sexo;
                cliente.Contato = usuario.Nome;
                cliente.FoneContato = usuario.Telefone;
                cliente.Endereco = usuario.Endereco;
                cliente.Complemento = usuario.Complemento;
                cliente.Bairro = usuario.Bairro;
                cliente.CEP = usuario.CEP;
                cliente.PaisId = 1;
                cliente.CidadeId = usuario.CidadeId;
                cliente.EstadoId = usuario.EstadoId;
                cliente.Telefone = usuario.Telefone;
                cliente.Celular = usuario.Celular;
                cliente.WhatsApp = usuario.WhatsApp;
                _user.CadastraUsuario(cliente);
                return RedirectToAction("Index", "Usuario");
            }

            ViewBag.Estado = _user.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            return View(usuario);
        }

        // GET: Admin/Úsuario/Edit/5
        public ActionResult Edit(string email)
        {
            Usuario usuario = _user.RecuperarUsuarioPorEmail(email);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            var cliente = new UsuarioViewModel();
            cliente.UserId = usuario.Id;
            cliente.PerfilUsuarioId = 2;
            cliente.Email = usuario.Email;
            cliente.Nome = usuario.UserName.ToUpper();
            cliente.Numero = usuario.Numero;
            cliente.DataNascimento = usuario.DataNascimento;
            cliente.CPF = usuario.CPF;
            cliente.Sexo = usuario.Sexo;
            cliente.Endereco = usuario.Endereco;
            cliente.Complemento = usuario.Complemento;
            cliente.Bairro = usuario.Bairro;
            cliente.CEP = usuario.CEP;
            cliente.PaisId = 1;
            cliente.CidadeId = usuario.CidadeId;
            cliente.EstadoId = usuario.EstadoId;
            cliente.Telefone = usuario.Telefone;
            cliente.Celular = usuario.Celular;
            cliente.WhatsApp = usuario.WhatsApp;

            ViewBag.Estado = _user.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _user.BuscarPorEstado(usuario.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();

            return View(cliente);
        }

        // POST: Admin/Úsuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            if (SessionManager.IsAuthenticated == false) return RedirectToAction("Login", "Account");

            var cpf = usuario.CPF;
            if (Functions.ValidaCpf(cpf) == false)
                ModelState.AddModelError("CPF", "CPF Inválido...");

            if (ModelState.IsValid)
            {
                Usuario cliente = _user.RecuperarUsuarioPorEmail(usuario.Email);
                cliente.Id = usuario.UserId;
                cliente.PerfilUsuarioId = 2;
                cliente.Email = usuario.Email;
                cliente.Senha = cliente.Senha;
                cliente.UserName = usuario.Nome.ToUpper();
                cliente.Numero = usuario.Numero;
                cliente.DataNascimento = usuario.DataNascimento;
                cliente.CPF = usuario.CPF;
                cliente.Brasileiro = 0;
                cliente.Sexo = usuario.Sexo;
                cliente.Contato = usuario.Nome;
                cliente.FoneContato = usuario.Telefone;
                cliente.Endereco = usuario.Endereco;
                cliente.Complemento = usuario.Complemento;
                cliente.Bairro = usuario.Bairro;
                cliente.CEP = usuario.CEP;
                cliente.PaisId = 1;
                cliente.CidadeId = usuario.CidadeId;
                cliente.EstadoId = usuario.EstadoId;
                cliente.Telefone = usuario.Telefone;
                cliente.Celular = usuario.Celular;
                cliente.WhatsApp = usuario.WhatsApp;
                _user.CadastraUsuario(cliente);
                return RedirectToAction("Index", "Usuario");
            }

            ViewBag.Estado = _user.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            ViewBag.Cidade = _user.BuscarPorEstado(usuario.EstadoId).Select(x => new { x.CidadeId, x.Nome }).ToList();

            return View(usuario);
        }

        // POST: Admin/Categoria/Delete/5
        [HttpPost]
        public JsonResult DeleteUsuario(int id)
        {
            string mensagemErro = "Excluído com sucesso...";
            try
            {
                Usuario usuario = _user.GetById(id);
                _user.Remove(usuario);
            }
            catch (Exception ex)
            {
                mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return Json(mensagemErro, JsonRequestBehavior.DenyGet);
        }
    }
}