using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace JornalNoticia.Models
{
    public class ConexaoDAO
    {   

        private MySqlConnection bdConn;
        public int inserir(Noticia noticia)
        {
            int numerodelinhas = 0;
            bdConn = new MySqlConnection("Server=localhost;Database=noticia;Uid=root;Pwd=necnec@1");
            try
            {
                bdConn.Open();
                
                MySqlCommand cmd = new MySqlCommand("insert into publicacao(titulo,corponoticia,caminhoimg)  values(@Titulo,@Publicacao,@Caminho)", bdConn);
                cmd.Parameters.AddWithValue("@Titulo", noticia.Titulo);
                cmd.Parameters.AddWithValue("@Publicacao", noticia.Corponoticia);
                cmd.Parameters.AddWithValue("@Caminho", noticia.caminhoimg);
                numerodelinhas =cmd.ExecuteNonQuery();
                bdConn.Close();

            }
            catch(MySqlException ex)
            {

                string erro = ex.Message;
                bdConn.Close();
                


            }
            return numerodelinhas;


           
               
                
            
            
        }
        public List<Noticia> consultarNoticia()
        {
           
            bdConn = new MySqlConnection("Server=localhost;Database=noticia;Uid=root;Pwd=necnec@1");
            List<Noticia> listadados = new List<Noticia>();
            try
            {
                bdConn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from publicacao LIMIT 3", bdConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read())
                {
                    Noticia noticia = new Noticia();
                    noticia.Idnoticia = Convert.ToInt32(reader["idnoticia"].ToString());
                    noticia.Titulo = Convert.ToString(reader["titulo"].ToString());
                    noticia.Corponoticia = Noticia.TruncateString(Convert.ToString(reader["corponoticia"].ToString()),40,Noticia.TruncateOptions.None);
                    noticia.caminhoimg = Convert.ToString(reader["caminhoimg"].ToString());
                    listadados.Add(noticia);
                }
                reader.Close();
           

            }
            catch(MySqlException ex)
            {
                string error = ex.Message;
                bdConn.Close();


            }
            return listadados;







        }


    }
}