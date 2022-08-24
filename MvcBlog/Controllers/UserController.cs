using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        BlogManager bm = new BlogManager();
        // GET: User
        UserProfileManager userprofile = new UserProfileManager();
        public ActionResult Index()
        {
            return View();

        }
        public PartialViewResult Partial1(string p)
        {

            p = (string)Session["Mail"];

            var profilevalues = userprofile.GetAuthorByMail(p);

            return PartialView(profilevalues);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userprofile.UpdateAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
        

            context c = new context();
            p = (string)Session["Mail"];

            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
        
            
            var blogs = userprofile.GetBlogByAuthor(id); //Giriş yapan yazarın bloglarını getirecek.
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {

            Blog blog = bm.FindBlog(id);
            context c = new context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()

                                            }).ToList();
            ViewBag.values2 = values2;

            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");

        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            //DropdownList
            context c = new context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()

                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBL(b);     //adminin blog eklemesi için yazdığım methodu çağırdım.
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin","Login");
        }

    }
}