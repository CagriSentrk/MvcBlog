using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
     public class CategoryManager
    {

        //Repository'de crud işlemleri var.
        //Burada repositoryde ki crud işlemlerini kategori üzerinde uyguladım.
        //Bu işlemi yapınca DataAccesLayer'da ki abstract klasöründe yaptığımız işleme gerek kalmadı.

        Repository<Category> repocategory = new Repository<Category>(); 
        public List<Category> GetAll()
        {
            return repocategory.List();
        }
        public int DeleteCategoryBL(int p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p);
            return repocategory.Delete(category);
        }

    }
}
 