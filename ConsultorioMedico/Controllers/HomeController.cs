﻿using ConsultorioMedico.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsultorioMedico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ProExpFinalContext datos = new ProExpFinalContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //[AuthorizeUsers]
        [HttpPost]
        public IActionResult login(string usuario, string contra)
        {
            var users = datos.Usuarios.FirstOrDefault(x => x.NomUser == usuario && x.PassUser == contra);

            if (users.NomUser != null && users.PassUser != null)
            {
                string nivel = users.IdRol.ToString();
                HttpContext.Session.SetString("varSesion", nivel);
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["Resultado"] = "Intente nuevamente...";
            return View();
        }


        public IActionResult Privacy()
        {
            ViewBag.sesion = HttpContext.Session.GetString("varSesion");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}