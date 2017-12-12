using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Models
{
    public class Nutricionista
    {
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String CPF { get; set; }
        public String Senha { get; set; }
        public String Telefone { get; set; }
        public Int32 Idade { get; set; }
        public String ImagemPerfilN { get; set; }
        public String LocalTrabalho { get; set; }
        public String Bio { get; set; }
        public String Endereco { get; set; }
        public String crm { get; set; }
        public Nutricionista() { }

        public Nutricionista(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Nutricionista WHERE Cod=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Email = (String)Leitor["Email"];
            this.Senha = (String)Leitor["Senha"];
            this.Endereco = (String)Leitor["Endereco"];
            this.Nome = (String)Leitor["Nome"];
            this.Idade = (int)Leitor["Idade"];
            this.ImagemPerfilN = (String)Leitor["Foto"];
            this.CPF = (String)Leitor["CPF_Nutri"];
            this.Bio = (String)Leitor["Bio"];
            this.LocalTrabalho = (String)Leitor["LocalTrabalho"];
            this.Telefone = (String)Leitor["Telefone"];
            this.crm = (String)Leitor["CRM"];

            Conexao.Close();
        }


        public Nutricionista(String CPF, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Nutricionista WHERE CPF_Nutri=@CPF AND Senha=@Senha;";
            Comando.Parameters.AddWithValue("@CPF", CPF);
            Comando.Parameters.AddWithValue("@Senha", Senha);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Email = (String)Leitor["Email"];
            this.Senha = (String)Leitor["Senha"];
            this.Endereco = (String)Leitor["Endereco"];
            this.Nome = (String)Leitor["Nome"];
            this.Idade = (int)Leitor["Idade"];
            this.ImagemPerfilN = (String)Leitor["Foto"];
            this.CPF = (String)Leitor["CPF_Nutri"];
            this.Bio = (String)Leitor["Bio"];
            this.LocalTrabalho = (String)Leitor["LocalTrabalho"];
            this.Telefone = (String)Leitor["Telefone"];
            this.crm = (String)Leitor["CRM"];



            Conexao.Close();
        }
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao; /*'111.111.111-11','1', 40, 'Rua40','mesquini@live.com', '(19)9 8745-6321', 'Nutri', 'imagemPadrao.jpeg', 'SENAI'*/
            Comando.CommandText = "INSERT INTO Nutricionista (CPF_Nutri, Senha, Idade, Endereco, Email, Telefone, Nome, Foto, LocalTrabalho, CRM, Bio)"
              + "VALUES                                     (@CPF_Nutri, @Senha, @Idade, @Endereco, @Email, @Telefone, @Nome, @Foto, @LocalTrabalho, @CRM, @Bio);";

            Comando.Parameters.AddWithValue("@CPF_Nutri", this.CPF);
            Comando.Parameters.AddWithValue("@Senha", this.Senha);
            Comando.Parameters.AddWithValue("@Idade", this.Idade);
            Comando.Parameters.AddWithValue("@Endereco", this.Endereco);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Foto", "imagemPadrao.jpeg");
            Comando.Parameters.AddWithValue("@LocalTrabalho", this.LocalTrabalho);
            Comando.Parameters.AddWithValue("@CRM", this.crm);
            Comando.Parameters.AddWithValue("@Bio", this.Bio);


            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public Boolean EditarPerfil()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();


            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "UPDATE Nutricionista SET Idade = @Idade, Endereco = @Endereco, Email = @Email, Telefone = @Telefone, Foto = @Foto, LocalTrabalho = @LocalTrabalho, Bio = @Bio"
               + " WHERE Cod = @ID;";

            Comando.Parameters.AddWithValue("@ID", this.Cod);
            Comando.Parameters.AddWithValue("@Idade", this.Idade);
            Comando.Parameters.AddWithValue("@Endereco", this.Endereco);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
            Comando.Parameters.AddWithValue("@Foto", this.ImagemPerfilN);
            Comando.Parameters.AddWithValue("@LocalTrabalho", this.LocalTrabalho);
            Comando.Parameters.AddWithValue("@Bio", this.Bio);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<Nutricionista> ListarN()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            
            Comando.CommandText = "SELECT * FROM Nutricionista;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Nutricionista> Nutricionistas = new List<Nutricionista>();
            while (Leitor.Read())
            {
                Nutricionista N = new Nutricionista();
                N.Cod = (Int32)Leitor["Cod"];
                N.CPF = (String)Leitor["CPF_Nutri"];
                N.Senha = (String)Leitor["Senha"];
                N.Idade = (Int32)Leitor["Idade"];
                N.Endereco = Leitor["Endereco"].ToString();
                N.Email = ((String)Leitor["Email"]);
                N.Telefone = (String)Leitor["Telefone"];
                N.Nome = ((String)Leitor["Nome"]);
                N.ImagemPerfilN = (String)Leitor["Foto"];
                N.LocalTrabalho = (String)Leitor["LocalTrabalho"];
                N.crm = (String)Leitor["CRM"];
                N.Bio = ((String)Leitor["Bio"]);

                Nutricionistas.Add(N);
            }

            Conexao.Close();

            return Nutricionistas;
        }
        public Boolean BuscarDados(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Nutricionista WHERE Cod = @ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Boolean resultado = Leitor.HasRows;

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            Nutricionista Nutricionistas = new Nutricionista((Int32)Leitor["Cod"]);
            this.Email = (String)Leitor["Email"];
            this.Senha = (String)Leitor["Senha"];
            this.Endereco = (String)Leitor["Endereco"];
            this.Nome = (String)Leitor["Nome"];
            this.Idade = (Int32)Leitor["Idade"];
            this.ImagemPerfilN = (String)Leitor["Foto"];
            this.CPF = (String)Leitor["CPF_Nutri"];
            this.Bio = (String)Leitor["Bio"];
            this.LocalTrabalho = (String)Leitor["LocalTrabalho"];
            this.crm = (String)Leitor["CRM"];
            this.Telefone = (String)Leitor["Telefone"];

            Conexao.Close();
            return resultado;
        }
        public static Boolean Autenticar(String CPF, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Nutricionista WHERE CPF_Nutri=@CPF AND Senha=@Senha;";
            Comando.Parameters.AddWithValue("@CPF", CPF);
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
        public Boolean Apagar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Nutricionista WHERE Cod = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.Cod);

            Int32 Resultado = Comando.ExecuteNonQuery();



            return Resultado > 0 ? true : false;
        }
    }

}