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
        }

        [WebMethod]

        public List<Cardapio> buscaCardapio(String CPF)
        {
            List<Cardapio> lista = new List<Cardapio>();
            Cardapio c = new Cardapio();

            if (Cardapio.VerificaCPFCardapioWeb(CPF))
            {
                lista = new Cardapio().BuscarDadosWeb(CPF);

                return lista;
            }
            else
            {
                return null;
            }
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
