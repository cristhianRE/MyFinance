using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class UsuarioController : Controller
    {
        public object TempView { get; private set; }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
            bool login = usuario.ValidarLogin();
            if(login)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
                return RedirectToAction("Login");
            }
        }
    }
}