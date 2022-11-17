using System.Collections.Generic;
using BLLLibary;
using CommonLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLibWebApp.Models;

namespace NewLibWebApp.Controllers
{
    public class UserController : Controller
    {
        int x;
        Mapper mapper;
        BLLUser user = new BLLUser();
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewUsers()
        {
            UserViewModel viewModel = new UserViewModel();

            viewModel.AllUsers = new List<UserModel>();
            List<User> boUsers = user.getAllUser();
            viewModel.AllUsers = Mapp(boUsers);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModel userVm)
        {
            string view = "Login";
            User boUser = Map(userVm);
            if (ModelState.IsValid == false)
            {
                view = "Register";
            }
            else
            {
            user.addUser(boUser);

            }
            return View(view);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel userVm)
        {
            bool loginCheck;

            string actionResult = "";
            string controller = "";
            User boUser = Map(userVm);

            User storedUser = user.getUserByUserName(userVm.SingleUser.UserName);
            loginCheck = user.Login(storedUser.password, user.GetHash(boUser.password));

            if (loginCheck == true)
            {
                HttpContext.Session.SetInt32("Id", storedUser.ID);
                HttpContext.Session.SetString("Username", storedUser.UserName);
                HttpContext.Session.SetInt32("RoleId", storedUser.Role);

                actionResult = "Index";
                controller = "Home";
                ViewBag.result = "Login successful";
            }
            else if (loginCheck == false || !ModelState.IsValid)
            {

                actionResult = "Login";
                controller = "User";
                ViewBag.LoginError = "Login Failed";
            }

            return RedirectToAction(actionResult, controller);
        }
        [HttpGet]
        public ActionResult UpdateUser(int UserID)
        {
            BLLUser _bll = new BLLUser();
            User storedUser = _bll.getUser(UserID);
            UserViewModel User = Map(storedUser);
            return View(User);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserViewModel UserTobeUpdated)
        {
            BLLUser _Bll = new BLLUser();
            string actionResult = "ViewUsers";
            string controller = "User";
            User boUser = Map(UserTobeUpdated);

            _Bll.UpdateUser(boUser, UserTobeUpdated.SingleUser.ID);
          

            return RedirectToAction(actionResult, controller);
        }


        [HttpGet]
        public ActionResult RemoveUser(int UserId)
        {
            BLLUser _bll = new BLLUser();
            UserViewModel viewModel = new UserViewModel();


            User storedUser = _bll.getUser(UserId);
            _bll.removeUser(storedUser.ID);
            List<User> User = _bll.getAllUser();
            viewModel.AllUsers = Mapp(User);
            UserViewModel UserVM = Map(storedUser);
            return RedirectToAction("ViewUsers", "User");
        }
        [HttpPost]
        public ActionResult RemoveUser(UserViewModel UserToBeRemoved)
        {
            BLLUser _Bll = new BLLUser();
            UserViewModel viewModel = new UserViewModel();

            viewModel.AllUsers = new List<UserModel>();
            string actionResult = "ViewUsers";
            string controller = "User";
            User storedUser = _Bll.getUser(UserToBeRemoved.SingleUser.ID);
            _Bll.removeUser(storedUser.ID);
            viewModel.AllUsers = new List<UserModel>();
            List<User> boUser = _Bll.getAllUser();
            viewModel.AllUsers = Mapp(boUser);



            return RedirectToAction(actionResult, controller);

        }
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



    }
}

