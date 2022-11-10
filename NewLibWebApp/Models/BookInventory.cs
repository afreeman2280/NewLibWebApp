using System;

namespace NewLibWebApp.Models
{
    public class BookInventory
    {
        public int ID { get; set; }

        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool CheckedIn { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime checkOutTime { get; set; }
    }
}
