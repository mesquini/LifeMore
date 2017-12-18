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
        public String NomeAli { get; set; }
        public String NomeC { get; set; }
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
            this.Cod_Cliente = (String)Leitor["Cod_Cliente"];
            this.Cod_Nutri = (String)Leitor["Cod_Nutri"];

            Conexao.Close();
        }
        //METODO PARA CADASTRAR UM NOVO CARDAPIO
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Cardapio (Nome, Cod_Cliente, Cod_Nutri)"
              + "VALUES                             (@Nome, @Cod_Cliente, @Cod_Nutri);";
            
            Comando.Parameters.AddWithValue("@Nome", this.NomeC);
            Comando.Parameters.AddWithValue("@Cod_Cliente", this.Cod_Cliente);
            Comando.Parameters.AddWithValue("@Cod_Nutri", this.Cod_Nutri);



            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        //METODO PARA CADASTRAR UM NOVO CARDAPIO
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
        //METODO PARA PEGAR NOME DO CARDAPIO E NOME DA NUTRICIONISTA
        public  Boolean ListarCardapio(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "Select Cardapio.Cod_Cardapio, Cardapio.Nome AS NomeC,Nutricionista.Nome as NomeNutri"+

   " from CardapioAlimento, Cardapio, Alimento, Nutricionista"+

   " where Cardapio.Cod_Cardapio = CardapioAlimento.Cod_Cardapio"+

   " and CardapioAlimento.Cod_Alimento = Alimento.Cod_Alimento"+

   " and Cardapio.Cod_Nutri = Nutricionista.CPF_Nutri"+

   " and Cod_Cliente = @CPF_Paciente" +

   " and Cardapio.Cod_Cardapio = (Select Max(cod_cardapio) from cardapio where Cod_Cliente = @CPF_Paciente); ";

            Comando.Parameters.AddWithValue("@CPF_Paciente", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();
            
            this.Cod_Cardapio = (Int32)Leitor["Cod_Cardapio"];
            this.NomeC = (String)Leitor["NomeC"];
            this.NomeNutri = (String)Leitor["NomeNutri"];
            

            Conexao.Close();

            return true;
        }
        //METODO PARA VERIFICAR CPF JA CADASTRADO EM UM CARDAPIO
        public Boolean VerificaCPFCardapio(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "select Cardapio.Cod_Cliente from Paciente, Cardapio where Cod_Cliente = @CPF_Paciente";
            Comando.Parameters.AddWithValue("@CPF_Paciente", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            if (!Leitor.HasRows)
            {
                return false;
            }

            Conexao.Close();

            return true;
        }
        public static Boolean  VerificaCPFCardapioWeb(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "select Cardapio.Cod_Cliente from Paciente, Cardapio where Cod_Cliente = @CPF_Paciente";
            Comando.Parameters.AddWithValue("@CPF_Paciente", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            if (!Leitor.HasRows)
            {
                return false;
            }

            Conexao.Close();

            return true;
        }
        //METODO PARA RETORNAR ULTIMO CARDAPIO CADASTRADO
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
        public static List<Cardapio> BuscarDados(String CPF)
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

            List<Cardapio> Cardapios = new List<Cardapio>();

                while (Leitor.Read())
                {
                    Cardapio N = new Cardapio((Int32)Leitor["Cod_Cardapio"]);

                     N.Cod_Cardapio = (Int32)Leitor["Cod_Cardapio"];
                    N.NomeAli = (String)Leitor["Alimento"];
                    N.Observacao = (String)Leitor["Observacao"];
                    N.Qtd = (Int32)Leitor["Qnt"];
                    N.Caloria = (Double)Leitor["Caloria"];
                    N.Peso = (String)Leitor["Peso"];
                    N.Carboidrato = (Double)Leitor["Carboidrato"];

                    Cardapios.Add(N);
                }
            
            Conexao.Close();

            return Cardapios;
        }
        public  List<Cardapio> BuscarDadosWeb(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "Select Cardapio.Cod_Cardapio, Cardapio.Nome AS NomeCardapio, Alimento.Nome AS Alimento, Alimento.Peso, Alimento.Caloria, Alimento.Carboidrato, Observacao, Qnt, Nutricionista.Nome AS NomeNutri" +

    " from CardapioAlimento, Cardapio, Alimento, Nutricionista" +

    " where Cardapio.Cod_Cardapio = CardapioAlimento.Cod_Cardapio" +

    " and CardapioAlimento.Cod_Alimento = Alimento.Cod_Alimento" +

    " and Cardapio.Cod_Nutri = Nutricionista.CPF_Nutri" +

    " and Cod_Cliente = @ID " +

    " and Cardapio.Cod_Cardapio = (Select Max(cod_cardapio) from cardapio where Cod_Cliente = @ID)";

            Comando.Parameters.AddWithValue("@ID", CPF);


            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Cardapio> Cardapios = new List<Cardapio>();

            while (Leitor.Read())
            {
                Cardapio N = new Cardapio((Int32)Leitor["Cod_Cardapio"]);

                N.Cod_Cardapio = (Int32)Leitor["Cod_Cardapio"];
                N.NomeAli = (String)Leitor["Alimento"];
                N.Observacao = (String)Leitor["Observacao"];
                N.Qtd = (Int32)Leitor["Qnt"];
                N.Caloria = (Double)Leitor["Caloria"];
                N.Peso = (String)Leitor["Peso"];
                N.Carboidrato = (Double)Leitor["Carboidrato"];

                Cardapios.Add(N);
            }

            Conexao.Close();

            return Cardapios;
        }
        //METODO PARA APAGAR A TABELA CARDAPIOALIMENTO
        public Boolean ApagarCA()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM CardapioAlimento WHERE Cod_Cardapio = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.Cod_Cardapio);

            Int32 Resultado = Comando.ExecuteNonQuery();

            return Resultado > 0 ? true : false;
        }
        //METODO PARA APAGAR O CARDAPIO
        public Boolean ApagarC(string CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Cardapio WHERE Cod_Cliente = @ID;";
            Comando.Parameters.AddWithValue("@ID", CPF);

            Int32 Resultado = Comando.ExecuteNonQuery();

            return Resultado > 0 ? true : false;
        }
    }
}