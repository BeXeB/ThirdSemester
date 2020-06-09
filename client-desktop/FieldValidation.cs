using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace client_desktop
{
    static class FieldValidation
    {
        public static bool ValidateEmail(string email)
        {
            var regex = new Regex(@"^\S+@\S+\.\S+$");
            if (!regex.IsMatch(email))
            {
                return false;
            }
            return true;
        }

        public static bool ValidatePassword(string password)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$");
            if (!regex.IsMatch(password))
            {
                return false;
            }
            return true;
        }

        public static bool ValidatePhone(string phone)
        {
            var regex = new Regex(@"^[0-9\-\+]{9,15}$");
            if (!regex.IsMatch(phone))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateInt(string no)
        {
            return int.TryParse(no, out _);
        }
    }
}
