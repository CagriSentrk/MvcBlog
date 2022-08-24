using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
   public class SubscribeMailManager
    {
        Repository<SubscribeMail> reposubsrcibemail = new Repository<SubscribeMail>();
        public int BLAdd(SubscribeMail p)
        {
            //gmail.com
            if (p.Mail.Length<=10||p.Mail.Length>=50)
            {
                return -1; //işlemi gerçekleştirme anlamına geliyor.
            }
            return reposubsrcibemail.Insert(p);
        }

    }
}
