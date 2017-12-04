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
        //VARIAVEIS
        public Int32 Cod { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String CPF { get; set; }
        public int Objetivo { get; set; }
        public String Senha { get; set; }
        public String Telefone { get; set; }
        public String Idade { get; set; }
        public String ImagemPerfil { get; set; }
        public String Peso { get; set; }
        public String Altura { get; set; }
        public String Endereco { get; set; }

        public Paciente() { }

        public Paciente(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Paciente WHERE Cod=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];
            this.Email = (String)Leitor["Email"];
            this.Senha = (String)Leitor["Senha"];
            this.Endereco = (String)Leitor["Endereco"];
            this.Nome = (String)Leitor["Nome"];
            this.Objetivo = (int)Leitor["Objetivo"];
            this.ImagemPerfil = (String)Leitor["Foto"];
            this.CPF = (String)Leitor["CPF_Paciente"];
            this.Altura = (String)Leitor["Altura"];
            this.Peso = (String)Leitor["Peso"];
            this.Idade = (String)Leitor["Idade"];
            this.Telefone = (String)Leitor["Telefone"];

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
            this.Objetivo = (int)Leitor["Objetivo"];
            this.ImagemPerfil = (String)Leitor["Foto"];
            this.CPF = (String)Leitor["CPF_Paciente"];
            this.Altura = (String)Leitor["Altura"];
            this.Peso = (String)Leitor["Peso"];
            this.Idade = (String)Leitor["Idade"];
            this.Telefone = (String)Leitor["Telefone"];




            Conexao.Close();
        }
        //METODO PARA VERIFICAR SE O CPF JA EXISTE
        public Boolean VerificaCPF(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;

            Comando.CommandText = "SELECT * FROM Paciente WHERE CPF_Paciente = @CPF_Paciente";
            Comando.Parameters.AddWithValue("@CPF_Paciente", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            if(!Leitor.HasRows)
            {
                return false;
            }

            Conexao.Close();

            return true;
        }
        //METODO PARA CRIAR UM NOVO USUARIO
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao; /*'458.363.878-77', 'teste', 'Rua 1', 'imagemPadrao.jpeg', 1.71, 'Emagrecer', 75.510, '987456321', 'Teste', 18, 'mesquini@live.com'*/
            Comando.CommandText = "INSERT INTO Paciente (CPF_Paciente, Nome, Endereco, Foto, Altura, Objetivo, Peso, Telefone, Senha, Idade, Email)"
              + "VALUES (@CPF_Paciente, @Nome, @Endereco, @Foto, @Altura, @Objetivo, @Peso, @Telefone, @Senha, @Idade, @Email);";

            Comando.Parameters.AddWithValue("@CPF_Paciente", this.CPF);
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Endereco", this.Endereco);
            Comando.Parameters.AddWithValue("@Foto", "imagemPadrao.jpeg");
            Comando.Parameters.AddWithValue("@Altura", this.Altura);
            Comando.Parameters.AddWithValue("@Objetivo", this.Objetivo);
            Comando.Parameters.AddWithValue("@Peso", this.Peso);
            Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
            Comando.Parameters.AddWithValue("@Senha", this.Senha);
            Comando.Parameters.AddWithValue("@Idade", this.Idade);
            Comando.Parameters.AddWithValue("@Email", this.Email);

            Int32 Resultado = Comando.ExecuteNonQuery();
           
            Conexao.Close();

            return Resultado > 0 ? true : false;

        }
        //METODO PARA EDITAR O PERFIL DE UM USUARIO
        public Boolean EditarPerfil()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();


            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "UPDATE Paciente SET Peso = @Peso , Altura = @Altura, Foto = @Imagem, Idade = @Idade, Email = @Email, Telefone = @Telefone,"
               +"Objetivo = @Objetivo, Endereco = @Endereco WHERE Cod = @ID;";

            Comando.Parameters.AddWithValue("@ID", this.Cod);
            Comando.Parameters.AddWithValue("@Peso", this.Peso);
            Comando.Parameters.AddWithValue("@Altura", this.Altura);
            Comando.Parameters.AddWithValue("@Imagem", this.ImagemPerfil);
            Comando.Parameters.AddWithValue("@Idade", this.Idade);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Telefone", this.Telefone);
            Comando.Parameters.AddWithValue("@Objetivo", this.Objetivo);
            Comando.Parameters.AddWithValue("@Endereco", this.Endereco);

            Int32 Resultado = Comando.ExecuteNonQuery();
            
            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        //METODO PARA BUSCAR INFORMAÇOES DO PACIENTE
        public Boolean BuscarDados(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Paciente WHERE Cod = @ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Boolean resultado = Leitor.HasRows;

            Leitor.Read();

            this.Cod = (Int32)Leitor["Cod"];

            Paciente Pacientes = new Paciente((Int32)Leitor["Cod"]);
            
            this.Email = (String)Leitor["Email"];
            this.Senha = (String)Leitor["Senha"];
            this.Endereco = (String)Leitor["Endereco"];
            this.Nome = (String)Leitor["Nome"];
            this.Objetivo = (int)Leitor["Objetivo"];
            this.ImagemPerfil = (String)Leitor["Foto"];
            this.CPF = (String)Leitor["CPF_Paciente"];
            this.Altura = (String)Leitor["Altura"];
            this.Peso = (String)Leitor["Peso"];
            this.Idade = (String)Leitor["Idade"];
            this.Telefone = (String)Leitor["Telefone"];

            Conexao.Close();
            return resultado;
        }
        //METODO PARA LISTAR OS PACIENTES
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
                P.CPF = (String)Leitor["CPF_Paciente"];
                P.Idade = (String)Leitor["Idade"];
                P.Email = ((String)Leitor["Email"]);
                P.Senha = (String)Leitor["Senha"];
                P.Altura = ((String)Leitor["Altura"]);
                P.Peso = (String)Leitor["Peso"];
                P.ImagemPerfil = (String)Leitor["Foto"];
                P.Telefone = (String)Leitor["Telefone"];


                Pacientes.Add(P);
            }

            Conexao.Close();

            return Pacientes;
        }

        //METODO PARA LISTAR OS DADOS DO PACIENTE ATRAVÉS DO CPF
        public List<Paciente> ListarPacienteCPF(String CPF)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Paciente WHERE CPF_Paciente = @CPF;";
            Comando.Parameters.AddWithValue("@CPF", CPF);

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Paciente> Pacientes = new List<Paciente>();
            while (Leitor.Read())
            {
                Paciente P = new Paciente();
                P.Cod = (Int32)Leitor["Cod"];
                P.Nome = ((String)Leitor["Nome"]);
                P.Endereco = Leitor["Endereco"].ToString();
                P.CPF = (String)Leitor["CPF_Paciente"];
                P.Idade = (String)Leitor["Idade"];
                P.Email = ((String)Leitor["Email"]);
                P.Senha = (String)Leitor["Senha"];
                P.Altura = ((String)Leitor["Altura"]);
                P.Peso = (String)Leitor["Peso"];
                P.ImagemPerfil = (String)Leitor["Foto"];
                P.Telefone = (String)Leitor["Telefone"];


                Pacientes.Add(P);
            }

            Conexao.Close();

            return Pacientes;
        }
        //METODO PARA AUTENTICAR UM USUARIO COM O CPF E SENHA
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

            if (!Leitor.HasRows)
            {
                Conexao.Close();
                return false;
            }
            Leitor.Read();

            Conexao.Close();

            return true;
        }
        //METODO PARA APAGAR UM USUARIO
        public Boolean Apagar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LifeMore"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Paciente WHERE Cod = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.Cod);

            Int32 Resultado = Comando.ExecuteNonQuery();
            
            return Resultado > 0 ? true : false;
        }
    }
    
}