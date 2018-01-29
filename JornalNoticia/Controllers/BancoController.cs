using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JornalNoticia.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
       public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Redirecionar()
        {
           return RedirectToAction("About", "Home");
        }
    }
}