Imports System.Data.SqlClient
Imports System.IO

Public Class SQLClass


    Private conStr As String = "@Data Source=ACCOMEDIASVR\VOICEWARE;Initial Catalog=mttool2;Integrated Security=False;User ID=mttool;Password=sysMAN1@#$%;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
    Private mainStr As String = "@Data Source=ACCOMEDIASVR\VOICEWARE;Initial Catalog=mttool2;Integrated Security=False;User ID=mttool;Password=sysMAN1@#$%;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
    Private testStr As String = "@Data Source=ACC-TEST-SQL\SQLEXPRESS;Initial Catalog=mttool2;Integrated Security=True"
    Private cf As New CustomFunctions
    Private conn = New SqlConnection
    Private dtbl As DataTable
    Private affected_rows As Integer
    Private parameters As List(Of String)
    Private cmd As SqlCommand
    Private reader As SqlDataReader
    Private squeryas As String
    Private IsSQLDependency As Boolean
    Public isDbChange As Boolean = False
    Public LogExceptions As Boolean = True


    Public Sub sql()
        conStr = If(cf.ReadAppSetting("contype") Is "NOT FOUND", mainStr, If(cf.ReadAppSetting("contype") Is "test", testStr, mainStr))
        Try
            Dim perm As SqlClientPermission = New SqlClientPermission(Security.Permissions.PermissionState.Unrestricted)
            perm.Demand()
        Catch ex As Exception
            Throw New ApplicationException("No permission")
        End Try

        conn = New SqlConnection(conStr)
        dtbl = New DataTable
        parameters = New List(Of String)

        Try
            conn.Open
            Console.Write("Connection success")
            conn.Close
        Catch e As SqlException
            Dim msg = If(e.ErrorCode = -2, "Connection timeout occured.", e.Message)
            Debug(msg & ". {0}")
            Console.Write(e.ToString)
        End Try

    End Sub

    Public Sub Debug(ByVal [error] As String)
        Console.Write([error] & "/n/r")

        If LogExceptions Then
            Me.WriteToFile([error] & ". {0}")
        End If
    End Sub

    Private Sub WriteToFile(ByVal text As String)
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SQLLOG.txt"

        Using writer = New StreamWriter(path, True)
            writer.WriteLine(String.Format(text, Date.Now.ToString("dd/MM/yyyy hh:mm:ss tt")))
        End Using
    End Sub

    Public Function nQuery(ByVal query As String, ByVal Optional bindings As String() = Nothing) As Integer
        Init(query, bindings)
        Return Me.affected_rows
    End Function

    Friend Class SurroundingClass
        Private Sub Init(ByVal Query As String, ByVal Optional bindings As String() = Nothing)
            If conn.State.ToString IsNot "Open" Then
                conn.Open
            End If

            Using CSharpImpl.__Assign(cmd, New SqlCommand(Query, conn))
                bind(bindings)

                If parameters.Count > 0 Then
                    parameters.ForEach(Function(ByVal parameter As String)
                                           Dim sparameters = parameter.ToString.Split(ChrW(127))
                                           cmd.Parameters.AddWithValue(sparameters(0), sparameters(1))
                                       End Function)
                End If

                Me.isDbChange = False
                Me.squery = Query.ToLower

                If squery.Contains("select") Then

                    If IsSQLDependency Then
                        IniSqlDependency
                    End If

                    Me.dtbl = execDatatable
                End If

                If squery.Contains("delete") OrElse squery.Contains("update") OrElse squery.Contains("insert") Then
                    Me.affected_rows = execNonquery
                End If

                Me.parameters.Clear
            End Using

            conn.Close
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Class
