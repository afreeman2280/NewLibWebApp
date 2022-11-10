using BLLLibary;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLibWebApp.Models;
using BusinessLogicClassLibrary;

namespace NewLibWebApp.Controllers
{
    public class BookInventoryController : Controller
    {
        BLLBookInventory bookInventory = new BLLBookInventory();
        // GET: BookInventoryController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewBooksInventory()
        {
            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventory>();
            List<BLLBookInventory> boBooks = bookInventory.getAllBookInventory();
            viewModel.AllBooks = Mapper(boBooks);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult ViewAllBooksInventoryBookUserCheckOut(int id)
        {
            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventory>();
            List<BLLBookInventory> boBooks = bookInventory.getAllBookInventory();
            viewModel.AllBooks = Mapper(boBooks);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult AddBooksInventory(int BookID)
        {
            int userID = (int)HttpContext.Session.GetInt32("Id");
            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventory>();
            List<BLLBookInventory> boBook = bookInventory.Test(BookID,userID);
            viewModel.AllBooks = Mapper(boBook);
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult AddBooksInventory(BookInventoryViewModel BookVm)
        {
            BLLBookInventory _Bll = new BLLBookInventory();
            BLLBookInventory boBook = Map(BookVm);
            string actionResult = "ViewBooks";
            string controller = "Book";
            _Bll.addToBookInventory(boBook);
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
        public ActionResult CheckIn(int BookID)
        {
            int userId = (int)HttpContext.Session.GetInt32("Id");

            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventory>();
            List<BLLBookInventory> boBook = bookInventory.Test(BookID, userId);
          //  bookInventory.checkedInInventory(BookID, userId);
            viewModel.AllBooks = Mapper(boBook);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CheckIn(BookInventoryViewModel BookVm)
        {
            BLLBookInventory _Bll = new BLLBookInventory();
            BLLBookInventory boBook = Map(BookVm);
            string actionResult = "ViewBooks";
            string controller = "Book";
            _Bll.checkedInInventory(boBook);
            if (ModelState.IsValid == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction(actionResult, controller);
            }
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
        public List<BookInventory> Mapper(List<BLLBookInventory> dABooks)
        {
            List<BookInventory> BookList = new List<BookInventory>();

            foreach (BLLBookInventory dABook in dABooks)
            {
                BookInventory Book = new BookInventory();
                Book.ID = dABook.ID;
                Book.UserId = dABook.UserId;
                Book.BookId = dABook.BookId;
                Book.CheckedIn = dABook.CheckedIn;
                Book.checkInTime = dABook.checkInTime;
                Book.checkOutTime = dABook.checkOutTime;
                BookList.Add(Book);
            }
            return BookList;
        }
        public BookInventoryViewModel Map(BLLBookInventory dABook)
        {
            BookInventoryViewModel Book = new BookInventoryViewModel();
            Book.SingleBook.ID = dABook.ID;
            Book.SingleBook.UserId = dABook.UserId;
            Book.SingleBook.BookId = dABook.BookId;
            Book.SingleBook.CheckedIn = dABook.CheckedIn;
            Book.SingleBook.checkInTime=dABook.checkInTime;
            Book.SingleBook.checkOutTime = dABook.checkOutTime;
            return Book;
        }
        public BLLBookInventory Map(BookInventoryViewModel dABook)
        {
            BLLBookInventory Book = new BLLBookInventory();
            Book.ID = dABook.SingleBook.ID;
            Book.UserId = dABook.SingleBook.UserId;
            Book.BookId = dABook.SingleBook.BookId;
            Book.CheckedIn = dABook.SingleBook.CheckedIn;
            Book.checkInTime = dABook.SingleBook.checkInTime;
            Book.checkOutTime = dABook.SingleBook.checkOutTime;
            return Book;
        }
    }
}
