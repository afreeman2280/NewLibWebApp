using System.ComponentModel.DataAnnotations;
using BLLLibary;
using CommonLib;

namespace NewLibWebApp.Utlities
{
    public class Valid: ValidationAttribute
    {
        private readonly bool _name;
        public Valid (bool name)
        {
            this._name = name;
        }
        public override bool IsValid(object value)
        {
            bool result;
            BLLUser u = new BLLUser();
            string x = value.ToString();

            result = u.userExist(x);
            return !result;
        }
    }
}
