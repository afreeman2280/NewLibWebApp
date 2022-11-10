using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NewLibWebApp.Models
{
    public class UserModel
    {
       public int ID;
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "The User Name is required")]
        public   string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "The Password is required")]
        public string password { get; set; }
        [Display(Name = "User Role")]
        [Required(ErrorMessage = "The User Role is required")]

        public int RoleId { get; set; }
    }
}
