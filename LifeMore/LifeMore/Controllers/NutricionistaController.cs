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

                String Nome = Request.Form["nome"];
                String Senha = Request.Form["senha"];
                String CPF = Request.Form["cpf"];
                String Email = Request.Form["email"];
                int Idade = int.Parse(Request.Form["idade"]);
                String LocalTrabalho = Request.Form["LocalTrabalho"];
                String Bio = Request.Form["bio"];
                String End = Request.Form["endereco"];
                String Tel = Request.Form["telefone"];
                String Foto = Request.Form["foto"];


                Nutricionista NovoUser = new Nutricionista();

                NovoUser.Nome = Nome;
                NovoUser.Senha = Senha;
                NovoUser.CPF = CPF;
                NovoUser.Email = Email;
                NovoUser.Idade = Idade;
                NovoUser.Telefone = Tel;
                NovoUser.Endereco = End;
                NovoUser.ImagemPerfil = Foto;
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

            return RedirectToAction("Listar");
        }
    }
}