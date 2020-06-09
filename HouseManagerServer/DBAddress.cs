using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBAddress : IDBAddress
    {
        private static SqlCommand command = null;
        public int CreateAddress(Address address)
        {
            string sql = "insert into Address (zipcode, city, street, houseno, floorno, doorno) values (@zipcode, @city, @street, @houseno, @floorno, @doorno); SELECT SCOPE_IDENTITY()";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter zipcodeParam = new SqlParameter("@zipcode", SqlDbType.Int);
            zipcodeParam.Value = address.ZipCode;
            SqlParameter cityParam = new SqlParameter("@city", SqlDbType.VarChar, 50);
            cityParam.Value = address.City;
            SqlParameter streetParam = new SqlParameter("@street", SqlDbType.VarChar, 50);
            streetParam.Value = address.Street;
            SqlParameter housenoParam = new SqlParameter("@houseno", SqlDbType.VarChar, 10);
            housenoParam.Value = address.HouseNo;
            SqlParameter floornoParam = new SqlParameter("@floorno", SqlDbType.SmallInt);
            floornoParam.Value = address.FloorNo;
            SqlParameter doornoParam = new SqlParameter("@doorno", SqlDbType.VarChar, 10);
            doornoParam.Value = address.DoorNo;
            command.Parameters.Add(zipcodeParam);
            command.Parameters.Add(cityParam);
            command.Parameters.Add(streetParam);
            command.Parameters.Add(housenoParam);
            command.Parameters.Add(floornoParam);
            command.Parameters.Add(doornoParam);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public bool DeleteAddress(Address address)
        {
            string sql = "delete from Address where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = address.Id;
            command.Parameters.Add(idParam);
            command.ExecuteNonQuery();
            return true;
        }

        public Address GetAddressById(int id)
        {
            string sql = "select * from Address where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int addressid = int.Parse(reader["id"].ToString());
                int zipcode = int.Parse(reader["zipcode"].ToString());
                string city = reader["city"].ToString();
                string street = reader["street"].ToString();
                string houseno = reader["houseno"].ToString();
                short floorno = short.Parse(reader["floorno"].ToString());
                string doorno = reader["doorno"].ToString();
                reader.Close();
                return ObjectBuilder(addressid, zipcode, city, street, houseno, floorno, doorno);
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public bool UpdateAddress(Address address)
        {
            string sql = "update Address set zipcode = @zipcode, city = @city, street = @street, houseno = @houseno, floorno = @floorno, doorno = @doorno where id = @id";
            command = DBConnection.GetDbConn().CreateCommand();
            command.CommandText = sql;
            command.Parameters.Clear();
            SqlParameter zipcodeParam = new SqlParameter("@zipcode", SqlDbType.Int);
            zipcodeParam.Value = address.ZipCode;
            SqlParameter cityParam = new SqlParameter("@city", SqlDbType.VarChar, 50);
            cityParam.Value = address.City;
            SqlParameter streetParam = new SqlParameter("@street", SqlDbType.VarChar, 50);
            streetParam.Value = address.Street;
            SqlParameter housenoParam = new SqlParameter("@houseno", SqlDbType.VarChar, 10);
            housenoParam.Value = address.HouseNo;
            SqlParameter floornoParam = new SqlParameter("@floorno", SqlDbType.SmallInt);
            floornoParam.Value = address.FloorNo;
            SqlParameter doornoParam = new SqlParameter("@doorno", SqlDbType.VarChar, 10);
            doornoParam.Value = address.DoorNo;
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = address.Id;
            command.Parameters.Add(zipcodeParam);
            command.Parameters.Add(cityParam);
            command.Parameters.Add(streetParam);
            command.Parameters.Add(housenoParam);
            command.Parameters.Add(floornoParam);
            command.Parameters.Add(doornoParam);
            command.Parameters.Add(idParam);
            command.ExecuteNonQuery();
            return true;
        }

        private Address ObjectBuilder(int id, int zipcode, string city, string street, string houseno, short floorno, string doorno)
        {
            return new Address { Id = id, ZipCode = zipcode, City = city, Street = street, HouseNo = houseno, FloorNo = floorno, DoorNo = doorno };
        }
    }
}
