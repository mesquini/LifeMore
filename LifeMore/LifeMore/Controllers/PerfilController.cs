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
            if (Session["Paciente"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }
            if (Request.HttpMethod == "POST")
            {
                Paciente p = (Paciente)Session["Paciente"];

                String Email = Request.Form["Email"];
                String Endereco = Request.Form["Endereco"];
                String Tel = Request.Form["Tel"];
                String Objetivo = Request.Form["Objetivo"];
                String Peso = Request.Form["Peso"];
                String Altura = Request.Form["Altura"];
                String Idade = Request.Form["Idade"];
                String Image = Request.Form["Imag"];

                Paciente novoUser = new Paciente();
                
                novoUser.Email = Email;
                novoUser.Endereco = Endereco;
                novoUser.ImagemPerfil = Image;
                novoUser.Peso = Peso;
                novoUser.Altura = Altura;
                novoUser.Telefone = Tel;
                novoUser.Idade = Idade;

                if (novoUser.EditarPerfil())
                {
                    ViewBag.Mensagem = "Perfil Atualizado com sucesso!";
                    Response.Redirect("/Perfil/IndexPerfil");
                }
                else
                {
                    ViewBag.Mensagem = "Erro ao atualizar, tente novamente";
                }

                List<Paciente> User = Paciente.ListarP();
                ViewBag.Paciente = User;
                return View();
            }

            return View();
        }
    }
}