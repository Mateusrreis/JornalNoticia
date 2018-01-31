using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JornalNoticia.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public String TipCategria { get; set; }
        public String Situacao { get; set; }
    }
}