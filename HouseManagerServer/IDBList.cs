using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBList
    {
        int InsertList(MemoList list);
        bool UpdateList(MemoList list);
        MemoList GetMemoListById(int id);
        List<MemoList> GetAllListOfUser(int personid);
        bool DeleteList(MemoList list);
    }
}