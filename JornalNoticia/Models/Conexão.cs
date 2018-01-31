using System.Data.SqlClient;


namespace JornalNoticia.Models
{
    public class Conexão
    {

        SqlConnection bdConn;
        public  SqlConnection conectar()
        {
           
            bdConn = new SqlConnection("Server=DESKTOP-M8FGI40;Database=Jornal;Trusted_Connection = yes;");
            return bdConn;
            //Verifica se a conexão está aberta
        }

        public SqlConnection desconectar()
        {
           
           
               bdConn.Close();
               return bdConn;
    

            
        }


    }
}