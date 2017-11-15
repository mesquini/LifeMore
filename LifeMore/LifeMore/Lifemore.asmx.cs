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

        public Paciente AutenticarP(String CPF, String Senha)
        {
            Paciente.Autenticar(CPF, Senha);
            Paciente P = new Paciente(CPF, Senha);

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
