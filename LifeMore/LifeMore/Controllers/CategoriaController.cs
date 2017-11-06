using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult CadastrarC()
        {

            if (Request.HttpMethod == "POST")
            {
                String Nome = Request.Form["nome"].ToString();

                Categoria C = new Categoria();

                C.Nome = Nome;

                if (C.Novo())
                {
                    ViewBag.Mensagem = "Categoria criado com sucesso!";
                    Response.Redirect("/Adm/Listar");
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar a Categoria. Verifique o Nome e tente novamente.";
                }
            }
            return View();
        }
        public ActionResult ApagarC(String ID)
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            Categoria Ca = new Categoria(Convert.ToInt32(ID));

            if (Ca.Apagar())
            {
                ViewBag.Mensagem = "Categoria removida com sucesso!";
            }


            else
            {
                TempData["Mensagem"] = "Não foi possível remover a Categoria. Verifique os dados e tente novamente";
            }

            return RedirectToAction("/Adm/Listar");
        }
    }
}