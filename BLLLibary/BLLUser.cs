using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            user.AddUser(users.Role, users.UserName,GetHash(users.password));

            Console.WriteLine("New user added");
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
        public bool userExist(string id)
        {
            bool result;
            List<User> userList = user.GetAllUser();

            result= userList.Any(p => p.UserName == id);
            return result;
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
            return (GetHash(password1) == GetHash(password2));

        }
        public int getID(string userName, string password)
        {
            List<User> userList = user.GetAllUser();


            User userID = userList.FirstOrDefault(p => p.UserName == userName && GetHash(p.password) ==GetHash(password));

            return userID.ID;
        }
        public int getUserInfoForLogin(string userName, string password)
        {
            List<User> userList = user.GetAllUser();

            User loginUser = userList.FirstOrDefault(p => p.UserName == userName && GetHash(p.password) == GetHash(password));

            return loginUser.Role;

        }
        public string GetHash(string pwd)//returns 32 character long hash password
        {
            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();//Helps to generate the Hash
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pwd);
                byte[] hashBytes = md5.ComputeHash(inputBytes);//converted to a computed hash and saved in hashBytes
                StringBuilder newPwd = new StringBuilder();//a mutable string of characters
                for (int index = 0; index < hashBytes.Length; index++)
                {
                    newPwd.Append(hashBytes[index].ToString("X2"));//formats each character into a hexadecimal string
                }
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buffer = new byte[1024];

                rng.GetBytes(buffer);
                string salt = BitConverter.ToString(buffer);
                var saltedPassword = newPwd.ToString() + salt;
                return newPwd.ToString();
            }
            catch (Exception e)
            {
                string _ErrorLogFileLocation = @"C:\Users\admin2\Desktop\\ErrorLogs3.txt";
                using (StreamWriter lwriter = new StreamWriter(_ErrorLogFileLocation, true))
                {
                    lwriter.WriteLine(e.Message);

                }
            }
            return null;
        }
        public void updateUserName(int id, string newUserName)
        {
            user.UpdateUsername(id, newUserName);


        }

        public void updatePassword(int id, string password)
        {
            user.UpadatePassword(id, GetHash(password));

        }
    
        public List<User> getAllUser()
        {
            return user.GetAllUser();
        }
      
    }
}
