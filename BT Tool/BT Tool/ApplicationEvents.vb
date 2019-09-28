Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices
Imports System.Windows.Forms
Imports System.IO

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private frm As New Form
        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MessageBox.Show("Unhandled Exception Error:" & vbNewLine & "" & e.Exception.Message & vbNewLine & vbNewLine & e.Exception.ToString() _
                            & vbNewLine & vbNewLine & e.Exception.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.WriteToFile("-------------------------{0}---------------------------")
            Me.WriteToFile(e.Exception.ToString)
            Me.WriteToFile(e.Exception.TargetSite.ToString())
            Me.WriteToFile("-------------------------------------------------------")
            Me.WriteToFile(e.Exception.InnerException.ToString)
            Me.WriteToFile(e.Exception.InnerException.TargetSite.ToString())
        End Sub

        Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            If e.IsNetworkAvailable Then
                frm.Hide()
            Else
                frm.ShowDialog()
            End If
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

            frm.FormBorderStyle = BorderStyle.None
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowInTaskbar = False
            frm.ShowIcon = False
            frm.Height = 50
            frm.Width = 210
            frm.TopMost = True
            frm.BackColor = Color.DimGray
            frm.Padding = New Padding(2)

            frm.Hide()

            Dim lbl As New Label
            lbl.Text = "No Network Connection"
            lbl.ForeColor = Color.Red
            lbl.BackColor = Color.White
            lbl.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            lbl.Dock = DockStyle.Fill
            lbl.TextAlign = ContentAlignment.MiddleCenter

            frm.Controls.Add(lbl)
        End Sub

        Private Sub WriteToFile(txt As String)
            Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BTTOOL_Error_log.txt"
            Using writer As StreamWriter = New StreamWriter(path, True)
                writer.WriteLine(String.Format(txt, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")))
            End Using
        End Sub
    End Class
End Namespace
