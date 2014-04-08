Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Management.Smo
Imports System.Collections.Specialized
Imports System.IO
Imports Microsoft.SqlServer.Management.Common
Imports System.Net.NetworkInformation
Imports SyncScopeProvision
Imports System.IO.Compression

Public Class frmMain

    Private strConnectionMode As String
    Private strMainstrControlCaption As String
    Private connErr As Boolean = False
    Private strShellPath As String = ""
    Private strHostIP As String = ""
    Private cmd As SqlCommand
    Private reader As SqlDataReader
    Private ctrl As UserControl

    Private Declare Auto Function SendMessage Lib "user32" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    'Then overide ProcessCmdKey in the MDI parent:
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            SendMessage(Me.SplitContainer.Panel2.Controls(0).Handle, msg.Msg, msg.WParam, msg.LParam)
        Catch ex As Exception
        End Try

    End Function

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmd = New SqlCommand()
        Try
            Call Handle_NetworkAvailabilityChanged()
            Me.tscmbLanguage.SelectedIndex = 0

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.Connection = conn
            cmd.CommandText = "select isnull(ShellPath,'" & Application.ExecutablePath & "'),isnull(HostIP,'localhost') from tblAppVersionControl"
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    Me.tstxtHostIP.Text = reader.GetValue(1)
                End While
            End Using

            Call LoadTree()
            Call ReturnLGAAndDatabaseName()
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub tsbtnSynchronise_Click(sender As Object, e As EventArgs) Handles tsbtnSynchronise.Click

        Dim strFigureSerialNumber As String
        Dim sHostIP As String = Me.tstxtHostIP.Text.ToString

        If GetConfigLevel() <> 5 Then
            Me.tscmbSynchOptions.Text = "All Forms"
            Me.tscmbSynchOptions.Enabled = False
        Else
            Me.tscmbSynchOptions.Enabled = True
        End If

        If Me.tscmbSynchOptions.Text = "" Then
            MsgBox("Please select the type of synchronisation you want to make", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Me.tscmbSynchOptions.Text = "All Forms" Then
            strFigureSerialNumber = ""
        Else
            If LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.Count = 0 Then
                MsgBox("No record has been selected" & vbCrLf & "Please select the record to synchronise..", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls(0).Name <> "ctrlEditForm" Then
                MsgBox("No record has been selected" & vbCrLf & "Please select the record to synchronise..", MsgBoxStyle.Information)
                Exit Sub
            End If
            strFigureSerialNumber = LGMD.g_FormSerialNumber
        End If

        If GetConfigLevel() = 5 Then
            MsgBox("Please note when synchronising with the main server, it will be assumed, when sending data, that it is complete and ready for scrutinization at Regional level." & vbCrLf & "DED approval is required for this action." & vbCrLf & "When synchronising to receive approval information from the Region, DED approval is not required", MsgBoxStyle.Exclamation)

            If MsgBox("Are you sure you want to synchronise the main server?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If GetConfigLevel() <> 5 Then
            If MsgBox("Are you sure you want to synchronise the main server?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.tsbtnSynchronise.Enabled = False
        DisplayAvailability(My.Computer.Network.IsAvailable)

        SynchronizeRecordsWithMainServer()

        DisplayAvailability(My.Computer.Network.IsAvailable)

        Me.Cursor = Cursors.Default

        Exit Sub
    End Sub

    Public Sub LoadTree()

        ' TODO: Add code to add items to the treeview

        Me.tvMain.Nodes.Clear()
        Dim tvRoot As TreeNode
        Dim tvNode As TreeNode
        Dim tvNodeSecondRoot As TreeNode

        If g_language = "English" Then
            If GetConfigLevel() = 5 Or GetConfigLevel() = 6 Then
                tvRoot = Me.tvMain.Nodes.Add("Data entry", "Data entry", 12, 12)
                tvNode = tvRoot.Nodes.Add("Enter data", "Enter data", 3, 3)
                tvNode = tvRoot.Nodes.Add("Edit unapproved data", "Edit unapproved data", 2, 2)
                tvNode = tvRoot.Nodes.Add("View unapproved data", "View unapproved data", 2, 2)
                tvNode = tvRoot.Nodes.Add("View approved data", "View approved data", 2, 2)
                tvRoot.ExpandAll()
            Else
                tvRoot = Me.tvMain.Nodes.Add("Data scrutinisation", "Data scrutinisation", 12, 12)
                tvNode = tvRoot.Nodes.Add("View unapproved data", "View unapproved data", 2, 2)
                tvNode = tvRoot.Nodes.Add("View approved data", "View approved data", 2, 2)
                tvRoot.ExpandAll()
            End If

            'Reports
            tvRoot = Me.tvMain.Nodes.Add("Outputs", "Outputs", 11, 11)
            tvNode = tvRoot.Nodes.Add("Figure analysis", "Figure analysis", 5, 5)
            'tvNode = tvRoot.Nodes.Add("Text answer printout", "Text answer printout", 5, 5)
            tvNode = tvRoot.Nodes.Add("Ward Reports", "Ward Reports", 5, 5)
            tvNode = tvRoot.Nodes.Add("District Reports", "District Reports", 5, 5)
            tvNode = tvRoot.Nodes.Add("Integrated Reports", "Integrated Reports", 5, 5)
            tvNode = tvRoot.Nodes.Add("Report Submission Status", "Report Submission Status", 5, 5)

            tvRoot.ExpandAll()
            tvRoot = Me.tvMain.Nodes.Add("System Utilities", "System Utilities", 6, 6)
            tvNodeSecondRoot = tvRoot.Nodes.Add("Database Management", "Database Management", 18, 18)

            tvNode = tvNodeSecondRoot.Nodes.Add("New Database", "New Database", 19, 19)

            If g_user_id <> "administrator" Then
                'tvNode = tvNodeSecondRoot.Nodes.Add("Delete Database", "Delete Database", 7, 7)
            Else
                tvNode = tvNodeSecondRoot.Nodes.Add("Delete Database", "Delete Database", 13, 13)
                'tvNode = tvNodeSecondRoot.Nodes.Add("Rebuild Database", "Rebuild Database", 7, 7)
            End If
            tvNode = tvNodeSecondRoot.Nodes.Add("Backup", "Backup", 15, 15)
            tvNode = tvNodeSecondRoot.Nodes.Add("Restore", "Restore", 14, 14)

            tvNode = tvRoot.Nodes.Add("Database Utilities", "Database Utilities", 22, 22)
            If GetConfigLevel() = 5 Then
                ' tvNode = tvRoot.Nodes.Add("Create Export File (.zip)", "Create Export File (.zip)", 7, 7)
            ElseIf GetConfigLevel() = 2 Then
                tvNode = tvRoot.Nodes.Add("Import Data (.zip)", "Import Data (.zip)", 17, 17)
                'ElseIf GetConfigLevel() = 4 Then
                '   tvNode = tvRoot.Nodes.Add("Import from National", "Import from National", 7, 7)
            End If
            'tvNode = tvRoot.Nodes.Add("Users", "Users", 8, 8)
            tvRoot.ExpandAll()

            tvRoot = Me.tvMain.Nodes.Add("Security", "Security", 21, 21)
            tvNode = tvRoot.Nodes.Add("Change Password", "Change Password", 20, 20)
            tvNode = tvRoot.Nodes.Add("Users", "Users", 8, 8)
            'tvNode = tvRoot.Nodes.Add("Groups", "Groups", 8, 8)
            tvRoot.ExpandAll()
        Else
            tvRoot = Me.tvMain.Nodes.Add("Kuingiza Data", "Kuingiza Data", 12, 12)
            tvNode = tvRoot.Nodes.Add("Ingiza data", "Ingiza data", 3, 3)
            tvNode = tvRoot.Nodes.Add("Edit unapproved data", "Badilisha data", 2, 2)
            tvRoot.ExpandAll()
            tvRoot = Me.tvMain.Nodes.Add("Printouts", "Ripoti", 5, 5)
            tvNode = tvRoot.Nodes.Add("Annual/Quarterly Report", "Ripoti 1", 5, 5)
            tvNode = tvRoot.Nodes.Add("Printout 2", "Ripoti 2", 5, 5)
            tvNode = tvRoot.Nodes.Add("Chart 1", "Chati 1", 11, 11)
            tvRoot.ExpandAll()
            tvRoot = Me.tvMain.Nodes.Add("Database Utilities", "Vifaa vya Database", 6, 6)
            tvNode = tvRoot.Nodes.Add("Synchronise", "Synchronise", 7, 7)
            tvNode = tvRoot.Nodes.Add("Users", "Watumiaji", 8, 8)
            tvRoot.ExpandAll()
        End If
        'tvNodeSecondRoot.Collapse()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MsgBox("Are you sure you want to exit the system?", 36, "System Message") = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMain.AfterSelect
        ' TODO: Add code to change the listview contents based on the currently-selected node of the treeview      
        strSelectedNode = e.Node.Text
        Call SelectTreeNode()
        Me.tvMain.HideSelection = False

    End Sub

    Public Sub SelectTreeNode()

        g_bViewOnly = False
        g_bSeleted = False

        If Me.SplitContainer.Panel2.Controls.Count > 0 Then

            If Me.SplitContainer.Panel2.Controls(0).Name = "ctrlEditForm" And strSelectedNode = "Create Export File (.zip)" Then '(strSelectedNode="Edit unapproved data" or strSelectedNode= "Badilisha data" or strSelectedNode = "View unapproved data")  Then
                g_bSeleted = True
            Else
                Me.SplitContainer.Panel2.Controls.RemoveAt(0)
            End If

        End If

        Select Case strSelectedNode
            Case "Enter data", "Ingiza data"
                ctrl = New ctrlAddForm
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Edit unapproved data", "Badilisha data", "View unapproved data", "View approved data"
                If (strSelectedNode = "View unapproved data" Or strSelectedNode = "View approved data") Then 'And GetConfigLevel() = 5 Then
                    g_bViewOnly = True
                Else
                    g_bViewOnly = False
                End If
                ctrl = New ctrlEditForm
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Figure analysis", ""
                ctrl = New ctrlFigureAnalysis
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Text answer printout"
                'ctrl = New ctrlRptText
                'Me.SplitContainer.Panel2.Controls.Add(ctrl)
                'ctrl.Dock = DockStyle.Fill

            Case "Ward Reports"
                ctrl = New ctrlReportsLocal("Ward")
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "District Reports"
                ctrl = New ctrlReportsLocal("District")
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Integrated Reports"
                ctrl = New ctrlReportsLocal("Integrated")
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Report Submission Status"
                ctrl = New ctrlReportsLocal("Submission")
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Users"
                ctrl = New ctrlAddUser5
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Database Management"
                'ctrl = New ctrlManageDatabases
                'Me.SplitContainer.Panel2.Controls.Add(ctrl)
                'ctrl.Dock = DockStyle.Fill

            Case "New Database"
                ctrl = New ctrlManageDatabases
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Delete Database"
                ctrl = New ctrlManageDatabases("Delete")
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Rebuild Database"
                'Dim wcfSynch As New Form1
                'wcfSynch.fnStartSynch(Me, True)

            Case "Attach"
                ctrl = New ctrlDatabaseTasks("Attach", ApplicationGlobal.sqlServer.Databases(My.Settings.databaseName))
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Detach"
                ctrl = New ctrlDatabaseTasks("Detach", ApplicationGlobal.sqlServer.Databases(My.Settings.databaseName))
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Backup"
                ctrl = New ctrlDatabaseTasks("Backup", ApplicationGlobal.sqlServer.Databases(My.Settings.databaseName))
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Restore"
                ctrl = New ctrlDatabaseTasks("Restore", ApplicationGlobal.sqlServer.Databases(My.Settings.databaseName))
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Database Utilities"
                'Dim SrvConn As New ServerConnection
                'SrvConn = New ServerConnection()
                'SrvConn.ConnectionString = My.Settings.DataConnectionString
                ctrl = New ctrlDatabaseUtilities(ApplicationGlobal.sqlServerConnection)
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Import Data (.zip)"
                Dim dlgImportFile As New OpenFileDialog
                dlgImportFile.Title = "Open LGMD2 export file from district"
                dlgImportFile.Filter = "LGMD2 Files(*.zip)|*.zip"

                If dlgImportFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ' Create the database
                    Dim sDatabaseName As String
                    Dim db As Database
                    Dim fg As FileGroup
                    Dim df As DataFile
                    Dim lf As LogFile
                    Dim csr As Cursor = Nothing

                    csr = Me.Cursor ' Save the old cursor
                    Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

                    ' Get the name of the new database
                    sDatabaseName = dlgImportFile.FileName

                    Try
                        ' Extract zipped file to lge file into data folder
                        ZipFile.ExtractToDirectory(sDatabaseName, ApplicationGlobal.sqlServer.MasterDBPath)

                        ' Check for new non-zero length name
                        If sDatabaseName.Length = 0 Then
                            System.Windows.Forms.MessageBox.Show(Me, _
                            My.Resources.NoDatabaseName, Me.Text, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error, _
                            MessageBoxDefaultButton.Button1, 0)
                            Return
                        End If

                        ' Refresh database list
                        ApplicationGlobal.sqlServer.Databases.Refresh()

                        ' Attach the database
                        Dim sc As StringCollection
                        sc = New StringCollection
                        Dim owner As String = "sa"
                        Dim logstr As String = ""
                        Dim datastr As String = ""
                        Dim fileData As FileInfo = My.Computer.FileSystem.GetFileInfo(sDatabaseName)

                        ' Is database name new and unique?
                        If (ApplicationGlobal.sqlServer.Databases.Contains(fileData.Name.Replace(".zip", ""))) Then
                            System.Windows.Forms.MessageBox.Show(Me, _
                            My.Resources.DuplicateDatabaseName, _
                            Me.Text, MessageBoxButtons.OK, _
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0)
                            Return
                        End If

                        datastr = Replace(My.Computer.FileSystem.GetParentPath(ApplicationGlobal.sqlServer.Databases("master").FileGroups("primary").Files(0).FileName) & "\" & fileData.Name.ToString.Replace(".lge", "") & ".mdf", ".zip", "")
                        fileData = My.Computer.FileSystem.GetFileInfo(datastr.Replace(".mdf", ".lge"))

                        Try
                            If (ApplicationGlobal.sqlServer.Databases.Contains(fileData.Name.ToString.Replace(".zip", ""))) Then
                                ApplicationGlobal.sqlServer.Databases(fileData.Name.ToString.Replace(".zip", "")).Drop()
                                ApplicationGlobal.sqlServer.Databases.Refresh()
                            End If
                            Try
                                fileData.MoveTo(datastr)
                            Catch ex As Exception
                            End Try

                            sc.Add(datastr)
                            'sc.Add(logstr)
                            ApplicationGlobal.sqlServer.AttachDatabase(fileData.Name.ToString.Replace(".lge", "").Replace(".mdf", ""), sc, owner, AttachOptions.None)

                            ' Refresh database list
                            ' ShowDatabases(False)
                            ApplicationGlobal.sqlServer.Databases.Refresh()
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                        End Try

                        sDatabaseName = fileData.Name.ToString.Replace(".lge", "").Replace(".mdf", "")
                        ' Instantiate a new database object
                        'db = New Microsoft.SqlServer.Management.Smo.Database(SqlServerSelection, sDatabaseName)
                        db = New Microsoft.SqlServer.Management.Smo.Database(ApplicationGlobal.sqlServer, My.Settings.databaseName)

                        If conn.State = ConnectionState.Closed Then
                            conn.Open()
                        End If

                        cmd = New SqlCommand

                        With cmd
                            .CommandType = CommandType.StoredProcedure
                            .Connection = conn
                            .CommandText = "appUspImportData"
                            .Parameters.AddWithValue("@dbImported", sDatabaseName)
                            .ExecuteNonQuery()
                            .Parameters.Clear()
                        End With

                        ApplicationGlobal.sqlServer.Databases(sDatabaseName).Drop()

                        MsgBox("Data imported successfuly")

                    Catch ex As SmoException
                        ApplicationGlobal.sqlServer.Databases(sDatabaseName).Drop()
                        If ex.SmoExceptionType.ToString <> "FailedOperationException" Then
                            Dim emb As New ExceptionMessageBox(ex)
                            emb.Show(Me)
                        End If

                    Finally
                        ' Clean up.
                        db = Nothing
                        fg = Nothing
                        df = Nothing
                        lf = Nothing
                        conn.Close()
                        Me.Cursor = csr ' Restore the original cursor
                    End Try
                End If

            Case "Change Password"
                ctrl = New ctrlChangePassword
                Me.SplitContainer.Panel2.Controls.Add(ctrl)
                ctrl.Dock = DockStyle.Fill

            Case "Groups"

        End Select
    End Sub

    Public Sub getControl(Optional ByVal strControl As String = "", Optional ByVal strControlCaption As String = "", Optional ByVal IsSameForm As Boolean = False)
        Dim bNoEditRights As Boolean = False
    End Sub

    Public Sub getControl(ByVal ctrl As UserControl)

        If Me.SplitContainer.Panel2.Controls.Count > 0 Then
            Me.SplitContainer.Panel2.Controls.RemoveAt(0)
        End If
        Me.SplitContainer.Panel2.Controls.Add(ctrl)

    End Sub

    Private Sub tscLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscmbLanguage.SelectedIndexChanged

        Select Case Me.tscmbLanguage.SelectedItem.ToString
            Case "English"
                g_language = "English"
            Case "Kiswahili"
                g_language = "Swahili"
        End Select

        LoadTree()

        'strSelectedNode = Me.TreeView.SelectedNode.Text
        Call SelectTreeNode()

    End Sub

    Private Sub DisplayAvailability(ByVal available As Boolean)

        If strMainstrControlCaption = "" Then
            Me.Text = GetConfigLevel(True)
        Else
            Me.Text = GetConfigLevel(True) & " (" & strMainstrControlCaption & ")"
        End If

        Dim strNotification As String = ""

        If available Then
            strConnectionMode = " - Online Mode"
            strNotification = "Online Mode"
            Me.tsbtnSynchronise.Enabled = True
        Else
            strConnectionMode = " - Offline Mode"
            strNotification = "Offline Mode"
            Me.tsbtnSynchronise.Enabled = False
            'Me.btnSyncronise.Enabled = True
        End If

        If Len(GetConfigArea(True)) < 50 Then
            strNotification = GetConfigArea(True) & " - " & strNotification
        End If

        Me.Text = Me.Text & strConnectionMode
        If NotifyIcon1.Visible = False Then
            NotifyIcon1.Visible = True
        End If
        If available Then
            NotifyIcon1.Text = strNotification
            NotifyIcon1.Icon = Me.Icon
            'notifyIcon1.Visible = True
            Me.NotifyIcon1.ShowBalloonTip(10, "LGMD2", strNotification, ToolTipIcon.Info)
        Else
            NotifyIcon1.Text = strNotification
            'notifyIcon1.Visible = True
            NotifyIcon1.Icon = Me.Icon
            Me.NotifyIcon1.ShowBalloonTip(10, "LGMD2", strNotification, ToolTipIcon.Warning)
        End If

    End Sub

    Private Sub MyComputerNetwork_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Devices.NetworkAvailableEventArgs)
        DisplayAvailability(e.IsNetworkAvailable)
    End Sub

    Public Sub Handle_NetworkAvailabilityChanged()
        AddHandler My.Computer.Network.NetworkAvailabilityChanged, _
           AddressOf MyComputerNetwork_NetworkAvailabilityChanged
        DisplayAvailability(My.Computer.Network.IsAvailable)
    End Sub

    Private Sub txtHostIP_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstxtHostIP.Leave

        cmd = New SqlCommand()

        If Me.tstxtHostIP.Text.ToString.Length = 0 Then Exit Sub

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update tblAppVersionControl set  HostIP ='" & Me.tstxtHostIP.Text & "'"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub TreeView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvMain.Click

        If g_bSeleted Then
            strSelectedNode = Me.tvMain.SelectedNode.Text
            Call SelectTreeNode()
        End If

    End Sub

    Public Sub fnSetLastRowVersion()

        cmd = New SqlCommand()

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "UspAppInsertLRV"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub SynchronizeRecordsWithMainServer(Optional ByVal rebuild As Boolean = False)

        Dim serverAddress As String = Me.tstxtHostIP.Text.ToString
        Dim localConnection As String = My.Settings.DataConnectionString
        Dim remoteConnection As String = ""

        'remoteConnection = "Data Source=" + serverAddress + ",1833; Initial Catalog=LGMD2iServer; User ID=LGMDSynch; pwd=lgmd"
        remoteConnection = "Data Source=.\sqlexpress; Initial Catalog=LGMD2iServer; User ID=LGMDSynch; pwd=lgmd"

        Dim synchronizer As New SynchronizerForm(localConnection, remoteConnection, rebuild)
        synchronizer.ShowDialog()

    End Sub

    Private Function CheckHostAvailability(ByVal strHostIP As String) 'ByVal sender As Object, ByVal e As PingCompletedEventArgs)

        Me.Cursor = Cursors.WaitCursor
        Dim remotemachine As String = strHostIP ' use any other machine name

        Dim pingreq As Ping = New Ping()

        Dim rep As PingReply
        Try
            rep = pingreq.Send(remotemachine)

            Me.Cursor = Cursors.Default
            If rep.Status = IPStatus.Success Then

                Return True
            Else
                DisplayAvailability(My.Computer.Network.IsAvailable)
                Return False
            End If

        Catch ex As Exception
            DisplayAvailability(My.Computer.Network.IsAvailable)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Function

    Public Sub ReturnLGAAndDatabaseName()

        cmd = New SqlCommand()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select name from areas where id=(select config_value from tbl_config where config_name='area_id')"
            g_LGAName = "Geographic Area:" + cmd.ExecuteScalar
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

        Me.ToolStripStatusLabel1.Text = frmLogin.lblServer.Text
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If e.CloseReason = CloseReason.ApplicationExitCall Then
            Exit Sub
        ElseIf e.CloseReason = CloseReason.FormOwnerClosing Then
            If MsgBox("Are you sure you want to exit the system,form owner?", 36, "System Message") = vbNo Then
                e.Cancel = True
            End If
        ElseIf e.CloseReason = CloseReason.MdiFormClosing Then
            Exit Sub
        ElseIf e.CloseReason = CloseReason.None Then
            Exit Sub
        ElseIf e.CloseReason = CloseReason.TaskManagerClosing Then
            Exit Sub
        ElseIf e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("Are you sure you want to exit the system?", 36, "System Message") = vbNo Then
                e.Cancel = True
            End If
        ElseIf e.CloseReason = CloseReason.WindowsShutDown Then
            Exit Sub
        End If
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOffToolStripMenuItem.Click
        Dim strCurrentUser As String = ""
        strCurrentUser = My.User.Name
        Dim frmLogin As New frmLogin

        frmLogin.ShowDialog()

        If strCurrentUser <> My.User.Name Then
            LoadTree()
            Handle_NetworkAvailabilityChanged()
            If Me.SplitContainer.Panel2.Controls.Count > 0 Then
                Me.SplitContainer.Panel2.Controls.RemoveAt(0)
            End If
        End If
    End Sub

    Private Sub AggregateDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggregateDataToolStripMenuItem.Click
        ctrl = New ctrlAggregateData

        If Me.SplitContainer.Panel2.Controls.Count > 0 Then
            Me.SplitContainer.Panel2.Controls.RemoveAt(0)
        End If

        Me.SplitContainer.Panel2.Controls.Add(ctrl)
    End Sub

    Private Sub PriorEstimateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriorEstimateToolStripMenuItem.Click
        ctrl = New ctrlPriorEstimate

        If Me.SplitContainer.Panel2.Controls.Count > 0 Then
            Me.SplitContainer.Panel2.Controls.RemoveAt(0)
        End If

        Me.SplitContainer.Panel2.Controls.Add(ctrl)
    End Sub
End Class
