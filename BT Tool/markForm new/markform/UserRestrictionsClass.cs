using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace markform
{
    public class UserRestrictionsClass
    {
        public bool FilePriority { get; set; }
        public bool ReturnFileBtn { get; set; }
        public FileInformation FileInformation { get; set; }
        public WorkFile WorkFile { get; set; }
        public AssignUser AssignUser { get; set; }

        public FileEval FileEval { get; set; }
        public FileReturn FileReturn { get; set; }
        public Flagging Flagging { get; set; }
        public Monitoring Monitoring { get; set; }
        public RatioTracker RatioTracker { get; set; }
        public IdleTracker IdleTracker { get; set; }
        public WaitTracker WaitTracker { get; set; }
        public FilesDue FilesDue { get; set; }
        public UserList UserList { get; set; }
        public WorkFlow WorkFlow { get; set; }
        public UploadFunction UploadFunction { get; set; }
        public ExportFunction ExportFunction { get; set; }
        public ArchiveFunction ArchiveFunction { get; set; }
        public ReportLog ReportLog { get; set; }
        public ReferenceFunction ReferenceFunction { get; set; }
        public BTFileFunction BTFileFunction { get; set; }

        public string DefaultRestriction = "{'FilePriority':true," +
            "'FileInformation':{'Enabled':true,'DueDate':true,'ServiceDate':true,'Client':true,'Branch':true,'Receive':true,'DurationInfo':true,'PageInfo':true,'Accuracy':true}," +
            "'WorkFile':{'Enabled':true,'AudioFile':true,'DocumentInfo':true}," +
            "'AssignUser':{'Enabled':true,'BT':true,'PR':true,'ST':true,'CC':true,'BTQA':true,'PRQA':true,'STQA':true,'CCQA':true}," +
            "'FileEval':{'Enabled':true,'AllowCreateEval':true,'AllowViewEval':true,'AllowExport':true,'RestrictedDepartment':['bt','pr','bet']}," +
            "'FileReturn':{'Enabled':true,'AllowSave':true,'AllowDelete':true,'AllowExport':true,'AllowChangeSeen':true,'AllowViewReturn':true,'RestrictedDepartment':['bt','pr','bet']}," +
            "'Flagging':{'Enabled':true,'AllowSave':true,'AllowDelete':true,'AllowExport':true,'AllowChangeSeen':true,'AllowViewFlag':true,'RestrictedDepartment':['bt','pr','bet']}," +
            "'Monitoring':{'Enabled':true}," +
            "'RatioTracker':{'Enabled':true}," +
            "'IdleTracker':{'Enabled':true}," +
            "'WaitTracker':{'Enabled':true}," +
            "'FilesDue':{'Enabled':true}," +
            "'UserList':{'Enabled':true,'AllowSave':true}," +
            "'WorkFlow':{'Enabled':true}," +
            "'UploadFunction':{'Enabled':true}," +
            "'ExportFunction':{'Enabled':true}," +
            "'ArchiveFunction':{'Enabled':true}," +
            "'ReportLog':{'Enabled':true,'AllowViewBreakLog':true,'AllowViewIdleLog':true,'BreakLogRestrictedDepartment':['bt','pr','bet'],'IdleLogRestrictedDepartment':['bt','pr','bet']}," +
            "'ReferenceFunction':{'Enabled':true}," +
            "'BTFileFunction':{'Enabled':true}," +
            "'FilePriority':true}";
        /// <summary>
        /// Get a preset of restriction base on department and position.
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public string GetPresetRestriction(string dep = "", string pos = "")
        {
            string preset = DefaultRestriction;
            if (new string[] { "sup", "tl" }.Contains(pos))
            {
                preset = "{'FilePriority':true," +
                    "'FileInformation':{'Enabled':true,'DueDate':true,'ServiceDate':true,'Client':true,'Branch':true,'Receive':true,'DurationInfo':true,'PageInfo':true,'Accuracy':true}," +
                    "'WorkFile':{'Enabled':true,'AudioFile':true,'DocumentInfo':true}," +
                    "'AssignUser':{'Enabled':true," +
                    "'BT':" + (dep == "bt" ? "true" : "false") + "," +
                    "'PR':" + (dep == "pr" ? "true" : "false") + "," +
                    "'ST':" + (dep == "bet" ? "true" : "false") + "," +
                    "'CC':" + (dep == "bet" ? "true" : "false") + "," +
                    "'BTQA':" + (dep == "bt" ? "true" : "false") + "," +
                    "'PRQA':" + (dep == "pr" ? "true" : "false") + "," +
                    "'STQA':" + (dep == "bet" ? "true" : "false") + "," +
                    "'CCQA':" + (dep == "bet" ? "true" : "false") + "}," +
                    "'FileEval':{'Enabled':true,'AllowCreateEval':" + (dep == "pr" ? "true" : "false") + ",'AllowViewEval':true,'AllowExport':true,'RestrictedDepartment':['" + dep.ToLower() + "']}," +
                    "'FileReturn':{'Enabled':true,'AllowSave':true,'AllowDelete':true,'AllowExport':true,'AllowChangeSeen':true,'AllowViewReturn':true,'RestrictedDepartment':['" + (dep == "bet" ? "pr" : "bt") + "']}," +
                    "'Flagging':{'Enabled':true,'AllowSave':true,'AllowDelete':true,'AllowExport':true,'AllowChangeSeen':true,'AllowViewFlag':true,'RestrictedDepartment':['" + dep.ToLower() + "']}," +
                    "'Monitoring':{'Enabled':true}," +
                    "'RatioTracker':{'Enabled':true}," +
                    "'IdleTracker':{'Enabled':true}," +
                    "'WaitTracker':{'Enabled':true}," +
                    "'FilesDue':{'Enabled':true}," +
                    "'UserList':{'Enabled':true,'AllowSave':true}," +
                    "'WorkFlow':{'Enabled':false}," +
                    "'UploadFunction':{'Enabled':false}," +
                    "'ExportFunction':{'Enabled':false}," +
                    "'ArchiveFunction':{'Enabled':false}," +
                    "'ReportLog':{'Enabled':true,'AllowViewBreakLog':true,'AllowViewIdleLog':true,'BreakLogRestrictedDepartment':['" + dep.ToLower() + "'],'IdleLogRestrictedDepartment':['" + dep.ToLower() + "']}," +
                    "'ReferenceFunction':{'Enabled':" + (dep == "bet" ? "true" : "false") + "}," +
                    "'BTFileFunction':{'Enabled':true}," +
                    "'FilePriority':false}";
            }
            else if (pos == "sched")
            {
                preset = "{'FilePriority':true," +
                    "'FileInformation':{'Enabled':true,'DueDate':true,'ServiceDate':true,'Client':true,'Branch':true,'Receive':true,'DurationInfo':true,'PageInfo':true,'Accuracy':true}," +
                    "'WorkFile':{'Enabled':true,'AudioFile':true,'DocumentInfo':true}," +
                    "'AssignUser':{'Enabled':true," +
                    "'BT':" + (dep == "bt" ? "true" : "false") + "," +
                    "'PR':" + (dep == "pr" ? "true" : "false") + "," +
                    "'ST':" + (dep == "bet" ? "true" : "false") + "," +
                    "'CC':" + (dep == "bet" ? "true" : "false") + "," +
                    "'BTQA':" + (dep == "bt" ? "true" : "false") + "," +
                    "'PRQA':" + (dep == "pr" ? "true" : "false") + "," +
                    "'STQA':" + (dep == "bet" ? "true" : "false") + "," +
                    "'CCQA':" + (dep == "bet" ? "true" : "false") + "}," +
                    "'FileEval':{'Enabled':true,'AllowCreateEval':" + (dep == "pr" ? "true" : "false") + ",'AllowViewEval':true,'AllowExport':true,'RestrictedDepartment':['" + dep.ToLower() + "']}," +
                    "'FileReturn':{'Enabled':true,'AllowSave':false,'AllowDelete':false,'AllowExport':false,'AllowChangeSeen':false,'AllowViewReturn':true,'RestrictedDepartment':['" + (dep == "bet" ? "pr" : "bt") + "']}," +
                    "'Flagging':{'Enabled':true,'AllowSave':true,'AllowDelete':true,'AllowExport':true,'AllowChangeSeen':true,'AllowViewFlag':true,'RestrictedDepartment':['" + dep.ToLower() + "']}," +
                    "'Monitoring':{'Enabled':true}," +
                    "'RatioTracker':{'Enabled':true}," +
                    "'IdleTracker':{'Enabled':true}," +
                    "'WaitTracker':{'Enabled':true}," +
                    "'FilesDue':{'Enabled':true}," +
                    "'UserList':{'Enabled':true,'AllowSave':true}," +
                    "'WorkFlow':{'Enabled':false}," +
                    "'UploadFunction':{'Enabled':true}," +
                    "'ExportFunction':{'Enabled':false}," +
                    "'ArchiveFunction':{'Enabled':false}," +
                    "'ReportLog':{'Enabled':true,'AllowViewBreakLog':true,'AllowViewIdleLog':true,'BreakLogRestrictedDepartment':['" + dep.ToLower() + "'],'IdleLogRestrictedDepartment':['" + dep.ToLower() + "']}," +
                    "'ReferenceFunction':{'Enabled':" + (dep == "bet" ? "true" : "false") + "}," +
                    "'BTFileFunction':{'Enabled':true}," +
                    "'FilePriority':false}";
            }
            else if (pos == "prod")
            {
                preset = "{'FilePriority':false," +
                    "'FileInformation':{'Enabled':false,'DueDate':true,'ServiceDate':true,'Client':true,'Branch':true,'Receive':true,'DurationInfo':true,'PageInfo':true,'Accuracy':true}," +
                    "'WorkFile':{'Enabled':true,'AudioFile':true,'DocumentInfo':true}," +
                    "'AssignUser':{'Enabled':false,'BT':true,'PR':true,'ST':true,'CC':true,'BTQA':true,'PRQA':true,'STQA':true,'CCQA':true}," +
                    "'FileEval':{'Enabled':" + (dep == "pr" ? "true" : "false") + ",'AllowCreateEval':true,'AllowViewEval':false,'AllowExport':true,'RestrictedDepartment':['bt','pr','bet']}," +
                    "'FileReturn':{'Enabled':true,'AllowSave':" + (new string[] { "bet", "pr" }.Contains(dep) ? "true" : "false") + ",'AllowDelete':false,'AllowExport':false,'AllowChangeSeen':false,'AllowViewReturn':false,'RestrictedDepartment':['bt','pr','bet']}," +
                    "'Flagging':{'Enabled':true,'AllowSave':true,'AllowDelete':false,'AllowExport':false,'AllowChangeSeen':false,'AllowViewFlag':false,'RestrictedDepartment':['bt','pr','bet']}," +
                    "'Monitoring':{'Enabled':false}," +
                    "'RatioTracker':{'Enabled':false}," +
                    "'IdleTracker':{'Enabled':false}," +
                    "'WaitTracker':{'Enabled':false}," +
                    "'FilesDue':{'Enabled':false}," +
                    "'UserList':{'Enabled':false,'AllowSave':true}," +
                    "'WorkFlow':{'Enabled':false}," +
                    "'UploadFunction':{'Enabled':false}," +
                    "'ExportFunction':{'Enabled':false}," +
                    "'ArchiveFunction':{'Enabled':false}," +
                    "'ReportLog':{'Enabled':false,'AllowViewBreakLog':false,'AllowViewIdleLog':false,'BreakLogRestrictedDepartment':['bt','pr','bet'],'IdleLogRestrictedDepartment':['bt','pr','bet']}," +
                    "'ReferenceFunction':{'Enabled':" + (dep == "bet" ? "true" : "false") + "}," +
                    "'BTFileFunction':{'Enabled':false}," +
                    "'FilePriority':" + (dep == "pr" ? "true" : "false") + "}";
            }
            else if (pos == "ts")
            {
                preset = "{'FilePriority':true," +
                    "'FileInformation':{'Enabled':true,'DueDate':true,'ServiceDate':true,'Client':true,'Branch':true,'Receive':true,'DurationInfo':true,'PageInfo':true,'Accuracy':true}," +
                    "'WorkFile':{'Enabled':true,'AudioFile':true,'DocumentInfo':true}," +
                    "'AssignUser':{'Enabled':false,'BT':true,'PR':true,'ST':true,'CC':true,'BTQA':true,'PRQA':true,'STQA':true,'CCQA':true}," +
                    "'FileEval':{'Enabled':false,'AllowCreateEval':true,'AllowViewEval':true,'AllowExport':true,'RestrictedDepartment':['bt','pr','bet']}," +
                    "'FileReturn':{'Enabled':true,'AllowSave':false,'AllowDelete':false,'AllowExport':true,'AllowChangeSeen':true,'AllowViewReturn':true,'RestrictedDepartment':['bt','pr','bet']}," +
                    "'Flagging':{'Enabled':true,'AllowSave':false,'AllowDelete':false,'AllowExport':true,'AllowChangeSeen':true,'AllowViewFlag':true,'RestrictedDepartment':['bt','pr','bet']}," +
                    "'Monitoring':{'Enabled':true}," +
                    "'RatioTracker':{'Enabled':true}," +
                    "'IdleTracker':{'Enabled':true}," +
                    "'WaitTracker':{'Enabled':true}," +
                    "'FilesDue':{'Enabled':true}," +
                    "'UserList':{'Enabled':true,'AllowSave':true}," +
                    "'WorkFlow':{'Enabled':true}," +
                    "'UploadFunction':{'Enabled':true}," +
                    "'ExportFunction':{'Enabled':true}," +
                    "'ArchiveFunction':{'Enabled':false}," +
                    "'ReportLog':{'Enabled':true,'AllowViewBreakLog':true,'AllowViewIdleLog':true,'BreakLogRestrictedDepartment':['bt','pr','bet'],'IdleLogRestrictedDepartment':['bt','pr','bet']}," +
                    "'ReferenceFunction':{'Enabled':false}," +
                    "'BTFileFunction':{'Enabled':true}," +
                    "'FilePriority':false}";
            }
            return preset;
        }
    }

    /// <summary>
    /// Restriction for File Priority
    /// </summary>
    public class FilePriority
    {
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for Return file button
    /// </summary>
    public class ReturnFileButton
    {
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for File Information that will enable/disable user to edit the File Information
    /// </summary>
    public class FileInformation
    {
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool DueDate { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool ServiceDate { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Client { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Branch { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Receive { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool DurationInfo { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool PageInfo { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Accuracy { get; set; } = true;
    }
    public class WorkFile
    {
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool AudioFile { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool DocumentInfo { get; set; } = true;
    }
    public class AssignUser
    {
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool BT { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool PR { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool ST { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool CC { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool BTQA { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool PRQA { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool STQA { get; set; } = true;
        /// <summary>
        /// Default: <see langword="true"/>
        /// </summary>
        public bool CCQA { get; set; } = true;
    }
    /// <summary>
    /// Restriction for file evaluation
    /// </summary>
    public class FileEval
    {
        public bool Enabled { get; set; } = true;
        public bool AllowCreateEval { get; set; } = true;
        public bool AllowViewEval { get; set; } = true;
        public bool AllowExport { get; set; } = true;
        /// <summary>
        /// List of department that will filter the user list when <seealso cref="AllowViewEval"/> is set to <see langword="true"/>
        /// <para>Default: new string[] { "bt","pr","bet"}</para>
        /// </summary>
        public string[] RestrictedDepartment { get; set; } = new string[] { "bt","pr","bet"};
    }
    /// <summary>
    /// Restriction for file return
    /// </summary>
    public class FileReturn
    {
        public bool Enabled { get; set; } = true;
        public bool AllowSave { get; set; } = true;
        public bool AllowDelete { get; set; } = true;
        public bool AllowExport { get; set; } = true;
        public bool AllowChangeSeen { get; set; } = true;
        public bool AllowViewReturn { get; set; } = true;
        /// <summary>
        /// List of department that will filter the flag list when <seealso cref="AllowViewReturn"/> is set to <see langword="true"/>
        /// <para>Default: new string[] { "bt","pr","bet"}</para>
        /// </summary>
        public string[] RestrictedDepartment { get; set; } = new string[] { "bt", "pr", "bet" };
    }
    /// <summary>
    /// Restriction for flagging
    /// </summary>
    public class Flagging
    {
        public bool Enabled { get; set; } = true;
        public bool AllowSave { get; set; } = true;
        public bool AllowDelete { get; set; } = true;
        public bool AllowExport { get; set; } = true;
        public bool AllowChangeSeen { get; set; } = true;
        public bool AllowViewFlag { get; set; } = true;
        /// <summary>
        /// List of department that will filter the flag list when <seealso cref="AllowViewFlag"/> is set to <see langword="true"/>
        /// <para>Default: new string[] { "bt","pr","bet"}</para>
        /// </summary>
        public string[] RestrictedDepartment { get; set; } = new string[] { "bt", "pr", "bet" };
    }
    /// <summary>
    /// Restriction for monitoring
    /// </summary>
    public class Monitoring
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for QRTracker
    /// </summary>
    public class RatioTracker
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for idle tracker
    /// </summary>
    public class IdleTracker
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for wait tracker
    /// </summary>
    public class WaitTracker
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for files on due
    /// </summary>
    public class FilesDue
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for user list
    /// </summary>
    public class UserList
    {
        public bool Enabled { get; set; } = true;
        public bool AllowSave { get; set; } = true;
    }
    /// <summary>
    /// Restriction for work flow
    /// </summary>
    public class WorkFlow
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for upload function
    /// </summary>
    public class UploadFunction
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for export function
    /// </summary>
    public class ExportFunction
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for archive function
    /// </summary>
    public class ArchiveFunction
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for report log
    /// </summary>
    public class ReportLog
    {
        public bool Enabled { get; set; } = true;
        public bool AllowViewBreakLog { get; set; } = true;
        public bool AllowViewIdleLog { get; set; } = true;
        /// <summary>
        /// List of department that will filter the break log list when <seealso cref="AllowViewBreakLog"/> is set to <see langword="true"/>
        /// <para>Default: new string[] { "bt","pr","bet"}</para>
        /// </summary>
        public string[] BreakLogRestrictedDepartment { get; set; } = new string[] { "bt", "pr", "bet" };
        /// <summary>
        /// List of department that will filter the idle log list when <seealso cref="AllowViewIdleLog"/> is set to <see langword="true"/>
        /// <para>Default: new string[] { "bt","pr","bet"}</para>
        /// </summary>
        public string[] IdleLogRestrictedDepartment { get; set; } = new string[] { "bt", "pr", "bet" };
    }
    /// <summary>
    /// Restriction for reference
    /// </summary>
    public class ReferenceFunction
    {
        public bool Enabled { get; set; } = true;
    }
    /// <summary>
    /// Restriction for bt file
    /// </summary>
    public class BTFileFunction
    {
        public bool Enabled { get; set; } = true;
    }
}
