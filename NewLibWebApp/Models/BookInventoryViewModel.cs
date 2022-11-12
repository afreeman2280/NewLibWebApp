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
        public BookInventoryModel SingleBook { get; set; }
        public List<BookInventoryModel> AllBooks { get; set; }
    }
}
