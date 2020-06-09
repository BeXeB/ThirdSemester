using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBChore
    {
        bool InsertChore(Chore chore, int houseid);
        List<Chore> GetChoresForHouse(int houseid);
        Chore GetChoreById(int id);
        bool AssignPersonToChoreById(int choreid, int personid);
        bool DeleteChoreByHouseId(int houseid);
        bool UpdateChoreStatus(Chore chore);
    }
}