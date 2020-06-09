using HouseManagerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    class ListService : IListService
    {
        private static readonly IDBSession dBSession = new DBSession();
        private static readonly IDBList dBList = new DBList();
        public int CreateList(MemoList list, string sessionid)
        {
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            return dBList.InsertList(new HouseManagerServer.MemoList { Title = list.Title, Description = list.Description, Person = person });
        }

        public bool DeleteList(MemoList list, string sessionid)
        {
            int personidsession = dBSession.GetSessionBySessionID(sessionid).Person.Id;
            int personidlist = dBList.GetMemoListById(list.Id).Person.Id;
            if (personidlist == personidsession)
            {
                return dBList.DeleteList(new HouseManagerServer.MemoList { Id = list.Id});
            }
            else
            {
                return false;
            }
        }

        public List<MemoList> GetAllList(string sessionid)
        {
            List<MemoList> list = new List<MemoList>();
            int personid = dBSession.GetSessionBySessionID(sessionid).Person.Id;
            List<HouseManagerServer.MemoList> serverList = dBList.GetAllListOfUser(personid);
            foreach (var item in serverList)
            {
                list.Add(new MemoList { Id = item.Id, Description = item.Description, Title = item.Title });
            }
            return list;
        }

        public bool UpdateList(MemoList list, string sessionid)
        {
            int personidsession = dBSession.GetSessionBySessionID(sessionid).Person.Id;
            int personidlist = dBList.GetMemoListById(list.Id).Person.Id;
            if (personidlist == personidsession)
            {
                return dBList.UpdateList(new HouseManagerServer.MemoList { Id = list.Id, Title = list.Title, Description = list.Description });
            }
            else
            {
                return false;
            }
        }
    }
}
