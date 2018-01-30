using System.Data;
using MySql.Data.MySqlClient;

namespace JornalNoticia.Models
{
    public class Conexão
    {

        MySqlConnection bdConn;
        public  MySqlConnection conectar()
        {
           
            bdConn = new MySqlConnection("Server=localhost;Database=teste;Uid=root;Pwd=gengar38");
            return bdConn;
            //Verifica se a conexão está aberta
        }

        public MySqlConnection desconectar()
        {
           
           
               bdConn.Close();
               return bdConn;
    

            
        }


    }
}