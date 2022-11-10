using System.Collections.Generic;

namespace NewLibWebApp.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            SingleBook = new BookModel();
            AllBooks = new List<BookModel>();
        }
        public BookModel SingleBook { get; set; }
        public List<BookModel> AllBooks { get; set; }
    }
}
