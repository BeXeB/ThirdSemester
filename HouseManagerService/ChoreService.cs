using HouseManagerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    class ChoreService : IChoreService
    {
        private static readonly IDBChore dBChore = new DBChore();
        private static readonly IDBSession dBSession = new DBSession();
        public bool CreateChore(Chore chore, int houseid)
        {
            return dBChore.InsertChore(new HouseManagerServer.Chore { Status = 2, DueDate = chore.DueDate, Description = chore.Description }, houseid);
        }

        public List<Chore> GetChoresForHouse(int houseid)
        {
            List<Chore> list = new List<Chore>();
            List<HouseManagerServer.Chore> serverList = dBChore.GetChoresForHouse(houseid);

            foreach (var item in serverList)
            {
                Person person;
                if (item.Person == null)
                {
                    person = null;
                }
                else
                {
                    person = new Person { UserName = item.Person.UserName };
                }
                list.Add(new Chore { Id = item.Id, Status = item.Status, Description = item.Description, DueDate = item.DueDate, Person = person });
            }

            return list;
        }

        public bool JoinChore(Chore chore, string sessionid)
        {
            lock (dBChore)
            {
                HouseManagerServer.Chore ch = dBChore.GetChoreById(chore.Id);
                if (ch.Person == null)
                {
                    int personid = dBSession.GetSessionBySessionID(sessionid).Person.Id;
                    return dBChore.AssignPersonToChoreById(chore.Id, personid);
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateStatus(Chore chore, string sessionid)
        {
            HouseManagerServer.Chore ch = dBChore.GetChoreById(chore.Id);
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            if (ch.Person != null && ch.Person.Id == person.Id)
            {
                return dBChore.UpdateChoreStatus(new HouseManagerServer.Chore { Id = chore.Id, Status = chore.Status });
            }
            else
            {
                return false;
            }
        }
    }
}
