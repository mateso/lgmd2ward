Imports Microsoft.SqlServer.Management.Common
Imports System.Windows.Forms.MessageBox
Imports Microsoft.SqlServer.Management.Smo
Imports LGMD.ApplicationGlobal
Imports System.Collections.Specialized

Public Class frmDatabaseUtilities

    Private bError As Boolean
    Private strExArg As String
    Private dt As DataTable

    Public Sub New()

        InitializeComponent()

    End Sub

    Public Sub New(ByVal connection As ServerConnection, Optional ByVal strExArgument As String = "")

        InitializeComponent()
        Try
            ApplicationGlobal.sqlServerConnection = connection
        Catch ex As Exception
        End Try

        strExArg = strExArgument
    End Sub

    Private Sub frmDatabaseUtilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetServerList()

        ProcessWindowsAuthentication()

        CreateFirstDatabase()
    End Sub

    Private Sub radioBtnWindowsAuthentication_CheckedChanged(sender As Object, e As EventArgs) Handles radioBtnWindowsAuthentication.CheckedChanged
        ProcessWindowsAuthentication()
    End Sub

    Private Sub cmbDatabases_Enter(sender As Object, e As EventArgs) Handles cmbDatabases.Enter
        Me.cmbDatabases.Items.Clear()
        'If DatabasesComboBox.Items.Count = 0 Then
        fnConnectToServer()
        ShowDatabases(False)
        'End If
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Dim csr As Cursor = Nothing

        Try
            If Me.cmbDatabases.Text.Length = 0 Then
                MsgBox("There is no selected database")
                Exit Sub
            End If
            If Not HasRightTables() Then
                MsgBox("The selected database has invalid structure for LGMD Application")
                Exit Sub
            End If

            Select Case strExArg
                Case "dBDetails"
                    objUserctrl = New ctrlDatabaseDetails
                    objFrmMain.getControl("DatabaseDetails")
                Case "dBLoggin"
                    Dim hk As New frmLogin
                    If Not objFrmLogin Is Nothing Then
                        objFrmLogin.Close()
                        objFrmLogin = Nothing
                    End If
                    objFrmLogin = hk
                    objFrmLogin.ShowDialog()
                    Me.Dispose()
                Case Else
                    MessageBox.Show("Connected successfully")
                    ApplicationGlobal.dbCurrentDatabase = Me.cmbDatabases.SelectedItem.ToString()

                    If Not ApplicationGlobal.sqlServerConnection.ConnectionString.Contains("Initial Catalog") Then
                        My.Settings.DataConnectionString = ApplicationGlobal.sqlServerConnection.ConnectionString & ";Initial Catalog=" & Replace(Replace(Me.cmbDatabases.Text, "[", ""), "]", "")
                    Else
                        My.Settings.DataConnectionString = Replace(My.Settings.DataConnectionString, My.Settings.databaseName, Replace(Replace(Me.cmbDatabases.Text, "[", ""), "]", ""))
                    End If

                    My.Settings.DataConnectionString = Replace(My.Settings.DataConnectionString, My.Settings.DataConnectionString.Split(";")(0), "Data Source=" & Me.cmbServerNames.Text)

                    My.Settings.sqlServerName = Replace(Replace(Me.cmbServerNames.Text, "[", ""), "]", "")
                    My.Settings.databaseName = Replace(Replace(Me.cmbDatabases.Text, "[", ""), "]", "")
                    My.Settings.Save()

                    'Set flag to restart the application
                    My.Application.RestartOnShutdown = True

                    'Close the current application instance
                    Application.Exit()
            End Select
        Catch ex As ConnectionFailureException
            Dim emb As New ExceptionMessageBox(ex)
            'emb.Show(Me)
            bError = True
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            'emb.Show(Me)
            bError = True
        Finally
            ' Restore the original cursor
            csr = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Not ApplicationGlobal.dbCurrentDatabase Is Nothing Then
            Me.Hide()
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub GetServerList()
        dt = New DataTable
        lblProgress.Visible = True
        lblProgress.Refresh()
        'worker.ReportProgress(1, "Loading...")
        progressBarLogin.Update()
        progressBarLogin.Visible = True
        progressBarLogin.Value = progressBarLogin.Minimum

        Try
            ' Get list of SQL Servers
            dt = SmoApplication.EnumAvailableSqlServers(False)

            If (dt.Rows.Count > 0) Then
                ' Load server names into combo box
                For Each row As DataRow In dt.Rows
                    'If dr.Item(4).ToString.StartsWith("9.") Then  'This if adds only ver9 of SQL Server
                    cmbServerNames.Items.Add(row("Name"))
                    'End If
                Next
                ' Default to this machine 
                'cmbServerNames.Text = ServerNamesComboBox.FindStringExact(Environment.MachineName) & "\SQLEXPRESS"
                cmbServerNames.Text = Environment.MachineName & "\SQLEXPRESS"
            End If
        Catch ex As Exception
            Dim emb As New ExceptionMessageBox()
            emb.Text = My.Resources.NoSqlServers
            'emb.Show(Me)
        Finally
            lblProgress.Visible = False
            lblProgress.Refresh()
            progressBarLogin.Visible = False
            progressBarLogin.Value = progressBarLogin.Minimum
        End Try
    End Sub

    Private Sub ProcessWindowsAuthentication()
        If radioBtnWindowsAuthentication.Checked = True Then
            txtUsername.Enabled = False
            txtPassword.Enabled = False
        Else
            txtUsername.Enabled = True
            txtPassword.Enabled = True
        End If
    End Sub

    Private Sub OnSqlInfoMessage(ByVal sender As Object, ByVal args As System.Data.SqlClient.SqlInfoMessageEventArgs)
        Dim err As SqlClient.SqlError
        Dim emb As ExceptionMessageBox

        For Each err In args.Errors
            emb = New ExceptionMessageBox()
            emb.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, _
                My.Resources.SqlError, err.Source, _
                err.Class, err.State, err.Number, err.LineNumber, _
                err.Procedure, err.Server, err.Message)
            'emb.Show(Me)
        Next
    End Sub

    Private Sub OnServerMessage(ByVal sender As Object, ByVal args As ServerMessageEventArgs)
        Dim err As SqlClient.SqlError = args.Error

        Dim emb As New ExceptionMessageBox()
        emb.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, _
           My.Resources.SqlError, err.Source, _
          err.Class, err.State, err.Number, err.LineNumber, _
          err.Procedure, err.Server, err.Message)
        'emb.Show(Me)
    End Sub

    Private Sub OnStateChange(ByVal sender As Object, ByVal args As StateChangeEventArgs)
        If (Me.IsDisposed = False) Then
            Dim emb As New ExceptionMessageBox()
            emb.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, _
            My.Resources.StateChanged, _
                 args.OriginalState.ToString(), args.CurrentState.ToString())
            'emb.Show(Me)
        End If
    End Sub

    Private Sub OnStatementExecuted(ByVal sender As Object, ByVal args As StatementEventArgs)
        Dim emb As New ExceptionMessageBox()
        emb.Text = args.SqlStatement
        'emb.Show(Me)
    End Sub

    Private Sub ShowDatabases(ByVal selectDefault As Boolean)

        Dim csr As Cursor = Nothing
        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

            If ApplicationGlobal.sqlServerConnection.SqlConnectionObject.State = ConnectionState.Open Then
                ApplicationGlobal.sqlServer = New Microsoft.SqlServer.Management.Smo.Server(ApplicationGlobal.sqlServerConnection)
                If Not (ApplicationGlobal.sqlServer Is Nothing) Then
                End If
            Else
                Exit Sub
            End If

            ' Clear control
            cmbDatabases.Items.Clear()

            ' Limit the properties returned to just those that we use

            ApplicationGlobal.sqlServer.SetDefaultInitFields(GetType(Database), New String() {"Name", "IsSystemObject", "IsAccessible"})

            ' Add database objects to combobox; the default ToString will display the database name
            ' This was commented by Mateso so as to enable more than one server to be used
            'Try
            '    For Each db As Database In frmMain.SqlServerSelection.Databases
            '        If db.IsSystemObject = False AndAlso db.IsAccessible = True Then
            '            DatabasesComboBox.Items.Add(db)
            '        End If
            '    Next
            'Catch ex As Exception
            'End Try
            Try
                ApplicationGlobal.sqlServer = New Server(Me.cmbServerNames.Text)
                For Each db As Database In ApplicationGlobal.sqlServer.Databases
                    If db.IsSystemObject = False AndAlso db.IsAccessible = True Then
                        cmbDatabases.Items.Add(db)
                    End If
                Next
            Catch ex As Exception
            End Try

            If selectDefault = True AndAlso cmbDatabases.Items.Count > 0 Then
                cmbServerNames.SelectedIndex = cmbServerNames.FindStringExact(Environment.MachineName) + "\SQLEXPRESS"
            End If
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            'emb.Show(Me)
        Finally
            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

    Private Sub CreateFirstDatabase()
        ' Create the database
        Dim sDatabaseName As String
        Dim db As Database
        Dim fg As FileGroup
        Dim df As DataFile
        Dim lf As LogFile
        Dim csr As Cursor = Nothing

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor
            ' Get the name of the new database
            sDatabaseName = "LGMD2iData"

            ' Check for new non-zero length name
            If sDatabaseName.Length = 0 Then
                System.Windows.Forms.MessageBox.Show(Me, _
                My.Resources.NoDatabaseName, Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Error, _
                MessageBoxDefaultButton.Button1, 0)
                Return
            End If

            ' Ensure we have the current list of databases to check.
            Try
                ApplicationGlobal.sqlServer.Databases.Refresh()
            Catch ex As Exception
            End Try

            ' Refresh database list
            ShowDatabases(False)

            ' Is database name new and unique?
            Try
                If (ApplicationGlobal.sqlServer.Databases.Contains(sDatabaseName)) Then
                    Return
                End If
            Catch ex As Exception
            End Try

            ' Attach the database
            Dim sc As StringCollection = New StringCollection()
            Dim owner As String = "dbo"
            Dim logstr As String = ""
            Dim strDatabasesource = My.Computer.FileSystem.GetParentPath(Application.ExecutablePath) & "\Data\LGMD2iDataModel.mdf"
            If Dir(strDatabasesource) = "" Then
                MsgBox("Template File is missing")
                Exit Sub
            End If
            Dim datastr As String = ""  'Me.BackupFileTextBox.Text

            Try
                datastr = My.Computer.FileSystem.GetParentPath(ApplicationGlobal.sqlServer.Databases("master").FileGroups("primary").Files(0).FileName) & "\" & sDatabaseName & ".mdf"
            Catch ex As Exception
            End Try
            My.Computer.FileSystem.CopyFile(strDatabasesource, datastr, True)
            sc.Add(datastr)
            sDatabaseName = "LGMD2iData"
            ' sc.Add(logstr)
            Try
                ApplicationGlobal.sqlServer.AttachDatabase(sDatabaseName, sc, owner, AttachOptions.None)
            Catch ex As Exception
            End Try

            ApplicationGlobal.sqlServer.Databases.Refresh()
            ' Refresh database list
            ShowDatabases(False)

            ' Find and select the database just created
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            'emb.Show(Me)
        Finally
            ' Clean up.
            db = Nothing
            fg = Nothing
            df = Nothing
            lf = Nothing

            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

    Private Function HasRightTables() As Boolean

        ' Return True

        HasRightTables = False

        Dim db As Database

        Dim csr As Cursor = Nothing

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

            ' Clear the tables list

            cmbTables.Items.Clear()

            ' Show the current tables for the selected database

            If cmbDatabases.SelectedIndex >= 0 Then

                db = CType(cmbDatabases.SelectedItem, Database)

                For Each tbl As Table In db.Tables
                    If tbl.IsSystemObject = False Then
                        cmbTables.Items.Add(tbl.Name)
                    End If
                Next

                ' Select the first item in the list

                If cmbTables.Items.Count > 0 Then
                    cmbTables.SelectedIndex = 0
                Else
                End If
            End If

            Dim oneDimArray() As String = {"RecordInfo", "AnnualRecord"}

            For i As Integer = 0 To oneDimArray.GetUpperBound(0)

                Dim strObjectName As String = oneDimArray(i)

                If Not cmbTables.Items.Contains(strObjectName) Then
                    Return False
                End If
            Next

            Return True
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            'emb.Show(Me)
        Finally
            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Function

    Private Function fnConnectToServer() As Boolean
        Dim csr As Cursor = Nothing

        Try
            If cmbServerNames.Text.Length = 0 Then
                MsgBox("No server has been selected")
                Return False
            End If
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

            bError = False ' Assume no error

            ' Recreate connection if necessary
            If Not ApplicationGlobal.sqlServerConnection Is Nothing Then
                If ApplicationGlobal.sqlServerConnection.SqlConnectionObject.State <> ConnectionState.Open Or ApplicationGlobal.sqlServerConnection.ServerInstance <> cmbServerNames.Text Then
                Else
                    Me.Cursor = csr
                    Return True
                End If
            End If
            ApplicationGlobal.sqlServerConnection = Nothing
            If ApplicationGlobal.sqlServerConnection Is Nothing Then
                ApplicationGlobal.sqlServerConnection = New ServerConnection
            End If

            ' Fill in necessary information
            ' If ServerConn.ServerInstance <> ServerNamesComboBox.Text Then
            ApplicationGlobal.sqlServerConnection.ServerInstance = cmbServerNames.Text

            ' Setup capture and execute to be able to display script
            ApplicationGlobal.sqlServerConnection.SqlExecutionModes = SqlExecutionModes.ExecuteAndCaptureSql
            ApplicationGlobal.sqlServerConnection.ConnectTimeout = CType(numericUpDownTimeout.Value, Int32)
            ' End If
            If radioBtnWindowsAuthentication.Checked = True Then
                ' Use Windows authentication
                ApplicationGlobal.sqlServerConnection.LoginSecure = True
            Else
                If txtUsername.Text = "" Then
                    MsgBox("User name is missing")
                    Exit Function
                End If
                ' Use SQL Server authentication
                ApplicationGlobal.sqlServerConnection.LoginSecure = False
                ApplicationGlobal.sqlServerConnection.Login = txtUsername.Text
                ApplicationGlobal.sqlServerConnection.Password = txtPassword.Text
            End If

            If checkBoxDisplayEvents.CheckState = CheckState.Checked Then
                ' TODO Check handlers
                AddHandler ApplicationGlobal.sqlServerConnection.InfoMessage, _
                   AddressOf OnSqlInfoMessage
                AddHandler ApplicationGlobal.sqlServerConnection.ServerMessage, _
                    AddressOf OnServerMessage
                AddHandler ApplicationGlobal.sqlServerConnection.SqlConnectionObject.StateChange, _
                    AddressOf OnStateChange
                AddHandler ApplicationGlobal.sqlServerConnection.StatementExecuted, _
                    AddressOf OnStatementExecuted
            End If

            ApplicationGlobal.sqlServerConnection.Connect()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ' Restore the original cursor
            Me.Cursor = csr
        End Try
        Return True
    End Function
End Class