using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testando.Models;

namespace testando.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Remessa arq)
        {
            try
            {
                string nomeArquivo = "";
                string arquivoEnviados = "";
                foreach (var arquivo in arq.Arquivos)
                {
                    if (arquivo.ContentLength > 0)
                    {
                        
                        nomeArquivo = Path.GetFileName(arquivo.FileName);
                        var caminho = Path.Combine(Server.MapPath("~/App_Data/uploads"), nomeArquivo);
                        arquivo.SaveAs(caminho);
                    }
                    arquivoEnviados = arquivoEnviados + " , " + nomeArquivo;
                }
                ViewBag.Mensagem = "Arquivos enviados  : " + arquivoEnviados + " , com sucesso.";
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro : " + ex.Message;
            }
            return View();
        }
    }
}
