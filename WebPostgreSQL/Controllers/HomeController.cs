using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebPostgreSQL.Models;

namespace WebPostgreSQL.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly Contexto _dbContext;

        public HomeController(Contexto dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login( string nome)
            
        {
            var usuario = _dbContext.Usuarios
            .FirstOrDefault(u => u.Nome == nome);


            if (usuario != null)
            {
                // L�gica de autentica��o bem-sucedida
                // Pode redirecionar para outra p�gina
                return RedirectToAction("PaginaBemVinda");
            }
            
            TempData["Alert"] = "Nome de usu�rio inv�lido";
            return RedirectToAction(nameof(Login));

        }

        public IActionResult PaginaBemVinda(int id)
        {
            // P�gina de boas-vindas
            // Pode exibir o nome do usu�rio com id
            var usuario = _dbContext.Usuarios.Find(id);
            return View(usuario);
        }
    }


}

