using System;
using System.Collections.Generic;
using System.Linq;
using BLLibary;
using CommonLib;
using DALLib;

namespace BLLLibary
{

    public class BLLUser
    {
        
        DAUser user = new DAUser();
        public BLLUser()
        {

        }




        public void addUser(User users)
        {
            user.AddUser(users.Role, users.UserName, users.password);

            Console.WriteLine("New user added");
        }
        public void addUser(string userName, int role, string password)
        {
            user.AddUser(role, userName, password);


        }
        public User getUser(int id)
        {
            return (user.GetUser(id));
        }
        public void UpdateUser(User UpdateUser, int IdOfUserToBeUpdated)
        {

            user.updateUser(UpdateUser, IdOfUserToBeUpdated);

        }
        public bool userExist(int id)
        {
            List<User> userList = user.GetAllUser();

            return userList.Any(p => p.ID == id);
        }
        public void removeUser(int id)
        {
            user.RemoveUser(id);

        }
        public User getUserByUserName(string username)
        {
            return user.GetUserByUsername(username);
        }
        public bool Login(string password1, string password2)
        {
            return (password1 == password2);

        }
        public int getID(string userName, string password)
        {
            List<User> userList = user.GetAllUser();


            User userID = userList.FirstOrDefault(p => p.UserName == userName && p.password == password);

            return userID.ID;
        }
        public int getUserInfoForLogin(string userName, string password)
        {
            List<User> userList = user.GetAllUser();

            User loginUser = userList.FirstOrDefault(p => p.UserName == userName && p.password == password);

            return loginUser.Role;

        }
        public void updateUserName(int id, string newUserName)
        {
            user.UpdateUsername(id, newUserName);


        }

        public void updatePassword(int id, string password)
        {
            user.UpadatePassword(id, password);

        }
    
        public List<User> getAllUser()
        {
            return user.GetAllUser();
        }
      
    }
}
