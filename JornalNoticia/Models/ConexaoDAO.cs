using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace JornalNoticia.Models
{
    public class ConexaoDAO
    {
        private MySqlConnection bdConn;
        Conexão conexao = new Conexão();

        public int inserirImagem(Noticia noticia)
        {
            int numerodelinha = 0;
            bdConn = conexao.conectar();

            try
            {
                bdConn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into imagens(tipoimg,caminhoimg) Values(@Imagem,@Caminho)", bdConn);

                cmd.Parameters.AddWithValue("@Imagem", noticia.imagem.tipoimg);
                cmd.Parameters.AddWithValue("@Caminho", noticia.imagem.caminhoimagem);
                numerodelinha = cmd.ExecuteNonQuery();
                bdConn.Close();


            }
            catch (MySqlException ex)
            {
                string erro = ex.Message;
                bdConn.Close();

            }
            return numerodelinha;
        }

        public int inserirCategoria(Categoria categoria)
        {
            int numerodelinhas = 0;
            bdConn = conexao.conectar();
            try
            {
                bdConn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into Categoria(tipCategoria) Values(@Categoria)", bdConn);

                cmd.Parameters.AddWithValue("@Categoria", categoria.TipCategria);
                numerodelinhas = cmd.ExecuteNonQuery();
                bdConn.Close();
            }
            catch(MySqlException ex)
            {
                string erro = ex.Message;
                bdConn.Close();
            }
            return numerodelinhas;

        }
        public int inserirArea(Area area)
        {
            int numerodelinhas = 0;
            bdConn = conexao.conectar();
            try
            {
                bdConn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into Area(NomeArea) Values(@Area)", bdConn);

                cmd.Parameters.AddWithValue("@Area", area.NomeArea);
                numerodelinhas = cmd.ExecuteNonQuery();
                bdConn.Close();
            }
            catch (MySqlException ex)
            {
                string erro = ex.Message;
                bdConn.Close();
            }
            return numerodelinhas;

        }





        public int inserir(Noticia noticia)
        {
            int numerodelinhas = 0;
           
            bdConn=conexao.conectar();
            try
            {
                bdConn.Open();
                
                MySqlCommand cmd = new MySqlCommand("insert into Publicação(Titulo,CorpoNoticia,DtaPublicacao,idCategoria,idArea) Values(@Titulo,@Publicacao,(SELECT DATE_FORMAT(Now(),' %d %M %Y %H:%i')),(Select idCategoria from Categoria where idCategoria = @Categoria),(Select idArea from Area where idArea = @Area))", bdConn);
                cmd.Parameters.AddWithValue("@Titulo", noticia.Titulo);
                cmd.Parameters.AddWithValue("@Publicacao", noticia.Corponoticia);
                cmd.Parameters.AddWithValue("@Categoria",noticia.categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@Area", noticia.area.IdArea);
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

            bdConn = conexao.conectar();
            List<Noticia> listadados = new List<Noticia>();
            try
            {
                bdConn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from publicacao LIMIT 3", bdConn);
                MySqlCommand cmd1 = new MySqlCommand("select * from imagens LIMIT 3", bdConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                MySqlDataReader readerimagem = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    Noticia noticia = new Noticia();
                    noticia.Idnoticia = Convert.ToInt32(reader["idPublicacao"].ToString());
                    noticia.Titulo = Convert.ToString(reader["Titulo"].ToString());
                    noticia.Corponoticia = Noticia.TruncateString(Convert.ToString(reader["Corponoticia"].ToString()),40,Noticia.TruncateOptions.None);
                   while(readerimagem.Read())
                    {
                        if(Convert.ToInt32(reader["idImagem"])==noticia.imagem.idimagem)
                        {
                            noticia.imagem.caminhoimagem = Convert.ToString(reader["caminhoimg"].ToString());
                        }
                       
                    }
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