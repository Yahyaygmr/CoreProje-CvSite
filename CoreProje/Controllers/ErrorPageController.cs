using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
