using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBList : IDBList
    {
        private static SqlCommand command = null;
        public bool DeleteList(MemoList list)
        {
            try
            {
                string sql = "delete from List where id = @id";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
                idParam.Value = list.Id;
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public List<MemoList> GetAllListOfUser(int personid)
        {
            List<MemoList> list = new List<MemoList>();
            string sql = "select * from List where personid = @personid";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = personid;
            command.Parameters.Add(personidParam);
            IDataReader reader = command.ExecuteReader();
            IDBPerson dbPerson = new DBPerson();

            while (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                Person person = dbPerson.GetPersonByID(int.Parse(reader["personid"].ToString()));
                string title = reader["title"].ToString();
                string descrtiption = reader["description"].ToString();
                list.Add(ObjectBuilder(id, person, title, descrtiption));
            }
            reader.Close();
            return list;
        }

        public MemoList GetMemoListById(int id)
        {
            string sql = "select * from List where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int listid = int.Parse(reader["id"].ToString());
                IDBPerson dbPerson = new DBPerson();
                Person person = dbPerson.GetPersonByID(int.Parse(reader["personid"].ToString()));
                string title = reader["title"].ToString();
                string descrtiption = reader["description"].ToString();
                reader.Close();
                return ObjectBuilder(listid, person, title, descrtiption);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public int InsertList(MemoList list)
        {
            string sql = "insert into List (personid, title, description) values (@personid, @title, @description); SELECT SCOPE_IDENTITY()";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter personidParam = new SqlParameter("@personid", SqlDbType.Int);
            personidParam.Value = list.Person.Id;
            SqlParameter titleParam = new SqlParameter("@title", SqlDbType.VarChar, 50);
            titleParam.Value = list.Title;
            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            descriptionParam.Value = list.Description;
            command.Parameters.Add(personidParam);
            command.Parameters.Add(titleParam);
            command.Parameters.Add(descriptionParam);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public bool UpdateList(MemoList list)
        {
            try
            {
                string sql = "update List set title = @title, description = @description where id = @id";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter titleParam = new SqlParameter("@title", SqlDbType.VarChar, 50);
                titleParam.Value = list.Title;
                SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 1000);
                descriptionParam.Value = list.Description;
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
                idParam.Value = list.Id;
                command.Parameters.Add(titleParam);
                command.Parameters.Add(descriptionParam);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        private MemoList ObjectBuilder(int id, Person person, string title, string description)
        {
            return new MemoList { Id = id, Person = person, Title = title, Description = description };
        }
    }
}
