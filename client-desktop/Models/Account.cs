using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_desktop.Models
{
    public class Account : Person
    {
        public static Account GetInstace()
        {
            if (instance_ == null)
            {
                instance_ = new Account();
            }
            return instance_;
        }
        private static Account instance_;

        public string Session { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        private Account()
        {
            UserName = "Me :)";
        }

        public static void NullOut()
        {
            instance_ = null;
        }
    }
}
