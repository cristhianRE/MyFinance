using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            ContaModel objConta = new ContaModel();
            ViewBag.ListaConta = objConta.ListaConta();
            return View();
        }
    }
}