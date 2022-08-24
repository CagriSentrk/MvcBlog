using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
     public interface IRepository<T> //T parametresine göre crud işlemleri yapılacak.Y parametresi(tablolar).
    {
        List<T> List();

        int Insert(T p); //ekleme için int kullanılır.

        int Update(T p);

        int Delete(T p);

        T GetByID(int id); //Gönderilen ıd ye göre işlem yapılacak.(Güncellemede kullanılacak.)

        List<T> List(Expression<Func<T, bool>> filter);

        T Find(Expression<Func<T, bool>> where);

    }
}
