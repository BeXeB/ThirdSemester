using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBHouse
    {
        int InsertHouse(House house);
        bool UpdateHouse(House house);
        bool DeleteHouse(House house);
        House GetHouseByInvitecode(string invitecode);
        House GetHouseById(int id);
    }
}