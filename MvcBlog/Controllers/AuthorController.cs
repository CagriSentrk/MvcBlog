using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager();//Yeni bir sayfaya yazar bilgisi taşırken bloğu oluşturan yazarın bilgisini taşıyoruz.
        AuthorManager authormanager = new AuthorManager();
        
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = bm.GetBlogByID(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = bm.GetAll().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorblogs = bm.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }
        public ActionResult AuthorList()
        {
            var authorlist = authormanager.GetAll();

            return View(authorlist);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            authormanager.AddAuthorBL(p);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authormanager.UpdateAuthor(p);
            return RedirectToAction("AuthorList");
        }

        public ActionResult AdminAuthorBlogList(int id)
        {

            var BlogListByAuthor = bm.GetBlogByAuthor(id);
            return View(BlogListByAuthor);
          
        }
      
        {


        }



    }
}