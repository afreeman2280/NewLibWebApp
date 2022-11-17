using System.ComponentModel.DataAnnotations;
using NewLibWebApp.Utlities;
using System.Xml.Linq;

namespace NewLibWebApp.Models
{
    public class UserModel
    {
       public int ID { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "The User Name is required")]
        [Valid(name:true,ErrorMessage ="Username already exist")]
        public  string UserName { get; set; }
        [Display(Name = "Password")]
      //  [Range(8,15,ErrorMessage = "Length Should be between 8 and 15 Charcters")]
        [RegularExpression("[A-Za-z\\d!@#$%^&*()_+]{7,19}",ErrorMessage ="Password must contain at least 1 Upper and Lower case Character and 1 Special Character")]
        [Required(ErrorMessage = "The Password is required")]
        public string password { get; set; }
        [Display(Name = "User Role")]
        [Required(ErrorMessage = "The User Role is required")]

        public int RoleId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    }
}
