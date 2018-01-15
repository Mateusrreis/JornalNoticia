using System.Data;
using MySql.Data.MySqlClient;

namespace JornalNoticia.Models
{
    public class ConexaoDAO
    {   

        private MySqlConnection bdConn;
        public int inserir(Noticia noticia)
        {
            int numerodelinhas = 0;
            bdConn = new MySqlConnection("Server=localhost;Database=teste;Uid=root;Pwd=gengar38");
            try
            {
                bdConn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into noticia(titulo,publicacao)  values(@Titulo,@Publicacao)",bdConn);
                cmd.Parameters.AddWithValue("@Titulo", noticia.Titulo);
                cmd.Parameters.AddWithValue("@Publicacao", noticia.Corponoticia);

                numerodelinhas=cmd.ExecuteNonQuery();
                bdConn.Close();

            }
            catch
            {
                bdConn.Close();


            }
            return numerodelinhas;


           
               
                
            
            
        }
    }
}