using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Models
{
    public class Adm
    {
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }

        public Adm() { }

        public Adm(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Administrador WHERE Cod=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Senha = (String)Leitor["Senha"];
            this.Nome = (String)Leitor["Nome"];

            Conexao.Close();
        }
        public Adm(String CPF, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Administrador WHERE Nome=@CPF AND Senha=@Senha;";
            Comando.Parameters.AddWithValue("@CPF", CPF);
            Comando.Parameters.AddWithValue("@Senha", Senha);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Senha = (String)Leitor["Senha"];
            this.Nome = (String)Leitor["Nome"];




            Conexao.Close();
        }
        public static Boolean Autenticar(String CPF, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Administrador WHERE Nome=@Nome AND Senha=@Senha;";
            Comando.Parameters.AddWithValue("@Nome", CPF);
            Comando.Parameters.AddWithValue("@Senha", Senha);

            SqlDataReader Leitor = Comando.ExecuteReader();

            if (!Leitor.HasRows)
            {
                Conexao.Close();
                return false;
            }
            Leitor.Read();

            Conexao.Close();

            return true;
        }

    }

    }