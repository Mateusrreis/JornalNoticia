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
        private readonly List<Noticia> listaArea;
        private readonly List<List<Noticia>> listaPai = new List<List<Noticia>>();
        public HomeController()
        {
            restaurandovalor = new ConexaoDAO().consultarNoticia();
            listacategoria =  new ConexaoDAO().carregandoCategoria();
            Categoria categoria = new Categoria();
            
            ViewBag.teste = listacategoria.ToList();
            //listaArea = new ConexaoDAO().carregandoArea();
            listaPai.Add(restaurandovalor);
           // listaPai.Add(listacategoria);
            listaPai.Add(listaArea);
        }

        

        public ActionResult Index()
        {

            var ultimasnoticias = listaPai;
            return View(ultimasnoticias);
        }


        //---------------------------------------------------------------------------
        
        public ActionResult About()
        {
            Categoria categoria = new Categoria();
            
            
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
        public ActionResult File(Noticia noticia,ImagemUpload imagem,Categoria categoria)
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
        public ActionResult About(Noticia noticia, ImagemUpload imagem)
        {
            var categoria = listaPai;

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