using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;//.Net Framework 4+ only
using System.Data.SqlClient;

namespace markform
{
    public class SQLClass
    {
        private const string MainDB = @"Data Source=ACCOMEDIASVR\VOICEWARE;Initial Catalog=mttool2;Network Library=DBMSSOCN;Integrated Security=False;User ID=mttool;Password=sysMAN1@#$%;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string TestDB = @"Data Source=ACC-TEST-SQL\SQLEXPRESS;Initial Catalog=mttool2;Integrated Security=True;Network Library=DBMSSOCN";//@"Data Source=ACC-TEST-SQL\SQLEXPRESS;Initial Catalog=mttool2;Network Library=DBMSSOCN;Integrated Security=False;User ID=;Password=;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private CustomClass cf = new CustomClass();
        //public string tblEnservioAllocation = "dbo.tblEnservioAllocation";
        private static string conStr = TestDB;
        private SqlConnection conn = new SqlConnection();
        private DataTable dtbl;
        private int affected_rows;
        private List<string> parameters;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private string squery;
        private bool IsSQLDependency;
        public bool isDbChange = false;
        public bool LogExceptions = true;
        

        public delegate void NewMessage();
        public event NewMessage OnNewMessage;

        public SQLClass()
        {
            try
            {
                SqlClientPermission perm = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                perm.Demand();
            }
            catch
            {
                throw new ApplicationException("No permission");
            }
            // Stop an existing services on this connection string
            // just be sure
            //SQLDependency(false);

            // Start the dependency
            // User must have SUBSCRIBE QUERY NOTIFICATIONS permission
            // Database must also have SSB enabled
            // ALTER DATABASE Chatter SET ENABLE_BROKER
            //SQLDependency();

            conn = new SqlConnection(conStr);
            dtbl = new DataTable();
            parameters = new List<string>();
            try
            {
                conn.Open();
                Console.Write("Connection success");
                conn.Close();
            }
            catch (SqlException e)
            {
                string msg = (e.Number == -2)?"Connection timeout occured.":e.Message;
                cf.Debug(e, true, msg);
                //Debug(msg+". {0}");
                Console.Write(e.ToString());
            }
        }

