using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LifeMore.Models
{
    public class Alimento
    {
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Peso { get; set; }
        public double Caloria { get; set; }
        public double Gordura { get; set; }
        public double Carboidrato { get; set; }
        public double Proteina { get; set; }
        public Int32 Categoria { get; set; }

        public Alimento() { }

        public Alimento(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Alimento WHERE Cod_Alimento=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod_Alimento"];
            this.Nome = (String)Leitor["Nome"];
            this.Categoria = (Int32)Leitor["Categoria"];
            this.Peso = (String)Leitor["Peso"];

            Conexao.Close();
        }
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao; 
            Comando.CommandText = "INSERT INTO Alimento (Nome, Peso, Caloria, Gordura, Carboidrato, Proteina, Categoria)"
              + "VALUES (@Nome, @Peso, @Caloria, @Gordura, @Carboidrato, @Proteina, @Categoria);";
            
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Peso", this.Peso);
            Comando.Parameters.AddWithValue("@Caloria", this.Caloria);
            Comando.Parameters.AddWithValue("@Gordura", this.Gordura);
            Comando.Parameters.AddWithValue("@Carboidrato", this.Carboidrato);
            Comando.Parameters.AddWithValue("@Proteina", this.Proteina);
            Comando.Parameters.AddWithValue("@Categoria", this.Categoria);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<Alimento> ListarA()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Alimento;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Alimento> Alimentos = new List<Alimento>();
            while (Leitor.Read())
            {
                Alimento A = new Alimento();
                A.Cod = (Int32)Leitor["Cod_Alimento"];
                A.Nome = ((String)Leitor["Nome"]);
                A.Peso = ((String)Leitor["Peso"]);
                A.Caloria = (double)Leitor["Caloria"];
                A.Gordura = ((double)Leitor["Gordura"]);
                A.Carboidrato = (double)Leitor["Carboidrato"];
                A.Proteina = (double)Leitor["Proteina"];
                A.Categoria = (Int32)Leitor["Categoria"];

                Alimentos.Add(A);
            }

            Conexao.Close();

            return Alimentos;
        }
        public Boolean ApagarA()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Alimento WHERE Cod_Alimento = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.Cod);

            Int32 Resultado = Comando.ExecuteNonQuery();



            return Resultado > 0 ? true : false;
        }

    }
}