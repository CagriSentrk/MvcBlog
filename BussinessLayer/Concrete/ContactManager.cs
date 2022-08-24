using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ContactManager
    {
        Repository<Contact> repocontect = new Repository<Contact>();

        public int BLContactAdd(Contact c)
        {
            if (c.Mail == "" || c.Message == "")
            {
                return -1;
            }
            return repocontect.Insert(c);
        }
        public List<Contact> GetAll()
        {
            return repocontect.List();
        }
      public Contact GetContactDetails(int id)
        {
            return repocontect.Find(x => x.ContactID == id);
        }
        public int DeleteMessageBl(int p)
        {
            Contact contact = repocontect.Find(x => x.ContactID == p);
            return repocontect.Delete(contact);
        }
        public int ContactStatusChangeToFalse(int id)
        {
            Contact contact = repocontect.Find(x => x.ContactID == id);
            contact.ContactStatus = false;

            return repocontect.Update(contact);

        }


    }
}
