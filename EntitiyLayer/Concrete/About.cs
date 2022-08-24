using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class About
    {
        [Key]   //primary Key olarak tanımladık.
        public int AboutID { get; set; }

        [StringLength(500)] //aboutcontent 500 karakterden fazla olamaz.
        public string AboutContent { get; set; }

        [StringLength(500)] //aboutcontent2 500 karakterden fazla olamaz.
        public string AboutContent2 { get; set; }

        [StringLength(100)] //AboutImage1 100 karakterden fazla olamaz.
        public string AboutImage1 { get; set; }

        [StringLength(100)] //AboutImage2 100 karakterden fazla olamaz.
        public string AboutImage2 { get; set; }
    }
}
