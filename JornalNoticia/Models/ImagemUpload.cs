using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;



namespace JornalNoticia.Models
{
    public class ImagemUpload
    {
        public string caminhoimagem { get; set; }
        public string nomedaimagem { get; set; }

        
        public string uploadimg(string caminhoimagem,string nomedaimagem)
        {
            String barra = "\\";
            return  this.caminhoimagem = String.Concat(caminhoimagem, barra, nomedaimagem);
             
            
        }

        public string carregandoimg(HttpPostedFileBase file,string caminhomapeado)
        {
            

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(caminhomapeado,fileName);
                file.SaveAs(path);
                string diretorio = Path.GetDirectoryName(path);
                string valor = fileName;


               string  result = uploadimg(diretorio, valor);

               return result;
            }
            return null;

        }
    }
}