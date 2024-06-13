using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Tesseract;

namespace ImageToText.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageToText : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            //validar el formato de la imagen
            if (file == null || (file.ContentType != "image/png" && file.ContentType != "image/jpeg"))
                return BadRequest("Error");

            string resultText = "";
            using( var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                resultText = ConvertImageToText(imageBytes);
            }
            return Ok(resultText);

        }

        private string ConvertImageToText(byte[] arrayImage)
        {
            //Logica de Tesseract
            var engine = new TesseractEngine("tessdata", "spa", EngineMode.Default);
            var image = Pix.LoadFromMemory(arrayImage);
            var page = engine.Process(image);

            string text = page.GetText();
            return text;
        }

        
    }
}
