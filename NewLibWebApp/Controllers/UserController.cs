using System.Collections.Generic;
using BLLLibary;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLibWebApp.Models;

namespace NewLibWebApp.Controllers
{
    public class UserController : Controller
    {
        int x;
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
            List<BLLUser> boUsers = user.getAllUser();
            viewModel.AllUsers = Mapper(boUsers);
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
            BLLUser boUser = Map(userVm);
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
            BLLUser boUser = Map(userVm);

            BLLUser storedUser = user.getUserByUserName(userVm.SingleUser.UserName);

            loginCheck = user.Login(storedUser.password, boUser.password);

            if (loginCheck == true && ModelState.IsValid)
            {
                HttpContext.Session.SetInt32("Id", storedUser.ID);
                HttpContext.Session.SetString("Username", storedUser.UserName);
                HttpContext.Session.SetInt32("RoleId", storedUser.RoleId);

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
            BLLUser storedUser = _bll.getUser(UserID);
            UserViewModel User = Map(storedUser);
            return View(User);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserViewModel UserTobeUpdated)
        {
            BLLUser _Bll = new BLLUser();
            string actionResult = "ViewUsers";
            string controller = "User";
            BLLUser boUser = Map(UserTobeUpdated);

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


            BLLUser storedUser = _bll.getUser(UserId);
            _bll.removeUser(storedUser.ID);
            List<BLLUser> User = _bll.getAllUser();
            viewModel.AllUsers = Mapper(User);
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
            BLLUser storedUser = _Bll.getUser(UserToBeRemoved.SingleUser.ID);
            _Bll.removeUser(storedUser.ID);
            viewModel.AllUsers = new List<UserModel>();
            List<BLLUser> boUser = _Bll.getAllUser();
            viewModel.AllUsers = Mapper(boUser);



            return RedirectToAction(actionResult, controller);

        }
        public List<UserViewModel> Map(List<BLLUser> dAUsers)
        {
            List<UserViewModel> userList = new List<UserViewModel>();

            foreach (BLLUser dAUser in dAUsers)
            {
                UserViewModel user = new UserViewModel();
                user.SingleUser.ID = dAUser.ID;
                user.SingleUser.UserName = dAUser.UserName;
                user.SingleUser.password = dAUser.password;
                user.SingleUser.RoleId = dAUser.RoleId;
                userList.Add(user);
            }
            return userList;
        }
        public List<UserModel> Mapper(List<BLLUser> dAUsers)
        {
            List<UserModel> userList = new List<UserModel>();

            foreach (BLLUser dAUser in dAUsers)
            {
                UserModel user = new UserModel();
                user.ID = dAUser.ID;
                user.UserName = dAUser.UserName;
                user.password = dAUser.password;
                user.RoleId = dAUser.RoleId;
                userList.Add(user);
            }
            return userList;
        }
       
        public UserViewModel Map(BLLUser dAUser)
        {
            UserViewModel user = new UserViewModel();
            user.SingleUser.ID = dAUser.ID;
            user.SingleUser.UserName = dAUser.UserName;
            user.SingleUser.password = dAUser.password;
            user.SingleUser.RoleId = dAUser.RoleId;
            return user;
        }
        public BLLUser Map(UserViewModel dAUser)
        {
            BLLUser user = new BLLUser();
            user.ID = dAUser.SingleUser.ID;
            user.UserName = dAUser.SingleUser.UserName;
            user.password = dAUser.SingleUser.password;
            user.RoleId = dAUser.SingleUser.RoleId;
            return user;
        }
    }
}

