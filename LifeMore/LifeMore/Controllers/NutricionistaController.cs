﻿using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class NutricionistaController : Controller
    {
        // GET: Nutricionista
        public ActionResult CadastrarN()
        {
            if (Request.HttpMethod == "POST")
            {

                String Nome = Request.Form["nomeN"];
                String Senha = Request.Form["senhaN"];
                String CPF = Request.Form["cpfN"];
                String Email = Request.Form["emailN"];
                int Idade = int.Parse(Request.Form["idadeN"]);
                String LocalTrabalho = Request.Form["localtrabN"];
                String Bio = Request.Form["bio"];
                String End = Request.Form["enderecoN"];
                String Tel = Request.Form["telefoneN"];


                Nutricionista NovoUser = new Nutricionista();

                NovoUser.Nome = Nome;
                NovoUser.Senha = Senha;
                NovoUser.CPF = CPF;
                NovoUser.Email = Email;
                NovoUser.Idade = Idade;
                NovoUser.Telefone = Tel;
                NovoUser.Endereco = End;
                NovoUser.Bio = Bio;
                NovoUser.LocalTrabalho = LocalTrabalho;

                

                if (NovoUser.Novo())
                {
                    ViewBag.Mensagem = "Nutricionista criado com sucesso!";
                    Response.Redirect("/Adm/Listar");
                }
                else
                {
                    ViewBag.Mensagem = "Houve um erro ao criar um Nutricionista. Verifique os dados e tente novamente.";
                }
            }
            return View();
        }

        public ActionResult VerN()
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }
            if(TempData["Nutricionista"] != null)
            {
                ViewBag.Perfil = (Nutricionista)TempData["Nutricionista"];
            }
            return View();
        }

        public ActionResult Perfil()
        {

            if (Session["Nutricionista"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }
            if (Session["Nutricionista"] != null)
            {
                ViewBag.Logado = Session["Nutricionista"];
                Nutricionista p = (Nutricionista)Session["Nutricionista"];
                ViewBag.Paciente = p;
                
                ViewBag.CPF = p.CPF;
                ViewBag.Nome = p.Nome;
                ViewBag.Email = p.Email;
                ViewBag.Endereco = p.Endereco;
                ViewBag.Imagem = p.ImagemPerfil;
                ViewBag.Tel = p.Telefone;
                ViewBag.Idade = p.Idade;
                ViewBag.LocalTrabalho = p.LocalTrabalho;
                ViewBag.Bio = p.Bio;

                return View();
            }

            return View();
        }
        public ActionResult Editar_Perfil()
        {
            if (Session["Nutricionista"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            ViewBag.Logado = Session["Nutricionista"];
            Nutricionista p = (Nutricionista)Session["Nutricionista"];
            ViewBag.Nutricionista = (Nutricionista)Session["Nutricionista"];

            if (Request.HttpMethod == "POST")
            {
                String Email = Request.Form["Email"];
                String Endereco = Request.Form["Endereco"];
                String Tel = Request.Form["Tel"];
                Int32 Objetivo = Int32.Parse(Request.Form["Objetivo"]);
                String Peso = Request.Form["Peso"];
                String Altura = Request.Form["Altura"];
                String Idade = Request.Form["Idade"];

                HttpPostedFileBase NovaImagemPerfil = Request.Files["Imag"];

                Nutricionista novoUser = new Nutricionista();

                novoUser = (Nutricionista)Session["Nutricionista"];
                novoUser.Email = Email;
                novoUser.Endereco = Endereco;
                novoUser.Telefone = Tel;
                int ID = novoUser.Cod;

                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase postedFile = Request.Files[fileName];
                    int contentLength = postedFile.ContentLength;
                    string contentType = postedFile.ContentType;
                    string nome = postedFile.FileName;
                    Imagem img = new Imagem();

                    if (contentType.IndexOf("jpeg") > 0 || contentType.IndexOf("jpg") > 0 || contentType.IndexOf("png") > 0)
                    {
                        Bitmap arquivoConvertido = img.ResizeImage(postedFile.InputStream, 100, 100);
                        string nomeArquivoUpload = "imagemPerfil" + ID + ".jpg";
                        postedFile.SaveAs(HttpRuntime.AppDomainAppPath + "\\images\\img_users\\" + nomeArquivoUpload);
                        postedFile.SaveAs(@"C:\Users\16128611\Source\Repos\LifeMore\Projeto\LifeMore\LifeMore\LifeMore\images\img_users" + nomeArquivoUpload);

                        novoUser.ImagemPerfil = nomeArquivoUpload;
                    }
                    else
                        postedFile.SaveAs(@"C:\Users\16128611\Source\Repos\LifeMore\Projeto\LifeMore\LifeMore\LifeMore\images" + Request.Form["Desc"] + ".txt");


                }

                if (novoUser.EditarPerfil())
                {
                    ViewBag.Mensagem = "Perfil Atualizado com sucesso!";
                    Response.Redirect("/Perfil/IndexPerfil");
                    Session["Paciente"] = novoUser;
                    ViewBag.Paciente = (Paciente)Session["Paciente"];
                }
                else
                {
                    ViewBag.Mensagem = "Erro ao atualizar, tente novamente";
                }

                return View();
            }

            return View();
        }
        public ActionResult ApagarN(String ID)
        {
            if (Session["Adm"] == null)
            {
                Response.Redirect("~/Home/Index", false);
            }

            Nutricionista Nutri = new Nutricionista(Convert.ToInt32(ID));

            if (Nutri.Apagar())
            {
                ViewBag.Mensagem = "Nutricionista removida com sucesso!";
            }


            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Usuario. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar", "Adm");
        }
    }
}