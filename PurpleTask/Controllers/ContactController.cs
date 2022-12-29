using Microsoft.AspNetCore.Mvc;

namespace PurpleTask.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
