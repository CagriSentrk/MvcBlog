using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        [StringLength(100)]
        public string BlogTitle { get; set; }
        [StringLength(100)]
        public string BlogImage { get; set; }

        public DateTime BlogDate { get; set; }

        public string BlogContent { get; set; }
        
        public int BlogRating { get; set; }

        //Kategori ile blogları bağladım.
        public int CategoryID { get; set; }                                      
        public virtual Category Category { get; set; }

        //yazarlar ile blogları bağladım.
        public int AuthorID { get; set; }                         
        public virtual Author Author { get; set; }

         public ICollection<Comment> Comments { get; set; }

    }
}
