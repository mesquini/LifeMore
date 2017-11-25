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
            if (Request.HttpMethod == "POST")
            {
                //PEGAR OS VALORES DIGITADOS 
                String NomeNutri = Request.Form["NomeN"];
                String Nome = Request.Form["Nome"];
                String Email = Request.Form["Email"];
                String Telefone = Request.Form["Tel"];
                String Dia = Request.Form["datepicker"];
                String Hora = Request.Form["timepicker"];
                String Comentario = Request.Form["mensagem"];
                String precoConsulta = Request.Form["precoConsulta"];
                String horaConsulta = Request.Form["horaConsulta"];
                String tipoConsulta = Request.Form["tipoConsulta"];


                Consulta NovaConsulta = new Consulta();
                //ATRIBUILOS NA VARIAVEL
                NovaConsulta.Cod_Nutri = NomeNutri;
                NovaConsulta.Nome = Nome;
                NovaConsulta.Email = Email;
                NovaConsulta.Telefone = Telefone;
                NovaConsulta.Dia = Dia;
                NovaConsulta.Hora = Hora;
                NovaConsulta.Comentario = Comentario;
                NovaConsulta.precoConsulta = precoConsulta;
                NovaConsulta.horaConsulta = horaConsulta;
                NovaConsulta.tipoConsulta = tipoConsulta;

                if (NovaConsulta.Novo())
                {
                    ViewBag.Sucesso = "Consulta marcado com sucesso!";
                }
                
            }
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

                ViewBag.Nome = Paciente.Nome;
                ViewBag.Email = Paciente.Email;
                ViewBag.Telefone = Paciente.Telefone;

            }
            List<Nutricionista> ns = Nutricionista.ListarN();
            ViewBag.Nutricionista = ns;

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