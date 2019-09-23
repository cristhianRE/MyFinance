using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;
using System;

namespace MyFinance.Controllers
{
    public class UsuarioController : Controller
    {
        public object TempView { get; private set; }

        [HttpGet]
        public IActionResult Login(int? id)
        {
            if(id != null)
            {
                if(id == 0)
                {
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
            bool login = usuario.ValidarLogin();
            if(login)
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                //Registrar usuário
                usuario.RegistrarUsuario();
                return RedirectToAction("Sucesso");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}