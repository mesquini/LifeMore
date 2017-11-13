using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LifeMore.Models
{
    public class Cardapio
    {
        
        public Int32 Cod_Cardapio { get; set; }
        public String Nome { get; set; }
        public String NomeCliente { get; set; }
        public String NomeNutri { get; set; }
            public Cardapio() { }


        public Cardapio(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Cardapio WHERE Cod_Cardapio=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod_Cardapio = (Int32)Leitor["Cod_Cardapio"];
            this.Nome = (String)Leitor["Nome"];
            this.NomeCliente = (String)Leitor["NomeCliente"];
            this.NomeNutri = (String)Leitor["NomeNutri"];

            Conexao.Close();
        }
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Cardapio (Cod_Cardapio, Nome, NomeCliente, NomeNutri)"
              + "VALUES                             (@Cod_Cardapio, @Nome, @NomeCliente, @NomeNutri);";

            Comando.Parameters.AddWithValue("@Cod_Cardapio", this.Cod_Cardapio);
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@NomeCliente", this.NomeCliente);
            Comando.Parameters.AddWithValue("@NomeNutri", this.NomeNutri);


            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<Cardapio> ListarCardapio()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "SELECT * FROM Cardapio;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Cardapio> Cardapios = new List<Cardapio>();
            while (Leitor.Read())
            {
                Cardapio N = new Cardapio();
                N.Cod_Cardapio = (Int32)Leitor["Cod_Cardapio"];
                N.Nome = ((String)Leitor["Nome"]);
                N.NomeCliente = (String)Leitor["NomeCliente"];
                N.NomeNutri = (String)Leitor["NomeNutri"];

                Cardapios.Add(N);
            }

            Conexao.Close();

            return Cardapios;
        }
    }
}