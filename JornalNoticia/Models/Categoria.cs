using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JornalNoticia.Models
{
    public class Categoria
    {
       
        public int IdCategoria { get; set; }
        public string TipCategria { get; set; }
        public string Situacao { get; set; }
    }
}