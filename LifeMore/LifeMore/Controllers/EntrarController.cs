﻿using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class EntrarController : Controller
    {
        // GET: Entrar
        public ActionResult Cadastrar()
        {
           

            if (Request.HttpMethod == "POST")
            {
                String CPF = Request.Form["cpf"].ToString();
                String Senha = Request.Form["senha"].ToString();
               
                if(Paciente.Autenticar(CPF, Senha))
                {
                    Paciente P = new Paciente(CPF, Senha);
                    Session["Paciente"] = P;
                    Response.Redirect("/Perfil/index");
                }
                else
                {

                    ViewBag.MsgErro = "Usuário e/ou Senha incorretos!";
                }
                      
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
        public void Sair()
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("/Home/Index", false);
        }

    }
}