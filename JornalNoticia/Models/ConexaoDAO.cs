using System;
using System.Data.SqlClient;

using System.Collections.Generic;



namespace JornalNoticia.Models
{
    public class ConexaoDAO
    {
        private SqlConnection  bdConn;
        Conexão conexao = new Conexão();

        public int inserirImagem(Noticia noticia)
        {
            int numerodelinha = 0;
            bdConn = conexao.conectar();

            try
            {
                bdConn.Open();
                SqlCommand cmd = new SqlCommand("insert into imagens(tipoimg,caminhoimg) Values(@Imagem,@Caminho)", bdConn);

                cmd.Parameters.AddWithValue("@Imagem", noticia.imagem.tipoimg);
                cmd.Parameters.AddWithValue("@Caminho", noticia.imagem.caminhoimagem);
                numerodelinha = cmd.ExecuteNonQuery();
                bdConn.Close();


            }
            catch (SqlException ex)
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
                SqlCommand cmd = new SqlCommand("insert into Categoria(tipCategoria) Values(@Categoria)", bdConn);

                cmd.Parameters.AddWithValue("@Categoria", categoria.TipCategria);
                numerodelinhas = cmd.ExecuteNonQuery();
                bdConn.Close();
            }
            catch(SqlException ex)
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
                SqlCommand cmd = new SqlCommand("insert into Area(NomeArea) Values(@Area)", bdConn);

                cmd.Parameters.AddWithValue("@Area", area.NomeArea);
                numerodelinhas = cmd.ExecuteNonQuery();
                bdConn.Close();
            }
            catch (SqlException ex)
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
                
                SqlCommand cmd = new SqlCommand("insert into Publicação(Titulo,CorpoNoticia,DtaPublicacao,idCategoria,idArea) Values(@Titulo,@Publicacao,(SELECT DATE_FORMAT(Now(),' %d %M %Y %H:%i')),(Select idCategoria from Categoria where idCategoria = @Categoria),(Select idArea from Area where idArea = @Area))", bdConn);
                cmd.Parameters.AddWithValue("@Titulo", noticia.Titulo);
                cmd.Parameters.AddWithValue("@Publicacao", noticia.Corponoticia);
                cmd.Parameters.AddWithValue("@Categoria",noticia.categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@Area", noticia.area.IdArea);
                numerodelinhas =cmd.ExecuteNonQuery();
                bdConn.Close();

            }
            catch(SqlException ex)
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

                SqlCommand cmd = new SqlCommand("select top 3 p.idPublicacao,p.titulo,p.Corponoticia,i.caminhoimg,i.tipoimg from Publicação p, imagens i where i.idPublicacao = p.idPublicacao ", bdConn);
               
                SqlDataReader reader = cmd.ExecuteReader();
               

                while (reader.Read())
                {
                    Noticia noticia = new Noticia();
                    noticia.Idnoticia = Convert.ToInt32(reader["p.idPublicacao"].ToString());
                    noticia.Titulo = Convert.ToString(reader["p.titulo"].ToString());
                    noticia.Corponoticia = Noticia.TruncateString(Convert.ToString(reader["p.Corponoticia"].ToString()),40,Noticia.TruncateOptions.None);
                    noticia.imagem.caminhoimagem = Convert.ToString(reader["i.caminhoimg"].ToString());
                    noticia.imagem.tipoimg = Convert.ToString(reader["i.tipoimg"].ToString());
                    listadados.Add(noticia);
                }
                reader.Close();

               
                

               

            }
            catch(SqlException ex)
            {
                string error = ex.Message;
                bdConn.Close();


            }
            return listadados;







        }




    }
}