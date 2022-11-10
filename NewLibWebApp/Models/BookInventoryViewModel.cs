using System.Collections.Generic;

namespace NewLibWebApp.Models
{
    public class BookInventoryViewModel
    {
        public BookInventoryViewModel()
        {
            SingleBook = new BookInventory();
            AllBooks = new List<BookInventory>();
        }
        public BookInventory SingleBook { get; set; }
        public List<BookInventory> AllBooks { get; set; }
    }
}
