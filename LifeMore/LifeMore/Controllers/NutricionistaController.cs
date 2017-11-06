using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class NutricionistaController : Controller
    {
        // GET: Nutricionista
        public ActionResult CadastrarN()
        {
            if (Request.HttpMethod == "POST")
            {

                String Nome = Request.Form["nomeN"];
                String Senha = Request.Form["senhaN"];
                String CPF = Request.Form["cpfN"];
                String Email = Request.Form["emailN"];
                int Idade = int.Parse(Request.Form["idadeN"]);
                String LocalTrabalho = Request.Form["localtrabN"];
                String Bio = Request.Form["bio"];
                String End = Request.Form["enderecoN"];
                String Tel = Request.Form["telefoneN"];


                Nutricionista NovoUser = new Nutricionista();

                NovoUser.Nome = Nome;
                NovoUser.Senha = Senha;
                NovoUser.CPF = CPF;
                NovoUser.Email = Email;
                NovoUser.Idade = Idade;
                NovoUser.Telefone = Tel;
                NovoUser.Endereco = End;
                NovoUser.Bio = Bio;
                NovoUser.LocalTrabalho = LocalTrabalho;

                

                if (NovoUser.Novo())
                {
                    ViewBag.Mensagem = "Nutricionista criado com sucesso!";
                    Response.Redirect("/Adm/Listar");
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar um Nutricionista. Verifique os dados e tente novamente.";
                }
            }
            return View();
        }

        public ActionResult VerN()
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }
            if(TempData["Nutricionista"] != null)
            {
                ViewBag.Perfil = (Nutricionista)TempData["Nutricionista"];
            }
            return View();
        }
        public ActionResult ApagarN(String ID)
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            Nutricionista Nutri = new Nutricionista(Convert.ToInt32(ID));

            if (Nutri.Apagar())
            {
                ViewBag.Mensagem = "Nutricionista removida com sucesso!";
            }


            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Usuario. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar", "Adm");
        }
    }
}