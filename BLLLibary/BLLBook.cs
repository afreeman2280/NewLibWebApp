using System;
using System.Collections.Generic;
using System.Linq;
using DALLib;
using CommonLib;
using static System.Reflection.Metadata.BlobBuilder;

namespace BLLLibary
{

    public class BLLBook
    {
        public int ID { get; set; }

        public string Bookname { get; set; }
        public string Author { get; set; }

        DABook book = new DABook();
        List<BLLBook> BLLBooks = new List<BLLBook>();
        public BLLBook()
        {
            this.ID = 0;
            this.Bookname = string.Empty;
            this.Author = string.Empty;
        }
        public BLLBook(int id, string bookName, string bookAuthor)
        {
            this.ID = id;
            this.Bookname = bookName;
            this.Author = bookAuthor;
        }
        public void addBook(Book book)
        {
            DABook dAook = new DABook();

            dAook.AddBook(book.BookName, book.Author);
        }
        public void addBook(string bookName, string bookAuthor)
        {
            DABook dAook = new DABook();
            dAook.AddBook(bookName, bookAuthor);
        }
        public bool bookExist(int id)
        {
            List<Book> bookList = book.GetAllBook();

            return bookList.Any(p => p.ID == id);
        }
        public void RemoveBook(int IdOfBookToBeRemoved)
        {

            // DABook dABook = Map(Book);
            book.RemoveBook(IdOfBookToBeRemoved);

        }
        public void UpdateBook(Book UpdatedBook, int IdOfBookToBeUpdated)
        {

            book.updateBook(UpdatedBook, IdOfBookToBeUpdated);

        }



        public void updateBookName(int id, string newBookName)
        {
            book.UpdateBookname(id, newBookName);
            Console.WriteLine("Book Name Updated");
        }

        public void updateAuthor(int id, string Author)
        {
            book.UpadateAuthor(id, Author);
            Console.WriteLine("Author Updated");
        }

        public Book getBook(int id)
        {
            return book.GetBook(id);
        }
        public List<Book> getAllBook()
        {
            return book.GetAllBook();
        }



    }
}
