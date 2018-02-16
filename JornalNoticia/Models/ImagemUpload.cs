using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;



namespace JornalNoticia.Models
{
    public class ImagemUpload
    {
        public string  caminhoimagem { get; set; }
        public string tipoimg { get; set; }
        public int idimagem { get; set; }
        public string situacao { get; set; }
        

        int incrementar = 0;
        public ImagemUpload()
        {
            incrementar++;
        }

        public string uploadimg(string caminhoimagem,string nomedaimagem)
        {
                          
            String cortar="Images";
            
            
            String barra = "\\";
            return  this.caminhoimagem = String.Concat(cortar, barra, nomedaimagem);
             
            
        }

        public string carregandoimg(HttpPostedFileBase file,string caminhomapeado)
        {
            

            if (file != null && file.ContentLength > 0)
            {
                
                
               var fileName = Path.GetFileName(file.FileName);
               tipoimg = Path.GetExtension(file.FileName);
                //fileName = String.Concat("img",incremento,tipoimg);
                String path = Path.Combine(caminhomapeado,fileName);
                if (System.IO.File.Exists(path))
                {
                    
                    int counter=0;
                   while (System.IO.File.Exists(path))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        fileName = DateTime.Now.ToString("MM-yyyy_")+ counter.ToString() + "img"+tipoimg;
                        path = Path.Combine(caminhomapeado, fileName);
                        counter++;
                    }
                    
                    



                }

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