﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;



namespace JornalNoticia.Models
{
    public class ImagemUpload
    {
        private  string  caminhoimagem { get; set; }
        private string tipoimg { get; set; }
        private int idimagem { get; set; }
        private string situacao { get; set; }



        public string uploadimg(string caminhoimagem,string nomedaimagem)
        {
          
            String cortar="Images";
 //          

            String barra = "\\";
            return  this.caminhoimagem = String.Concat(cortar, barra, nomedaimagem);
             
            
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