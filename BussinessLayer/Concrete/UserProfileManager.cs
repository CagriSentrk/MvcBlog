using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repouserblog = new Repository<Blog>();
        Repository<Comment> repousercomment = new Repository<Comment>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.Mail == p); //Maile göre yazar bilgilerini listeleme.
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserblog.List(x => x.AuthorID == id);
        }

        public List<Comment> GetCommentsByAuthor(int id)
        {
            return repousercomment.List(x => x.BlogID == id);
        }


        public int UpdateAuthor(Author p)
        {
            Author author = repouser.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.Title = p.Title;
            author.Mail = p.Mail;
            author.PhoneNumber = p.PhoneNumber;
            author.Password = p.Password;


            return repouser.Update(author);

        }
    }
}
