using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JornalNoticia.Models
{
    public class Revisores
    {
        public string usuarioRev { get; set; }
        public string senha { get; set; }
        public int idRevisores { get; set; }
        public string situacao { get; set; }
        public Area area { get; set; }
    }
}