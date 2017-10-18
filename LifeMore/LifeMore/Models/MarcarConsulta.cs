using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Models
{
    public class MarcarConsulta
    {
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
       public String Observacao { get; set; }
       public String Hora { get; set; }
       public String Data { get; set;}
         public MarcarConsulta () {  }

        public MarcarConsulta(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM MarcarConsulta WHERE Cod_Consulta=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Nome = (String)Leitor["Nome"];
            this.Email = (String)Leitor["Email"];
            this.Telefone = (String)Leitor["Telefone"];
            this.Observacao = (String)Leitor["Observações"];

            Conexao.Close();
        }
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao; /*'458.363.878-77', 'teste', 'Rua 1', 'imagemPadrao.jpeg', 1.71, 'Emagrecer', 75.510, '987456321', 'Teste', 18, 'mesquini@live.com'*/
            Comando.CommandText = "INSERT INTO MarcarConsulta (Cod_Consulta, Nome, Hora, Email, Observacao, Telefone, Data)"
              + "VALUES (@Cod_Consulta, @Nome, @Hora, @Email, @Observacao, @Telefone, @Data);";

            Comando.Parameters.AddWithValue("@Cod_Consulta", this.Cod);
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Hora", this.Hora);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Observacao", this.Observacao);
            Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
            Comando.Parameters.AddWithValue("@Data", this.Data);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<MarcarConsulta> ListarM()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM MarcarConsulta;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<MarcarConsulta> MarcarConsultas = new List<MarcarConsulta>();
            while (Leitor.Read())
            {
                MarcarConsulta M = new MarcarConsulta();
                M.Cod = (Int32)Leitor["Cod"];
                M.Nome = ((String)Leitor["Nome"]);
                M.Hora = ((String)Leitor["Hora"]);
                M.Email = (String)Leitor["Email"];
                M.Observacao = ((String)Leitor["Observacao"]);
                M.Telefone = (String)Leitor["Telefone"];
                M.Data = (String)Leitor["Data"];


                MarcarConsultas.Add(M);
            }

        Conexao.Close();

            return MarcarConsultas;
        }
        public Boolean Apagar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM MarcarConsulta WHERE Cod = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.Cod);

            Int32 Resultado = Comando.ExecuteNonQuery();



            return Resultado > 0 ? true : false;
        }
    }
    }
