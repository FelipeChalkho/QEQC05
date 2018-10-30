using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

namespace QEQ.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Instrucciones()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult TraerUnUsuario()
        {
            return View();
        }
        public ActionResult Bienvenido()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarLogin(Usuario Perfil)
        {
            bool Profile = BD.TraerUnUsuario(Perfil.Email, Perfil.Contraseña);
            if (Profile == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Bienvenido", "Home");
        }
     }
  }

