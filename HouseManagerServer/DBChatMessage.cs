using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace HouseManagerServer
{
    public class DBChatMessage : IDBChatMessage
    {
        private static SqlCommand command = null;

        public bool DeleteChatMessageByHouseId(int houseid)
        {
            try
            {
                string sql = "delete from ChatMessage where houseid = @houseid";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
                houseidParam.Value = houseid;
                command.Parameters.Add(houseidParam);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public List<ChatMessage> GetAllChatMessageInHouse(int houseid)
        {
            List<ChatMessage> list = new List<ChatMessage>();
            try
            {
                string sql = "select * from ChatMessage where houseid = @houseid";
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
                    int id = Convert.ToInt32(reader["id"]);
                    string message = reader["message"].ToString();
                    DateTime senddate = DateTime.Parse(reader["senddate"].ToString());
                    Person person = dBPerson.GetPersonByID(int.Parse(reader["senderid"].ToString()));
                    list.Add(ObjectBuilder(id, message, senddate, person));
                }
                reader.Close();
                return list;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public bool InsertMessage(ChatMessage message, int houseid)
        {
            try
            {
                string sql = "insert into ChatMessage (houseid, senderid, message, senddate) values (@houseid, @senderid, @message, @senddate)";
                command = DBConnection.GetDbConn().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Clear();
                SqlParameter houseidParam = new SqlParameter("@houseid", SqlDbType.Int);
                houseidParam.Value = houseid;
                SqlParameter senderidParam = new SqlParameter("@senderid", SqlDbType.Int);
                senderidParam.Value = message.Sender.Id;
                SqlParameter messageParam = new SqlParameter("@message", SqlDbType.VarChar, 255);
                messageParam.Value = message.Message;
                SqlParameter senddateParam = new SqlParameter("@senddate", SqlDbType.DateTime);
                senddateParam.Value = message.SendDate;
                command.Parameters.Add(houseidParam);
                command.Parameters.Add(senderidParam);
                command.Parameters.Add(messageParam);
                command.Parameters.Add(senddateParam);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        private ChatMessage ObjectBuilder(int id, string message, DateTime senddate, Person person)
        {
            return new ChatMessage { Id = id, Message = message, SendDate = senddate, Sender = new Person { UserName = person.UserName } };
        }
    }
}