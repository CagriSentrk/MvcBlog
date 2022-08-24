using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
   public class AboutManager
    {
        Repository<About> repoblog = new Repository<About>();
        public List<About> GetAll()
        {
            return repoblog.List();
        }
        public int UpdateAbout(About p)
        {
           About about = repoblog.Find(x => x.AboutID == p.AboutID);
            about.AboutID = p.AboutID;
            about.AboutContent = p.AboutContent;
            about.AboutContent2 = p.AboutContent2;
            about.AboutImage1 = p.AboutImage1;
            about.AboutImage2 = p.AboutImage2;
           


            return repoblog.Update(about);

        }


    }
}

