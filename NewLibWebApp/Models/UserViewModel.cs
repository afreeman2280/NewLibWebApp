using System.Collections.Generic;

namespace NewLibWebApp.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            SingleUser = new UserModel();
            AllUsers = new List<UserModel>();
        }
        public UserModel SingleUser { get; set; }
        public List<UserModel> AllUsers { get; set; }
    }
}
