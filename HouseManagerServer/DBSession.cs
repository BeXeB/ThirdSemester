using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBSession : IDBSession
    {
        private static SqlCommand command = null;
        public Session GetSessionBySessionID(string sessionid)
        {
            string sql = "select * from Session where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.VarChar, 100);
            idParam.Value = sessionid;
            command.Parameters.Add(idParam);
            command.Prepare();
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string id = reader["id"].ToString();
                IDBPerson dbPerson = new DBPerson();
                Person person = dbPerson.GetPersonByID(int.Parse(reader["personid"].ToString()));
                reader.Close();
                return ObjectBuilder(id, person);
            }
            else
            {
                reader.Close();
                throw new Exception("Empty Query(Session)");
            }
        }

        public bool InsertSession(Session session)
        {
            try
            {
                string sql = "insert into Session (id, personid) values (@id, @personid)";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.VarChar, 100);
                idParam.Value = session.SessionID;
                SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
                personidParam.Value = session.Person.Id;
                command.Parameters.Add(idParam);
                command.Parameters.Add(personidParam);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        private Session ObjectBuilder(String sessionid, Person person) 
        {
            return new Session { SessionID = sessionid, Person = person };
        }
    }
}
