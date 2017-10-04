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
        public ActionResult IndexPerfil()
        {
            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente p = (Paciente)Session["Paciente"];
                ViewBag.Paciente = p;

                ViewBag.CPF = p.CPF;
                ViewBag.Nome = p.Nome;
                ViewBag.Objetivo = p.Objetivo;
                ViewBag.Email = p.Email;
                ViewBag.Endereco = p.Endereco;
                ViewBag.Imagem = p.ImagemPerfil;
                ViewBag.Peso = p.Peso;
                ViewBag.Altura = p.Altura;
                ViewBag.Tel = p.Telefone;
                ViewBag.Idade = p.Idade;

                return View();
            }
                
            return View();
        }
        public ActionResult Editar_Perfil()
        {
            if (Session["Paciente"] != null)
            {
                ViewBag.Logado = Session["Paciente"];
                Paciente p = (Paciente)Session["Paciente"];
                ViewBag.Paciente = p;

                ViewBag.CPF = p.CPF;
                ViewBag.Nome = p.Nome;
                ViewBag.Objetivo = p.Objetivo;
                ViewBag.Email = p.Email;
                ViewBag.Endereco = p.Endereco;
                ViewBag.Imagem = p.ImagemPerfil;
                ViewBag.Peso = p.Peso;
                ViewBag.Altura = p.Altura;
                ViewBag.Tel = p.Telefone;
                ViewBag.Idade = p.Idade;

                return View();
            }

            return View();
        }
    }
}