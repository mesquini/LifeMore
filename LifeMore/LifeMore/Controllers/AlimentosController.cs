using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class AlimentosController : Controller
    {
        // GET: Alimentos
        public ActionResult CadastrarA()
        {
            if (Request.HttpMethod == "POST")
            {

                String Nome = Request.Form["nomeA"];
                String Peso = Request.Form["pesoA"];
                double Caloria = Double.Parse(Request.Form["caloriaA"]);
                double Gordura = Double.Parse(Request.Form["gorduraA"]);
                double Carboidrato = Double.Parse(Request.Form["carboidratoA"]);
                double Proteina = Double.Parse(Request.Form["proteinaA"]);
                Int32 Categoria = Int32.Parse(Request.Form["categoriaA"]);

                Alimento Ali = new Alimento();

                Ali.Nome = Nome;
                Ali.Peso = Peso;
                Ali.Caloria = Caloria;
                Ali.Gordura = Gordura;
                Ali.Carboidrato = Carboidrato;
                Ali.Proteina = Proteina;
                Ali.Categoria = Categoria;

                if (Ali.Novo())
                {
                    ViewBag.Mensagem = "Usuário criado com sucesso!";
                    Response.Redirect("/Adm/Listar");
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar o Usuário. Verifique os dados e tente novamente.";
                }
            }

            return View();
        }
        public ActionResult ApagarA(String ID)
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            Alimento As = new Alimento(Convert.ToInt32(ID));

            if (As.ApagarA())
            {
                ViewBag.Mensagem = "Alimento removida com sucesso!";
            }


            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Alimento. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar");
        }
    }
}