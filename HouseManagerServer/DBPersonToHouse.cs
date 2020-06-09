using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBPersonToHouse : IDBPersonToHouse
    {
        private static SqlCommand command = null;

        public List<PersonToHouse> GetAllPersonInHouse(int houseid)
        {
            List<PersonToHouse> list = new List<PersonToHouse>();
            string sql = "select * from PersonToHouse where houseid = @houseid and moveoutdate is null";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(houseidParam);
            IDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                IDBPerson dbPerson = new DBPerson();
                Person person = dbPerson.GetPersonByID(int.Parse(reader["personid"].ToString()));
                bool isowner = (bool)reader["isowner"];
                DateTime moveindate = DateTime.Parse(reader["moveindate"].ToString());
                DateTime? moveoutdate = null;
                int hid = (int)reader["houseid"];
                list.Add(ObjectBuilder(person, isowner, moveindate, moveoutdate, hid));
            }
            reader.Close();
            return list;
        }

        public List<PersonToHouse> GetAllHouseForPerson(int personid)
        {
            List<PersonToHouse> list = new List<PersonToHouse>();
            string sql = "select * from PersonToHouse where personid = @personid and moveoutdate is null";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personid;
            command.Parameters.Add(personidParam);
            IDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                IDBPerson dbPerson = new DBPerson();
                Person person = dbPerson.GetPersonByID(int.Parse(reader["personid"].ToString()));
                bool isowner = (bool)reader["isowner"];
                DateTime moveindate = DateTime.Parse(reader["moveindate"].ToString());
                DateTime? moveoutdate = null;
                int hid = (int)reader["houseid"];
                list.Add(ObjectBuilder(person, isowner, moveindate, moveoutdate, hid));
            }
            reader.Close();
            return list;
        }

        public PersonToHouse GetPersonToHouseByBothId(int personid, int houseid)
        {
            string sql = "select * from PersonToHouse where personid = @personid and houseid = @houseid and moveoutdate is null";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personid;
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(personidParam);
            command.Parameters.Add(houseidParam);
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                IDBPerson dbPerson = new DBPerson();
                Person person = dbPerson.GetPersonByID(int.Parse(reader["personid"].ToString()));
                bool isowner = (bool)reader["isowner"];
                DateTime moveindate = DateTime.Parse(reader["moveindate"].ToString());
                DateTime? moveoutdate = null;
                int hid = (int)reader["houseid"];
                reader.Close();
                return ObjectBuilder(person, isowner, moveindate, moveoutdate, hid);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public bool JoinHouse(PersonToHouse personToHouse, int houseid)
        {
            string sql = "insert into PersonToHouse (personid, houseid, moveindate, isowner) values (@personid, @houseid, @moveindate, @isowner)";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personToHouse.Person.Id;
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            SqlParameter isownerParam = new SqlParameter("@isowner", SqlDbType.TinyInt);
            isownerParam.Value = personToHouse.IsOwner;
            SqlParameter moveindateParam = new SqlParameter("@moveindate", SqlDbType.DateTime);
            moveindateParam.Value = DateTime.Now;
            command.Parameters.Add(moveindateParam);
            command.Parameters.Add(personidParam);
            command.Parameters.Add(houseidParam);
            command.Parameters.Add(isownerParam);
            command.ExecuteNonQuery();
            return true;
        }

        public bool DeletePersonToHouseByHouseId(int houseid)
        {
            string sql = "delete from PersonToHouse where houseid = @houseid";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(houseidParam);
            command.ExecuteNonQuery();
            return true;
        }

        public bool LeaveHouse(PersonToHouse personToHouse, int houseid)
        {
            string sql = "update PersonToHouse set moveoutdate = @moveoutdate where personid = @personid and houseid = @houseid";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter moveoutdateParam = new SqlParameter("@moveoutdate", SqlDbType.DateTime);
            moveoutdateParam.Value = DateTime.Now;
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personToHouse.Person.Id;
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(moveoutdateParam);
            command.Parameters.Add(personidParam);
            command.Parameters.Add(houseidParam);
            command.ExecuteNonQuery();
            return true;
        }

        private PersonToHouse ObjectBuilder(Person person, bool isowner, DateTime moveindate, DateTime? moveoutdate, int houseid)
        {
            return new PersonToHouse { Person = person, IsOwner = isowner, MoveInDate = moveindate, MoveOutDate = moveoutdate, HouseId = houseid };
        }

        public bool Update(PersonToHouse personToHouse, int houseid)
        {
            string sql = "update PersonToHouse set moveoutdate = @moveoutdate where personid = @personid and houseid = @houseid";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter moveoutdateParam = new SqlParameter("@moveoutdate", SqlDbType.DateTime);
            moveoutdateParam.IsNullable = true;
            moveoutdateParam.Value = DBNull.Value;
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personToHouse.Person.Id;
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(moveoutdateParam);
            command.Parameters.Add(personidParam);
            command.Parameters.Add(houseidParam);
            command.ExecuteNonQuery();
            return true;
        }

        public PersonToHouse GetPersonToHouseByBothIdMovedOut(int personid, int houseid)
        {
            string sql = "select * from PersonToHouse where personid = @personid and houseid = @houseid and moveoutdate is not null";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personid;
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(personidParam);
            command.Parameters.Add(houseidParam);
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                IDBPerson dbPerson = new DBPerson();
                Person person = dbPerson.GetPersonByID(int.Parse(reader["personid"].ToString()));
                bool isowner = (bool)reader["isowner"];
                DateTime moveindate = DateTime.Parse(reader["moveindate"].ToString());
                DateTime? moveoutdate = DateTime.Parse(reader["moveoutdate"].ToString());
                int hid = (int)reader["houseid"];
                reader.Close();
                return ObjectBuilder(person, isowner, moveindate, moveoutdate, hid);
            }
            else
            {
                reader.Close();
                return null;
            }
        }
    }
}
