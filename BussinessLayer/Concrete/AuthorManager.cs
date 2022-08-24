using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoblog = new Repository<Author>();
        Repository<Blog> repouserblog = new Repository<Blog>();

        //tüm yazarları getirme
        public List<Author> GetAll()
        {
            return repoblog.List();
        }

        //yeni yazar ekleme
        public int AddAuthorBL(Author p)
        {
            if(p.AuthorName==""| p.Title=="")
            {
                return -1;
            }
            return repoblog.Insert(p);
        }

        //Yazarı id değerine göre edit sayfasına taşıma
        public Author FindAuthor(int id)
        {
            return repoblog.Find(x => x.AuthorID== id);
        }
        public int UpdateAuthor(Author p)
        {
            Author author = repoblog.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.Title = p.Title;
            author.Mail = p.Mail;
            author.PhoneNumber = p.PhoneNumber;
            author.Password = p.Password;
           

            return repoblog.Update(author);

        }
        public List<Blog> GetBlogByAuthor1(int id)
        {
            return repouserblog.List(x => x.AuthorID == id); //id ye göre blog listele.
        }

       

    }
}
