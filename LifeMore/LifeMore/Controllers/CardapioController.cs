using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class CardapioController : Controller
    {
        // GET: Cardapio
        public ActionResult CadastrarC()
        {
            if (Request.HttpMethod == "POST")
            {
                String Nutricionista = Request.Form["nomeNC"];
                String Nome = Request.Form["NomeC"];            
                String Alimento = Request.Form["Alimento1"];
                String Informacoes = Request.Form["InformacoesC"];
            }

            List<Paciente> pc = Paciente.ListarP();
            ViewBag.Paciente = pc;

            List<Alimento> al = Alimento.ListarA();
            ViewBag.Alimento = al;

            List<Nutricionista> nt = Nutricionista.ListarN();
            ViewBag.Nutricionista = nt;
            return View();
        }
        
    }
}