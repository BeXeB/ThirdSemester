using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBPerson
    {
        bool InsertPerson(Person person);
        Person GetPersonByID(int personid);
        Person GetPersonByUserName(string username);
        bool UpdatePerson(Person person);
    }
}
