using BussinessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class RegisterController : Controller
    {
        AuthorManager authormanager = new AuthorManager();
        // GET: Register
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Author p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            authormanager.AddAuthorBL(p);
            return View();

        }
    }
}