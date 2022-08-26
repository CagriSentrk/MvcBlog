using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
     public class Author
    {
        [Key]
        public int AuthorID { get; set; }
 
        [StringLength(50)]
        public string AuthorName { get; set; }
        [StringLength(100)]
        public string AuthorImage { get; set; }
        [StringLength(250)]
        public string AuthorAbout { get; set; }
        [StringLength(50)]
        public String Title { get; set; }
        
        [StringLength(50)]
        public string Mail { get; set; }
       
        [StringLength(20)]
        public string PhoneNumber { get; set; } 
        [StringLength(20)]
        public string Password { get; set; }


        public ICollection<Blog> Blogs { get; set; }
        public ICollection<MessageAuthor> MessageAuthors { get; set; }


    }
}
