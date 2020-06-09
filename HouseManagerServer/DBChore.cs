using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBChore : IDBChore
    {
        private static SqlCommand command = null;

        public bool AssignPersonToChoreById(int choreid, int personid)
        {
            string sql = "update Chore set personid = @personid where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = choreid;
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personid;
            command.Parameters.Add(idParam);
            command.Parameters.Add(personidParam);
            command.ExecuteNonQuery();
            return true;
        }

        public bool DeleteChoreByHouseId(int houseid)
        {
            string sql = "delete from Chore where houseid = @houseid";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(houseidParam);
            command.ExecuteNonQuery();
            return true;
        }

        public Chore GetChoreById(int id)
        {
            string sql = "select * from Chore where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            IDataReader reader = command.ExecuteReader();
            IDBPerson dBPerson = new DBPerson();

            if (reader.Read())
            {
                int choreid = int.Parse(reader["id"].ToString());
                byte status = Convert.ToByte(reader["status"]);
                string description = reader["description"].ToString();
                DateTime duedate = DateTime.Parse(reader["duedate"].ToString());
                object personid = reader["personid"];
                Person person;
                if (reader["personid"] == DBNull.Value)
                {
                    person = null;
                }
                else
                {
                    person = dBPerson.GetPersonByID(Convert.ToInt32(reader["personid"]));
                }
                reader.Close();
                return ObjectBuilder(choreid, status, description, duedate, person);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public List<Chore> GetChoresForHouse(int houseid)
        {
            List<Chore> list = new List<Chore>();
            string sql = "select * from Chore where houseid = @houseid";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            command.Parameters.Add(houseidParam);
            IDataReader reader = command.ExecuteReader();
            IDBPerson dBPerson = new DBPerson();

            while (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                byte status = Convert.ToByte(reader["status"]);
                string description = reader["description"].ToString();
                DateTime duedate = DateTime.Parse(reader["duedate"].ToString());
                Person person;
                if (reader["personid"] == DBNull.Value)
                {
                    person = null;
                }
                else
                {
                    person = dBPerson.GetPersonByID(Convert.ToInt32(reader["personid"]));
                }
                list.Add(ObjectBuilder(id, status, description, duedate, person));
            }
            reader.Close();
            return list;
        }

        public bool InsertChore(Chore chore, int houseid)
        {
            string sql = "insert into Chore (houseid, status, duedate, description) values (@houseid, @status, @duedate, @description)";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
            houseidParam.Value = houseid;
            SqlParameter statusParam = new SqlParameter("@status", SqlDbType.TinyInt);
            statusParam.Value = chore.Status;
            SqlParameter duedateParam = new SqlParameter("@duedate", SqlDbType.DateTime);
            duedateParam.Value = chore.DueDate;
            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            descriptionParam.Value = chore.Description;
            command.Parameters.Add(houseidParam);
            command.Parameters.Add(statusParam);
            command.Parameters.Add(duedateParam);
            command.Parameters.Add(descriptionParam);
            command.ExecuteNonQuery();
            return true;
        }

        public bool UpdateChoreStatus(Chore chore)
        {
            string sql = "update Chore set status = @status where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = chore.Id;
            SqlParameter statusParam = new SqlParameter("@status", SqlDbType.TinyInt);
            statusParam.Value = chore.Status;
            command.Parameters.Add(idParam);
            command.Parameters.Add(statusParam);
            command.ExecuteNonQuery();
            return true;
        }

        private Chore ObjectBuilder(int id, byte status, string description, DateTime duedate, Person person)
        {
            return new Chore { Id = id, Status = status, Description = description, DueDate = duedate, Person = person };
        }
    }
}
