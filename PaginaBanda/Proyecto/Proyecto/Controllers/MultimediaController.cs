using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class MultimediaController : Controller
    {
        public IActionResult Galeria()
        {
            return View();
        }
        public IActionResult Musica()
        {
            return View();
        }
    }
}
