using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace CoreProje.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class DashboardUserController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardUserController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;
            //Weather Api
            string api = "270ee2e1d2e397c5b0fd607ec6b1b5ca";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value.ToString().Substring(0,2);

            //statistics
            Context c = new Context();
            ViewBag.v1 = c.WriterMessages.Where(x=> x.Reciever == values.Email).Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.WriterMessages.Where(x => x.Sender == values.Email).Count();

            return View();
        }
    }
}
/*
    https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml
 */
