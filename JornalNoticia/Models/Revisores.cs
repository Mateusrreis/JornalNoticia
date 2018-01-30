using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JornalNoticia.Models
{
    public class Revisores
    {
        private string usuarioRev { get; set; }
        private string senha { get; set; }
        private int idRevisores { get; set; }
        private string situacao { get; set; }
        private Area area { get; set; }
    }
}