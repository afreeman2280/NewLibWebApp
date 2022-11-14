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
            viewModel.AllUsers = mapper.Mapp(boUsers);
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
            User boUser = mapper.Map(userVm);
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
            User boUser = mapper.Map(userVm);

            User storedUser = user.getUserByUserName(userVm.SingleUser.UserName);

            loginCheck = user.Login(storedUser.password, boUser.password);

            if (loginCheck == true && ModelState.IsValid)
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
            x = UserID;
            User storedUser = _bll.getUser(UserID);
            UserViewModel User = mapper.Map(storedUser);
            return View(User);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserViewModel UserTobeUpdated)
        {
            BLLUser _Bll = new BLLUser();
            string actionResult = "ViewUsers";
            string controller = "User";
            User boUser = mapper.Map(UserTobeUpdated);

            _Bll.UpdateUser(boUser, UserTobeUpdated.SingleUser.ID);
            if (ModelState.IsValid == false)
            {

                return View();
            }

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
            viewModel.AllUsers = mapper.Mapp(User);
            UserViewModel UserVM = mapper.Map(storedUser);
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
            viewModel.AllUsers = mapper.Mapp(boUser);



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
       
       
      
        
    }
}

