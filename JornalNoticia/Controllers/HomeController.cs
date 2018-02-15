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
        //private List<Noticia> listacategoria;
      
        public HomeController()
        {
            ConexaoDAO combo = new ConexaoDAO();
          
            ViewBag.categoria = new SelectList(combo.carregandoCategoria(), "IdCategoria", "TipCategria", "Selecione um valor");
            ViewBag.area = new SelectList(combo.carregandoArea(), "IdArea","NomeArea", "Selecione um valor");
            restaurandovalor = new ConexaoDAO().consultarNoticia();
           
        }

        

        public ActionResult Index()
        {

            //var ultimasnoticias = listaPai;
            return View(restaurandovalor);
        }


        //---------------------------------------------------------------------------
        
        public ActionResult About()
        {
            
            /*ViewBag.teste = new SelectList
              (
                 listacategoria = new ConexaoDAO().carregandoCategoria(),

                  "categoria.IdCategoria",
                  "categoria.TipCategria"
               );*/
            
            




            if (Request.Files.Count > 0)
            {
               
                var file = Request.Files[1];
                string caminhoimagem = Server.MapPath("Images");
                string valorfinal = img.carregandoimg(file, caminhoimagem);
                ViewBag.Upload = valorfinal;
                

            }
          
            
        
            return View();
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
            //var categoria = listaPai;

            if (Request.Files.Count > 0)
            {
                
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