using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LifeMore.Models
{
    public class Feedbacks
    {
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Mensagem { get; set; }
        public DateTime Data { get; set; }

        public Feedbacks() { }

        public Feedbacks(Int32 ID)
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
            Comando.CommandText = "INSERT INTO Feedback (Nome, Email, Comentario, Data) VALUES (@Nome, @Email, @Comentario, @Data);";

            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Comentario", this.Mensagem);
            Comando.Parameters.AddWithValue("@Data", DateTime.Now);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<Feedbacks> ListarF()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Feedback;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Feedbacks> feedbacks = new List<Feedbacks>();
            while (Leitor.Read())
            {
                Feedbacks F = new Feedbacks();
                F.Cod = (Int32)Leitor["Cod_Feedback"];
                F.Nome = ((String)Leitor["Nome"]);
                F.Email = ((String)Leitor["Email"]);
                F.Mensagem = ((String)Leitor["Comentario"]);
                F.Data = (DateTime)Leitor["Data"];

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