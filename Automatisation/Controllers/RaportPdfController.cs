using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Path = System.IO.Path;

namespace Automatisation.Controllers
{
    public class RaportPdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult LireAvecITextSharp()
        {
            
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "D:/pdf/raport.pdf");

            
            if (!System.IO.File.Exists(filePath))
            {
                return Content("Le fichier PDF n'existe pas.");
            }

            
            string pdfText = LireContenuDuPdfAvecITextSharp(filePath);

            
            return Content(pdfText);
        }

        
        private string LireContenuDuPdfAvecITextSharp(string filePath)
        {
            string textePdf = string.Empty;

            
            using (PdfReader reader = new PdfReader(filePath))
            {
                
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    
                    textePdf += PdfTextExtractor.GetTextFromPage(reader, i);
                }
            }

            return textePdf;
        }
    }
}


