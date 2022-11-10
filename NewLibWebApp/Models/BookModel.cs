using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NewLibWebApp.Models
{
    public class BookModel
    {

        public int ID { get; set; }
        [Display(Name = "Book Name")]
        [Required(ErrorMessage = "The Book Name is required")]
        public string Bookname { get; set; }
        [Required(ErrorMessage = "The Author is required")]
        public string Author { get; set; }
    }
}
