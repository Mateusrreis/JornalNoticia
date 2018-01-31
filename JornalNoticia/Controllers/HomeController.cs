using JornalNoticia.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JornalNoticia.Controllers
{
    public class HomeController : Controller
    {
        ImagemUpload img = new ImagemUpload();
        private readonly List<Noticia> restaurandovalor ;
        private readonly List<Noticia> listacategoria;
        private readonly List<List<Noticia>> listaPai = new List<List<Noticia>>();
        public HomeController()
        {
            restaurandovalor = new ConexaoDAO().consultarNoticia();
            listacategoria = new ConexaoDAO().carregandoCategoria();
            listaPai.Add(restaurandovalor);
            listaPai.Add(listacategoria);
        }

        

        public ActionResult Index()
        {

            var ultimasnoticias = listaPai;
            return View(ultimasnoticias);
        }


        //---------------------------------------------------------------------------
        
        public ActionResult About()
        {
            var categoria = listaPai;
            if (Request.Files.Count > 0)
            {
               
                var file = Request.Files[1];
                string caminhoimagem = Server.MapPath("Images");
                string valorfinal = img.carregandoimg(file, caminhoimagem);
                ViewBag.Upload = valorfinal;
                

            }
          
            
        
            return View(categoria);
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult File(Noticia noticia)
        {
            if (noticia.Titulo != String.Empty)
            {
                int valor = 0;

                ConexaoDAO conexão = new ConexaoDAO();
              //  noticia.caminhoimg = img.caminhoimagem;
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
            var categoria = listaPai;
            if (Request.Files.Count > 0)
            {
                
                var file = Request.Files[0];
                string caminhoimagem = Server.MapPath("~/Images/");
                string valorfinal = img.carregandoimg(file, caminhoimagem);
               
                ViewBag.Upload = valorfinal;
                
            }
           



            return View(categoria);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}