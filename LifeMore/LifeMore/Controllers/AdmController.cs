using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class AdmController : Controller
    {
        public ActionResult LogarAdm()
        {
            if (Request.HttpMethod == "POST")
            {
                String Nome = Request.Form["nome"].ToString();
                String Senha = Request.Form["senha"].ToString();

                if (Adm.Autenticar(Nome, Senha))
                {
                    Adm adm = new Adm(Nome, Senha);
                    Session["Adm"] = adm;
                    Response.Redirect("/Adm/Listar");
                }
                else
                {
                    ViewBag.MsgErro = "CPF e/ou Senha incorreto!";
                }
            }

            if (Session["Adm"] != null)
            {
                ViewBag.Logado = Session["Adm"];
                Adm Adms = (Adm)Session["Adm"];

                ViewBag.Nome = Adms.Nome;
            }

            return View();
        }

        // GET: Adm
        public ActionResult Listar()
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            ViewBag.Logado = Session["Adm"];
            Adm p = (Adm)Session["Adm"];

                List<Paciente> ps = Paciente.ListarP();
                 List<Nutricionista> ns = Nutricionista.ListarN();

                ViewBag.Usuario = ps;
            ViewBag.Nutricionista = ns;

               
            return View();
        }
        public ActionResult ApagarP(String ID)
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            Paciente Pacientes = new Paciente(Convert.ToInt32(ID));
            

            if (Pacientes.Apagar())
            {
                TempData["Mensagem"] = "Usuario removido com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Usuario. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar");
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
        public void Sair()
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("/Home/Index", false);
        }
    }
}