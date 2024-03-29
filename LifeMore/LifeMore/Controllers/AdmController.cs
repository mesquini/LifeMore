﻿using LifeMore.Models;
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
                ViewBag.LogadoA = Session["Adm"];
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

            ViewBag.LogadoA = Session["Adm"];
            Adm p = (Adm)Session["Adm"];

             List<Paciente> ps = Paciente.ListarP();
             List<Nutricionista> ns = Nutricionista.ListarN();
             List<Categoria> cs = Categoria.ListarC();
             List<Alimento> a = Alimento.ListarA();
            List<Feedbacks> fs = Feedbacks.ListarF();

            ViewBag.Usuario = ps;
            ViewBag.Nutricionista = ns;
            ViewBag.Categoria = cs;
            ViewBag.Alimento = a;
            ViewBag.Feedback = fs;

            return View();
        }

        public ActionResult previsualizacao(Int32 id)
        {
            Nutricionista nutricionistas = new Nutricionista(id);
            if (nutricionistas.BuscarDados(id))
            {
                TempData["Nutricionista"] = nutricionistas;

                return RedirectToAction("VerN", "Nutricionista");
            }
            else
            {
                return RedirectToAction("Listar", "Adm");
            }
        }
        public ActionResult previsualizacaoP(Int32 id)
        {
            Paciente Pacientes = new Paciente(id);
            if (Pacientes.BuscarDados(id))
            {
                TempData["Paciente"] = Pacientes;

                return RedirectToAction("VerP", "Adm");
            }
            else
            {
                return RedirectToAction("Listar", "Adm");
            }
        }
        public ActionResult VerP()
        {
            ViewBag.LogadoA = Session["Adm"];

            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }
            if (TempData["Paciente"] != null)
            {
                ViewBag.Perfil = (Paciente)TempData["Paciente"];
            }
            return View();
        }

        public void Sair()
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("/Home/Index", false);
        }
    }
}