using System;
using System.Collections.Generic;
using System.Linq;
using DALLib;
using BLLibary;
using static System.Reflection.Metadata.BlobBuilder;
using BLLLibary;

namespace BusinessLogicClassLibrary
{

    public class BLLBookInventory
    {
        public int ID { get; set; }

        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool CheckedIn { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime checkOutTime { get; set; }

        DABookInventory inventory = new DABookInventory();
        List<BLLBookInventory> BLLBookInventorys = new List<BLLBookInventory>();
        public BLLBookInventory()
        {
            this.ID = 0;
            this.UserId = 0;
            this.BookId = 0;
            this.CheckedIn = false;
        }
        public BLLBookInventory(int iD, int userId, int bookId, bool checkedIn)
        {
            this.ID = iD;
            this.UserId = userId;
            this.BookId = bookId;
            this.CheckedIn = checkedIn;
        }


        public void addBookToInventory(int BookId, int UserId)
        {
            DABookInventory inventory = new DABookInventory();
            inventory.AddToBookInventory(BookId, UserId);
        }
        public void addToBookInventory(BLLBookInventory book)
        {
            inventory.AddToBookInventory(Map(book));
            Console.WriteLine("New book added");
        }
   




        public void checkedInInventory(int BookId, int UserId)
        {
            inventory.Checkin(BookId, UserId);
        }
        public void checkedInInventory(BLLBookInventory book)
        {
             inventory.Checkin(book.BookId,book.UserId);
            Console.WriteLine("New book added");
        }
        public List<BLLBookInventory> Test(int bookId,int userId)
        {
            List<BLLBookInventory> boHardware = Map(inventory.Test(bookId,userId));
            return boHardware;
        }


     
       
        public List<BLLBookInventory> getAllBookInventory()
        {
            return Map(inventory.GetAllBookInventory());
        }
        public void printAllBooks()
        {
            List<BLLBookInventory> bookList = Map(inventory.GetAllBookInventory());
            foreach (BLLBookInventory book in bookList)
            {
                Console.WriteLine("The Book Id  " + book.ID);
                Console.WriteLine("Book name " + book.BookId);
                Console.WriteLine("Author " + book.UserId);
            }
        }
        public List<BLLBookInventory> Map(List<DABookInventory> dABooks)
        {
            List<BLLBookInventory> bLLBookInventories = new List<BLLBookInventory>();
            foreach (DABookInventory dbook in dABooks)
            {
                BLLBookInventory inventory = new BLLBookInventory();
                inventory.ID = dbook.ID;
                inventory.BookId = dbook.BookId;
                inventory.UserId = dbook.UserId;
                inventory.CheckedIn = dbook.CheckedIn;
                bLLBookInventories.Add(inventory);
            }
            return bLLBookInventories;
        }
        public BLLBookInventory Map(DABookInventory dABook)
        {
            BLLBookInventory inventory = new BLLBookInventory();
            inventory.ID = dABook.ID;
            inventory.BookId = dABook.BookId;
            inventory.UserId = dABook.UserId;
            inventory.CheckedIn = dABook.CheckedIn;
            return inventory;
        }
        public DABookInventory Map(BLLBookInventory dABook)
        {
            DABookInventory inventory = new DABookInventory();
            inventory.ID = dABook.ID;
            inventory.BookId = dABook.BookId;
            inventory.UserId = dABook.UserId;
            inventory.CheckedIn = dABook.CheckedIn;
            return inventory;
        }
    }
}
