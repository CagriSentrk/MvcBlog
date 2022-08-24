using BussinessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager();

        // GET: Comment
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {

            var commentlist = cm.CommentByBlog(id);       //bloğun id'sine göre yorumları listele.
            
            return PartialView(commentlist);
        }
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult LeaveComment(int id)
            
        {
            ViewBag.id = id;
          
            return PartialView();
        }
      
        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult LeaveComment(Comment c)
        {
   
            cm.CommentAdd(c);
            return PartialView();
        }

       public ActionResult AdminCommentList()
        {

           
            var commentlist = cm.CommentByStatus();
            return View(commentlist);
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            cm.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentList");
        }

        public ActionResult CommentsByBlog(int id)
        {
            var commentlist = cm.CommentByStatus().Where(x=>x.BlogID==id);
            return View(commentlist);
       
        }
        public ActionResult CommentsByBlogCount(int id)
        {
            var commentlistcount = cm.CommentByStatus().Where(x => x.BlogID == id).Count();
            ViewBag.commentlistcount = commentlistcount;
            return View(commentlistcount);

        }
        public ActionResult CommentCount(Comment c)
        {

            var contactCount = c.Blogs.Comments.Count();
            ViewBag.contactCount = contactCount;
            return View();

        }


    }
}