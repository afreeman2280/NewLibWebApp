using BLLLibary;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLibWebApp.Models;
using CommonLib;
using BusinessLogicClassLibrary;

namespace NewLibWebApp.Controllers
{
    public class BookInventoryController : Controller
    {
        BLLBookInventory bookInventory = new BLLBookInventory();
        Mapper mapper;
        // GET: BookInventoryController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewBooksInventory()
        {
            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventoryModel>();
            List<BookInventory> boBooks = bookInventory.getAllBookInventory();
            viewModel.AllBooks = Mapper(boBooks);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult ViewBooksInventory(int id)
        {
            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventoryModel>();
            List<BookInventory> boBooks = bookInventory.getAllBookInventory();
            viewModel.AllBooks = Mapper(boBooks);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult ViewUserBookInventory(int id)
        {
            BookInventoryViewModel viewModel = new BookInventoryViewModel();
            id = (int)HttpContext.Session.GetInt32("Id");
            viewModel.AllBooks = new List<BookInventoryModel>();
            List<BookInventory> boBooks = bookInventory.GetUserCheckedOutBooks(id);
            viewModel.AllBooks = Mapper(boBooks);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult AddBooksInventory(int BookID)
        {
            int BookInventoryID = (int)HttpContext.Session.GetInt32("Id");
            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventoryModel>();
            List<BookInventory> boBook = bookInventory.Test(BookID,BookInventoryID);
            viewModel.AllBooks = Mapper(boBook);
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult AddBooksInventory(BookInventoryViewModel BookVm)
        {
            BLLBookInventory _Bll = new BLLBookInventory();
            BookInventory boBook = mapper.Map(BookVm);
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
            int BookInventoryId = (int)HttpContext.Session.GetInt32("Id");

            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventoryModel>();
            List<BookInventory> boBook = bookInventory.Test(BookID, BookInventoryId);
            bookInventory.checkedInInventory(BookID, BookInventoryId);
            viewModel.AllBooks = Mapper(boBook);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CheckIn(BookInventoryViewModel BookVm)
        {
            BLLBookInventory _Bll = new BLLBookInventory();
            BookInventory boBook = mapper.Map(BookVm);
            string actionResult = "ViewUserBookInventory";
            string controller = "BookInventory";
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
        [HttpGet]
        public ActionResult RemoveBookInventory(int BookId)
        {
            BLLBookInventory _bll = new BLLBookInventory();
            BookInventoryViewModel viewModel = new BookInventoryViewModel();
            _bll.RemoveBookInventory((int)HttpContext.Session.GetInt32("Id"), BookId);


            BookInventory storedBookInventory = _bll.getBookInventory(BookId);
            List<BookInventory> BookInventory = _bll.getAllBookInventory();
            viewModel.AllBooks = Mapper(BookInventory);
            return RedirectToAction("ViewUserBookInventory", "BookInventory");
        }
        [HttpPost]
        public ActionResult RemoveBookInventory(BookInventoryViewModel BookInventoryToBeRemoved)
        {
            BLLBookInventory _Bll = new BLLBookInventory();
            BookInventoryViewModel viewModel = new BookInventoryViewModel();

            viewModel.AllBooks = new List<BookInventoryModel>();
            string actionResult = "ViewUserBookInventory";
            string controller = "BookInventory";
            BookInventory storedBookInventory = _Bll.getBookInventory(BookInventoryToBeRemoved.SingleBook.ID);
            _Bll.RemoveBookInventory(storedBookInventory.UserId,storedBookInventory.BookId);
            viewModel.AllBooks = new List<BookInventoryModel>();
            List<BookInventory> boBookInventory = _Bll.GetUserCheckedOutBooks((int)HttpContext.Session.GetInt32("Id"));
            viewModel.AllBooks = Mapper(boBookInventory);



            return RedirectToAction(actionResult, controller);

        }
        public List<BookInventoryModel> Mapper(List<BookInventory> dABooks)
        {
            List<BookInventoryModel> BookList = new List<BookInventoryModel>();

            foreach (BookInventory dABook in dABooks)
            {
                BookInventoryModel Book = new BookInventoryModel();
                Book.ID = dABook.ID;
                Book.UserId = dABook.UserId;
                Book.BookId = dABook.BookId;
                Book.CheckedIn = dABook.CheckedIn;
                Book.checkInTime = dABook.checkintime;
                Book.checkOutTime = dABook.checkOut;
                BookList.Add(Book);
            }
            return BookList;
        }
 


    }
}
