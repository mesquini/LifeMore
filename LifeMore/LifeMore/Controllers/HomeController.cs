﻿using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public bool EnviarEmail()
        {
            if (Request.HttpMethod == "POST")
            {
                try
                {

                    MailMessage mailMessage = new MailMessage();

                    //Endereço que irá aparecer no e-mail do usuário
                    String destinatario = "mesquini@live.com";

                    mailMessage.From = new MailAddress(destinatario);

                    
                    //45b7Ac senha nova padrão para inserir depois
                    String mensagem = Request.Form["Nome"] + " : " + Request.Form["Mensagem"] + Environment.NewLine + " De: " + Request.Form["Email"].ToString();
                    String titulo = Request.Form["Assunto"];
                    //destinatarios do e-mail, para incluir mais de um basta separar por ponto e virgula 
                    mailMessage.To.Add(destinatario);
                    //Com a passagem do dia e mês no Titulo do e-mail, todos os e-mails que fora recebidos no mesmo dia será agrupados em um único espaço no mailbox.
                    
                    mailMessage.IsBodyHtml = true;

                    //conteudo do corpo do e-mail
                    mailMessage.Body = mensagem.ToString();
                    mailMessage.Priority = MailPriority.High;
                    mailMessage.Subject = titulo.ToString();

                    //smtp do e-mail que irá enviar
                    SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");

                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;

                    //credenciais da conta que utilizará para enviar o e-mail
                    smtpClient.Credentials = new NetworkCredential("mesquini@live.com", "aser2728");

                    smtpClient.Send(mailMessage);
                    return true;

                }
                catch
                {
                    return false;
                }
            }
            return false;
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