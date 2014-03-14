Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Specialized
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
Imports System.IO
Imports System.Data.SqlClient
Imports LGMD.ApplicationGlobal
Imports Microsoft.Win32
Imports System.Reflection

Public Class frmLogin

    Private Const c_RegistryKey As String = "Software\LGMD\MHESTTemplate"
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private dt As DataTable
    Private cmd As SqlCommand
    Private reader As SqlDataReader
    Private strHostIP As String = ""
    Private appVersion As Version
    Private sc As StringCollection = New StringCollection
    Private defaultDatabaseOwner As String = "dbo"
    Private defaultLogFile As String = ""
    Private defaultDataModel As String = ""
    Private defaultMainDataFile As String = ""
    Private defaultDataFile As String = ""

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        appVersion = Assembly.GetExecutingAssembly().GetName().Version
        Me.lblVersion.Text = "Ver " & appVersion.ToString

        'My.Settings.databaseName = "LGMD2iData"
        'My.Settings.Save()

        Try
            ApplicationGlobal.sqlServerConnection = New ServerConnection(My.Settings.sqlServerName)
            ApplicationGlobal.sqlServer = New Server(sqlServerConnection)
            ApplicationGlobal.sqlServerConnection.ConnectionString = My.Settings.DataConnectionString

            defaultDataModel = Application.StartupPath & "\Data\" & My.Settings.defaultDatabaseName & "Model.mdf"

            defaultDataFile = ApplicationGlobal.sqlServer.Databases("master").PrimaryFilePath & "\" & My.Settings.defaultDatabaseName & ".mdf"

            defaultLogFile = ApplicationGlobal.sqlServer.Databases("master").PrimaryFilePath & "\" & My.Settings.defaultDatabaseName & "_log.ldf"

            'defaultMainDataFile = ApplicationGlobal.sqlServer.Databases("master").PrimaryFilePath & "\" & My.Settings.defaultDatabaseName & ".mdf"

            'If My.Computer.FileSystem.FileExists(defaultDataModel) And defaultDataFile.Length = 0 Then
            '    defaultMainDataFile = ApplicationGlobal.sqlServer.Databases("master").PrimaryFilePath & "\" & My.Settings.defaultDatabaseName & ".mdf"
            'End If

            'If defaultMainDataFile = "" Then
            '    defaultMainDataFile = ApplicationGlobal.sqlServer.Databases("master").PrimaryFilePath & "\" & My.Settings.defaultDatabaseName & ".mdf"
            'End If

            If Not My.Computer.FileSystem.FileExists(defaultDataFile) Then
                Try
                    My.Computer.FileSystem.CopyFile(defaultDataModel, defaultDataFile, True)
                    sc.Add(defaultDataFile)
                    'sc.Add(defaultLogFile)
                    If My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.GetParentPath(defaultDataFile), FileIO.SearchOption.SearchAllSubDirectories, My.Settings.databaseName & "*.ldf").ToArray.Count > 0 Then
                        My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.GetParentPath(defaultDataFile), FileIO.SearchOption.SearchAllSubDirectories, My.Settings.databaseName & "*.ldf").ToArray(0))
                    End If
                    ApplicationGlobal.sqlServer.AttachDatabase(My.Settings.databaseName, sc, defaultDatabaseOwner, AttachOptions.None)
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                    'Dim objFrmDatabaseUtilities As New frmDatabaseUtilities
                    'objFrmDatabaseUtilities.Text = "Database connection"
                    'objFrmDatabaseUtilities.ctrlDatabaseUtilities.PasswordTextBox.Text = "dmgl"
                    'objFrmDatabaseUtilities.ctrlDatabaseUtilities.UserNameTextBox.Text = "lgmduser"
                    'objFrmDatabaseUtilities.ctrlDatabaseUtilities.WindowsAuthenticationRadioButton.Checked = False
                    'objFrmDatabaseUtilities.ctrlDatabaseUtilities.radioButton2.Checked = True
                    'objFrmDatabaseUtilities.ShowDialog()
                    Application.Exit()
                End Try
            End If
        Catch ex As Exception
        End Try

        If ApplicationGlobal.sqlServerConnection Is Nothing Then
            Me.lblServer.Text = "Not Connected to database: Application Version " + appVersion.ToString() + " "
            Me.txtUsername.Visible = False
            Me.txtPassword.Visible = False
            Me.lblUsername.Visible = False
            Me.lblPassword.Visible = False
            Me.btnLogin.Enabled = False
            Me.btnLogin.Text = "Server\Database Connection"
        Else
            Try
                Me.lblInstallationType.Text = GetConfigLevel(True) & " Level - " & GetConfigArea(True)
                Me.lblStationName.Text = GetConfigArea(True)
                Me.lblServer.Text = "Connected to " + ApplicationGlobal.sqlServerConnection.TrueName + ", Database " + My.Settings.databaseName + ", Application Version " + appVersion.ToString() + ", Geographic Area " + Me.lblStationName.Text
            Catch ex As Exception
                Me.lblServer.Text = ex.Message.ToString + ", " + My.Settings.databaseName + ", Application Version " + appVersion.ToString() + " "
                If Dir(defaultDataFile) <> "" Then
                    MessageBox.Show("Failed to get connected, This could be because the server is stopped or not connected." & vbCrLf & "Please start the server or get connected to the right server.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Dim objFrmDatabaseUtilities As New frmDatabaseUtilities
                'objFrmDatabaseUtilities.Text = "Database connection"
                'objFrmDatabaseUtilities.ctrlDatabaseUtilities.PasswordTextBox.Text = "dmgl"
                'objFrmDatabaseUtilities.ctrlDatabaseUtilities.UserNameTextBox.Text = "lgmduser"
                'objFrmDatabaseUtilities.ctrlDatabaseUtilities.WindowsAuthenticationRadioButton.Checked = False
                'objFrmDatabaseUtilities.ctrlDatabaseUtilities.radioButton2.Checked = True
                'objFrmDatabaseUtilities.ShowDialog()

                Application.Exit()
                Exit Sub
            End Try

            If IsConfigured() = False Then
                Dim frmConfigure As New frmConfig
                frmConfigure.ShowDialog()
                Me.lblInstallationType.Text = GetConfigLevel(True) & " Level"
            End If

        End If
    End Sub

    Private Sub Login()
        Dim credential(,) As String = New String(0, 1) {}

        ReDim Preserve credential(0, 1)
        credential(0, 0) = txtUsername.Text
        credential(0, 1) = txtPassword.Text

        Try
            Dim bPassed As Boolean = False
            Try
                If Me.txtUsername.Text.Length = 0 Then
                    MsgBox("User name is missing")
                    Exit Sub
                End If
                If Me.txtPassword.Text.Length = 0 Then
                    MsgBox("Password is missing")
                    Exit Sub
                End If

                bPassed = Me.Authenticate(txtUsername.Text, txtPassword.Text)

            Catch ex As Exception
                Dim inner As Exception = ex.InnerException
                While Not (inner Is Nothing)
                    MsgBox("{0}", CType(inner.Message, MsgBoxStyle))
                    inner = inner.InnerException
                End While

                MsgBox(ex.Message, MsgBoxStyle.Information, "LGMD2 Operator Message")
                Exit Sub
            End Try

            Try
                Dim regKey As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey(c_RegistryKey)
                If False Then
                    regKey.SetValue("Username", txtUsername.Text)
                Else
                    regKey.DeleteValue("Username", False)
                    regKey.DeleteValue("Password", False)
                End If
                regKey.Close()
            Catch ex As Exception
            End Try

            If bPassed = True Then
                Dim NewDB As Boolean = False
                Try
                    Try
                        If DomainLookup("CLPatchVersion", "tblAppVersionControl", "1=1") Is Nothing Then
                            NewDB = True
                            cmd = New SqlCommand()
                            If conn.State = ConnectionState.Closed Then
                                conn.Open()
                            End If

                            cmd.Connection = conn
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = " INSERT INTO [dbo].[tblAppVersionControl] ([BEVersion],[CLPatchVersion],[HostIP]) VALUES (1 ,1 ,'Localhost')"
                            cmd.ExecuteNonQuery()
                        End If

                    Finally
                        conn.Close()
                    End Try

                    If NewDB Or DomainLookup("CLPatchVersion", "tblAppVersionControl", "1=1").ToString = "" Or DomainLookup("CLPatchVersion", "tblAppVersionControl", "1=1").ToString <> Assembly.GetExecutingAssembly.FullName.Split(",")(1).Split("=")(1).Replace(".", "") Then
                        Dim db As Database = Nothing
                        For Each db In ApplicationGlobal.sqlServer.Databases
                            Dim intLastIndex As Int16 = ApplicationGlobal.sqlServerConnection.ConnectionString.IndexOf(";", ApplicationGlobal.sqlServerConnection.ConnectionString.IndexOf("Initial Catalog"))
                            If intLastIndex = -1 Then
                                intLastIndex = Len(ApplicationGlobal.sqlServerConnection.ConnectionString)
                            End If
                            Dim intFirstIndex As Int16 = ApplicationGlobal.sqlServerConnection.ConnectionString.IndexOf(";", ApplicationGlobal.sqlServerConnection.ConnectionString.IndexOf("Initial Catalog"))
                            Dim intStart As Int16 = ApplicationGlobal.sqlServerConnection.ConnectionString.IndexOf("Initial Catalog")

                            If db.Name.ToLower = ApplicationGlobal.sqlServerConnection.ConnectionString.Substring(intStart, (intLastIndex) - ApplicationGlobal.sqlServerConnection.ConnectionString.IndexOf("Initial Catalog")).Split("=")(1).ToLower Then

                                If MsgBox("LGMD2 has detected an old database structure which needs to be upgraded." & vbCrLf & "This might take a few minutes" & vbCrLf & "Would you like to proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    Application.Exit()
                                    Exit Sub
                                End If

                                Me.Cursor = Cursors.WaitCursor

                                Try
                                    'Dim fileContents As String

                                    'Try
                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1701.txt") '1701
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1702.txt") '1702
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1703.txt") '1703
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1704.txt") '1704
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1705.txt") '1705
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1706.txt") '1706
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1707.txt") '1707
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1708.txt") '1708
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1709.txt") '1709
                                    ''db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1710.txt") '1710
                                    ''db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1711.txt") '1711
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1712.txt") '1712
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1713.txt") '1713
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1714.txt") '1714
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1715.txt") '1715
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1716.txt") '1716
                                    'db.ExecuteNonQuery(fileContents)

                                    ''fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1717.txt") '1717
                                    ''db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1720.txt") '1720
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1722.txt") '1722
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1723.txt") '1723
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1724.txt") '1724
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1725.txt") '1725
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1726.txt") '1726
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1727.txt") '1727
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1728.txt") '1728
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1729.txt") '1729
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1730.txt") '1730
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1731.txt") '1731
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1732.txt") '1732
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1733.txt") '1733
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1734.txt") '1734
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1735.txt") '1735
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1736.txt") '1736
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1737.txt") '1737
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1738.txt") '1738
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1739.txt") '1739
                                    'db.ExecuteNonQuery(fileContents)

                                    'fileContents = My.Computer.FileSystem.ReadAllText("Data\Script1740.txt") '1740
                                    'db.ExecuteNonQuery(fileContents)
                                    'Catch ex As Exception
                                    'End Try

                                    Try
                                        cmd = New SqlCommand()
                                        If conn.State = ConnectionState.Closed Then
                                            conn.Open()
                                        End If
                                        cmd.Connection = conn
                                        cmd.CommandText = "select isnull(ShellPath,'" & Application.ExecutablePath & "'),isnull(HostIP,'localhost') from tblAppVersionControl"
                                        reader = cmd.ExecuteReader()
                                        Using reader
                                            While reader.Read
                                                frmMain.tstxtHostIP.Text = reader.GetValue(1)
                                            End While
                                        End Using
                                    Catch ex As Exception
                                    End Try
                                Catch ex As Exception
                                End Try

                                Try
                                    If db.IsSystemObject = False AndAlso db.IsAccessible = True Then
                                        For Each t As Table In db.Tables
                                            If t.IsSystemObject = False Then
                                                If Not t.Columns.Contains("RowVersionID") Then
                                                    Dim clm As New Microsoft.SqlServer.Management.Smo.Column
                                                    clm.Name = "RowVersionID"
                                                    t.Columns.Add(clm)
                                                    clm.DataType = Microsoft.SqlServer.Management.Smo.DataType.Timestamp
                                                    t.Alter()
                                                End If
                                                If t.Name = "tblAppVersionControl" And Not t.Columns.Contains("LastAcknowledgedRVID") Then
                                                    Dim clm As New Microsoft.SqlServer.Management.Smo.Column
                                                    clm.Name = "LastAcknowledgedRVID"
                                                    t.Columns.Add(clm)
                                                    clm.DataType = Microsoft.SqlServer.Management.Smo.DataType.BigInt
                                                    t.Alter()
                                                End If
                                            End If
                                        Next
                                    End If
                                Catch ex As Exception
                                Finally
                                    conn.Close()
                                End Try
                                Exit For
                            End If

                        Next
                        If Not db Is Nothing Then
                            cmd = New SqlCommand
                            If conn.State = ConnectionState.Closed Then
                                conn.Open()
                            End If
                            cmd.Connection = conn
                            cmd.CommandText = "Update tblAppVersionControl set CLPatchVersion =" & Assembly.GetExecutingAssembly.FullName.Split(",")(1).Split("=")(1).Replace(".", "")
                            cmd.ExecuteNonQuery()
                            MsgBox("Database has been successfully updated")
                        End If
                    End If
                Catch ex As Exception
                Finally
                    Me.Cursor = Cursors.Default
                    conn.Close()
                End Try

                If My.Settings.DataConnectionString.StartsWith("server") Then
                    My.Settings.databaseName = My.Settings.DataConnectionString.Split("=")(4)
                Else
                    My.Settings.databaseName = My.Settings.DataConnectionString.Split("=")(2).Split(";")(0)
                End If
                If My.Settings.databaseName.ToLower = "true" Then
                    My.Settings.databaseName = My.Settings.DataConnectionString.Split("Initial Catalog")(1).Split("=")(1)
                End If

                Me.Close()

                If Not objFrmMain Is Nothing Then
                    objFrmMain.LoadTree()
                    objFrmMain.Handle_NetworkAvailabilityChanged()
                End If

                Exit Sub

                If Not objFrmMain Is Nothing Then
                    objFrmMain = Nothing
                End If

                objFrmMain = New frmMain()

                Me.txtPassword.Text = ""
                Me.txtUsername.Text = ""

                objFrmMain.ShowDialog()

                ApplicationGlobal.dbCurrentDatabase = My.Settings.databaseName.ToString
                My.Settings.Save()

                Me.txtPassword.Text = ""
                Me.txtUsername.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function Authenticate(ByVal userName As String, ByVal password As String) As Boolean
        Try
            LoginManager.Login(userName, password)

            Dim objfrmMainScreen As New frmMain
            If Not LGMD.ApplicationGlobal.objFrmMain Is Nothing Then
            Else
                LGMD.ApplicationGlobal.objFrmMain = objfrmMainScreen
                objfrmMainScreen.Show()
            End If
            objfrmMainScreen.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable

            g_user_id = Me.txtUsername.Text

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub ResizePanels()
        Me.Invalidate()
    End Sub

    Private Sub txtPassword_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Enter
        If Me.txtPassword.Text.Length > 0 AndAlso Me.txtUsername.Text.Length > 0 Then
            Me.Login()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If Me.txtPassword.Text.Length > 0 AndAlso Me.txtUsername.Text.Length > 0 AndAlso e.KeyData.ToString = "Return" Then
            Me.Login()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Login()
    End Sub

    Private Sub btnSwitchDatabase_Click(sender As Object, e As EventArgs) Handles btnSwitchDatabase.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objFrmDatabaseUtilities As New frmDatabaseUtilities
            objFrmDatabaseUtilities.Text = "Database connection"
            objFrmDatabaseUtilities.txtUsername.Text = "dmgl"
            objFrmDatabaseUtilities.txtPassword.Text = "lgmduser"
            objFrmDatabaseUtilities.radioBtnWindowsAuthentication.Checked = True
            objFrmDatabaseUtilities.radioBtnSqlServerAuthentication.Checked = False
            objFrmDatabaseUtilities.ShowDialog()
            'Application.Exit()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
        
    End Sub
End Class