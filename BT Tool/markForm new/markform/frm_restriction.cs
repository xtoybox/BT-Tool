using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace markform
{
    public partial class frm_restriction : Form
    {
        #region Initialize Class
        SQLClass db = new SQLClass();
        CustomClass cf = new CustomClass();
        UserRestrictionsClass urc = new UserRestrictionsClass();
        #endregion

        #region Setting Variables
        /// <summary>
        /// The default values of the restrictions
        /// </summary>
        private string DefaultRestriction = "";
        private string TempRestriction = "";
        private int UserID = 0;
        private string UserName = "";
        public string UserRestriction = "";
        private int CurrentSelectedRow = -1;
        private int CurrentUID = 0;
        /// <summary>
        /// If true then it will show the user list.
        /// </summary>
        private bool IsAll = false;
        #endregion

        #region Form Class Initialization
        /// <summary>
        /// Performance evaluation form
        /// <paramref name="args"/> example: <para><c>New String[]{userid,username,user restriction,show user list,current user ID}</c></para>
        /// </summary>
        /// <param name="args">
        /// <para>Array must contain the following values in order.</para>
        /// <para>userid,username,user restriction,boolean that indicate the visibility of the user list, current logged in user ID.</para>
        public frm_restriction(object[] args = null)
        {
            InitializeComponent();
            try
            {
                //args = new object[] { 0, "", "", true, 64 };
                if (args != null)
                {
                    UserID = (int)args[0];
                    UserName = (args[1] == null)?"":args[1].ToString();
                    UserRestriction = args[2].ToString();
                    IsAll = (bool)args[3];
                    CurrentUID = (int)args[4];
                    pnl_contains_userlist.Visible = IsAll;

                    if (IsAll) { LoadUserList(); }
                    
                    this.Text = (IsAll) ? "BT TOOL - User Restriction Editor" : "BT TOOL - User Restriction Editor (" + (UserID == 0? "New User": UserName.ToUpper()) + ")";

                    DefaultRestriction = urc.DefaultRestriction;

                    
                    PopulatePresets();
                    cbo_preset_dep.SelectedIndexChanged += new EventHandler(CBO_SelectedIndexChanged);
                    cbo_preset_pos.SelectedIndexChanged += new EventHandler(CBOPos_SelectedIndexChanged);
                    FilterCBO("all", "all");
                    SetRestriction((!cf.IsStringEmpty(UserRestriction)?UserRestriction: DefaultRestriction));
                    //GetPreset();
                }
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        #endregion

        #region Events
        private void txt_f_username_TextChanged(object sender, EventArgs e)
        {
            FilterDGV();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                FileInformation fi = new FileInformation()
                {
                    Enabled = chk_file_info.Checked,
                    DueDate = chk_due_date.Checked,
                    ServiceDate = chk_serv_date.Checked,
                    Client = chk_client.Checked,
                    Branch = chk_branch.Checked,
                    Receive = chk_receive.Checked,
                    DurationInfo = chk_dur.Checked,
                    PageInfo = chk_page.Checked,
                    Accuracy = chk_accuracy.Checked
                };
                WorkFile wf = new WorkFile()
                {
                    Enabled = chk_work_file.Checked,
                    AudioFile = chk_audio.Checked,
                    DocumentInfo = chk_doc.Checked
                };
                AssignUser au = new AssignUser()
                {
                    Enabled = chk_assign_user.Checked,
                    BT = chk_bt.Checked,
                    PR = chk_pr.Checked,
                    ST = chk_st.Checked,
                    CC = chk_cc.Checked,
                    BTQA = chk_btqa.Checked,
                    PRQA = chk_prqa.Checked,
                    STQA = chk_stqa.Checked,
                    CCQA = chk_ccqa.Checked
                };
                #region Get file eval restrictions
                FileEval fileEval = new FileEval()
                {
                    Enabled = chk_file_eval.Checked,
                    AllowCreateEval = chk_fe_allow_create_eval.Checked,
                    AllowExport = chk_fe_allow_export_eval.Checked,
                    AllowViewEval = chk_fe_allow_view_eval.Checked
                };
                List<string> fe_dept = new List<string>();
                foreach (CheckBox chk in pnl_evaldep.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_fe_allow_view_eval" && chk.Checked) { fe_dept.Add(chk.Text.ToLower()); }
                }
                fileEval.RestrictedDepartment = fe_dept.ToArray();
                #endregion Get file eval restrictions

                #region Get file return restrictions
                FileReturn fileReturn = new FileReturn()
                {
                    Enabled = chk_view_return.Checked,
                    AllowSave = chk_ret_allow_save.Checked,
                    AllowDelete = chk_ret_allo_delete.Checked,
                    AllowExport = chk_ret_allo_export.Checked,
                    AllowChangeSeen = chk_ret_allow_seen.Checked,
                    AllowViewReturn = chk_ret_allow_view.Checked
                };
                List<string> fr_dep = new List<string>();
                foreach (CheckBox chk in pnl_ret_allow_dep.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_ret_allow_view" && chk.Checked) { fr_dep.Add(chk.Text.ToLower()); }
                }
                fileReturn.RestrictedDepartment = fr_dep.ToArray();
                #endregion Get file return restrictions

                #region Get Flagging Restrictions
                Flagging flagging = new Flagging()
                {
                    Enabled = chk_flagging.Checked,
                    AllowDelete = chk_flag_allow_delete.Checked,
                    AllowExport = chk_flag_allo_export.Checked,
                    AllowSave = chk_flag_allow_create.Checked,
                    AllowViewFlag = chk_flag_view_all.Checked,
                    AllowChangeSeen = chk_flag_allow_seen.Checked
                };
                List<string> flag_dept = new List<string>();
                foreach (CheckBox chk in pnl_flag_allow_dep.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_flag_view_all" && chk.Checked) { flag_dept.Add(chk.Text.ToLower()); }
                }
                flagging.RestrictedDepartment = flag_dept.ToArray();
                #endregion Get Flagging Restrictions

                #region Get Report Log Restrictions
                ReportLog reportLog = new ReportLog()
                {
                    Enabled = chk_report_logs.Checked,
                    AllowViewBreakLog = chk_rl_allow_bl.Checked,
                    AllowViewIdleLog = chk_rl_allow_il.Checked
                };
                List<string> rlbl_dep = new List<string>(), rlil_dep = new List<string>();
                foreach (CheckBox chk in pnl_rl_allow_bl.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_rl_allow_bl" && chk.Checked) { rlbl_dep.Add(chk.Text.ToLower()); }
                }
                foreach (CheckBox chk in pnl_rl_allow_il.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_rl_allow_il" && chk.Checked) { rlil_dep.Add(chk.Text.ToLower()); }
                }
                reportLog.BreakLogRestrictedDepartment = rlbl_dep.ToArray();
                reportLog.IdleLogRestrictedDepartment = rlil_dep.ToArray();
                #endregion Get Report Log Restrictions

                Monitoring monitoring = new Monitoring()
                {
                    Enabled = chk_monitoring.Checked
                };
                RatioTracker ratioTracker = new RatioTracker()
                {
                    Enabled = chk_ratio_track.Checked
                };
                IdleTracker idleTracker = new IdleTracker()
                {
                    Enabled = chk_idle_track.Checked
                };
                WaitTracker waitTracker = new WaitTracker()
                {
                    Enabled = chk_wait_tracker.Checked
                };
                FilesDue filesDue = new FilesDue()
                {
                    Enabled = chk_files_due.Checked
                };
                UserList userList = new UserList()
                {
                    Enabled = chk_userlist.Checked,
                    AllowSave = chk_ua_allow_save.Checked
                };
                WorkFlow workFlow = new WorkFlow()
                {
                    Enabled = chk_workflow.Checked
                };
                UploadFunction uploadFunction = new UploadFunction()
                {
                    Enabled = chk_upload.Checked
                };
                ExportFunction exportFunction = new ExportFunction()
                {
                    Enabled =chk_export.Checked
                };
                ArchiveFunction archiveFunction = new ArchiveFunction()
                {
                    Enabled = chk_archive.Checked
                };
                ReferenceFunction referenceFunction = new ReferenceFunction()
                {
                    Enabled = chk_ref.Checked
                };
                BTFileFunction bTFileFunction = new BTFileFunction()
                {
                    Enabled = chk_btfile.Checked
                };


                UserRestrictionsClass urc = new UserRestrictionsClass()
                {
                    FilePriority = chk_file_prio.Checked, FileInformation = fi, WorkFile = wf,
                    AssignUser = au, FileEval = fileEval, FileReturn = fileReturn, Flagging = flagging,
                    Monitoring = monitoring, RatioTracker = ratioTracker, IdleTracker = idleTracker,
                    WaitTracker = waitTracker, FilesDue = filesDue, UserList = userList, WorkFlow = workFlow,
                    UploadFunction = uploadFunction, ExportFunction = exportFunction,
                    ArchiveFunction = archiveFunction, ReportLog = reportLog,
                    ReferenceFunction = referenceFunction, BTFileFunction = bTFileFunction,
                    ReturnFileBtn = chk_return_file.Checked
                };
                string restrictions = JsonConvert.SerializeObject(urc);
                //TempRestriction = restrictions;
                Console.WriteLine(restrictions);
                if (!IsAll)
                {
                    UserRestriction = restrictions;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    int qry = db.nQuery("UPDATE dbo.UserData SET restrictions = '" + restrictions + "' WHERE Id = " + UserID);
                    if (qry != 0)
                    {
                        MessageBox.Show(this, "Success!", UserName + "'s restrictions successfully saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_userlist[2, CurrentSelectedRow].Value = restrictions;
                    }
                    else
                    {
                        MessageBox.Show(this, "Failed!", UserName + "'s restrictions failed to save.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            SetRestriction(DefaultRestriction);
        }
        private void CBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dep = cbo_preset_dep.SelectedValue.ToString(),
                pos = cbo_preset_pos.SelectedValue.ToString();
            FilterCBO(dep, pos);
            GetPreset();
        }
        private void CBOPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPreset();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = (CheckBox)sender;
                switch (chk.Name)
                {
                    case "chk_file_info":
                        gbox_fileinfo.Enabled = chk_file_info.Checked;
                        break;
                    case "chk_work_file":
                        gbox_workfile.Enabled = chk_work_file.Checked;
                        break;
                    case "chk_assign_user":
                        gbox_assign_user.Enabled = chk_assign_user.Checked;
                        break;
                    case "chk_fe_allow_view_eval":
                        pnl_evaldep.Enabled = chk_fe_allow_view_eval.Checked;
                        break;
                    case "chk_file_eval":
                        (tab_file_eval as Control).Enabled = chk_file_eval.Checked;
                        break;
                    case "chk_view_return":
                        (tab_view_return as Control).Enabled = chk_view_return.Checked;
                        break;
                    case "chk_userlist":
                        (tab_userlist as Control).Enabled = chk_userlist.Checked;
                        break;
                    case "chk_report_logs":
                        (tab_report_logs as Control).Enabled = chk_report_logs.Checked;
                        break;
                    case "chk_flag_view_all":
                        pnl_flag_allow_dep.Enabled = chk_flag_view_all.Checked;
                        break;
                    case "chk_ret_allow_view":
                        pnl_ret_allow_dep.Enabled = chk_ret_allow_view.Checked;
                        break;
                    case "chk_rl_allow_bl":
                        pnl_rl_allow_bl.Enabled = chk_rl_allow_bl.Checked;
                        break;
                    case "chk_rl_allow_il":
                        pnl_rl_allow_il.Enabled = chk_rl_allow_il.Checked;
                        break;
                }
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        private void dgv_userlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex != -1)
                {
                    CurrentSelectedRow = e.RowIndex;
                    DataGridViewRow SelRow = dgv_userlist.Rows[e.RowIndex];
                    UserID = (int)SelRow.Cells[0].Value;
                    UserName = SelRow.Cells[1].Value.ToString().ToUpper();
                    UserRestriction = SelRow.Cells[2].Value.ToString();
                    SetRestriction(UserRestriction);
                }
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        private void Filter_CheckChange(object sender, EventArgs e)
        {
            FilterDGV();
        }
        #endregion Events

        #region Void Methods
        /// <summary>
        /// Populate userlist data to the datagridview
        /// </summary>
        private void LoadUserList()
        {
            try
            {
                DataTable ndt = new DataTable();
                ndt.Columns.Add("uid", typeof(int));
                ndt.Columns.Add("Username", typeof(string));
                ndt.Columns.Add("Restrictions", typeof(string));
                ndt.Columns.Add("Department", typeof(string));
                DataTable dt = db.query("SELECT Id, UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,restrictions,department FROM dbo.UserData WHERE deactivated = 0 AND Id != "+ CurrentUID + " ORDER BY department,position,username");
                foreach (DataRow row in dt.Rows)
                {
                    object[] obj = row.ItemArray;
                    ndt.Rows.Add((int)obj[0], obj[1], obj[2], obj[3].ToString().ToUpper());
                }
                dgv_userlist.DataSource = ndt;
                dgv_userlist.Columns[0].Visible = false;
                dgv_userlist.Columns[2].Visible = false;
                dgv_userlist.Columns[1].Width = 82;
                dgv_userlist.Columns[3].Width = 50;
                dgv_userlist.ClearSelection();
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        /// <summary>
        /// Filter datagridview
        /// </summary>
        private void FilterDGV()
        {
            try
            {
                //Get all the checked item text
                List<string> dep = new List<string>();
                foreach (CheckBox chk in pnl_filterdgv_container.Controls.OfType<CheckBox>().Reverse())
                {
                    if(chk.Checked)dep.Add("'"+chk.Text.ToLower()+"'");
                }

                List<string> flter = new List<string>();//storage for the filter query

                string txt = txt_f_username.Text;
                if (!cf.IsStringEmpty(txt)) { flter.Add("Username LIKE '%" + txt + "%'"); }
                if(dep.Count > 0) { flter.Add("Department IN("+ string.Join(",",dep) +")"); }
                
                (dgv_userlist.DataSource as DataTable).DefaultView.RowFilter = string.Join(" AND ",flter);
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        /// <summary>
        /// Populate the comboboxes inside the presets groupbox
        /// </summary>
        private void PopulatePresets()
        {
            try
            {
                DataTable depdt = new DataTable();
                depdt.Columns.Add("text", typeof(string));
                depdt.Columns.Add("value", typeof(string));
                depdt.Rows.Add("All", "all");
                depdt.Rows.Add("BT", "bt"); depdt.Rows.Add("PR", "pr");
                depdt.Rows.Add("BET", "bet"); depdt.Rows.Add("TS", "ts");
                cbo_preset_dep.DisplayMember = "text"; cbo_preset_dep.ValueMember = "value";
                cbo_preset_dep.DataSource = depdt; cbo_preset_dep.SelectedIndex = 0;

                DataTable posdt = new DataTable();
                posdt.Columns.Add("text", typeof(string));
                posdt.Columns.Add("value", typeof(string));
                posdt.Rows.Add("All", "all"); posdt.Rows.Add("Supervisor", "sup");
                posdt.Rows.Add("Team Leader", "tl"); posdt.Rows.Add("Scheduler", "sched");
                posdt.Rows.Add("Production", "prod"); posdt.Rows.Add("Technical Support", "ts");
                cbo_preset_pos.DisplayMember = "text"; cbo_preset_pos.ValueMember = "value";
                cbo_preset_pos.DataSource = posdt; cbo_preset_pos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        /// <summary>
        /// Set the restriction settings
        /// </summary>
        /// <param name="JSONString"></param>
        private void SetRestriction(string JSONString)
        {
            try
            {
                JSONString = (!cf.IsStringEmpty(JSONString)) ? JSONString : DefaultRestriction;
                
                UserRestrictionsClass urc = JsonConvert.DeserializeObject<UserRestrictionsClass>(JSONString);
                
                FileInformation fi = urc.FileInformation;
                WorkFile wf = urc.WorkFile;
                AssignUser au = urc.AssignUser;

                FileEval fe = urc.FileEval; FileReturn fr = urc.FileReturn;
                Flagging flag = urc.Flagging; Monitoring mo = urc.Monitoring;
                RatioTracker rt = urc.RatioTracker; IdleTracker it = urc.IdleTracker;
                WaitTracker wt = urc.WaitTracker; FilesDue fd = urc.FilesDue;
                UserList ua = urc.UserList; WorkFlow wfw = urc.WorkFlow;
                UploadFunction uf = urc.UploadFunction; ExportFunction ef = urc.ExportFunction;
                ArchiveFunction af = urc.ArchiveFunction; ReportLog rl = urc.ReportLog;
                ReferenceFunction rf = urc.ReferenceFunction; BTFileFunction btf = urc.BTFileFunction;


                chk_file_prio.Checked = urc.FilePriority;
                chk_return_file.Checked = urc.ReturnFileBtn;

                #region Set menus restriction
                chk_file_eval.Checked = fe.Enabled;
                chk_monitoring.Checked = mo.Enabled;
                chk_view_return.Checked = fr.Enabled;
                chk_flagging.Checked = flag.Enabled;
                chk_ratio_track.Checked = rt.Enabled;
                chk_idle_track.Checked = it.Enabled;
                chk_wait_tracker.Checked = wt.Enabled;
                chk_files_due.Checked = fd.Enabled;
                chk_userlist.Checked = ua.Enabled;
                chk_workflow.Checked = wfw.Enabled;
                chk_upload.Checked = uf.Enabled;
                chk_export.Checked = ef.Enabled;
                chk_archive.Checked = af.Enabled;
                chk_report_logs.Checked = rl.Enabled;
                chk_ref.Checked = rf.Enabled;
                chk_btfile.Checked = btf.Enabled;
                #endregion Set menus restriction

                #region Set File Eval Restrionctions
                chk_fe_allow_create_eval.Checked = fe.AllowCreateEval;
                chk_fe_allow_export_eval.Checked = fe.AllowExport;
                chk_fe_allow_view_eval.Checked = fe.AllowViewEval;
                int feindex = 0;string[] fe_dep = fe.RestrictedDepartment;
                foreach (CheckBox chk in pnl_evaldep.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_fe_allow_view_eval") { chk.Checked = (fe_dep.Contains(chk.Text.ToLower())); feindex++; }
                }
                #endregion Set File Eval Restrionctions
                #region Set Return File Restrictions
                chk_ret_allow_save.Checked = fr.AllowSave;
                chk_ret_allo_delete.Checked = fr.AllowDelete;
                chk_ret_allo_export.Checked = fr.AllowExport;
                chk_ret_allow_seen.Checked = fr.AllowChangeSeen;
                chk_ret_allow_view.Checked = fr.AllowViewReturn;
                feindex = 0; fe_dep = fr.RestrictedDepartment;
                foreach (CheckBox chk in pnl_ret_allow_dep.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_ret_allow_view") { chk.Checked = (fe_dep.Contains(chk.Text.ToLower())); feindex++; }
                }
                #endregion Set Return File Restrictions
                #region Set Flagging Restrictions
                chk_flag_allow_create.Checked = flag.AllowSave;
                chk_flag_allow_delete.Checked = flag.AllowDelete;
                chk_flag_allo_export.Checked = flag.AllowExport;
                chk_flag_view_all.Checked = flag.AllowViewFlag;
                chk_flag_allow_seen.Checked = flag.AllowChangeSeen;
                feindex = 0;fe_dep = flag.RestrictedDepartment;
                foreach (CheckBox chk in pnl_flag_allow_dep.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_flag_view_all") { chk.Checked = (fe_dep.Contains(chk.Text.ToLower())); feindex++; }
                }
                #endregion Flagging Restrictions
                #region Set Report Log Restrictions
                chk_rl_allow_bl.Checked = rl.AllowViewBreakLog;
                chk_rl_allow_il.Checked = rl.AllowViewIdleLog;
                feindex = 0; fe_dep = rl.BreakLogRestrictedDepartment;
                foreach (CheckBox chk in pnl_rl_allow_bl.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_rl_allow_bl") { chk.Checked = (fe_dep.Contains(chk.Text.ToLower())); feindex++; }
                }
                feindex = 0; fe_dep = rl.IdleLogRestrictedDepartment;
                foreach (CheckBox chk in pnl_rl_allow_il.Controls.OfType<CheckBox>().Reverse())
                {
                    if (chk.Name != "chk_rl_allow_il") { chk.Checked = (fe_dep.Contains(chk.Text.ToLower())); feindex++; }
                }
                #endregion Set Report Log Restrictions

                #region Set file information restrictions
                chk_file_info.Checked = fi.Enabled;
                chk_due_date.Checked = fi.DueDate;
                chk_serv_date.Checked = fi.ServiceDate;
                chk_client.Checked = fi.Client;
                chk_branch.Checked = fi.Branch;
                chk_receive.Checked = fi.Receive;
                chk_dur.Checked = fi.DurationInfo;
                chk_page.Checked = fi.PageInfo;
                chk_accuracy.Checked = fi.Accuracy;
                #endregion Set file information restrictions

                #region Set work file restrictions
                chk_work_file.Checked = wf.Enabled;
                chk_audio.Checked = wf.AudioFile;
                chk_doc.Checked = wf.DocumentInfo;
                #endregion Set work file restrictions

                #region Set assign user
                chk_assign_user.Checked = au.Enabled;
                chk_bt.Checked = au.BT;
                chk_pr.Checked = au.PR;
                chk_st.Checked = au.ST;
                chk_cc.Checked = au.CC;
                chk_btqa.Checked = au.BTQA;
                chk_prqa.Checked = au.PRQA;
                chk_stqa.Checked = au.STQA;
                chk_ccqa.Checked = au.CCQA;
                #endregion Set assign user
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        /// <summary>
        /// Filter the selection from the position combobox base on the department combobox.
        /// </summary>
        /// <param name="cbodep"></param>
        /// <param name="cbopos"></param>
        private void FilterCBO(string cbodep, string cbopos)
        {
            try
            {
                string fpos = "";
                if (cbodep == "ts")
                {
                    fpos = "value LIKE 'ts'";
                }
                else if (cbodep == "all")
                {
                    fpos = "value LIKE 'all'";
                }
                else
                {
                    fpos = "value NOT IN('ts','all')";
                }
                (cbo_preset_pos.DataSource as DataTable).DefaultView.RowFilter = fpos;
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }

        private void GetPreset()
        {
            try
            {
                string cbodep = cbo_preset_dep.SelectedValue.ToString(),
                cbopos = cbo_preset_pos.SelectedValue.ToString();
                string preset = urc.GetPresetRestriction(cbodep, cbopos);
                SetRestriction(preset);//(!cf.IsStringEmpty(UserRestriction)? UserRestriction:preset)
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
        }
        #endregion

        #region Functions

        #endregion Functions

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
