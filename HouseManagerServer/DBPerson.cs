using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBPerson : IDBPerson
    {
        private static SqlCommand command = null;

        public Person GetPersonByID(int personid)
        {
            string sql = "select * from Person where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = personid;
            command.Parameters.Add(idParam);
            command.Prepare();
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string userName = reader["username"].ToString();
                string password = reader["pw"].ToString();
                string firstName = reader["firstname"].ToString();
                string lastName = reader["lastname"].ToString();
                string phone = reader["phone"].ToString();
                string email = reader["email"].ToString();
                DateTime dateOfBirth = DateTime.Parse(reader["dateofbirth"].ToString());
                reader.Close();
                return ObjectBuilder(id, userName, password, firstName, lastName, phone, email, dateOfBirth);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public Person GetPersonByUserName(string username)
        {
            string sql = "select * from Person where username = @username";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar, 50);
            usernameParam.Value = username;
            command.Parameters.Add(usernameParam);
            command.Prepare();
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string userName = reader["username"].ToString();
                string password = reader["pw"].ToString();
                string firstName = reader["firstname"].ToString();
                string lastName = reader["lastname"].ToString();
                string phone = reader["phone"].ToString();
                string email = reader["email"].ToString();
                DateTime dateOfBirth = DateTime.Parse(reader["dateofbirth"].ToString());
                reader.Close();
                return ObjectBuilder(id, userName, password, firstName, lastName, phone, email, dateOfBirth);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public bool InsertPerson(Person person)
        {
            try
            {
                string sql = "insert into Person (username, pw, firstname, lastname, phone, email, dateofbirth) values (@username, @pw, @firstname, @lastname, @phone, @email, @dateofbirth);";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar, 50);
                usernameParam.Value = person.UserName;
                SqlParameter pwParam = new SqlParameter("@pw", SqlDbType.VarChar, 1024);
                pwParam.Value = person.PassWord;
                SqlParameter firstnameParam = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
                firstnameParam.Value = person.FirstName;
                SqlParameter lastnameParam = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
                lastnameParam.Value = person.LastName;
                SqlParameter phoneParam = new SqlParameter("@phone", SqlDbType.VarChar, 50);
                phoneParam.Value = person.Phone;
                SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar, 50);
                emailParam.Value = person.Email;
                SqlParameter dateofbirthParam = new SqlParameter("@dateofbirth", SqlDbType.DateTime);
                dateofbirthParam.Value = person.DateOfBirth;
                command.Parameters.Add(usernameParam);
                command.Parameters.Add(pwParam);
                command.Parameters.Add(firstnameParam);
                command.Parameters.Add(lastnameParam);
                command.Parameters.Add(phoneParam);
                command.Parameters.Add(emailParam);
                command.Parameters.Add(dateofbirthParam);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdatePerson(Person person)
        {
            try
            {
                string sql = "update Person set username = @username, pw = @pw, phone = @phone, email = @email where id = @id";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar, 50);
                usernameParam.Value = person.UserName;
                SqlParameter pwParam = new SqlParameter("@pw", SqlDbType.VarChar, 1024);
                pwParam.Value = person.PassWord;
                SqlParameter phoneParam = new SqlParameter("@phone", SqlDbType.VarChar, 50);
                phoneParam.Value = person.Phone;
                SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar, 50);
                emailParam.Value = person.Email;
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
                idParam.Value = person.Id;
                command.Parameters.Add(usernameParam);
                command.Parameters.Add(pwParam);
                command.Parameters.Add(phoneParam);
                command.Parameters.Add(emailParam);
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

        private Person ObjectBuilder(int id, string userName, string password, string firstName, string lastName, string phone, string email, DateTime dateOfBirth) 
        {
            return new Person { Id = id, UserName = userName, PassWord = password, FirstName = firstName, LastName = lastName, Phone = phone, Email = email, DateOfBirth = dateOfBirth};
        }
    }
}
