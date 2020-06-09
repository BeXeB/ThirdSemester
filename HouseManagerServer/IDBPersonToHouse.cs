using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBPersonToHouse
    {
        bool JoinHouse(PersonToHouse personToHouse, int houseid);
        bool Update(PersonToHouse personToHouse, int houseid);
        bool DeletePersonToHouseByHouseId(int houseid);
        bool LeaveHouse(PersonToHouse personToHouse, int houseid);
        List<PersonToHouse> GetAllPersonInHouse(int houseid);
        List<PersonToHouse> GetAllHouseForPerson(int personid);
        PersonToHouse GetPersonToHouseByBothId(int personid, int houseid);
        PersonToHouse GetPersonToHouseByBothIdMovedOut(int personid, int houseid);
    }
}