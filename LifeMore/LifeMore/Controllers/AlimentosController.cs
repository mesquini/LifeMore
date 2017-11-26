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
            if (Session["Adm"] != null)
            {
                ViewBag.LogadoA = Session["Adm"];
                Adm Adms = (Adm)Session["Adm"];
                
            }
            if (Session["Nutricionista"] != null)
            {
                ViewBag.LogadoN = Session["Nutricionista"];
                Nutricionista Ns = (Nutricionista)Session["Nutricionista"];
                
            }
            if (Request.HttpMethod == "POST")
            {
                String Nome = Request.Form["nomeA"];
                String Peso = Request.Form["pesoA"];
                double Caloria = Double.Parse(Request.Form["caloriaA"]);
                double Gordura = Double.Parse(Request.Form["gorduraA"]);
                double Carboidrato = Double.Parse(Request.Form["carboidratoA"]);
                double Proteina = Double.Parse(Request.Form["proteinaA"]);
                Int32 Cat = Int32.Parse(Request.Form["categoriaA"]);

                Alimento Ali = new Alimento();

                Ali.Nome = Nome;
                Ali.Peso = Peso;
                Ali.Caloria = Caloria;
                Ali.Gordura = Gordura;
                Ali.Carboidrato = Carboidrato;
                Ali.Proteina = Proteina;
                Ali.Categoria = Cat;

                if (Ali.Novo())
                {
                    ViewBag.Mensagem = "Alimento cadastrado com sucesso!";
                }
                else
                {
                    ViewBag.MsgErro = "Houve um erro ao cadastrar o alimento. Verifique os dados e tente novamente.";
                }
            }

            List<Categoria> cs = Categoria.ListarC();
            ViewBag.Categoria = cs;

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

            return RedirectToAction("Listar", "Adm");
        }
    }
}