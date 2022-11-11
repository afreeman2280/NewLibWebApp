using BLLLibary;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLibWebApp.Models;

namespace NewLibWebApp.Controllers
{
    public class BookController : Controller
    {
        int bookId;
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
            List<BLLBook> boBooks = Book.getAllBook();
            viewModel.AllBooks = Mapper(boBooks);
            return View(viewModel);
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
            BLLBook boBook = Map(BookVm);
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
            BLLBook storedBook = _bll.getBook(BookID);
            BookViewModel book = Map(storedBook);
            return View(book);
        }
        [HttpPost]
        public ActionResult UpdateBook(BookViewModel BookTobeUpdated)
        {
            BLLBook _Bll = new BLLBook();
            string actionResult = "ViewBooks";
            string controller = "Book";
            BLLBook boHardware = Map(BookTobeUpdated);

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


            BLLBook storedBook = _bll.getBook(BookId);
            _bll.RemoveBook(storedBook.ID);
            List<BLLBook> book = _bll.getAllBook();
            viewModel.AllBooks = Mapper(book);
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
            BLLBook storedBook = _Bll.getBook(BookToBeRemoved.SingleBook.ID);
            _Bll.RemoveBook(storedBook.ID);
            viewModel.AllBooks = new List<BookModel>();
            List<BLLBook> boBook = _Bll.getAllBook();
            viewModel.AllBooks = Mapper(boBook);



            return RedirectToAction(actionResult, controller);

        }
        public List<BookViewModel> Map(List<BLLBook> dABooks)
        {
            List<BookViewModel> BookList = new List<BookViewModel>();

            foreach (BLLBook dABook in dABooks)
            {
                BookViewModel Book = new BookViewModel();
                Book.SingleBook.ID = dABook.ID;
                Book.SingleBook.Bookname = dABook.Bookname;
                Book.SingleBook.Author = dABook.Author;
                BookList.Add(Book);
            }
            return BookList;
        }
        public List<BookModel> Mapper(List<BLLBook> dABooks)
        {
            List<BookModel> BookList = new List<BookModel>();

            foreach (BLLBook dABook in dABooks)
            {
                BookModel Book = new BookModel();
                Book.ID = dABook.ID;
                Book.Bookname = dABook.Bookname;
                Book.Author = dABook.Author;
                BookList.Add(Book);
            }
            return BookList;
        }
        public BookViewModel Map(BLLBook dABook)
        {
            BookViewModel Book = new BookViewModel();
            Book.SingleBook.ID = dABook.ID;
            Book.SingleBook.Bookname = dABook.Bookname;
            Book.SingleBook.Author = dABook.Author;
            return Book;
        }
        public BLLBook Map(BookViewModel dABook)
        {
            BLLBook Book = new BLLBook();
            Book.ID = dABook.SingleBook.ID;
            Book.Bookname = dABook.SingleBook.Bookname;
            Book.Author = dABook.SingleBook.Author;
            return Book;
        }
    }
}

   