        public void SQLDependency(bool b = true)
        {
            try
            {
                if (b)
                {
                    SqlDependency.Start(conStr);
                }
                else
                {
                    SqlDependency.Stop(conStr);
                }
                this.IsSQLDependency = b;
            }
            catch (SqlException e)
            {
                string msg = (e.Number == -2) ? "Connection timeout occured." : e.Message;
                cf.Debug(e, true, msg);
                //Debug(msg + ". {0}");
                
            }
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~SQLClass()
        {
            // Stop the dependency before exiting
            SqlDependency.Stop(conStr);
        }
        public void CloseConnection()
        {
            conn.Close();
        }
        private void Init(string Query, string[] bindings = null)
        {
            // No connection with database? make connection
            if (conn.State.ToString() != "Open")
            {
                conn.Open();
            }

            // Automatically disposes the MySQLcommand instance
           using (cmd = new SqlCommand(Query, conn))
            {
                // 
                bind(bindings);

                // Prevents SQL injection
                if (parameters.Count > 0)
                {
                    parameters.ForEach(delegate (string parameter)
                    {
                        string[] sparameters = parameter.ToString().Split('\x7F');
                        cmd.Parameters.AddWithValue(sparameters[0], sparameters[1]);
                    });
                }
                this.isDbChange = false;
                this.squery = Query.ToLower();
                if (squery.Contains("select"))
                {
                    if (IsSQLDependency)
                    {
                        IniSqlDependency();
                    }
                    this.dtbl = execDatatable();
                }
                if (squery.Contains("delete") || squery.Contains("update") || squery.Contains("insert"))
                {
                    this.affected_rows = execNonquery();
                }

                // Clear de parameters, 
                this.parameters.Clear();
            }
            conn.Close();
        }
        public void bind(string field, string value)
        {
            parameters.Add("@" + field + "\x7F" + value);
        }

        public void bind(string[] fields)
        {
            if (fields != null)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    bind(fields[i], fields[i + 1]);
                    i += 1;
                }
            }
        }
        // Example:
        // qBind(new string[] { "12", "John" });
        // nQuery("SELECT * FROM User WHERE ID=@0 AND Name=@1");
        /// <summary>
        /// Bind multiple fields/values without identifier.
        /// </summary>
        /// <param name="fields"></param>
        public void qBind(string[] fields)
        {
            if (fields != null)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    bind(i.ToString(), fields[i]);
                }
            }
        }
        private DataTable execDatatable()
        {
            DataTable dt = new DataTable();
            try
            {
                reader = cmd.ExecuteReader();

                dt.Load(reader);
            }
            catch (SqlException my)
            {
                string exception = "Exception : " + my.Message.ToString() + "\n\r SQL Query : \n\r" + squery;
                cf.Debug(my,true,"",squery);
                //Debug(exception);
                //throw new Exception("Uncaught MYSQL Exception", my);
                //MessageBox.Show(exception, "Uncaught MYSQL Exception");

                
            }

            return dt;
        }
        private int execNonquery()
        {

            int affected = 0;

            try
            {
                affected = cmd.ExecuteNonQuery();
            }
            catch (SqlException my)
            {
                string exception = "Exception : " + my.Message.ToString() + "\n\r SQL Query : \n\r" + squery;
                if (my.Message.ToString() != "The query notification subscription message is invalid.")
                {
                    cf.Debug(my, true, "",squery);
                    //Debug(exception);
                    //throw new Exception("Uncaught MYSQL Exception", my);
                }
                //MessageBox.Show(exception, "Uncaught MYSQL Exception");

                
            }

            return affected;
        }
        public DataTable table(string table, string[] bindings = null)
        {
            Init("SELECT * FROM " + table, bindings);
            return this.dtbl;
        }

        public List<object> table(string table, Type t)
        {
            return new List<object>();
        }
        public DataTable query(string query, string[] bindings = null)
        {
            Init(query, bindings);
            return this.dtbl;
        }

        public int nQuery(string query, string[] bindings = null)
        {
            Init(query, bindings);
            return this.affected_rows;
        }
        public string single(string query, string[] bindings = null)
        {
            Init(query, bindings);

            if (dtbl.Rows.Count > 0)
            {
                return dtbl.Rows[0][0].ToString();
            }

            return string.Empty;
        }
        public string[] row(string query, string[] bindings = null)
        {
            Init(query, bindings);

            string[] row = new string[dtbl.Columns.Count];

            if (dtbl.Rows.Count > 0)
                for (int i = 0; i++ < dtbl.Columns.Count; row[i - 1] = dtbl.Rows[0][i - 1].ToString()) ;

            return row;
        }
        public List<string> column(string query, string[] bindings = null)
        {
            Init(query, bindings);

            List<string> column = new List<string>();

            for (int i = 0; i++ < dtbl.Rows.Count; column.Add(dtbl.Rows[i - 1][0].ToString())) ;

            return column;
        }
        //public void Debug(string error)
        //{
        //    Console.Write(error + "/n/r");
        //    if (LogExceptions)
        //    {
        //        this.WriteToFile(error + ". {0}");
        //    }
        //}

        private void IniSqlDependency()
        {
            // Clear any existing notifications
            cmd.Notification = null;

            // Create the dependency for this command
            SqlDependency dependency = new SqlDependency(cmd);

            // Add the event handler
            dependency.OnChange += new OnChangeEventHandler(OnChange);
        }
        /// <summary>
        /// Handler for the SqlDependency OnChange event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnChange(object sender, SqlNotificationEventArgs e)
        {
            //'Console.writeline("wow2");
            SqlDependency dependency = sender as SqlDependency;

            // Notices are only a one shot deal
            // so remove the existing one so a new 
            // one can be added
            dependency.OnChange -= OnChange;
            // Fire the event
            if (OnNewMessage != null)
            {
                OnNewMessage();
            }
            //if (!isDbChange)
            //{
            //    this.isDbChange = true;
            //}

        }
        private void WriteToFile(string text)
        {
            //string path = Application.StartupPath + "ARIKLSVLOG.txt";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SQLLOG.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
            }
        }

    }
}
