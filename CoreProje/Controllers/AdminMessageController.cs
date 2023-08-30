using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Mesajlar";
            ViewBag.v2 = "Mesajlar";
            ViewBag.v3 = "Mesajlar";
            return View();
        }
        public IActionResult RecieverMessageList()
        {
            ViewBag.v1 = "Yazar-Admin Gelen Listesi";
            ViewBag.v2 = "Mesajlar";
            ViewBag.v3 = "Gelen Listesi";
            string p;
            p = "admin@mail.com";
            var values = writerMessageManager.GetListRecieverMessage(p);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            ViewBag.v1 = "Yazar-Admin Gönderilmiş Listesi";
            ViewBag.v2 = "Mesajlar";
            ViewBag.v3 = "Gönderilmiş Listesi";
            string p;
            p = "admin@mail.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            ViewBag.v1 = "Mesaj Detay";
            ViewBag.v2 = "Mesajlar";
            ViewBag.v3 = "Mesaj Detay";
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        public IActionResult DeleteAdminMessage(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AdminSendMessage()
        {
            ViewBag.v1 = "Yazar-Admin Mesaj Yaz";
            ViewBag.v2 = "Mesajlar";
            ViewBag.v3 = "Mesaj Yaz";
            return View();
        }
        [HttpPost]
        public IActionResult AdminSendMessage(WriterMessage p)
        {
            p.Sender = "admin@mail.com";
            p.SenderName = "Admin";
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Reciever).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            p.RecieverName = usernamesurname;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
