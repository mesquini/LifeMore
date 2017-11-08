using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            if(Session["Adm"] != null)
            {

                ViewBag.LogadoA = Session["Adm"];
                Adm p = (Adm)Session["Adm"];
                ViewBag.Nome = p.Nome;
            }

            if (Session["Nutricionista"] != null)
            {

                ViewBag.LogadoN = Session["Nutricionista"];
                Nutricionista n = (Nutricionista)Session["Adm"];
            }

            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente Paciente = (Paciente)Session["Paciente"];
                ViewBag.Imagem = Paciente.ImagemPerfil;
                ViewBag.CPF = Paciente.CPF;
                ViewBag.Nome = Paciente.Nome;
                ViewBag.Objetivo = Paciente.Objetivo;

            }
            return View();
        }
        public ActionResult About()
        {
            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente Paciente = (Paciente)Session["Paciente"];
                ViewBag.Imagem = Paciente.ImagemPerfil;
                ViewBag.CPF = Paciente.CPF;
                ViewBag.Nome = Paciente.Nome;
                ViewBag.Objetivo = Paciente.Objetivo;

            }

            if (Session["Nutricionista"] != null)
            {

                ViewBag.LogadoN = Session["Nutricionista"];
                Nutricionista n = (Nutricionista)Session["Adm"];
            }

            if (Session["Adm"] != null)
            {

                ViewBag.LogadoA = Session["Adm"];
                Adm p = (Adm)Session["Adm"];
                ViewBag.Nome = p.Nome;
            }
            return View();
        }
        public ActionResult Contato()
        {
            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente Paciente = (Paciente)Session["Paciente"];
                ViewBag.Imagem = Paciente.ImagemPerfil;
                ViewBag.CPF = Paciente.CPF;
                ViewBag.Nome = Paciente.Nome;
                ViewBag.Objetivo = Paciente.Objetivo;

            }
            if (Session["Nutricionista"] != null)
            {

                ViewBag.LogadoN = Session["Nutricionista"];
                Nutricionista n = (Nutricionista)Session["Adm"];
            }
            if (Session["Adm"] != null)
            {

                ViewBag.LogadoA = Session["Adm"];
                Adm p = (Adm)Session["Adm"];
                ViewBag.Nome = p.Nome;
            }
            return View();
        }
        public ActionResult Single()
        {
            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente Paciente = (Paciente)Session["Paciente"];
                ViewBag.Imagem = Paciente.ImagemPerfil;
                ViewBag.CPF = Paciente.CPF;
                ViewBag.Nome = Paciente.Nome;
                ViewBag.Objetivo = Paciente.Objetivo;

            }
            if (Session["Nutricionista"] != null)
            {

                ViewBag.LogadoN = Session["Nutricionista"];
                Nutricionista n = (Nutricionista)Session["Adm"];
            }
            if (Session["Adm"] != null)
            {

                ViewBag.LogadoA = Session["Adm"];
                Adm p = (Adm)Session["Adm"];
                ViewBag.Nome = p.Nome;
            }
            return View();


        }

        public ActionResult Dicas()
        {
            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente Paciente = (Paciente)Session["Paciente"];
                ViewBag.Imagem = Paciente.ImagemPerfil;
                ViewBag.CPF = Paciente.CPF;
                ViewBag.Nome = Paciente.Nome;
                ViewBag.Objetivo = Paciente.Objetivo;

            }
            if (Session["Nutricionista"] != null)
            {

                ViewBag.LogadoN = Session["Nutricionista"];
                Nutricionista n = (Nutricionista)Session["Adm"];
            }
            if (Session["Adm"] != null)
            {

                ViewBag.LogadoA = Session["Adm"];
                Adm p = (Adm)Session["Adm"];
                ViewBag.Nome = p.Nome;
            }
            return View();
        }
    }
}