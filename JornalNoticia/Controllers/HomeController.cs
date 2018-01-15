using JornalNoticia.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JornalNoticia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
           
            if (Request.Files.Count > 0)
            {
                ImagemUpload img = new ImagemUpload();
                var file = Request.Files[1];
                string caminhoimagem = Server.MapPath("~/Images/");
                string valorfinal = img.carregandoimg(file, caminhoimagem);
                ViewBag.Upload = valorfinal;

            }
          
            
        
            return View();
        }



        [HttpPost]
        public ActionResult File(Noticia noticia)
        {
            if (noticia.Titulo != String.Empty)
            {
                int valor = 0;

                ConexaoDAO conexão = new ConexaoDAO();



                valor = conexão.inserir(noticia);
                if (valor > 0)
                {
                    ViewBag.status = "Funcionou";
                }
                else
                {
                    ViewBag.status = "";
                }

            }

            return View("About");
        }






        [HttpPost]
        public ActionResult About(Noticia noticia)
        {
            if (Request.Files.Count > 0)
            {
                ImagemUpload img = new ImagemUpload();
                var file = Request.Files[0];
                string caminhoimagem = Server.MapPath("~/Images/");
                string valorfinal = img.carregandoimg(file, caminhoimagem);
                ViewBag.Upload = valorfinal;
                
            }
           



            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}