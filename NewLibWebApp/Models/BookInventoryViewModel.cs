using System.Collections.Generic;

namespace NewLibWebApp.Models
{
    public class BookInventoryViewModel
    {
        public BookInventoryViewModel()
        {
            SingleBook = new BookInventoryModel();
            AllBooks = new List<BookInventoryModel>();
        }
        public BookModel book { get; set; }
        public List<BookModel> listofbook { get; set; }

        public UserModel User { get; set; }
        public BookInventoryModel SingleBook { get; set; }
        public List<BookInventoryModel> AllBooks { get; set; }
    }
}
