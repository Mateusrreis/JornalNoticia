using System.Data.SqlClient;


namespace JornalNoticia.Models
{
    public class Conexão
    {

        SqlConnection bdConn;
        public  SqlConnection conectar()
        {
           
            bdConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\matheusrps\\Desktop\\Intranet\\JornalNoticia-Atualizado2\\JornalNoticia-Atualizado\\JornalNoticia\\App_Data\\Jornal.mdf;Integrated Security=True");
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