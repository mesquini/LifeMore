using LifeMore.Models;
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
        // GET: Perfil
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
                       // postedFile.SaveAs(@"C:\Users\16128611\Source\Repos\LifeMore\Projeto\LifeMore\LifeMore\LifeMore\images\img_users" + nomeArquivoUpload);

                        postedFile.SaveAs(@"C:\Users\Mesquini\Source\LifeMore\LifeMore\LifeMore\images\img_users" + nomeArquivoUpload);
                        novoUser.ImagemPerfil = nomeArquivoUpload;
                    }
                    else
                     //postedFile.SaveAs(@"C:\Users\16128611\Source\Repos\LifeMore\Projeto\LifeMore\LifeMore\LifeMore\images" + Request.Form["Desc"] + ".txt");

                    postedFile.SaveAs(@"C:\Users\Mesquini\Source\LifeMore\LifeMore\LifeMore\images" + Request.Form["Desc"] + ".txt");
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
        public ActionResult ApagarP(String ID)
        {
            if (Session["Paciente"] == null)
            {
                Response.Redirect("/Home/Index", false);
            }

            Paciente P = new Paciente(Convert.ToInt32(ID));


            if (P.Apagar())
            {
                TempData["Mensagem"] = "Post removido com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Não foi possível remover o Post. Verifique os dados e tente novamente";
            }

            return RedirectToAction("Listar", "Adm");
        }
        public ActionResult Cardapio(string CPF)
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
                c.BuscarDados(CPF);

                ViewBag.Cardapio = c;
            }else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}