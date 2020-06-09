using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_web.Models
{
    public class AccountModel : PersonModel
    {
        public static AccountModel GetInstace()
        {
            if (instance_ == null)
            {
                instance_ = new AccountModel();
            }
            return instance_;
        }
        private static AccountModel instance_;

        public string Session { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        private AccountModel()
        {
            UserName = "Me :)";
        }

        public static void NullOut()
        {
            instance_ = null;
        }
    }
}
