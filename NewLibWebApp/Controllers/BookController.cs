using BLLLibary;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommonLib;
using NewLibWebApp.Models;
using System.Net;
using System;
using DALLib;

namespace NewLibWebApp.Controllers
{
    public class BookController : Controller
    {
        int bookId;
        Mapper Mapper;
        BLLBook Book = new BLLBook();
        // GET: BookController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewBooks()
        {
            BookViewModel viewModel = new BookViewModel();

            viewModel.AllBooks = new List<BookModel>();
            List<Book> boBooks = Book.getAllBook();
            viewModel.AllBooks = Mapp(boBooks);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult ViewBook(int BookId)
        {
            BLLBook _bll = new BLLBook();
            bookId = BookId;
            Book storedBook = _bll.getBook(bookId);
            BookViewModel book = Map(storedBook);
            return View(book);
        }

        
        public IActionResult Search(IFormCollection form)
        {
            
            
            List<Book> books = Book.SearchBooks(form["expr"]);
            BookViewModel bookModels = new BookViewModel();
            bookModels.AllBooks = new List<BookModel>();
            bookModels.AllBooks = Mapp(books);
            if (books == null|| books.Count == 0 ) { return RedirectToAction("ViewBooks"); }
            
            return View(bookModels);
        }

        private BookModel Mapp(Book book)
        {
            BookModel bookModel = new BookModel();
            bookModel.ID = book.ID;
            bookModel.Bookname = book.BookName;
            bookModel.Author = book.Author;
            return bookModel;
        }

       

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BookViewModel BookVm)
        {
            BLLBook _Bll = new BLLBook();
            Book boBook = Map(BookVm);
            string actionResult = "ViewBooks";
            string controller = "Book";
            _Bll.addBook(boBook);
            if (ModelState.IsValid == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction(actionResult, controller);
            }
        }
        [HttpGet]
        public ActionResult UpdateBook(int BookID)
        {
            BLLBook _bll = new BLLBook();
            bookId = BookID;
            Book storedBook = _bll.getBook(BookID);
            BookViewModel book = Map(storedBook);
            return View(book);
        }
        [HttpPost]
        public ActionResult UpdateBook(BookViewModel BookTobeUpdated)
        {
            BLLBook _Bll = new BLLBook();
            string actionResult = "ViewBooks";
            string controller = "Book";
            Book boHardware = Map(BookTobeUpdated);

            _Bll.UpdateBook(boHardware, BookTobeUpdated.SingleBook.ID);
            if (ModelState.IsValid == false)
            {
   
                return View();
            }

            return RedirectToAction(actionResult, controller);
        }
        [HttpGet]
        public ActionResult RemoveBook(int BookId)
        {
            BLLBook _bll = new BLLBook();
            BookViewModel viewModel = new BookViewModel();


            Book storedBook = _bll.getBook(BookId);
            _bll.RemoveBook(storedBook.ID);
            List<Book> book = _bll.getAllBook();
            viewModel.AllBooks = Mapp(book);
            BookViewModel bookVM = Map(storedBook);
            return RedirectToAction("ViewBooks", "Book");
        }
        [HttpPost]
        public ActionResult RemoveBook(BookViewModel BookToBeRemoved)
        {
            BLLBook _Bll = new BLLBook();
            BookViewModel viewModel = new BookViewModel();

            viewModel.AllBooks = new List<BookModel>();
            string actionResult = "ViewBooks";
            string controller = "Book";
            Book storedBook = _Bll.getBook(BookToBeRemoved.SingleBook.ID);
            _Bll.RemoveBook(storedBook.ID);
            viewModel.AllBooks = new List<BookModel>();
            List<Book> boBook = _Bll.getAllBook();
            viewModel.AllBooks = Mapp(boBook);



            return RedirectToAction(actionResult, controller);

        }
        public List<BookViewModel> Map(List<Book> dABooks)
        {
            List<BookViewModel> BookList = new List<BookViewModel>();

            foreach (Book dABook in dABooks)
            {
                BookViewModel Book = new BookViewModel();
                Book.SingleBook.ID = dABook.ID;
                Book.SingleBook.Bookname = dABook.BookName;
                Book.SingleBook.Author = dABook.Author;
                BookList.Add(Book);
            }
            return BookList;
        }
        public List<BookModel> Mapp(List<Book> dABooks)
        {
            List<BookModel> BookList = new List<BookModel>();

            foreach (Book dABook in dABooks)
            {
                BookModel Book = new BookModel();
                Book.ID = dABook.ID;
                Book.Bookname = dABook.BookName;
                Book.Author = dABook.Author;
                BookList.Add(Book);
            }
            return BookList;
        }
        public BookViewModel Map(Book dABook)
        {
            BookViewModel Book = new BookViewModel();
            Book.SingleBook.ID = dABook.ID;
            Book.SingleBook.Bookname = dABook.BookName;
            Book.SingleBook.Author = dABook.Author;
            return Book;
        }
        public Book Map(BookViewModel dABook)
        {
            Book Book = new Book();
            Book.ID = dABook.SingleBook.ID;
            Book.BookName = dABook.SingleBook.Bookname;
            Book.Author = dABook.SingleBook.Author;
            return Book;
        }

    }
}

   

