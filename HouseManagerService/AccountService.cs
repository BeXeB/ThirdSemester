using HouseManagerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    class AccountService : IAccountService
    {
        private static readonly IDBPerson dBPerson = new DBPerson();
        private static readonly IDBSession dBSession = new DBSession();

        public bool ChangePassword(string oldpassword, string newpassword, string sessionid)
        {
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            if (oldpassword.Equals(person.PassWord))
            {
                person.PassWord = newpassword;
                return dBPerson.UpdatePerson(person);
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAccount(string sessionid)
        {
            throw new NotImplementedException();
        }

        public Person GetAccountIfromation(string sessionid)
        {
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            return new Person { DateOfBirth = person.DateOfBirth, Email = person.Email, FirstName = person.FirstName, LastName = person.LastName, Phone = person.Phone, UserName = person.UserName };
        }

        public bool SetChanges(Person account, string sessionid)
        {
            if (dBPerson.GetPersonByUserName(account.UserName) == null)
            {
                HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
                person.UserName = account.UserName;
                person.Phone = account.Phone;
                person.Email = account.Email;
                return dBPerson.UpdatePerson(person);
            }
            else
            {
                return false;
            }
        }
    }
}
