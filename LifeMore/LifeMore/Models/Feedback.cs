using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LifeMore.Models
{
    public class Feedback
    {
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Mensagem { get; set; }
        public String Data { get; set; }

        public Feedback() { }

        public Feedback(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Feedback WHERE Cod_Feedback=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod_Feedback"];

            Conexao.Close();
        }
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Feedback (Nome, Email, Comentario) VALUES (@Nome, @Email, @Comentario);";

            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Comentario", this.Mensagem);
           // Comando.Parameters.AddWithValue("@Data", this.Data);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<Feedback> ListarF()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Feedback;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Feedback> feedbacks = new List<Feedback>();
            while (Leitor.Read())
            {
                Feedback F = new Feedback();
                F.Cod = (Int32)Leitor["Cod_Categoria"];
                F.Nome = ((String)Leitor["Nome"]);
                F.Email = ((String)Leitor["Email"]);
                F.Mensagem = ((String)Leitor["Mensagem"]);
                F.Data = ((String)Leitor["Data"]);

                feedbacks.Add(F);
            }

            Conexao.Close();

            return feedbacks;
        }
        public Boolean Apagar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Feedback WHERE Cod_Feedback = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.Cod);

            Int32 Resultado = Comando.ExecuteNonQuery();



            return Resultado > 0 ? true : false;
        }
    }
}