﻿using LifeMore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeMore.Controllers
{
    public class PerfilController : Controller
    {
        //METODO PARA EXIBIR PERFIL
        public ActionResult IndexPerfil()
        {

            if (Session["Paciente"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }
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
        //METODO PARA DAR UPDATE NO PERFIL
        public ActionResult Editar_Perfil()
        {
            if (Session["Paciente"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            ViewBag.Logado = Session["Paciente"];
            Paciente p = (Paciente)Session["Paciente"];
            ViewBag.Paciente = (Paciente)Session["Paciente"];

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

                Paciente novoUser = new Paciente();

                    novoUser = (Paciente)Session["Paciente"];
                    novoUser.Email = Email;
                    novoUser.Endereco = Endereco;
                    novoUser.Peso = Peso;
                    novoUser.Altura = Altura;
                    novoUser.Telefone = Tel;
                    novoUser.Idade = Idade;
                    novoUser.Objetivo = Objetivo;

                    int ID = novoUser.Cod;
                //METODO PARA SALVAR A IMAGEM DO PERFIL NO PC OU EM UM SERVIDOR
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
                        //postedFile.SaveAs(@"C:\Users\16128611\Source\Repos\LifeMore\Projeto\LifeMore\LifeMore\LifeMore\images\img_users" + nomeArquivoUpload);

                        //postedFile.SaveAs(@"C:\Users\Mesquini\Source\Repos\LifeMore\LifeMore\LifeMore\images\img_users" + nomeArquivoUpload);
                       // postedFile.SaveAs(@"C:\Users\16128605\Source\Repos\LifeMore2\LifeMore\LifeMore\images\img_users" + nomeArquivoUpload);

                        novoUser.ImagemPerfil = nomeArquivoUpload;
                    }
                    //    else
                    //        //postedFile.SaveAs(@"C:\Users\16128611\Source\Repos\LifeMore\Projeto\LifeMore\LifeMore\LifeMore\images" + Request.Form["Desc"] + ".txt");
                    //        postedFile.SaveAs(HttpRuntime.AppDomainAppPath + "\\images\\img_users\\" + Request.Form["Desc"] + ".txt");
                    //    //postedFile.SaveAs(@"C:\Users\Mesquini\Source\Repos\LifeMore\LifeMore\LifeMore\images" + Request.Form["Desc"] + ".txt");
                    //    //postedFile.SaveAs(@"C:\Users\16128605\Source\Repos\LifeMore2\LifeMore\LifeMore\images" + Request.Form["Desc"] + ".txt");
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
        //METODO PARA APGAR O PACIENTE
        public ActionResult ApagarP(Int32 ID)
        {
            if (Session["Paciente"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            Paciente P = new Paciente(Convert.ToInt32(ID));
            Cardapio C = new Cardapio();
            
            //METODO PARA VERIFICAR O CPF NO CARDAPIO
            if (C.VerificaCPFCardapio(P.CPF)) {

                //METODO PARA BUSCAR AS INFORMAÇÕES DO CARDAPIO
                C.ListarCardapio(P.CPF);
                C = new Cardapio(C.Cod_Cardapio);
                
                //METODO PARA APAGAR O CARDAPIOALIMENTO DO PACIENTE
                if (C.ApagarCA())
                {
                    //METODO PARA APAGAR O CARDAPIO DO PACIENTE
                    if (C.ApagarC(P.CPF))
                    {
                        //METODO PARA APAGAR O PACIENTE
                        P.Apagar();
                    }
                }
        }
            //CASO ELE NAO TENHA CADASTRO EM ALGUM CARDAPIO ELE É APAGADO DIRETO
            else
            {
                P.Apagar();
            }
                
            return RedirectToAction("Listar", "Adm");
        }
        //METODO PARA LISTAR CARDAPIO DO PACIENTE
        public ActionResult CardapioV(string CPF)
        {
            if (Session["Paciente"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }
            ViewBag.Logado = Session["Paciente"];
            Paciente p = (Paciente)Session["Paciente"];
            ViewBag.Paciente = (Paciente)Session["Paciente"];

            CPF = p.CPF;
            //VERIFICA SE EXISTE ALGUM CPF CADASTRADO EM ALGUM CARDAPIO
            Cardapio c = new Cardapio();
            
            if (c.VerificaCPFCardapio(CPF))
            {
                
                List<Cardapio> cs = Cardapio.BuscarDados(CPF);
                ViewBag.Cardapio = cs;

                c.ListarCardapio(CPF);
                ViewBag.Cardapio1 = c;

            }
            else
            {
                return RedirectToAction("CardapioS", "Cardapio");
            }
            return View();
        }
    }
}