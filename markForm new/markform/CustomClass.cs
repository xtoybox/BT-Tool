using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace markform
{
    public class CustomClass
    {
        public string ErrorLogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BTTOOL_ERROR_LOG.txt";

        public Form GetForm;

        /// <summary>
        /// Write a text file to the given <paramref name="path"/>
        /// </summary>
        /// <param name="txt">Content of the file that will be appended if file already exist.</param>
        /// <param name="path">The location on where the file to be saved or existed.</param>
        public void WriteToFile(string txt, string path)
        {
            using(StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(string.Format(txt, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
            }
        }
        /// <summary>
        /// This will check if the given string(<paramref name="str"/>) is empty, null or white space only.
        /// </summary>
        /// <param name="str">String to be checked</param>
        /// <returns>boolean</returns>
        public bool IsStringEmpty(string str)
        {
            return (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str));
        }
        /// <summary>
        /// Checking if file exist.
        /// </summary>
        /// <param name="path">The full path of the file</param>
        /// <param name="expected">Expected result for satisfying the condition for "ok" result</param>
        /// <param name="numAttemps">The number of attemps before declaring the result "failed"</param>
        /// <returns></returns>
        public string IsExist(string path, bool expected = true, int numAttemps = 5)
        {
            string r = "failed";
            for(int x = 1; x <= numAttemps; x++)
            {
                if (File.Exists(path) == expected)
                {
                    r = "ok"; break;
                }
            }
            return r;
        }
        /// <summary>
        /// This will add incremented value to the datagridview row header
        /// </summary>
        /// <param name="dgv">DataGridView Control</param>
        public void RowsNumber(DataGridView dgv)
        {
            int i2 = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = i2.ToString();
                i2 = i2 + 1;
            }
        }
        /// <summary>
        /// Convert the default format of the file size to a readable format.
        /// </summary>
        /// <param name="TheSize"></param>
        /// <returns></returns>
        public string ReadableFileSize( double TheSize)
        {
            double DoubleBytes;
            string r ="";
            switch (TheSize)
            {
                case double n when n >= 1099511627776:
                    DoubleBytes = (double)TheSize / 1099511627776;
                    r = DoubleBytes.ToString("#0.00") +"TB";
                    break;
                case double n when n >= 1073741824 && n <= 1099511627775:
                    DoubleBytes = (double)TheSize / 1073741824;
                    r = DoubleBytes.ToString("#0.00") + "GB";
                    break;
                case double n when n >= 1048576 && n <= 1073741823:
                    DoubleBytes = (double)TheSize / 1048576;
                    r = DoubleBytes.ToString("#0.00") + "MB";
                    break;
                case double n when n >= 1024 && n <= 1048575:
                    DoubleBytes = (double)TheSize / 1024;
                    r = DoubleBytes.ToString("#0.00") + "KB";
                    break;
                case double n when n >= 0 && n <= 1023:
                    r = TheSize.ToString("#0.00") + "bytes";
                    break;
            }

            return r;
        }
        /// <summary>
        /// Convert seconds to time in 24 hour format
        /// </summary>
        /// <param name="sec"></param>
        /// <returns>string</returns>
        public string SecondsToTime24(double sec)
        {
            TimeSpan ts = TimeSpan.FromSeconds(sec);
            //string hoursStr = string.Format("{0:00}:{1:00}:{2:00}", ts.TotalHours, ts.Minutes, ts.Seconds);
            return ts.ToString(@"hh\:mm\:ss");
        }
        /// <summary>
        /// Getting the current date and format the result by the given format
        /// </summary>
        /// <param name="format"></param>
        /// <returns>String</returns>
        public string GetCurrentDate(string format = "MMM.d.yyyy")
        {
            return DateTime.Now.ToString(format);
        }
        public string GetPositionFull(string pos)
        {
            string fullpos = "";
            switch (pos)
            {
                case "prod":
                    fullpos = "production";
                    break;
                case "sup":
                    fullpos = "supervisor";
                    break;
                case "opsup":
                    fullpos = "operation supervisor";
                    break;
                case "tl":
                    fullpos = "team leader";
                    break;
                case "ts":
                    fullpos = "technical support";
                    break;
                default:
                    fullpos = pos;
                    break;
            }
            return fullpos;
        }
        /// <summary>
        /// Check if the form is current open.
        /// <para>If the form is open then the form propertied will be stored in GetForm</para>
        /// </summary>
        /// <param name="FormName">The name of the form</param>
        /// <param name="CheckTag">(Optional) true if you want to check the tag of the form and <paramref name="TagValue"/> must be set.</param>
        /// <param name="TagValue">(Optional) The tag name to be check when the <paramref name="CheckTag"/> it  set to true</param>
        /// <returns>bool</returns>
        public bool IsFormOpen(string FormName, bool CheckTag = false, string TagValue = "")
        {
            bool isOpen = false;
            foreach(Form frm in Application.OpenForms)
            {
                if(frm.Name == FormName)
                {
                    if (CheckTag)
                    {
                        string t = frm.Tag.ToString();
                        if(t == TagValue)
                        {
                            isOpen = true; this.GetForm = frm; break;
                        }
                    }
                    else
                    {
                        isOpen = true; this.GetForm = frm; break;
                    }
                }
            }
            return isOpen;
        }
        /// <summary>
        /// Write the exception details to a file located base from the <seealso cref="ErrorLogPath"/>
        /// and display a message about the <seealso cref="Exception.Message"/> or a custom message.
        /// </summary>
        /// <param name="ex"><seealso cref="Exception"/></param>
        /// <param name="IsShowMsg">Show <seealso cref="MessageBox"/> = <see langword="true"/> or <see langword="false"/></param>
        /// <param name="CustomMsg">Change the <seealso cref="Exception.Message"/> to the custom message. Works Only if <paramref name="IsShowMsg"/> = <see langword="true"/></param>
        /// <param name="AddLog">Additional info to be added to the log.</param>
        public void Debug(Exception ex,bool IsShowMsg = true, string CustomMsg = "", string AddLog = "")
        {
            AddLog = (this.IsStringEmpty(AddLog)) ? "" : "\nAdditional Info: " + AddLog;
            this.WriteToFile("{0}==>" + ex.ToString()+AddLog, this.ErrorLogPath);
            if (IsShowMsg)
            {
                string msg = (this.IsStringEmpty(CustomMsg)) ? ex.Message : CustomMsg;
                MessageBox.Show("Exception:\n" + msg, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                Debug(ex);
            }
        }

        public string ReadAppSetting(string key)
        {
            string result = "NOT FOUND";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "NOT FOUND";
            }
            catch (ConfigurationErrorsException ex)
            {
                Debug(ex);
            }
            return result;
        }

        public class GridHeaders
        {
            public int width { get; set; }//the width of the column
            public string text { get; set; }//header name
            /// <summary>
            /// Should be in order from 0 to n
            /// </summary>
            public int index { get; set;  }//index of the column
            /// <summary>
            /// Default = true
            /// </summary>
            public bool visible { get; set; } = true;//if column is visible
            /// <summary>
            /// Default = true
            /// </summary>
            public bool makeReadOnly { get; set; } = true;//if column cells are editable
            /// <summary>
            /// The datatype of the column
            /// </summary>
            public Type type { get; set; }
            /// <summary>
            /// Alignment of the content of the cell
            /// </summary>
            public DataGridViewContentAlignment align { get; set; }
        }
    }

    public class ReturnFile
    {
        public string accuracy { get; set; }
        public string specs { get; set; }
        public string btpr_comment { get; set; }
        public string side_comment { get; set; }
        public string comment { get; set; }
    }

    public class BreakLogData
    {
        public string filename { get; set; }
        public string bstart { get; set; }
        public string bend { get; set; }
        public string duration { get; set; }
    }
}
