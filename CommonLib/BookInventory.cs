using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    public class BookInventory
    {

        public int ID { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool CheckedIn { get; set; }
        public DateTime checkintime { get; set; }
        public DateTime checkOut { get; set; }
    }
}
