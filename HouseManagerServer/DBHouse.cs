using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBHouse : IDBHouse
    {
        private static SqlCommand command = null;
        public int InsertHouse(House house)
        {
            string sql = "insert into House (addressid, name, invitecode) values (@addressid, @name, @invitecode); SELECT SCOPE_IDENTITY()";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter addressidParam = new SqlParameter("@addressid", SqlDbType.Int);
            addressidParam.Value = house.Address.Id;
            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            nameParam.Value = house.Name;
            SqlParameter invitecodeParam = new SqlParameter("@invitecode", SqlDbType.VarChar, 200);
            invitecodeParam.Value = house.InviteCode;
            command.Parameters.Add(addressidParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(invitecodeParam);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public bool DeleteHouse(House house)
        {
            try
            {
                string sql = "delete from House where id = @id";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
                idParam.Value = house.Id;
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

        public bool UpdateHouse(House house)
        {
            string sql = "update House set name = @name where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            nameParam.Value = house.Name;
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = house.Id;
            command.Parameters.Add(nameParam);
            command.Parameters.Add(idParam);
            command.ExecuteNonQuery();
            return true;
        }

        public House GetHouseByInvitecode(string invitecode)
        {
            string sql = "select * from House where invitecode = @invitecode";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter invitecodeParam = new SqlParameter("@invitecode", SqlDbType.VarChar, 200);
            invitecodeParam.Value = invitecode;
            command.Parameters.Add(invitecodeParam);
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                int id = (int)reader["id"];
                string name = (string)reader["name"];
                int addressid = (int)reader["addressid"];
                reader.Close();
                return ObjectBuilder(id, name, invitecode, addressid);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public House GetHouseById(int id)
        {
            string sql = "select * from House where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            IDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string invitecode = (string)reader["invitecode"];
                string name = (string)reader["name"];
                int addressid = (int)reader["addressid"];
                reader.Close();
                return ObjectBuilder(id, name, invitecode, addressid);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        private House ObjectBuilder(int id, string name, string invitecode, int addressid)
        {
            return new House { Id = id, Name = name, InviteCode = invitecode, Address = new Address { Id = addressid } };
        }
    }
}
