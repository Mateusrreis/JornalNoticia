using System.Web.Mvc;

namespace JornalNoticia.Models
{
    public class Noticia
    {
        public int Idnoticia { get; set; }
        public string Titulo { get; set; }
        [AllowHtml]
        public string Corponoticia { get; set; }
        public string caminhoimg { get; set; }

        
    }
}