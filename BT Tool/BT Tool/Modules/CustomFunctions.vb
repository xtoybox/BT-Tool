Imports BT_Tool.BorderStyleNoneExtensions
Imports BT_Tool.BorderStyleNoneExtensions.Resizer
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class CustomFunctions
    ''' <summary>
    ''' Used for custom dropdown menu and <see cref="IsFormOpen(String, Boolean, String)"/> function.
    ''' </summary>
    Private frm As New Form()
    ''' <summary>
    ''' used for the <see cref="IsFormOpen(String, Boolean, String)"/> function.
    ''' </summary>
    Public GetForm As Form
    ''' <summary>
    ''' Setting the value of <see cref="frm"/>
    ''' </summary>
    ''' <param name="f"></param>
    Public Sub SetForm(ByRef f As Form)
        frm = f
    End Sub
    ''' <summary>
    ''' Getting the shared function SetWindowText from user32.dll
    ''' </summary>
    ''' <param name="hwnd"></param>
    ''' <param name="lpString"></param>
    ''' <returns></returns>
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function SetWindowText(ByVal hwnd As IntPtr, ByVal lpString As String) As Boolean
    End Function
    ''' <summary>
    ''' Execute a sub routine when form is resize.
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <param name="lbltxt"></param>
    Public Sub FormResize(ByVal frm As Form, ByVal lbltxt As String)
        'resize functionality
        Dim _resizer As New Resizer(frm)
        _resizer.Compass = CardinalDirection.All
        'or you can assign values this way in bitwise
        _resizer.Compass =
            CardinalDirection.East _
            Or CardinalDirection.South _
            Or CardinalDirection.North _
            Or CardinalDirection.West _
            Or CardinalDirection.SouthWest _
            Or CardinalDirection.SouthEast _
            Or CardinalDirection.NorthWest _
            Or CardinalDirection.NorthEast

        SetWindowText(frm.Handle.ToInt32, lbltxt)
    End Sub
    ''' <summary>
    ''' Make custom object as a trigger for the form to drag.
    ''' </summary>
    ''' <param name="frm">The form that contains the object as trigger</param>
    ''' <param name="trggr">The object that will trigger the drag event</param>
    Public Sub FormDrag(ByVal frm As Form, ByVal trggr As Object)
        'drag functionality
        Dim _dragger As New Dragger({trggr, frm})

    End Sub
    ''' <summary>
    ''' Setting the panel location at the bottom of the button and adding event handler to the button to trigger a dropdown effect to the panel.
    ''' </summary>
    ''' <param name="pnlName">The panel that contains the buttons as menu</param>
    ''' <param name="btnName">The button that will toggle the panel visibility</param>
    Public Sub ButtonDropdownLocation(ByVal pnlName As Panel, ByVal btnName As Button)
        'set panel location
        Dim pnlW As Integer = pnlName.Width
        Dim btnW As Integer = btnName.Width
        Dim btnH As Integer = btnName.Height
        Dim btnLeftLoc As Integer = btnName.Left
        Dim btnTopLoc As Integer = btnName.Top

        pnlName.Left = ((btnLeftLoc - pnlW) + btnH)
        pnlName.Top = -1
        DropdownHeight(pnlName)

        AddHandler btnName.Click, AddressOf DropDownBtn_Click
    End Sub
    ''' <summary>
    ''' Removing the event handler of a button that toggle the panel visibility.
    ''' </summary>
    ''' <param name="btnName"></param>
    Public Sub ButtonDropdownRemoveHandler(ByVal btnName As Button)
        RemoveHandler btnName.Click, AddressOf DropDownBtn_Click
    End Sub
    ''' <summary>
    ''' Adding event handler that will toggle the panel visibility.
    ''' </summary>
    ''' <param name="btnName"></param>
    Public Sub ButtonDropdownAddHandler(ByVal btnName As Button)
        AddHandler btnName.Click, AddressOf DropDownBtn_Click
    End Sub
    ''' <summary>
    ''' Setting the panel height base on the total height of te buttons contained inside the panel.
    ''' </summary>
    ''' <param name="pnl"></param>
    Public Sub DropdownHeight(ByVal pnl As Panel)
        Dim pnlH As Integer = 0
        Dim allbtn As New List(Of Control)
        For Each btns As Button In FindControlRecursive(allbtn, pnl, GetType(Button))
            pnlH = pnlH + btns.Height
        Next
        pnl.Height = pnlH + 2
    End Sub
    ''' <summary>
    ''' Execute a click event the button that toggles the panel visibility is click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DropDownBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim allbtn As New List(Of Control)
        For Each btns As Button In FindControlRecursive(allbtn, frm, GetType(Button))
            If btns.Tag IsNot Nothing Then
                Dim tagArr As String() = btns.Tag.ToString().Split(",")
                If tagArr(0) = "dropdown" Then
                    If btns.Name <> btn.Name Then
                        frm.Controls.Find(tagArr(1), True).FirstOrDefault().Visible = False
                        btns.BackColor = Color.White
                    Else
                        If btns.BackColor = Color.White Then
                            frm.Controls.Find(tagArr(1), True).FirstOrDefault().Visible = True
                            btn.BackColor = Color.FromArgb(220, 221, 223)
                        Else
                            frm.Controls.Find(tagArr(1), True).FirstOrDefault().Visible = False
                            btns.BackColor = Color.White
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' List all of the controls contained inside a set parent control.
    ''' </summary>
    ''' <param name="list"></param>
    ''' <param name="parent">The control in which the seach is rooted.</param>
    ''' <param name="ctrlType">The type of control to be search</param>
    ''' <returns></returns>
    Public Function FindControlRecursive(ByVal list As List(Of Control), ByVal parent As Control, ByVal ctrlType As System.Type) As List(Of Control)
        If parent Is Nothing Then Return list
        If parent.GetType Is ctrlType Then
            list.Add(parent)
        End If
        For Each child As Control In parent.Controls
            FindControlRecursive(list, child, ctrlType)
        Next
        Return list
    End Function
    ''' <summary>
    ''' Creating a file containing the text.
    ''' <para>It can also put a datetime log by adding {0} to the text.</para>
    ''' </summary>
    ''' <param name="txt">The text that will be written inside the text file.</param>
    ''' <param name="path">The file path and name of the text file.</param>
    Public Sub WriteToFile(ByVal txt As String, ByVal path As String)
        Using wr As StreamWriter = New StreamWriter(path, True)
            wr.WriteLine(String.Format(txt, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")))
        End Using
    End Sub
    ''' <summary>
    ''' Checking a given string if it is <see langword="NULL"/>, Empty, or only space 
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns>Boolean</returns>
    Public Function isEmpty(ByVal str As String) As Boolean
        Dim r As Boolean = False
        If String.IsNullOrEmpty(str) Or String.IsNullOrWhiteSpace(str) Then
            r = True
        End If
        Return r
    End Function
    ''' <summary>
    ''' Checking if a file exist in a given path
    ''' </summary>
    ''' <param name="path">The file path and file name.</param>
    ''' <param name="expected">The expected result of the checking.</param>
    ''' <returns>String</returns>
    Public Function IsExist(ByVal path As String, ByVal expected As Boolean) As String
        Dim r = "ok"
        Dim nAttempts As Integer = 0
        Dim ops As Boolean
        If expected Then
            ops = False
        Else
            ops = True
        End If
recheckfile:
        If File.Exists(path) = ops Then
            If nAttempts <= 5 Then
                GoTo recheckfile
            ElseIf nAttempts > 5 Then
                r = "failed"
            End If
            nAttempts = nAttempts + 1
        End If
        Return r
    End Function
    ''' <summary>
    ''' Setting the row number of the datagridview.
    ''' <para>Note: The row number is only visible if the RowHeadersVisible property of the datagridview is set to <see langword="True"/>.</para>
    ''' </summary>
    ''' <param name="dgv"></param>
    Public Sub RowsNumber(ByVal dgv As DataGridView)
        Dim i2 As Integer = 1
        For Each row As DataGridViewRow In dgv.Rows
            row.HeaderCell.Value = i2.ToString()
            i2 = i2 + 1
        Next
    End Sub
    ''' <summary>
    ''' Converting the given filesize into a user-friendly readable file size.
    ''' </summary>
    ''' <param name="TheSize"></param>
    ''' <returns>Double</returns>
    Public Function FormatFileSize(ByVal TheSize As Double)
        Dim DoubleBytes As Double
        Select Case TheSize
            Case Is >= 1099511627776
                DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
                Return FormatNumber(DoubleBytes, 2) & " TB"
            Case 1073741824 To 1099511627775
                DoubleBytes = CDbl(TheSize / 1073741824) 'GB
                Return FormatNumber(DoubleBytes, 2) & " GB"
            Case 1048576 To 1073741823
                DoubleBytes = CDbl(TheSize / 1048576) 'MB
                Return FormatNumber(DoubleBytes, 2) & " MB"
            Case 1024 To 1048575
                DoubleBytes = CDbl(TheSize / 1024) 'KB
                Return FormatNumber(DoubleBytes, 2) & " KB"
            Case 0 To 1023
                DoubleBytes = TheSize ' bytes
                Return FormatNumber(DoubleBytes, 2) & " bytes"
            Case Else
                Return ""
        End Select
    End Function
    ''' <summary>
    ''' Convert seconds to 24 hour format.
    ''' </summary>
    ''' <param name="sec"></param>
    ''' <returns>String</returns>
    Public Function SecondsToTime24(ByVal sec As Double) As String
        Dim ts As New TimeSpan(0, 0, sec)
        Dim hoursStr As String = String.Format(
            "{0:00}:{1:00}:{2:00}",
            ts.TotalHours, ts.Minutes, ts.Seconds)

        Return hoursStr
    End Function
    ''' <summary>
    ''' Checking if the given form is open.
    ''' </summary>
    ''' <param name="FormName">The name of the form.</param>
    ''' <param name="CheckTag">(Optional) If set to <see langword="True"/> then it will also check if the form tag is equal to the <paramref name="TagValue"/>.</param>
    ''' <param name="TagValue">(Optional) Used only if the <paramref name="CheckTag"/> is set to <see langword="True"/></param>
    ''' <returns>Boolean</returns>
    Public Function IsFormOpen(ByVal FormName As String, Optional ByVal CheckTag As Boolean = False, Optional ByVal TagValue As String = "") As Boolean
        Dim isOpen As Boolean = False
        For Each frm As Form In My.Application.OpenForms
            If frm.Name = FormName Then
                If CheckTag Then
                    Dim t As String = frm.Tag.ToString()
                    If t = TagValue Then
                        isOpen = True
                        Me.GetForm = frm
                        Exit For
                    End If
                Else
                    isOpen = True
                    Me.GetForm = frm
                    Exit For
                End If
            End If
        Next
        Return isOpen
    End Function
    ''' <summary>
    ''' Used on Try Catch and alert the user of the <seealso cref="Exception"/> by poping a <seealso cref="MessageBox"/> containing the <seealso cref="Exception.Message"/>.
    ''' </summary>
    ''' <param name="ex">The <seealso cref="Exception"/> thrown by the Try Catch.</param>
    ''' <param name="log">(Optional) if set to <see langword="True"/> then write a file containing the <seealso cref="Exception"/> details in the MyDocuments</param>
    Public Sub DebugMsg(ByVal ex As Exception, Optional ByVal log As Boolean = False)
        If log Then
            Me.WriteToFile("{0}===>" & ex.ToString(), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\BTTOOL_Error.txt")
        End If
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    ''' <summary>
    ''' Another version of <seealso cref="DebugMsg(Exception, Boolean)"/> but unlike <seealso cref="DebugMsg(Exception, Boolean)"/>, this will always log the <seealso cref="Exception"/>.
    ''' </summary>
    ''' <param name="ex"><seealso cref="Exception"/> from the Try Catch.</param>
    ''' <param name="msg">(optional) a custom message to be used for the <seealso cref="MessageBox"/>.</param>
    Public Sub ErrorLog(ByVal ex As Exception, Optional msg As String = Nothing)
        If msg Is Nothing Then msg = "Something went wrong. Check error log for more details of the error encountered."
        Me.WriteToFile("{0}==>" & ex.ToString(), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BTTOOL_Error_Log.txt")
        MessageBox.Show(msg & vbNewLine & Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BTTOOL_Error_Log.txt", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class
