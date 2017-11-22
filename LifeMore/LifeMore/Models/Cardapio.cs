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
        public String Cod_Cliente { get; set; }
        public String Cod_Nutri { get; set; }
        public Int32 Cod_Alimento { get; set; }
        public String Nome { get; set; }
        public String Observacao { get; set; }
        public String NomeCardapio { get; set; }
        public String NomePaciente { get;  set; }
        public String NomeNutri { get;  set; }
        public String Peso { get; set; }
        public Double Caloria { get; set; }
        public Double Carboidrato { get; set; }
        public Int32 Qtd { get; set; }

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
            this.Cod_Cliente = (String)Leitor["Cod_Cliente"];
            this.Cod_Nutri = (String)Leitor["Cod_Nutri"];

            Conexao.Close();
        }
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Cardapio (Nome, Cod_Cliente, Cod_Nutri)"
              + "VALUES                             (@Nome, @Cod_Cliente, @Cod_Nutri);";
            
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Cod_Cliente", this.Cod_Cliente);
            Comando.Parameters.AddWithValue("@Cod_Nutri", this.Cod_Nutri);



            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public Boolean NovoCardapio()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO CardapioAlimento (Cod_Alimento, Cod_Cardapio, Observacao, Qnt)"
              + "VALUES                             (@Cod_Alimento, @Cod_Cardapio, @Observacao, @Qnt);";

            Comando.Parameters.AddWithValue("@Cod_Alimento", this.Cod_Alimento);
            Comando.Parameters.AddWithValue("@Cod_Cardapio", this.Cod_Cardapio);
            Comando.Parameters.AddWithValue("@Observacao", this.Observacao);
            Comando.Parameters.AddWithValue("@Qnt", this.Qtd);



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
                N.Nome = (String)Leitor["Nome"];
                N.Cod_Cliente = (String)Leitor["Cod_Cliente"];
                N.Cod_Nutri = (String)Leitor["Cod_Nutri"];

                Cardapios.Add(N);
            }

            Conexao.Close();

            return Cardapios;
        }
        public Boolean VerificaCPFCardapio(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "select Paciente.CPF_Paciente from Paciente, Cardapio where Cod_Cliente = @CPF_Paciente";
            Comando.Parameters.AddWithValue("@CPF_Paciente", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            if (!Leitor.HasRows)
            {
                return false;
            }

            Conexao.Close();

            return true;
        }
        public static int ultimoCardapio()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "SELECT MAX(Cod_Cardapio) FROM Cardapio;";

            int Cod_Cardapio = Convert.ToInt32(Comando.ExecuteScalar());

            Conexao.Close();
            return Cod_Cardapio;
        }
        //METODO PARA BUSCAR INFORMAÇOES DO CARDAPIO
        public Boolean BuscarDados(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "Select Cardapio.Cod_Cardapio, Cardapio.Nome AS NomeCardapio, Alimento.Nome AS Alimento, Alimento.Peso, Alimento.Caloria, Alimento.Carboidrato, Observacao, Qnt, Nutricionista.Nome AS NomeNutri" +

    " from CardapioAlimento, Cardapio, Alimento, Nutricionista"+

    " where Cardapio.Cod_Cardapio = CardapioAlimento.Cod_Cardapio"+

    " and CardapioAlimento.Cod_Alimento = Alimento.Cod_Alimento"+

    " and Cardapio.Cod_Nutri = Nutricionista.CPF_Nutri"+

    " and Cod_Cliente = @ID "+

    " and Cardapio.Cod_Cardapio = (Select Max(cod_cardapio) from cardapio where Cod_Cliente = @ID)";

            Comando.Parameters.AddWithValue("@ID", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Boolean resultado = Leitor.HasRows;

            Leitor.Read();

            this.Cod_Cardapio = (Int32)Leitor["Cod_Cardapio"];

            Cardapio cardapios = new Cardapio((Int32)Leitor["Cod_Cardapio"]);

            this.Nome = (String)Leitor["Alimento"];
            this.Observacao = (String)Leitor["Observacao"];
            this.NomeCardapio = (String)Leitor["NomeCardapio"];
            this.Qtd = (Int32)Leitor["Qnt"];
            this.NomeNutri = (String)Leitor["NomeNutri"];
            this.Caloria = (Double)Leitor["Caloria"];
            this.Peso = (String)Leitor["Peso"];
            this.Carboidrato = (Double)Leitor["Carboidrato"];

            Conexao.Close();
            return resultado;
        }
    }
}