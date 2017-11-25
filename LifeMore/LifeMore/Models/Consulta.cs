using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LifeMore.Models
{
    public class Consulta
    {
        public Int32 Cod_Consulta { get; set; }
        public String Cod_Nutri { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Dia { get; set; }
        public String Hora { get; set; }
        public String Comentario { get; set; }
        public String precoConsulta { get; set; }
        public String horaConsulta { get; set; }
        public String tipoConsulta { get; set; }

        public Consulta() { }

        public Consulta(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Consulta WHERE Cod_Consulta=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod_Consulta = (Int32)Leitor["Cod_Consulta"];

            Conexao.Close();
        }
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Consulta (Nome, CPF_Nutri, Dia, Hora, Email, Comentario, Telefone, precoConsulta, horaConsulta,"+
                " tipoConsulta) VALUES (@Nome, @CPF_Nutri, @Dia, @Hora, @Email, @Comentario, @Telefone, @precoConsulta, @horaConsulta, @tipoConsulta);";

            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@CPF_Nutri", this.Cod_Nutri);
            Comando.Parameters.AddWithValue("@Dia", this.Dia);
            Comando.Parameters.AddWithValue("@Hora", this.Hora);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Comentario", this.Comentario);
            Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
            Comando.Parameters.AddWithValue("@precoConsulta", this.precoConsulta);
            Comando.Parameters.AddWithValue("@horaConsulta", this.horaConsulta);
            Comando.Parameters.AddWithValue("@tipoConsulta", this.tipoConsulta);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        //METODO PARA VERIFICAR SE O CPF JA EXISTE
        public Boolean VerificaCPF(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "SELECT * FROM Consulta WHERE CPF_Nutri = @CPF_Nutri";
            Comando.Parameters.AddWithValue("@CPF_Nutri", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            if (!Leitor.HasRows)
            {
                return false;
            }

            Conexao.Close();

            return true;
        }
        public static List<Consulta> ListarC(string cpf)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "SELECT * FROM Consulta where CPF_Nutri = @CPF;";
            Comando.Parameters.AddWithValue("@CPF", cpf);

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Consulta> Consultas = new List<Consulta>();
            while (Leitor.Read())
            {
                Consulta A = new Consulta();
                A.Cod_Nutri = (String)Leitor["CPF_Nutri"];
                A.Nome = ((String)Leitor["Nome"]);
                A.Dia = ((String)Leitor["Dia"]);
                A.Hora = ((String)Leitor["Hora"]);
                A.Email = ((String)Leitor["Email"]);
                A.Telefone = ((String)Leitor["Telefone"]);
                A.Comentario = ((String)Leitor["Comentario"]);
                A.tipoConsulta = ((String)Leitor["tipoConsulta"]);
                A.horaConsulta = ((String)Leitor["horaConsulta"]);
                A.precoConsulta = ((String)Leitor["precoConsulta"]);

                Consultas.Add(A);
            }

            Conexao.Close();

            return Consultas;
        }
        public Boolean Apagar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Consulta WHERE Cod_Consulta = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.Cod_Consulta);

            Int32 Resultado = Comando.ExecuteNonQuery();



            return Resultado > 0 ? true : false;
        }
    }
}