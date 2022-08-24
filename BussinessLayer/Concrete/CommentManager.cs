using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CommentManager

    {
        Repository<Comment> repocomment = new Repository<Comment>();
        //********************************************************************************************//
        public List<Comment> CommentList()
        {
            return repocomment.List();   //tüm yorumların listesi 

        }
        //******************************************************************************************//
        public List<Comment> CommentByBlog(int id)
        {
            return repocomment.List(x => x.BlogID == id);      //BlogID'ye göre yorumları listeledim.
        }
        public List<Comment> CommentByStatus()
        {
            return repocomment.List(x => x.CommentStatus == true); //silinmeyen yorumları getir.
        }
        public int CommentAdd(Comment c)
        {
            if (c.CommentText.Length <= 10 || c.CommentText.Length >= 500)
            {
                return -1;
            }
            return repocomment.Insert(c);

        }

        //silinecek yorumu false yaptım.
        public int CommentStatusChangeToFalse(int id)
        {
            Comment comment = repocomment.Find(x => x.CommentID == id);
            comment.CommentStatus = false;

            return repocomment.Update(comment);

        }

        

        

    }
}
