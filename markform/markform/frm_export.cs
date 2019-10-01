using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using ClosedXML.Excel;

namespace markform
{
    public partial class frm_export : Form
    {
        private markDBOClass.SQLClass db = new markDBOClass.SQLClass();
        private CustomClass cf = new CustomClass();
        private string[] FieldArr;
        private string[] TableArr = null;
        private int uid;
        private string uname, upos, udep;
        /// <summary>
        /// Contianer of the datatable that will be set from the DoWork
        /// </summary>
        private DataTable ndatatable = new DataTable();
        private DataSet nDataSet = new DataSet();
        /// <summary>
        /// Date range
        /// </summary>
        private SelectionRange DateSelectionRange;
        /// <summary>
        /// eval, break, flag or return
        /// </summary>
        private string dtype = "";
        private string client = "all", dep = "all";
        private int totalData = 0;
        private SelectionRange OldDateSelectionRange;
        private CancellationTokenSource _cts;
        private string ErroQuery = "";
        private string test = "";

        public frm_export(string[] args = null, string type = null)
        {
            InitializeComponent();
            if(args != null)
            {
                this.uid = int.Parse(args[0].ToString());
                this.uname = args[1].ToString();
                this.upos = args[2].ToString();
                this.udep = args[3].ToString();
                this.SetCboDataSource();
                this.FormTitle(type);
                this.dtype = type;
                this.DateSelectionRange = dtpicker.SelectionRange;

                tss_status.Text = "Ready";
                this.FetchData();
            }
        }
        /// <summary>
        /// Setting the title of the form base on the <paramref name="type"/> 
        /// as well as setting other properties and variables.
        /// </summary>
        /// <param name="type">Can be any of the following: eval, break, return, flag</param>
        private void FormTitle(string type)
        {
            string title = "Export To Excel";
            string[] fields = new string[] { };
            switch (type)
            {
                case "eval":
                    title = title + " - Evaluation";
                    fields = new string[] { "Date", "BT", "PR", "Account", "Filename", "Score" };
                    break;
                case "break":
                    title = title + " - Break";
                    if (new string[] { "sup", "tl" }.Contains(this.upos))
                    {
                        fields = new string[] { "Date", "Username", "Filename", "Break Start", "Break End", "Duration" };
                    }
                    else
                    {
                        fields = new string[] { "Date", "Department", "Username", "Filename", "Break Start", "Break End", "Duration" };
                        TableArr = new string[] {"BT","PR","BET"};
                    }
                    
                    break;
                case "return":
                    title = title + " - Return";
                    string opsdep = (this.udep == "pr") ? "bt" : "pr";
                    fields = new string[] { "Date and Time", opsdep.ToUpper() + " Name", udep.ToUpper() + " Name", "File Fixed By", udep.ToUpper() + " Name 2", "Client", "Filename", "Accuracy", "Specs", opsdep.ToUpper() + " Comment", "Action By " + opsdep.ToUpper() + " Sup", "Side-by-side Feedback", "Comment" };
                    break;
                case "flag":
                    title = title + " - Flagging";
                    fields = new string[] { "Date and Time", "Username", "Client", "Client Type", "Filename", "Problem" };
                    break;
            }
            this.FieldArr = fields;
            this.Text = title;
            this.Tag = type;
            this.Height = 320;

            if (new string[] { "flag", "return" }.Contains(type))
            {
                pnl_cl_dep_container.Visible = true;
                this.SetCboDataSource();
                this.Height = 390;
                this.cbo_client.SelectedIndexChanged += new EventHandler(Cbo_SelectedIndexChanged);
                this.cbo_dep.SelectedIndexChanged += new EventHandler(Cbo_SelectedIndexChanged);
            }
        }
        /// <summary>
        /// Fetching data by date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpicker_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.FetchData();
        }
        /// <summary>
        /// Fetching data by client and department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FetchData();
        }
        /// <summary>
        /// Fetching data from the database
        /// This will run in the background to prevent lag during a long process
        /// </summary>
        private async void FetchData()
        {
            _cts = new CancellationTokenSource(); CancellationToken token = _cts.Token;

            db.SQLDependency(false);
            SelectionRange dtsr = dtpicker.SelectionRange;
            string stime = dtsr.Start.ToString("MM/dd/yyyy"),
                etime = dtsr.End.ToString("MM/dd/yyyy"),
                tssStr = "",lblStr = "" ;
            //DateSelectionRange = dtpicker.SelectionRange;
            this.Cursor = Cursors.AppStarting;

            dtpicker.Enabled = false;
            btn_close.Enabled = false;
            btn_export.Enabled = false;
            tss_status.Text = "Initializing...";
            lbl_status.Text = "Preparing...";
            
            if (new string[] { "flag", "return" }.Contains(this.Tag.ToString()))
            {
                cbo_client.Enabled = false;
                cbo_dep.Enabled = false;
                this.client = cbo_client.SelectedValue.ToString();
                this.dep = cbo_dep.SelectedValue.ToString();
            }
            Progress<string> progressHandler = new Progress<string>(val => { tss_status.Text = val; });
            IProgress<string> progress = (IProgress<string>)progressHandler;
            try
            {
                await Task.Run(() =>
                {
                    //---Setting worksheet name---
                    string sheetname = (dtsr.Start != dtsr.End) ? dtsr.Start.ToString("MMM.d.yyyy") + "_" + dtsr.End.ToString("MMM.d.yyyy") :
                        dtsr.Start.ToString("MMM d, yyyy");
                    string qry = "";
                    List<string> qrywhere = new List<string>();
                    //---Setting query string--
                    switch (dtype)
                    {
                        case "eval":
                            qry = "SELECT (SELECT username FROM dbo.UserData WHERE Id = user_id)," +
                                "(SELECT username FROM dbo.UserData WHERE Id = eval_user_id)," +
                                "(SELECT cl_id FROM dbo.tbl_client WHERE cl_id = a.cl_id),filename,CONVERT(date, dt_created)," +
                                "total_score FROM dbo.tbl_btpr_eval AS a WHERE " +
                                "CONVERT(date, dt_created) BETWEEN CONVERT(date,'" + stime + "') AND CONVERT(date,'" + etime + "') " +
                                "ORDER BY CAST(dt_created AS datetime)";
                            break;
                        case "break":
                            if (new string[] { "sup", "tl" }.Contains(upos))
                            {
                                qrywhere.Add("department LIKE '" + udep + "'");
                            }
                            string w = (qrywhere.Count > 0) ? " AND " + string.Join(" AND ", qrywhere.ToArray()) : "";

                            qry = "SELECT a.Id,username,department,position,ISNULL(bstart,''),ISNULL(bend,'')," +
                                "ISNULL(bstart, ''),ISNULL(DATEDIFF(ss, CONVERT(datetime, bstart)," +
                                "CONVERT(datetime, bend)), 0) FROM dbo.UserData AS a " +
                                "LEFT OUTER JOIN dbo.tbl_break AS b ON a.Id = b.uid AND " +
                                "CONVERT(date, bstart) BETWEEN CONVERT(date,'" + stime + "') AND CONVERT(date,'" + etime + "') " +
                                "WHERE deactivated = 0 AND position NOT IN('it','sup','opsup') " + w + " " +
                                "ORDER BY department,CONVERT(date, bstart),username,CAST(bstart AS datetime)";
                            break;
                        default:
                            string qrysel = (dtype == "return") ? "others" : "problem,(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype";
                            //---the position that will get all the data. Additional filter may apply for for return---
                            string[] PosArrFull = new string[] { "sup", "opsup", "it", "hr", "tl", "ts", "auditor" };
                            if (!PosArrFull.Contains(upos))
                            {
                                qrywhere.Add("user_id = " + uid);
                                if (dtype == "return")
                                {
                                    qrywhere.Add("dep LIKE '" + udep + "'");
                                }
                            }
                            else
                            {
                                if (dtype == "return")
                                {
                                    qrywhere.Add("dep IN " + (udep == "pr" ? "('pr','bet')" : (udep == "bt" ? "pr" : "bet")));
                                }
                            }
                            if (client != "all")
                            {
                                qrywhere.Add("cl_id IN ((SELECT cl_id FROM dbo.tbl_client WHERE ctype LIKE '" + client + "'))");
                            }
                            if (dep != "all")
                            {
                                qrywhere.Add("dep LIKE '" + dep + "'");
                            }
                            string addWhereJoin = (qrywhere.Count > 0) ? string.Join(" AND ", qrywhere.ToArray()) + " AND " : "";
                            qry = "SELECT filename,CAST(dt_created AS datetime)," +
                                "(SELECT username FROM dbo.UserData WHERE Id = a.user_id) AS uname," +
                                "(SELECT username FROM dbo.UserData WHERE Id = a.user2_id) AS uname2," +
                                "(SELECT username FROM dbo.UserData WHERE Id = a.btpr_id) AS btprname," +
                                "(SELECT username FROM dbo.UserData WHERE Id = a.fixer_id) AS fixername," +
                                "(SELECT username FROM dbo.UserData WHERE Id = a.act_id) AS actname," +
                                "(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," + qrysel + " FROM dbo.tbl_flag_return AS a WHERE " + addWhereJoin + "" +
                                "type LIKE '" + dtype + "' AND CONVERT(date, dt_created) BETWEEN CONVERT(date,'" + stime + "') AND CONVERT(date,'" + etime + "') " +
                                "ORDER BY CAST(dt_created AS datetime)";
                            break;

                    }
                    progress.Report("Fetching data...");
                    DataTable dt = new DataTable();
                    //---Executing the query---
                    try
                    {
                        dt = db.query(qry);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    totalData = dt.Rows.Count;
                    DataTable newdt = new DataTable();
                    DataTable bt = new DataTable("BT"), pr = new DataTable("PR"), bet = new DataTable("BET");
                    DataTable[] dataTables = new DataTable[] { bt, pr, bet };
                    sheetname = (dtype == "break") ? "Others" : sheetname;
                    newdt = new DataTable(sheetname);
                    foreach (string field in FieldArr)
                    {
                        newdt.Columns.Add(field, typeof(string));
                    }

                    if (TableArr != null)
                    {
                        foreach (DataTable dataTable in dataTables)
                        {
                            foreach (string field in FieldArr)
                            {
                                dataTable.Columns.Add(field, typeof(string));
                            }
                        }
                    }

                    int i = 1,cnt = dt.Rows.Count;
                    string[] DepIndexArr = new string[] { "bt", "pr", "bet" };
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        token.ThrowIfCancellationRequested();
                        progress.Report(i+" of "+ cnt);
                        object[] obj = row.ItemArray;
                        switch (dtype)
                        {
                            case "eval":
                                newdt.Rows.Add(obj[4], obj[0], obj[1], obj[2], obj[3], obj[5]);
                                break;
                            case "break":
                                double DurSec = double.Parse(obj[7].ToString());
                                string dur = cf.SecondsToTime24(DurSec);
                                if (new string[] { "sup", "tl" }.Contains(upos))
                                {
                                    newdt.Rows.Add(obj[6], obj[1], obj[4], obj[5], dur);
                                }
                                else
                                {
                                    int depIndex = Array.IndexOf(DepIndexArr, obj[2].ToString().ToLower());
                                    if (depIndex == -1)
                                    {
                                        newdt.Rows.Add(obj[6], obj[2].ToString().ToUpper(), obj[1], obj[4], obj[5], dur);
                                    }
                                    else
                                    {
                                        dataTables[depIndex].Rows.Add(obj[6], obj[1], obj[4], obj[5], dur);
                                    }
                                }
                                break;
                            case "flag":
                                string clt = (obj[9].ToString() == "non") ? "Non-Insurance" : "Insurance";
                                newdt.Rows.Add(obj[1], obj[2], obj[7], clt, obj[0], obj[8]);
                                break;
                            case "return":

                                ReturnFile rfObj = JsonConvert.DeserializeObject<ReturnFile>(obj[8].ToString());

                                string ac = rfObj.accuracy, sp = rfObj.specs, com1 = rfObj.btpr_comment, com2 = rfObj.side_comment, com3 = rfObj.comment;

                                newdt.Rows.Add(obj[1], obj[4], obj[2], obj[5], obj[3], obj[7], obj[0], ac, sp, com1, obj[6], com2, com3);

                                break;
                        }
                        i++;
                    }

                    ndatatable = new DataTable();
                    ndatatable = newdt;
                    DataSet dset = new DataSet(dtype);
                    List<DataTable> lstdt = new List<DataTable>();

                    if (TableArr != null)
                    {
                        foreach (DataTable dataTable in dataTables)
                        {
                            dset.Tables.Add(dataTable);
                        }
                    }
                    dset.Tables.Add(newdt);
                    nDataSet = new DataSet();
                    nDataSet = dset;
                });
                btn_export.Enabled = (totalData > 0);
                tssStr = "Done."; lblStr = (totalData == 0) ? "No Data to Export" : "Total data: " + totalData;
                this.OldDateSelectionRange = dtsr;
            }
            catch (Exception ex)
            {
                tssStr = "Error Encountered!"; lblStr = "Failed";
                cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + ErroQuery, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ErroQuery = "";
            dtpicker.Enabled = true;
            btn_close.Enabled = true;
            if (new string[] { "flag", "return" }.Contains(dtype.ToString()))
            {
                cbo_client.Enabled = true;
                cbo_dep.Enabled = true;
            }
            tss_status.Text = tssStr;
            lbl_status.Text = lblStr;
            this.Cursor = Cursors.Default;
        }

        private void frm_export_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null) { _cts.Cancel(); }
        }

        /// <summary>
        /// export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_export_Click(object sender, EventArgs e)
        {
            if (totalData > 0)
            {
                _cts = new CancellationTokenSource(); CancellationToken token = _cts.Token;
                this.Cursor = Cursors.AppStarting;
                string path = "";
                //---Opening folder browser---
                using(FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select export location";
                    if(fbd.ShowDialog() == DialogResult.OK)
                    {
                        path = fbd.SelectedPath;
                    }
                }
                if(path != "")
                {
                    dtpicker.Enabled = false;
                    btn_close.Enabled = false;
                    if (new string[] { "flag", "return" }.Contains(this.Tag.ToString()))
                    {
                        cbo_client.Enabled = false;
                        cbo_dep.Enabled = false;
                    }
                    tss_status.Text = "Initializing...";
                    lbl_status.Text = "Preparing...";
                    string tssStr = "", lblStr = "";
                    Progress<string> progressHandler = new Progress<string>(val => { tss_status.Text = val; });

                    IProgress<string> progress = (IProgress<string>)progressHandler;

                    try
                    {
                        await Task.Run(()=> {
                            progress.Report("Preparing sheet name...");Thread.Sleep(500);
                            token.ThrowIfCancellationRequested();
                            string sheetname = (DateSelectionRange.Start != DateSelectionRange.End) ? DateSelectionRange.Start.ToString("MMM.d.yyyy") + "_" + DateSelectionRange.End.ToString("MMM.d.yyyy") :
                                DateSelectionRange.Start.ToString("MMM d, yyyy");

                            progress.Report("Preparing excel name...");Thread.Sleep(500);
                            token.ThrowIfCancellationRequested();
                            string withCLandDep = (dtype == "eval" || dtype == "break") ? "" : client + "_" + dep + "_";
                            string excelName = dtype.ToUpper() + "_" + sheetname + "_" + withCLandDep + DateTime.Now.ToString("yyyy.MM.dd.HHmmss") + ".xlsx";

                            progress.Report("Preparing to export...");Thread.Sleep(500);
                            token.ThrowIfCancellationRequested();
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                progress.Report("Adding data to excel worksheet...");Thread.Sleep(500);

                                wb.Worksheets.Add(nDataSet);
                                foreach (IXLWorksheet ws in wb.Worksheets)
                                {
                                    token.ThrowIfCancellationRequested();
                                    string str = (dtype == "break") ? ws.Worksheet.Name + " - " : "";
                                    string dtformat = (dtype == "eval") ? "m/d/yyyy" : "m/d/yyyy h:mm:ss AM/PM;@";

                                    progress.Report(str + "Removing default filter...");Thread.Sleep(500);
                                    token.ThrowIfCancellationRequested();
                                    ws.Tables.FirstOrDefault().ShowAutoFilter = false;

                                    progress.Report(str + "Setting data type...");Thread.Sleep(500);
                                    token.ThrowIfCancellationRequested();
                                    ws.Range("A2", "A" + ws.RowsUsed().Count().ToString()).DataType = XLDataType.DateTime;

                                    progress.Report(str + "Formatting cells...");Thread.Sleep(500);
                                    token.ThrowIfCancellationRequested();
                                    ws.Range("A2", "A" + ws.RowsUsed().Count().ToString()).Style.DateFormat.Format = dtformat;

                                    progress.Report(str + "Setting cell alignment...");Thread.Sleep(500);
                                    token.ThrowIfCancellationRequested();
                                    ws.Range("A2", "A" + ws.RowsUsed().Count().ToString()).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                                    progress.Report(str + "Freezing first row...");Thread.Sleep(500);
                                    token.ThrowIfCancellationRequested();
                                    ws.SheetView.FreezeRows(1);
                                }
                                progress.Report("Saving excel...");Thread.Sleep(500);
                                token.ThrowIfCancellationRequested();
                                wb.SaveAs(path + "\\" + excelName);
                            }
                        });
                        btn_export.Enabled = (totalData > 0);
                        tssStr = "Done."; lblStr = (totalData == 0) ? "No Data to Export" : "Total data: " + totalData;
                        MessageBox.Show(this, "Export complete.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        tssStr = "Error Encountered!"; lblStr = "Failed";
                        string innerException = (ex.InnerException.Message != null) ? "\n" + ex.InnerException.Message : "";
                        MessageBox.Show(this, "Exception:\n" + ex.Message + innerException, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dtpicker.Enabled = true;
                    btn_close.Enabled = true;
                    if (new string[] { "flag", "return" }.Contains(dtype.ToString()))
                    {
                        cbo_client.Enabled = true;
                        cbo_dep.Enabled = true;
                    }
                    tss_status.Text = tssStr;
                    lbl_status.Text = lblStr;
                    this.Cursor = Cursors.Default;
                }
                
            }
            else
            {
                MessageBox.Show(this, "No data to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Setting the datasource of the combobox
        /// </summary>
        private void SetCboDataSource()
        {
            DataTable dt = new DataTable();
            cbo_client.DisplayMember = "text";
            cbo_client.ValueMember = "value";
            cbo_dep.DisplayMember = "text";
            cbo_dep.ValueMember = "value";

            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));
            dt.Rows.Add("All", "all");
            dt.Rows.Add("Insurance", "ins");
            dt.Rows.Add("Non-insurance", "non");
            cbo_client.DataSource = dt;

            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));
            dt.Rows.Add("All", "all");
            dt.Rows.Add("Business Transcriber", "bt");
            dt.Rows.Add("Proofreader", "pr");
            dt.Rows.Add("BET", "bet");
            cbo_dep.DataSource = dt;

        }
        /// <summary>
        /// This will dispose the resources used by this form and close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
