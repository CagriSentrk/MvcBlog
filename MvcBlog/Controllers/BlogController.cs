using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    [Authorize]
    public class BlogController : Controller

    {
        BlogManager bm = new BlogManager();
        // GET: Blog
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {

            var bloglist = bm.GetAll().ToPagedList(page,3);//ilk parametre sayfalamanın başlayacağı sayfayı belirler.2.parametre bir sayfada kaç blog gözükecek onu belirler.

            return PartialView(bloglist);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1.Post
            //orderbyDescending ile son postu getiriyor.(tersten sıralıyor.)
            var postID1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
             x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();
            var posttitle1 = bm.GetAll().OrderByDescending(z=>z.BlogID).Where(
             x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postID1 = postID1;
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            //2.post
            var postID2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
           x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            var posttitle2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
            x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postID2 = postID2;
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;

            //3.post
            var postID3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
          x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();
            var posttitle3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
           x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postcategori= bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 3).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.postID3 = postID3;
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3= postdate3;
            ViewBag.postcategori = postcategori;
            //4.post
            var postID4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
          x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();
            var posttitle4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
          x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postID4 = postID4;
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            //5.post
            var postID5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
         x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();
            var posttitle5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
        x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();

            var postimage5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(
                x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.postID5 = postID5;
            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;



            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeturedPost()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);

        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogByCategories(int id)

        {
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDescription = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = CategoryDescription;

            var BlogListByCategory = bm.GetBlogByCategory(id);
            return PartialView(BlogListByCategory);
        }

     
        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetAll();
            return View(bloglist); 
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlogCategory(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");

        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);       //bloğun id'sine göre yorumları listele
           
            return View(commentlist);
          
        }



    }

}