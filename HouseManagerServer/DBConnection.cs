using System.Data.SqlClient;

namespace HouseManagerServer
{
    class DBConnection
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-RQQKGKJ;Initial Catalog=House_Manager;Integrated Security=True;MultipleActiveResultSets=true";
        public static readonly SqlConnection dbconn = new SqlConnection(connectionString);

        private static void Open()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
            {
                dbconn.Open();
            }
        }

        public static void Close()
        {
            dbconn.Close();
        }

        public static SqlConnection GetDbConn()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
            {
                Open();
            }
            return dbconn;
        }
    }
}