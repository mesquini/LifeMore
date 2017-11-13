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
            if (Session["Nutricionista"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            ViewBag.LogadoN = Session["Nutricionista"];
            Nutricionista N = (Nutricionista)Session["Nutricionista"];
            ViewBag.Nutricionista = (Nutricionista)Session["Nutricionista"];
            
            List<Paciente> pc = Paciente.ListarP();
            ViewBag.Paciente = pc;

            if (Request.HttpMethod == "POST")
            {
                String Cod_Nutri = N.CPF;
                String CPF_Paciente = Request.Form["NomeP"];
                String NomeCardapio = Request.Form["CardapioC"];

                Cardapio c = new Cardapio();
                
                c.Cod_Cliente = CPF_Paciente;
                c.Cod_Nutri = Cod_Nutri;
                c.Nome = NomeCardapio;

                //Cadastro de novo cardápio
                if (c.Novo())
                {
                    c.Cod_Cardapio = Cardapio.ultimoCardapio();

                    String Alimento1 = Request.Form["alimento1"];
                    if (!Alimento1.Equals("Selecione o alimento..."))
                    {
                        c.Observacao = Request.Form["Informacoes1"];
                        c.Qtd = int.Parse(Request.Form["Qtd1"]);
                        c.Cod_Alimento = Int32.Parse(Request.Form["alimento1"]);
                        
                        c.NovoCardapio();
                    }

                    String Alimento2 = Request.Form["alimento2"];
                    if (!Alimento2.Equals("Selecione o alimento..."))
                    {
                        c.Observacao = Request.Form["Informacoes2"];
                        c.Qtd = int.Parse(Request.Form["Qtd2"]);
                        c.Cod_Alimento = Int32.Parse(Request.Form["alimento2"]);

                        c.NovoCardapio();
                    }

                    String Alimento3 = Request.Form["alimento3"];
                    if (!Alimento3.Equals("Selecione o alimento..."))
                    {
                        c.Observacao = Request.Form["Informacoes3"];
                        c.Qtd = int.Parse(Request.Form["Qtd3"]);
                        c.Cod_Alimento = Int32.Parse(Request.Form["alimento3"]);

                        c.NovoCardapio();
                    }

                    String Alimento4 = Request.Form["alimento4"];
                    if (!Alimento4.Equals("Selecione o alimento..."))
                    {
                        c.Observacao = Request.Form["Informacoes4"];
                        c.Qtd = int.Parse(Request.Form["Qtd4"]);
                        c.Cod_Alimento = Int32.Parse(Request.Form["alimento4"]);

                        c.NovoCardapio();
                    }

                    String Alimento5 = Request.Form["alimento5"];
                    if (!Alimento5.Equals("Selecione o alimento..."))
                    {
                        c.Observacao = Request.Form["Informacoes5"];
                        c.Qtd = int.Parse(Request.Form["Qtd5"]);
                        c.Cod_Alimento = Int32.Parse(Request.Form["alimento5"]);

                        c.NovoCardapio();
                    }
                }
            }


            List<Alimento> al = Alimento.ListarA();
            ViewBag.Alimento = al;

            //List<Nutricionista> nt = Nutricionista.ListarN();
            //ViewBag.Nutricionista = nt;
            return View();
        }
        
    }
}