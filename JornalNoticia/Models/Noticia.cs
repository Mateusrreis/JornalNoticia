using System;
using System.Web.Mvc;

namespace JornalNoticia.Models
{
    public class Noticia
    {
        public int Idnoticia { get; set; }
        public string Titulo { get; set; }
        [AllowHtml]
        public string Corponoticia { get; set; }
        public ImagemUpload imagem { get; set; }
        public string situacao { get; set; }
        public Area area { get; set; }
        public Categoria categoria{ get; set;}
        public DateTime dtaPublicacao { get; set; }

        public static string TruncateString(string valueToTruncate, int maxLength, TruncateOptions options)
        {
            bool includeEllipsis = (options & TruncateOptions.IncludeEllipsis) ==
                          TruncateOptions.IncludeEllipsis;
            bool finishWord = (options & TruncateOptions.FinishWord) ==
                            TruncateOptions.FinishWord;
            bool allowLastWordOverflow =
                (options & TruncateOptions.AllowLastWordToGoOverMaxLength) ==
                TruncateOptions.AllowLastWordToGoOverMaxLength;
            string retValue = valueToTruncate;
            if (!finishWord)
            {
                if(retValue.Length < maxLength)
                {
                    return retValue;
                }
                else
                {
                    retValue = retValue.Remove(maxLength);
                    String[] array = retValue.Split();
                    String valor = array[array.Length - 1];
                    return retValue = retValue.Replace(valor, "...");
                    
                }
              
            }
            else if (allowLastWordOverflow)
            {
                int spaceIndex = retValue.IndexOf(" ", maxLength,
                    StringComparison.CurrentCultureIgnoreCase);
                if (spaceIndex != -1)
                {
                    retValue = retValue.Remove(spaceIndex);
                }
            }
            return retValue;



        }






        [Flags]
        public enum TruncateOptions
        {
            None = 0x0,
            FinishWord = 0x1,
            AllowLastWordToGoOverMaxLength = 0x2,
            IncludeEllipsis = 0x4
        }


    }
}