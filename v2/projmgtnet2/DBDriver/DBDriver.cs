using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PMT
{
    /// <summary>
    /// Summary description for DBDriver.
    /// </summary>
    public class DBDriver
    {
        //private string connString;
        //private string user;
        //private string pwd;
        private MySqlConnection db;
        private MySqlCommand cmd;
        private string query;
        private MySqlDataAdapter da;
        private MySqlDataReader dr;

        /// <summary>
        /// Query attribute
        /// </summary>
        public string Query
        {
            get{return query;}
            set
            {
                //to be added:query verification code
                // change sql param escape char to mysql param escape char
                query = value.Replace('@', '?'); 
                cmd = new MySqlCommand(query,db);
            }
        }

        private string ConnectionString
        {
            get {   return ConfigurationSettings.AppSettings["ConnectionString"];   }
        }

        /// <summary>
        /// DBDriver initializer
        /// </summary>
        public DBDriver()
        {
            //set username and password
            //user="softeng4";
            //pwd="n3wF4ngl3d";
            //set the connection string
            //connString="Data Source=localhost;Database=softeng4;User ID='"+user+"';Password='"+pwd+"';";
            //open the connection  
            db=new MySqlConnection(this.ConnectionString);
        }
        /// <summary>
        /// destructor for the garbage collector, to make sure the DB connection is
        /// closed before the object instance reference is lost
        /// </summary>
        ~DBDriver()
        {
            db.Close();
        }

        /// <summary>
        /// closes the database instance
        /// </summary>
        public void close()
        {
            db.Close();
        }

        /// <summary>
        /// creates a data adapter
        /// </summary>
        /// <returns>reference to the created adaptor</returns>
        public MySqlDataAdapter createAdapter()
        {
            db.Open();
            da=new MySqlDataAdapter(cmd);
            db.Close();
            return da;
        }

        /// <summary>
        /// Creates a data reader. you MUST use the close() function when done using the reader
        /// </summary>
        /// <returns>reference to the created data reader</returns>
        public MySqlDataReader createReader()
        {
            db.Open();
            dr=cmd.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// execute a query that returns the number of rows affected, and not data
        /// </summary>
        public int nonQuery()
        {
            db.Open();
            int ret=cmd.ExecuteNonQuery();
            db.Close();
            return ret;
        }

        /// <summary>
        /// execute a command that returns an integer value(eg, count(*))
        /// </summary>
        /// <returns>count returned from DB Query</returns>
        public object scalar()
        {
            db.Open();
            object ret=cmd.ExecuteScalar();
            db.Close();
            
            return ret;
        }

        /// <summary>
        /// create a new parameter in the query
        /// the parameter string must exist in the query already
        /// </summary>
        /// <param name="pName">the name of the parameter</param>
        /// <param name="val">the integer value to input into the parameter</param>
        public void addParam(string pName, int val)
        {
            // replace sql param escape char with mysql param escape char
            pName = pName.Replace('@', '?');
            MySqlParameter param = new MySqlParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = pName;
            param.Value = val;
            cmd.Parameters.Add(param);
        }

        /// <summary>
        /// create a new parameter in the query
        /// the parameter string must exist in the query already
        /// </summary>
        /// <param name="pName">the name of the parameter</param>
        /// <param name="val">the string value to input into the parameter</param>
        public void addParam(string pName, string val)
        {
            // replace sql param escape char with mysql param escape char
            pName = pName.Replace('@', '?');
            MySqlParameter param = new MySqlParameter();
            param.DbType = DbType.String;
            param.ParameterName = pName;
            param.Value = val;
            cmd.Parameters.Add(param);
        }
    }
}