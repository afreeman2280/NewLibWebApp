﻿using BLLLibary;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommonLib;
using NewLibWebApp.Models;

namespace NewLibWebApp.Controllers
{
    public class BookController : Controller
    {
        int bookId;
        Mapper mapper;
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
            viewModel.AllBooks = mapper.Mapp(boBooks);
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
            Book boBook = mapper.Map(BookVm);
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
            BookViewModel book = mapper.Map(storedBook);
            return View(book);
        }
        [HttpPost]
        public ActionResult UpdateBook(BookViewModel BookTobeUpdated)
        {
            BLLBook _Bll = new BLLBook();
            string actionResult = "ViewBooks";
            string controller = "Book";
            Book boHardware = mapper.Map(BookTobeUpdated);

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
            viewModel.AllBooks = mapper.Mapp(book);
            BookViewModel bookVM = mapper.Map(storedBook);
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
            viewModel.AllBooks = mapper.Mapp(boBook);



            return RedirectToAction(actionResult, controller);

        }
        
    }
}

   

