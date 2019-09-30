using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace markDBOClass
{
    public class DboClass
    {
        //public string tblEnservioAllocation = "dbo.tblEnservioAllocation";
        //Data Source=ACCOMEDIASVR\VOICEWARE;Initial Catalog=mttool2;Integrated Security=False;User ID=mttool;Password=sysMAN1@#$%;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private static string conStr = @"Data Source=ACCOMEDIASVR\VOICEWARE;Initial Catalog=mttool2;Integrated Security=False;User ID=mttool;Password=sysMAN1@#$%;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection conn = new SqlConnection();
        private DataTable dtbl;
        private int affected_rows;
        private List<string> parameters;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private string squery;
        public bool isDbChange = false;

        public delegate void NewMessage();
        public event NewMessage OnNewMessage;

        public DboClass()
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
            SqlDependency.Stop(conStr);

            // Start the dependency
            // User must have SUBSCRIBE QUERY NOTIFICATIONS permission
            // Database must also have SSB enabled
            // ALTER DATABASE Chatter SET ENABLE_BROKER
            SqlDependency.Start(conStr);

            conn = new SqlConnection(conStr);
            dtbl = new DataTable();
            parameters = new List<string>();
            try
            {
                conn.Open();
                Console.WriteLine("Connection success");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~DboClass()
        {
            // Stop the dependency before exiting
            SqlDependency.Stop(conStr);
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
                    IniSqlDependency();
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
                Debug(exception);
                throw new Exception("Uncaught MYSQL Exception", my);
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
                Debug(exception);
                throw new Exception("Uncaught MYSQL Exception", my);
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
        public void Debug(string error)
        {
            Console.WriteLine(error + "/n/r");
        }

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
            Console.WriteLine("wow2");
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

    }
}
