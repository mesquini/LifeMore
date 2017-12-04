using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LifeMore
{
    /// <summary>
    /// Summary description for Lifemore    
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Lifemore : System.Web.Services.WebService
    {

        [WebMethod]

        public List<Paciente> AutenticarP(String CPF, String Senha)
        {
            List<Paciente> lista = new List<Paciente>();

            if (Paciente.Autenticar(CPF, Senha))
            {
                lista = new Paciente().ListarPacienteCPF(CPF);
                return lista;
            }               
            else
            {
                return null;
            }
                
            //Paciente.ListarP();
            //return P;
        }

        [WebMethod]

        public Paciente listarP(String nome, int cod, String email, String CPF, int objetivo, String senha, String telefone, String idade, String imagemPerfil, String peso, String altura, String endereco)
        {
            Paciente.ListarP();
            Paciente P = new Paciente();
            //P.Nome = nome;
            //P.Cod = cod;
            //P.Email = email;
            //P.CPF = CPF;
            //P.Objetivo = objetivo;
            //P.Senha = senha;
            //P.Telefone = telefone;
            //P.Idade = idade;
            //P.ImagemPerfil = imagemPerfil;
            //P.Peso = peso;
            //P.Altura = altura;
            //P.Endereco = endereco;
           

            return P;
        }

        [WebMethod]

        public Nutricionista AutenticarN(String CPF, String Senha)
        {
            Nutricionista.Autenticar(CPF, Senha);
            Nutricionista N = new Nutricionista(CPF, Senha);
            return N;
        }
}
}
