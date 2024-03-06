using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Nosotros()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
        }
    }
}
