using System;
using System.Collections.Generic;
using System.Linq;
using BLLibary;
using DALLib;

namespace BLLLibary
{
   public enum Roles
    {
        guest,
        administrator,
        librarian,
        patron
    }
    public class BLLUser
    {
      public  int ID;
      public  string UserName { get; set; }
      public  string password { get; set; }
      public  int RoleId { get; set; }
       public Roles Role { get; set; }
      //  BLLUser User = new BLLUser();
        List<BLLUser> bLLUsers = new List<BLLUser>();
        List<DAUser> daUsers = new List<DAUser>();
        DAUser user = new DAUser();
    public BLLUser()
        {
            ID = 0;
            UserName = string.Empty;
            password = string.Empty;
            Role =  Roles.guest;
        }
    public BLLUser(int iD, string userName, Roles role,string password)
        {
           this.ID = iD;
            this.UserName = userName;
            this.password = password;
           this.Role = role;
        }

        public BLLUser(int role, string userName, string password)
        {
            RoleId = role;
            UserName = userName;
            this.password = password;
        }

        public void addUser(BLLUser users)
        {
            int roleID = (int)user.Role;
            user.AddUser(users.RoleId, users.UserName, users.password);

            Console.WriteLine("New user added");
        }
        public void addUser(string userName,int role,string password)
        {
            bLLUsers.Add(new BLLUser(role,userName,password));
           user.AddUser(role, userName, password);


        }
        public BLLUser getUser(int id)
        {
            return Map(user.GetUser(id));
        }
        public void UpdateUser(BLLUser UpdateUser, int IdOfUserToBeUpdated)
        {

            DAUser dABook = Map(UpdateUser);
            user.updateUser(dABook, IdOfUserToBeUpdated);

        }
        public bool userExist(int id)
        {
            List<BLLUser> userList = Map(user.GetAllUser());

            return userList.Any(p=> p.ID == id);
        }
        public void removeUser(int id)
        {
            user.RemoveUser(id);

        }
        public BLLUser getUserByUserName(string username)
        {
            return Map(user.GetUserByUsername(username));
        }
        public bool Login(string password1,string password2)
        {
            return (password1 == password2);

        }
        public int getID(string userName, string password)
        {
            List<BLLUser> userList = Map(user.GetAllUser());


            BLLUser userID = userList.FirstOrDefault(p => p.UserName == userName && p.password == password);

            return userID.ID;
        }
        public int getUserInfoForLogin(string userName, string password)
        {
            List<BLLUser> userList = Map(user.GetAllUser());

            BLLUser loginUser = userList.FirstOrDefault(p => p.UserName == userName && p.password == password);

            return loginUser.RoleId;

        }
        public void updateUserName (int id,string newUserName)
        {
            user.UpdateUsername(id,newUserName);    

           
        }

        public void updatePassword(int id, string password)
        {
            user.UpadatePassword(id,password);

        }
        public void printSingleUser(int id)
        {
            BLLRole role = new BLLRole();
            user = user.GetUser(id);
            if (user != null)
            {
                BLLUser bLLUser = Map(user);
                Console.WriteLine("User ID: " + bLLUser.ID);
                Console.WriteLine("Username: " + bLLUser.UserName);
                Console.WriteLine("User Role: " + role.getRole(bLLUser.RoleId));
            }
            else
            {
                Console.WriteLine("User does not exist ");
            }

        }
        public List<BLLUser> getAllUser()
        {
            return Map(user.GetAllUser());
        }
        public void printAllUsers()
        {
            BLLRole role = new BLLRole();
            List<BLLUser> userList = Map(user.GetAllUser());
            foreach (BLLUser user in userList)
            {
                Console.WriteLine("User ID: " + user.ID);
                Console.WriteLine("Username: " + user.UserName);
                Console.WriteLine("User Role: " + role.getRole(user.RoleId));
            }
        }
        public List<BLLUser> Map(List<DAUser> dAUsers)
        {
            List<BLLUser> userList = new List<BLLUser>();   
            
            foreach(DAUser dAUser in dAUsers)
            {
                BLLUser user = new BLLUser();
                user.ID = dAUser.ID;
                user.UserName = dAUser.UserName;
                user.password = dAUser.password;
                user.RoleId = dAUser.Role;
                userList.Add(user);
            }
            return userList;    
        }
        public BLLUser Map(DAUser dAUser)
        {
            BLLUser user = new BLLUser();
            user.ID = dAUser.ID;
            user.UserName = dAUser.UserName;
            user.password = dAUser.password;
            user.RoleId = dAUser.Role;
            return user;
        }
        public DAUser Map(BLLUser dAUser)
        {
            DAUser user = new DAUser();
            user.ID = dAUser.ID;
            user.UserName = dAUser.UserName;
            user.password = dAUser.password;
            user.Role = dAUser.RoleId;
            return user;
        }
    }
}
