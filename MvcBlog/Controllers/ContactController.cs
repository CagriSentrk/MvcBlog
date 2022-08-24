using BussinessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ContactController : Controller
    {

        ContactManager cm = new ContactManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
          
            return View();
        }
       [HttpGet]
        [AllowAnonymous]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendMessage(Contact p)
        {
            cm.BLContactAdd(p);
           
            return View();
        }
        public ActionResult SendBox()

        {

            var message = cm.GetAll().Where(x=>x.ContactStatus==true).OrderByDescending(x=>x.ContactID); //Id ye göre son gelen mesajı ilk gösterecek şekilde sıraladım.
            return View(message);
        }

        public ActionResult TrashMessage()
        {

            var message = cm.GetAll().Where(x => x.ContactStatus == false).OrderByDescending(x => x.ContactID); //Id ye göre son gelen mesajı ilk gösterecek şekilde sıraladım.
            return View(message);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetContactDetails(id);
            return View(contact);
        }
        public ActionResult DeleteMessage(int id)
        {
            cm.DeleteMessageBl(id);
            return RedirectToAction("SendBox");
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            cm.ContactStatusChangeToFalse(id);
            return RedirectToAction("SendBox");
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            cm.ContactStatusChangeToTrue(id);
            return RedirectToAction("SendBox");
        }
    }
}