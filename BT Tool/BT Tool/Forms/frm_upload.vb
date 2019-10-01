Imports System.IO
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks


Public Class frm_upload

    Private CustomFn As New CustomFunctions()
    Private cf As New markform.CustomClass()
    'CONSTANTS
    Private Const OF_SHARE_DENY_WRITE As Integer = &H20S
    'STUCTURES
    Private Structure AVIFileInfo
        Dim dwMaxBytesPerSec As Integer
        Dim dwFlags As Integer
        Dim dwCaps As Integer
        Dim dwStreams As Integer
        Dim dwSuggestedBufferSize As Integer
        Dim dwWidth As Integer
        Dim dwHeight As Integer
        Dim dwScale As Integer
        Dim dwRate As Integer
        Dim dwLength As Integer
        Dim dwEditCount As Integer
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=64)> Public szFileType As String
    End Structure

    'API FUNCTION DECLARATIONS
    Private Declare Function AVIFileOpen Lib "avifil32" Alias "AVIFileOpenA" (ByRef ppfile As Integer, ByVal szFile As String, ByVal mode As Integer, ByVal pclsidHandler As IntPtr) As Integer
    Private Declare Function AVIFileRelease Lib "avifil32" (ByVal pfile As Integer) As Integer
    Private Declare Function AVIFileInfo_Renamed Lib "avifil32" Alias "AVIFileInfoA" (ByVal pfile As Integer, ByRef pfi As AVIFileInfo, ByVal lSize As Integer) As Integer
    Private Declare Sub AVIFileInit Lib "avifil32" ()
    Private Declare Sub AVIFileExit Lib "avifil32" ()

    Public objShell = CreateObject("Shell.Application")

    Dim db As New markDBOClass.DboClass
    Dim uploadDir As String = ""
    Dim cList As List(Of String) = New List(Of String)
    Dim sDir As String = Path.Combine(varMod.BaseServer, "FROOT\AUDIO\UPLOAD")

    Private _cancl As CancellationTokenSource

    Private Sub frm_upload_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub btn_exit_MouseHover(sender As Object, e As EventArgs) Handles btn_exit.MouseHover
        btn_exit.BackColor = Color.Red
    End Sub

    Private Sub btn_exit_MouseLeave(sender As Object, e As EventArgs) Handles btn_exit.MouseLeave
        btn_exit.BackColor = Color.DarkRed
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click

        Try
            upList.Clear()
            prgBar.Value = 0
            Console.WriteLine(servSound)
            Dim dateDue As String = Format(Me.dtp_dueDate.Value, "MM/dd/yyyy")
            Dim dTime As String = Me.dtp_dueTime.Value.ToString("HH:mm")
            Dim ct As Integer = 0

            Dim increment As Integer = 0
            Me.lblStatus.Text = "Uploading"
            For a = 0 To Me.grid1.RowCount - 1
                If Me.grid1.Rows(a).Selected = True Then
                    ct += 1
                End If
            Next

            Dim div = 100 / ct

            Application.DoEvents()
            For Each selrow As DataGridViewRow In Me.grid1.SelectedRows

                Dim dateRec As String = selrow.Cells(0).Value
                Dim client As String = selrow.Cells(1).Value
                Dim branch As String = selrow.Cells(2).Value
                Dim fName As String = selrow.Cells(3).Value
                Dim duration As String = selrow.Cells(4).Value
                'source directory
                Dim sDir As String = selrow.Cells(5).Value
                Dim flow As String = Me.cbo_workflow.Text
                Dim ftype As String = selrow.Cells(6).Value
                Dim cFlow As Integer = 0


                Dim servSound As String = Path.Combine("FROOT\AUDIO", uploadDir, branch)
                Dim gPath As String = Path.Combine(varMod.BaseServer, servSound)
                'If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)

                'If branch <> "" Then
                '    If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)
                'End If

                'get date?
                'Dim newDir As String = Regex.Replace(sDir, "[/\\][/\\]+[A-Za-z0-9._%+-]+[/\\]+[A-Za-z0-9._%+-]+[/\\]", "", RegexOptions.IgnoreCase)
                'Dim newDir As String = Regex.Replace(sDir, varMod.BaseServer, "", RegexOptions.IgnoreCase)
                Dim newDir As String = sDir.Replace(varMod.BaseServer & "\", "")
                Dim serverPath As String = Path.Combine(gPath, fName)

                Try
                    increment = increment + div
                    If increment > prgBar.Maximum Then
                        increment = prgBar.Maximum
                    End If
                    prgBar.Value = increment
                Catch ex As Exception
                    'File.Copy(sFile, serverPath, True)
                    MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo onError
                End Try

                upList.Add(dateRec & "|" & dateDue & "|" & dTime & "|" & client & "|" & branch & "|" & fName & "|" & duration & "|" & newDir & "|" & flow & "|" & cFlow & "|" & ftype)

                Me.grid1.Rows.Remove(selrow)
            Next

            For Each element As String In upList
                Console.WriteLine(element)
            Next

            mainMod.uploadFiles()

            Me.grid1.Refresh()
            prgBar.Value = prgBar.Maximum
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            MsgBox("Upload complete", vbOKOnly, "Upload complete")
            frm_main.fillMain()
            Me.lblStatus.Text = "Upload Complete"
        Catch ex As Exception
            CustomFn.ErrorLog(ex)
        End Try

onError:
    End Sub
End Class