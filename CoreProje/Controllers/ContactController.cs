using BussinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Mesaj Listesi";
            ViewBag.v2 = "İletişim";
            ViewBag.v3 = "Mesaj Listesi";
            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult ContactDetails(int id)
        {
            ViewBag.v1 = "Mesaj Detay";
            ViewBag.v2 = "İletişim";
            ViewBag.v3 = "Mesaj Detay";
            var values = messageManager.TGetByID(id);

            return View(values);
        }
    }
}
