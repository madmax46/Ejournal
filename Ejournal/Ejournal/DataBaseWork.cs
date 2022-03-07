using System;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace Ejournal
{
    class DataBaseWork: DataBase
    {
        public static SqlConnection connection;

        public override SqlConnection Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
            }
        }

        public DataBaseWork(string connection)
        {
            Connection = new SqlConnection(connection);
        }

        public override DataTable QuerySelect(string String_SELECT)
        {   
            DataTable dt = new DataTable();

            //try
            //{
                Connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(String_SELECT, Connection);
                Connection.Close();
                dataAdapter.Fill(dt);
            //}
            //catch
            //{
            //    Connection.Close();
            //}
            return dt;
        }

        public override void NonQuery(string String_Query)
        {
            
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(String_Query, Connection);
                command.ExecuteNonQuery();
                Connection.Close();
            }
            catch
            {
                Connection.Close();
            }
        }

    }
}
