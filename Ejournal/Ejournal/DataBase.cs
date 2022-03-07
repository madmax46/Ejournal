using System;
using System.Data.SqlClient;
using System.Data;

namespace Ejournal
{
    abstract class DataBase
    {
        public abstract SqlConnection Connection { get;set;}

        public abstract DataTable QuerySelect(string String_SELECT);

        public abstract void NonQuery(string String_Query);
       
    }
}
