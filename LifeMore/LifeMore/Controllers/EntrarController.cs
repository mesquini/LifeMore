using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class EntrarController : Controller
    {
        // GET: Entrar
        public ActionResult Cadastrar()
        {
            
            if (Request.HttpMethod == "POST")
            {

                String Nome = Request.Form["nome"];
                String Senha = Request.Form["senha"];
                String CPF = Request.Form["cpf"];
                String Email = Request.Form["email"];
                int Objetivo = int.Parse(Request.Form["objetivo"]);
                String Idade = Request.Form["idade"];
                String Peso = Request.Form["peso"];
                String Altura = Request.Form["altura"];
                String End = Request.Form["endereco"];
                String Tel = Request.Form["telefone"];
                String Foto = Request.Form["foto"];
               

                Paciente NovoUser = new Paciente();

                NovoUser.Nome = Nome;
                NovoUser.Senha = Senha;
                
                NovoUser.CPF = CPF;
                NovoUser.Email = Email;
                NovoUser.Objetivo = Objetivo;
                NovoUser.Idade = Idade;
                NovoUser.Peso = Peso;
                NovoUser.Altura = Altura;
                NovoUser.Telefone = Tel;
                NovoUser.Endereco = End;
                NovoUser.ImagemPerfil = Foto;

                if (NovoUser.VerificaCPF(CPF))
                {
                    if (NovoUser.Novo())
                    {
                        ViewBag.Mensagem = "Usuário criado com sucesso!";
                        Response.Redirect("/Perfil/IndexPerfil");
                    }
                    else
                    {
                        ViewBag.Mensagem = "Houve um erro ao criar o Usuário. Verifique os dados e tente novamente.";
                    }
                }
                else
                {
                    ViewBag.CPF = "CPF já cadastrado!";
                }
                
                
            }
            
            return View();
        }
        public ActionResult Logar()
        {
            Session.Clear();

            if (Request.HttpMethod == "POST")
            {
                String CPF = Request.Form["cpf"].ToString();
                String Senha = Request.Form["senha"].ToString();

                if (Paciente.Autenticar(CPF, Senha))
                {
                    Paciente P = new Paciente(CPF, Senha);
                    Session["Paciente"] = P;
                    Response.Redirect("/Perfil/IndexPerfil");
                }
                   

                    if (Nutricionista.Autenticar(CPF, Senha))
                    {
                        Nutricionista N = new Nutricionista(CPF, Senha);
                        Session["Nutricionista"] = N;
                        Response.Redirect("/Nutricionista/Perfil");
                    }
                    else
                    {
                        ViewBag.MsgErro = "CPF e/ou Senha incorreto!";
                    }
                

                if (Session["Paciente"] != null)
                {
                    ViewBag.Logado = Session["Paciente"];
                    Paciente Paciente = (Paciente)Session["Paciente"];

                    ViewBag.CPF = Paciente.CPF;
                    ViewBag.Nome = Paciente.Nome;
                    ViewBag.Objetivo = Paciente.Objetivo;

                }
            }
                return View();

            }
        public void Sair()
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("/Home/Index", false);
        }

    }
}