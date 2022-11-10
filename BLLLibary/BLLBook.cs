using System;
using System.Collections.Generic;
using System.Linq;
using DALLib;
using static System.Reflection.Metadata.BlobBuilder;

namespace BLLLibary
{
  
    public class BLLBook
    {
       public int ID { get; set; }

       public string Bookname { get; set; }
      public  string Author { get; set; }

        DABook book = new DABook();
        List<BLLBook> BLLBooks = new List<BLLBook>();
    public BLLBook()
        {
           this.ID = 0;
           this.Bookname = string.Empty;
           this.Author = string.Empty;
        }
   public BLLBook(int id,string bookName,string bookAuthor)
        {
            this.ID = id;
            this.Bookname = bookName;
            this.Author = bookAuthor;
        }
      public void addBook(BLLBook book)
        {
            DABook dAook = new DABook();

            dAook.AddBook(book.Bookname,book.Author); 
        }
        public void addBook(string bookName,string bookAuthor)
        {
           DABook dAook = new DABook();
            dAook.AddBook(bookName, bookAuthor);
        }
        public bool bookExist(int id)
        {
            List<BLLBook> bookList = Map(book.GetAllBook());

            return bookList.Any(p=> p.ID == id);
        }
        public void RemoveBook( int IdOfBookToBeRemoved)
        {

           // DABook dABook = Map(Book);
            book.RemoveBook(IdOfBookToBeRemoved);

        }
        public void UpdateBook(BLLBook UpdatedBook,int IdOfBookToBeUpdated)
        {
            
                DABook dABook = Map(UpdatedBook);
                book.updateBook(dABook, IdOfBookToBeUpdated);
            
        }
     
        
        
        public void updateBookName (int id,string newBookName)
        {
            book.UpdateBookname(id, newBookName);
            Console.WriteLine("Book Name Updated");
        }

        public void updateAuthor(int id, string Author)
        {
            book.UpadateAuthor(id,Author);
            Console.WriteLine("Author Updated");
        }
        
        public BLLBook getBook(int id)
        {
            return Map(book.GetBook(id));
        }
        public List<BLLBook> getAllBook()
        {
            return Map(book.GetAllBook());
        }

        public void printSingleBook(int id)
        {
            DABook dABook = new DABook();
            dABook = book.GetBook(id);
            if (dABook != null)
            {


                BLLBook books = Map(book.GetBook(id));
                Console.WriteLine("The Book Id  " + books.ID);
                Console.WriteLine("Book name " +books.Bookname);
                Console.WriteLine("Author " + books.Author);
            }
            else
            {
                Console.WriteLine("Book does not exist");
            }
        }
        public void printAllBooks()
        {
            List<BLLBook> bookList = Map(book.GetAllBook());
            foreach (BLLBook book in bookList)
            {
                Console.WriteLine("The Book Id  " + book.ID);
                Console.WriteLine("Book name " + book.Bookname);
                Console.WriteLine("Author " + book.Author);
            }
        }
        public List<BLLBook> Map(List<DABook> dABooks)
        {
            List<BLLBook> books = new List<BLLBook>();  

            foreach (DABook dbook in dABooks)
            {
                BLLBook book = new BLLBook();
                book.ID = dbook.ID;
                book.Bookname = dbook.BookName;
                book.Author = dbook.Author;
                books.Add(book);
            }
            return books;
        }
        public BLLBook Map(DABook dABook)
        {
            BLLBook book = new BLLBook();
            book.ID = dABook.ID;
            book.Bookname = dABook.BookName;
            book.Author = dABook.Author;
            return book;
        }
        public DABook Map(BLLBook dABook)
        {
            DABook book = new DABook();
            book.ID = dABook.ID;
            book.BookName = dABook.Bookname;
            book.Author = dABook.Author;
            return book;
        }
    }
}
