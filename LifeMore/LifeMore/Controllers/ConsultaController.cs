using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: MarcarConsulta
        public ActionResult MarcarConsulta()
        {

            if (Session["Adm"] != null)
            {

                ViewBag.LogadoA = Session["Adm"];
                Adm p = (Adm)Session["Adm"];
                ViewBag.Nome = p.Nome;
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
        public ActionResult IndexConsulta()
        {

            if (Session["Adm"] != null)
            {

                ViewBag.LogadoA = Session["Adm"];
                Adm p = (Adm)Session["Adm"];
                ViewBag.Nome = p.Nome;
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
    }
}