using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult index()
        {
            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente p = (Paciente)Session["Paciente"];
                ViewBag.CPF = p.CPF;
                ViewBag.Nome = p.Nome;
                ViewBag.Objetivo = p.Objetivo;
                ViewBag.Email = p.Email;
                ViewBag.Endereco = p.Endereco;
                ViewBag.Imagem = p.ImagemPerfil;
                ViewBag.Peso = p.Peso;
                ViewBag.Altura = p.Altura;
                ViewBag.Tel = p.Telefone;

                return View();
            }

            Response.Redirect("~/Home/Index", false);
            return View();
        }
    }
}