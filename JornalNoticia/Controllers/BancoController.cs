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
        [HttpPost]
        public ActionResult DadosNoticia(int idnoticia,string noticia)
        {

            return View();
        }
    }
}