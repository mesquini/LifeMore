using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Models
{
    public class Paciente
    {
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String CPF { get; set; }
        public String Objetivo { get; set; }
        public String Senha { get; set; }
        public String Telefone { get; set; }
        public Int32 Idade { get; set; }
        public String ImagemPerfil { get; set; }
        public Double Peso { get; set; }
        public Double Altura { get; set; }
        public String Endereco { get; set; }

        public Paciente() { }

        public Paciente(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Paciente WHERE ID=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Email = (String)Leitor["Email"];
            this.Senha = (String)Leitor["Senha"];
            this.Nome = (String)Leitor["Nome"];
            this.CPF = (String)Leitor["CPF_Paciente"];

            Conexao.Close();
        }


        public Paciente(String CPF, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Paciente WHERE CPF_Paciente=@CPF AND Senha=@Senha;";
            Comando.Parameters.AddWithValue("@CPF", CPF);
            Comando.Parameters.AddWithValue("@Senha", Senha);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Email = (String)Leitor["Email"];
            this.Senha = (String)Leitor["Senha"];
            this.Endereco = (String)Leitor["Endereco"];
            this.Nome = (String)Leitor["Nome"];
            this.Objetivo = (String)Leitor["Objetivo"];
            this.ImagemPerfil = (String)Leitor["Foto"];
            this.CPF = (String)Leitor["CPF_Paciente"];
            this.Altura = (Double)Leitor["Altura"];
            this.Peso = (Double)Leitor["Peso"];
            this.Idade = (Int32)Leitor["Idade"];
            this.Telefone = (String)Leitor["Telefone"];




            Conexao.Close();
        }

        public static List<Paciente> ListarP()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Paciente;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Paciente> Pacientes = new List<Paciente>();
            while (Leitor.Read())
            {
                Paciente P = new Paciente();
                P.Cod = (Int32)Leitor["Cod"];
                P.Nome = ((String)Leitor["Nome"]);
                P.Endereco = Leitor["Endereco"].ToString();
                P.CPF = (String)Leitor["SobrenomeU"];
                P.Email = ((String)Leitor["Email"]);
                P.Senha = (String)Leitor["Senha"];
                P.Altura = (float)Leitor["Altura"];
                P.Peso = (float)Leitor["Peso"];
                P.ImagemPerfil = (String)Leitor["Foto"];
                P.Telefone = (String)Leitor["Telefone"];


                Pacientes.Add(P);
            }

            Conexao.Close();

            return Pacientes;
        }
        public static Boolean Autenticar(String CPF, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Paciente WHERE CPF_Paciente=@CPF AND Senha=@Senha;";
            Comando.Parameters.AddWithValue("@CPF", CPF);
            Comando.Parameters.AddWithValue("@Senha", Senha);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();
            
            Conexao.Close();

            return true;
        }
    }
    
}