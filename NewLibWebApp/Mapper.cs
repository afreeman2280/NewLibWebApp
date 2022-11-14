using BLLLibary;
using CommonLib;
using NewLibWebApp.Models;
using System.Collections.Generic;

namespace NewLibWebApp
{
    public class Mapper
    {
        public List<UserViewModel> Map(List<User> dAUsers)
        {
            List<UserViewModel> userList = new List<UserViewModel>();

            foreach (User dAUser in dAUsers)
            {
                UserViewModel user = new UserViewModel();
                user.SingleUser.ID = dAUser.ID;
                user.SingleUser.UserName = dAUser.UserName;
                user.SingleUser.password = dAUser.password;
                user.SingleUser.RoleId = dAUser.Role;
                userList.Add(user);
            }
            return userList;
        }
        public List<UserModel> Mapp(List<User> dAUsers)
        {
            List<UserModel> userList = new List<UserModel>();

            foreach (User dAUser in dAUsers)
            {
                UserModel user = new UserModel();
                user.ID = dAUser.ID;
                user.UserName = dAUser.UserName;
                user.password = dAUser.password;
                user.RoleId = dAUser.Role;
                userList.Add(user);
            }
            return userList;
        }

        public UserViewModel Map(User dAUser)
        {
            UserViewModel user = new UserViewModel();
            user.SingleUser.ID = dAUser.ID;
            user.SingleUser.UserName = dAUser.UserName;
            user.SingleUser.password = dAUser.password;
            user.SingleUser.RoleId = dAUser.Role;
            return user;
        }
        public User Map(UserViewModel dAUser)
        {
            User user = new User();
            user.ID = dAUser.SingleUser.ID;
            user.UserName = dAUser.SingleUser.UserName;
            user.password = dAUser.SingleUser.password;
            user.Role = dAUser.SingleUser.RoleId;
            return user;
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
        public BookInventoryViewModel Map(BookInventory dABook)
        {
            BookInventoryViewModel Book = new BookInventoryViewModel();
            Book.SingleBook.ID = dABook.ID;
            Book.SingleBook.UserId = dABook.UserId;
            Book.SingleBook.BookId = dABook.BookId;
            Book.SingleBook.CheckedIn = dABook.CheckedIn;
            Book.SingleBook.checkInTime = dABook.checkintime;
            Book.SingleBook.checkOutTime = dABook.checkOut;
            return Book;
        }
        public BookInventory Map(BookInventoryViewModel dABook)
        {
            BookInventory Book = new BookInventory();
            Book.ID = dABook.SingleBook.ID;
            Book.UserId = dABook.SingleBook.UserId;
            Book.BookId = dABook.SingleBook.BookId;
            Book.CheckedIn = dABook.SingleBook.CheckedIn;
            Book.checkintime = dABook.SingleBook.checkInTime;
            Book.checkOut = dABook.SingleBook.checkOutTime;
            return Book;
        }
    }
}
