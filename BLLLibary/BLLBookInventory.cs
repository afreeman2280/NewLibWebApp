using System;
using System.Collections.Generic;
using System.Linq;
using DALLib;
using BLLibary;
using CommonLib;
using static System.Reflection.Metadata.BlobBuilder;
using BLLLibary;

namespace BusinessLogicClassLibrary
{

    public class BLLBookInventory
    {
        
        DABookInventory inventory = new DABookInventory();
        public BLLBookInventory()
        {
            
        }
      

        public void addBookToInventory(int BookId, int UserId)
        {
            DABookInventory inventory = new DABookInventory();
            inventory.AddToBookInventory(BookId, UserId);
        }
        public void addToBookInventory(BookInventory book)
        {
            inventory.AddToBookInventory(book);
        }
   




        public void checkedInInventory(int BookId, int UserId)
        {
            inventory.Checkin(BookId, UserId);
        }
        public BookInventory getBookInventory(int userId)
        {
            return inventory.GetBookInventory(userId);
        }
        public void RemoveBookInventory(int userID,int bookId)
        {

            // DABook dABook = Map(Book);
            inventory.removeBookInventory(userID,bookId);

        }
        public void checkedInInventory(BookInventory book)
        {
             inventory.Checkin(book.BookId,book.UserId);
            Console.WriteLine("New book added");
        }
        public List<BookInventory> Test(int bookId,int userId)
        {
            List<BookInventory> boBook = inventory.Test(bookId,userId);
            return boBook;
        }


     
       
        public List<BookInventory> getAllBookInventory()
        {
            return inventory.GetAllBookInventory();
        }
       
       
    }
}
