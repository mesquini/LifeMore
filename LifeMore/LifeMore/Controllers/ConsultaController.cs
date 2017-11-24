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
                Int32 NomeNutri = Int32.Parse(Request.Form["NomeN"]);
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
                ViewBag.Imagem = Paciente.ImagemPerfil;
                ViewBag.CPF = Paciente.CPF;
                ViewBag.Nome = Paciente.Nome;
                ViewBag.Objetivo = Paciente.Objetivo;

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