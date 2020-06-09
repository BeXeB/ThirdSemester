using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBSession
    {
        bool InsertSession(Session session);
        Session GetSessionBySessionID(string sessionid);
    }
}