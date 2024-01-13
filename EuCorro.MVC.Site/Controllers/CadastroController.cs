using EuCorro.Domain.Models;
using EuCorro.App.Interface;
using EuCorro.Service;
using EuCorro.MVC.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IUsuarioApp _cadastro;

        public CadastroController(IUsuarioApp cadastro)
        {
            _cadastro = cadastro;
        }

        // GET: Cadastro
        public ActionResult Create()
        {
            ViewBag.Estado = _cadastro.BuscarEstados().Select(x => new { x.EstadoId, x.Nome }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ClienteId,PerfilUsuarioId,Login,Senha,Nome,DataNascimento,CPF,Email,Endereco,Numero,Complemento,Bairro,CEP,PaisId,CidadeId,EstadoId,Telefone,Operadora,WhatsApp,SKYPE,DataCadastro,Reentradas,Status,BancoId,Titular.TipoConta,Agencia,Conta,Operacao")] CadastroViewModel cadastroViewModel)
        public ActionResult Create(CadastroViewModel cadastroViewModel)
        {
            if (_cadastro.IsExistEmail(cadastroViewModel.Email))
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
                _cadastro.CadastraUsuario(cliente);
                return RedirectToAction("Index", "Home", new { Areas = "Clientes" });
            }
            return View(cadastroViewModel);
        }

        public JsonResult ValidarCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return Json("O campo CPF é obrigatório!", JsonRequestBehavior.AllowGet);
            }

            var retorno = _cadastro.BuscarCPF(cpf).CPF;
            if (!string.IsNullOrEmpty(retorno))
            {
                return Json("CPF já cadastrado!", JsonRequestBehavior.AllowGet);
            }

            if (Functions.ValidaCpf(cpf) == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("CPF inválido. Favor tente novamente!", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ChecaEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json("O campo E-mail é obrigatório!", JsonRequestBehavior.AllowGet);
            }


            var encontrado = _cadastro.IsExistEmail(email);
            if (encontrado == false)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("CPF inválido. Favor tente novamente!", JsonRequestBehavior.AllowGet);
            }
        }

        private IEnumerable<Cidade> GetCidades(int estadoId)
        {
            return _cadastro.BuscarPorEstado(estadoId).ToList();
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadCidadeId(string estadoId)
        {
            var cidadeList = GetCidades(Convert.ToInt32(estadoId));

            var cidadeData = cidadeList.Select(m => new SelectListItem
            {
                Text = m.Nome,
                Value = m.CidadeId.ToString(CultureInfo.InvariantCulture),
            });
            return Json(cidadeData, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Inscricao(int Evento)
        //{
        //    return View();
        //}
    }
}