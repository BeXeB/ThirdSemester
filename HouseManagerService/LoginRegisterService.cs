using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HouseManagerServer;

namespace HouseManagerService
{
    public class LoginRegisterService : ILoginRegisterService
    {
        private static readonly IDBPerson dBPerson = new DBPerson();
        private static readonly IDBSession dBSession = new DBSession();

        public string Login(Person person)
        {
            HouseManagerServer.Person user = dBPerson.GetPersonByUserName(person.UserName);
            if (user.PassWord.Equals(person.PassWord))
            {
                string sessionid = (user.UserName + DateTime.Now).Replace(" ", string.Empty);

                if (dBSession.InsertSession(new Session { SessionID = sessionid, Person = user }))
                {
                    return sessionid;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;            
            }
        }

        public string Register(Person person)
        {
            try
            {
                if (dBPerson.GetPersonByUserName(person.UserName) != null)
                {
                    return "Username taken";
                }
                if (person.DateOfBirth == null)
                {
                    person.DateOfBirth = DateTime.MinValue;
                }
                if (dBPerson.InsertPerson(new HouseManagerServer.Person { UserName = person.UserName, PassWord = person.PassWord, FirstName = person.FirstName, LastName = person.LastName, Email = person.Email, Phone = person.Phone, DateOfBirth = person.DateOfBirth }))
                {
                    return "Successful Registration";
                }
                else
                {
                    return "Registration Failed";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}