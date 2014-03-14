

'============================================================================
'  File:    BackupRestore.vb 
'
'  Summary: Implements a sample SMO backup and restore utility in VB.NET.
'
'  Date:    January 25, 2005
'------------------------------------------------------------------------------
'  This file is part of the Microsoft SQL Server Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'  This source code is intended only as a supplement to Microsoft
'  Development Tools and/or on-line documentation.  See these other
'  materials for detailed information regarding Microsoft code samples.
'
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'  PARTICULAR PURPOSE.
'============================================================================
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Specialized
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management
Imports Microsoft.SqlServer.Management.Common
Imports System.Windows.Forms.MessageBox
Imports System.IO

Public Class ctrlDatabaseTasks

    Private strDatabaseName As String
    Private strCurrentAction As String
    Private ObjDb As New Database

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strAction As String, Optional ByVal DatabaseName As Database = Nothing)

        InitializeComponent()
        strCurrentAction = strAction
        ObjDb = DatabaseName
    End Sub

    Private Sub ctrlDatabaseTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        Me.txtBackupFile.Text = ""

        If strCurrentAction = "Backup" Then
            Me.groupBox.Text = "Backup"
            Me.btnRestore.Visible = False
            Me.btnAttach.Visible = False
            Me.btnDetach.Visible = False
            Me.txtBackupFile.Text = "C:\LGMD2\Backup"
            Me.OpenFileDialog1.Filter = "Backup Files (*.bak)|*.bak"
            If Not ObjDb Is Nothing Then Me.txtDatabaseName.Text = ObjDb.Name
        End If

        If strCurrentAction = "Restore" Then
            Me.groupBox.Text = "Restore"
            Me.btnBackup.Visible = False
            Me.btnAttach.Visible = False
            Me.btnDetach.Visible = False
            Me.OpenFileDialog1.FileName = "*.bak"
            Me.OpenFileDialog1.Filter = "Backup Files (*.bak)|*.bak"
            Me.lblDatabaseTasks.Text = "Backup &File:"
            Me.btnRestore.Location = New Point(119, 84)
            If Not ObjDb Is Nothing Then Me.txtDatabaseName.Text = ObjDb.Name
        End If

        If strCurrentAction = "Attach" Then
            Me.btnAttach.Visible = True
            Me.txtBackupFile.Text = ""
            Me.btnBackup.Visible = False
            Me.btnRestore.Visible = False
            Me.txtDatabaseName.Enabled = True
            Me.txtBackupFile.Text = Nothing
            Me.OpenFileDialog1.Filter = "MDF Files (*.mdf)|*.mdf"
            Me.OpenFileDialog1.FileName = "*.mdf"
            Me.lblDatabaseTasks.Text = "&MDF File:"
        End If

        If strCurrentAction = "Detach" Then
            Me.btnDetach.Visible = True
            Me.txtBackupFile.Text = ""
            Me.btnBackup.Enabled = False
            Me.txtDatabaseName.Enabled = True
            Me.txtBackupFile.Text = Nothing
            Me.OpenFileDialog1.Filter = "MDF Files (*.mdf)|*.mdf"
            Me.OpenFileDialog1.FileName = "*.mdf"
            Me.lblDatabaseTasks.Text = "&MDF File:"
        End If

        ' Display the main window first
        Me.Show()
        Application.DoEvents()

        Try
            If ApplicationGlobal.sqlServerConnection.SqlConnectionObject.State = ConnectionState.Open Then
                ApplicationGlobal.sqlServer = New Microsoft.SqlServer.Management.Smo.Server(ApplicationGlobal.sqlServerConnection)
                If Not (ApplicationGlobal.sqlServer Is Nothing) Then
                    Me.Text = My.Resources.AppTitle & ApplicationGlobal.sqlServer.Name
                End If
            Else
            End If
        Catch ex As Exception
        End Try

        If Not ApplicationGlobal.sqlServer Is Nothing And Not ObjDb Is Nothing Then
            txtBackupFile.Text = ApplicationGlobal.sqlServer.Settings.BackupDirectory & "\" + ObjDb.Name + "Backup.bak"
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

        Dim csr As Cursor = Nothing
        Dim backup As Backup
        Dim db As Database
        Dim backupDeviceItem As BackupDeviceItem

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

            ' Get database object from combobox
            db = CType(ObjDb, Database)

            ' Backup a complete database to disk

            ' Create a new Backup object instance
            backup = New Backup()

            ' Backup database action
            backup.Action = BackupActionType.Database

            ' Set backup description
            backup.BackupSetDescription = "Sample Backup of " & db.Name

            ' Set backup name
            backup.BackupSetName = db.Name & " Backup"

            ' Set database name
            backup.Database = db.Name

            ' Create a file backup device
            backupDeviceItem = New BackupDeviceItem( _
                txtBackupFile.Text, DeviceType.File)

            ' Add a new backup device
            backup.Devices.Add(backupDeviceItem)

            ' Only store this backup in the set
            backup.Initialize = True

            ' Set the media name
            backup.MediaName = "Set 1"

            ' Set the media description
            backup.MediaDescription = "Sample Backup Media Set # 1"

            ' Notify this program every 5% 
            backup.PercentCompleteNotification = 5

            ' Set the backup file retention to the current server run value
            backup.RetainDays = db.Parent.Configuration.MediaRetention.RunValue

            ' Skip the tape header, because we are writing to a file
            backup.SkipTapeHeader = True

            ' Unload the tape after the backup completes
            backup.UnloadTapeAfter = True

            ' Add event handler to show progress
            AddHandler backup.PercentComplete, _
                AddressOf Me.ProgressEventHandler

            ' Generate and print script
            txtResults.AppendText(My.Resources.GeneratedScript)
            ScrollToBottom()

            ' Scripting here is strictly for text display purposes
            Dim script As String = backup.Script(ApplicationGlobal.sqlServer)
            txtResults.AppendText(script & Environment.NewLine)
            ScrollToBottom()

            txtResults.AppendText(My.Resources.BackingUp)
            ScrollToBottom()
            UpdateStatus(0)

            backup.SqlBackup(ApplicationGlobal.sqlServer)

            txtResults.AppendText(My.Resources.BackupComplete)
            ScrollToBottom()
            MsgBox("Backup Complete")
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)
        Finally
            ' Restore the original cursor
            Me.Cursor = csr
        End Try
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click

        'Dim csr As Cursor = Nothing
        'Dim restore As Restore
        'Dim db As Database
        'Dim backupDeviceItem As BackupDeviceItem

        '' Are you sure?  Default to No.
        'If System.Windows.Forms.MessageBox.Show(Me, _
        '    String.Format(System.Globalization.CultureInfo.InvariantCulture, _
        '    My.Resources.ReallyRestore, DatabasesComboBox.Text), _
        '    Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
        '    MessageBoxDefaultButton.Button2, 0) = Windows.Forms.DialogResult.No Then
        '    Return
        'End If

        'Try
        '    csr = Me.Cursor ' Save the old cursor
        '    Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

        '    ' Get database object from combobox
        '    db = CType(ObjDb, Database)

        '    ' Create a new Restore object instance
        '    restore = New Restore

        '    ' Restore database action
        '    restore.Action = RestoreActionType.Database

        '    ' Set database name
        '    restore.Database = db.Name

        '    ' Create a file backup device
        '    backupDeviceItem = New BackupDeviceItem( _
        '        BackupFileTextBox.Text, DeviceType.File)

        '    ' Add database backup device
        '    restore.Devices.Add(backupDeviceItem)

        '    ' Notify this program every 5% 
        '    restore.PercentCompleteNotification = 5

        '    ' Replace the existing database
        '    restore.ReplaceDatabase = True

        '    ' Unload the backup device (tape)
        '    restore.UnloadTapeAfter = True

        '    ' add event handler to show progress
        '    AddHandler restore.PercentComplete, _
        '        AddressOf Me.ProgressEventHandler

        '    ' Generate and print script
        '    ResultsTextBox.AppendText(My.Resources.GeneratedScript)

        '    Dim strColl As System.Collections.Specialized.StringCollection _
        '        = restore.Script(frmMain.SqlServerSelection)
        '    For Each str As String In strColl
        '        ResultsTextBox.AppendText(str & Environment.NewLine)
        '    Next

        '    ResultsTextBox.AppendText(My.Resources.Restoring)
        '    UpdateStatus(0)

        '    frmMain.SqlServerSelection.ConnectionContext.Disconnect()
        '    'frmMain.SqlServerSelection.ConnectionContext.ConnectionString = Replace(frmMain.SqlServerSelection.ConnectionContext.ConnectionString, frmMain.SqlServerSelection.ConnectionContext.ConnectionString.Split("=")(4).ToString, "master")
        '    frmMain.SqlServerSelection.ConnectionContext.ConnectionString = Replace(frmMain.SqlServerSelection.ConnectionContext.ConnectionString, db.Name, "master")
        '    frmMain.SqlServerSelection.ConnectionContext.Connect()

        '    frmMain.SqlServerSelection.KillAllProcesses(db.Name)

        '    restore.SqlRestore(frmMain.SqlServerSelection)

        '    frmMain.SqlServerSelection.ConnectionContext.ConnectionString = Replace(frmMain.SqlServerSelection.ConnectionContext.ConnectionString, "master", db.Name)
        '    frmMain.SqlServerSelection.ConnectionContext.Connect()

        '    ResultsTextBox.AppendText(My.Resources.RestoreComplete)
        '    MsgBoxBilingual("Restore has succesfully completed and the system is going to restart.", "", MsgBoxStyle.Information)
        '    Application.Restart()
        'Catch ex As SmoException
        '    Dim emb As New ExceptionMessageBox(ex)
        '    emb.Show(Me)
        'Finally
        '    ' Restore the original cursor
        '    Me.Cursor = csr
        'End Try

        'Dim conn As New SqlClient.SqlConnection
        'Dim db As New Database
        'conn.ConnectionString = My.Settings.DataConnectionString
        'conn.Open()

        'db=conn["Initial Catalog"]

        'Dim cmdRestoreDB As New SqlClient.SqlCommand
        'With cmdRestoreDB
        '    .Connection = conn
        '    .CommandType = CommandType.Text
        '    .CommandText = "RESTORE DATABASE X FROM DISK=Y"
        'End With

        'conn.Close()

        'Microsoft.SqlServer.Management.Smo.Server(ApplicationGlobal.ServerConn)
        'Dim conn As ServerConnection = New ServerConnection(My.Settings.DataConnectionString)
        Dim srv As Server = New Microsoft.SqlServer.Management.Smo.Server(ApplicationGlobal.sqlServerConnection)

        Dim res As New Restore

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim fileName As String = Me.txtBackupFile.Text
            Dim dbName As String = Me.txtDatabaseName.Text

            res.Database = dbName
            res.Action = RestoreActionType.Database
            res.Devices.AddDevice(fileName, DeviceType.File)

            'Me.ProgressBar1.Value = 0
            'Me.ProgressBar1.Maximum = 100
            'Me.ProgressBar1.Value = 10

            res.PercentCompleteNotification = 10
            srv.KillAllProcesses(dbName)
            res.ReplaceDatabase = True
            res.SqlRestore(srv)

            MessageBox.Show("Restore of " + res.Database + " Complete!", _
                            "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.GetBaseException.ToString)
        Finally
            Me.Cursor = Cursors.Default
            'Me.ProgressBar1.Value = 0
        End Try
    End Sub

    Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click

        ' Create the database
        Dim sDatabaseName As String
        Dim db As Database
        Dim fg As FileGroup
        Dim df As DataFile
        Dim lf As LogFile
        Dim csr As Cursor = Nothing
        '  Dim DatabaseListViewItem As ListViewItem

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor
            ' Get the name of the new database
            sDatabaseName = Me.txtDatabaseName.Text

            ' Check for new non-zero length name
            If sDatabaseName.Length = 0 Then
                System.Windows.Forms.MessageBox.Show(Me, _
                My.Resources.NoDatabaseName, Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Error, _
                MessageBoxDefaultButton.Button1, 0)

                Return
            End If

            If Me.txtBackupFile.Text.Length = 0 Then
                System.Windows.Forms.MessageBox.Show(Me, _
                "Source file is missing", Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Error, _
                MessageBoxDefaultButton.Button1, 0)

                Return
            End If

            If Dir(Me.txtBackupFile.Text) = "" Then
                System.Windows.Forms.MessageBox.Show(Me, _
                "Wrong Source file or invalid path", Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Error, _
                MessageBoxDefaultButton.Button1, 0)

                Return
            End If
            ' Ensure we have the current list of databases to check.
            ApplicationGlobal.sqlServer.Databases.Refresh()

            ' Refresh database list
            ShowDatabases(False)

            ' Is database name new and unique?
            If (ApplicationGlobal.sqlServer.Databases.Contains(sDatabaseName)) Then
                System.Windows.Forms.MessageBox.Show(Me, _
                My.Resources.DuplicateDatabaseName, _
                Me.Text, MessageBoxButtons.OK, _
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0)

                Return
            End If
            'Attach the database
            Dim sc As StringCollection
            sc = New StringCollection
            Dim owner As String = "dbo"
            Dim logstr As String = ""
            Dim datastr As String = Me.txtBackupFile.Text
            '  owner = srv.Databases("AdventureWorks").Owner
            datastr = My.Computer.FileSystem.GetParentPath(ApplicationGlobal.sqlServer.Databases("master").FileGroups("primary").Files(0).FileName) & "\" & sDatabaseName & ".mdf"

            If My.Computer.FileSystem.GetFileInfo(Me.txtBackupFile.Text).Name.ToLower = "hemisdata.mdf" Then
                My.Computer.FileSystem.CopyFile(Me.txtBackupFile.Text, My.Computer.FileSystem.GetParentPath(Application.ExecutablePath) & "\hemisdata.mdf", True)
            End If
            My.Computer.FileSystem.CopyFile(Me.txtBackupFile.Text, datastr, True)

            sc.Add(datastr)
            'sc.Add(logstr)
            ApplicationGlobal.sqlServer.AttachDatabase(sDatabaseName, sc, owner, AttachOptions.None)

            ' Refresh database list
            'ShowDatabases(False)
            Exit Sub

            ' Instantiate a new database object
            db = New Database(ApplicationGlobal.sqlServer, sDatabaseName)

            ' This may also be accomplished like so:
            ' db = new Database()
            ' db.Parent = SqlServerSelection
            ' db.Name = sDatabaseName

            ' Add a new file group named PRIMARY to the database's FileGroups collection
            fg = New FileGroup(db, "PRIMARY")

            ' Create a new data file and add it to the file group's Files collection
            ' Give the data file a physical filename using the master database path of the server
            df = New DataFile(fg, sDatabaseName & "_Data0", _
                ApplicationGlobal.sqlServer.Information.MasterDBPath & "\" _
                    & sDatabaseName & "_Data0" & ".mdf")

            ' Set the size, growth, and maximum size of the data file
            df.GrowthType = FileGrowthType.KB
            df.Growth = 1024 ' In KB
            df.Size = 10240 ' Set initial size in KB (optional)
            df.MaxSize = 20480 ' In KB

            fg.Files.Add(df)

            ' Create a new data file and add it to the file group's Files collection
            ' Give the data file a physical filename using the master database path of the server
            df = New DataFile(fg, sDatabaseName & "_Data1", _
                ApplicationGlobal.sqlServer.Information.MasterDBPath & "\" _
                    & sDatabaseName & "_Data1" & ".ndf")

            ' Set the size, growth, and maximum size of the data file
            df.GrowthType = FileGrowthType.KB
            df.Growth = 1024 ' In KB
            df.Size = 2048 ' Set initial size in KB (optional)
            df.MaxSize = 8192 ' In KB

            fg.Files.Add(df)

            ' Add the new file group to the database's FileGroups collection
            db.FileGroups.Add(fg)

            ' Add a new file group named PRIMARY to the database's FileGroups collection
            fg = New FileGroup(db, "SECONDARY")

            ' Create a new data file and add it to the file group's Files collection
            ' Give the data file a physical filename using the master database path of the server
            df = New DataFile(fg, sDatabaseName & "_Data2", _
                ApplicationGlobal.sqlServer.Information.MasterDBPath & "\" _
                    & sDatabaseName & "_Data2" & ".ndf")

            ' Set the size, growth, and maximum size of the data file
            df.GrowthType = FileGrowthType.KB
            df.Growth = 512 ' In KB
            df.Size = 1024 ' Set initial size in KB (optional)
            df.MaxSize = 4096 ' In KB

            fg.Files.Add(df)

            ' Create a new data file and add it to the file group's Files collection
            ' Give the data file a physical filename using the master database path
            df = New DataFile(fg, sDatabaseName & "_Data3", _
                ApplicationGlobal.sqlServer.Information.MasterDBPath & "\" _
                    & sDatabaseName & "_Data3" & ".ndf")

            ' Set the size, growth, and maximum size of the data file
            df.GrowthType = FileGrowthType.KB
            df.Growth = 512 ' In KB
            df.Size = 1024 ' Set initial size in KB (optional)
            df.MaxSize = 4096 ' In KB

            fg.Files.Add(df)

            ' Add the new file group to the database's FileGroups collection
            db.FileGroups.Add(fg)

            ' Define the database transaction log.
            lf = New LogFile(db, sDatabaseName & "_Log", _
                ApplicationGlobal.sqlServer.Information.MasterDBPath & "\" _
                    & sDatabaseName & "_Log" & ".ldf")
            lf.GrowthType = FileGrowthType.KB
            lf.Growth = 1024 ' In KB
            lf.Size = 2048 ' Set initial size in KB (optional)
            lf.MaxSize = 8192 ' In KB

            db.LogFiles.Add(lf)

            ' Create the database as defined.
            db.Create()

            ' Refresh database list
            ShowDatabases(False)

            ' Find and select the database just created
            'DatabaseListViewItem _
            '    = DatabasesListView.FindItemWithText(sDatabaseName)
            'DatabaseListViewItem.Selected = True
            'DatabaseListViewItem.EnsureVisible()
        Catch ex As SmoException
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

            If Not ApplicationGlobal.objFrmMain Is Nothing Then
                ApplicationGlobal.objFrmMain.getControl("ServerConnection")
            End If
            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

    Private Sub btnDetach_Click(sender As Object, e As EventArgs) Handles btnDetach.Click
        ApplicationGlobal.sqlServer.DetachDatabase(Me.txtDatabaseName.Text, False, False)
    End Sub

    Private Sub btnBackupFile_Click(sender As Object, e As EventArgs) Handles btnBackupFile.Click

        Me.OpenFileDialog1.ShowDialog()

        Me.txtBackupFile.Text = Me.OpenFileDialog1.FileName

    End Sub

    Private Sub ProgressEventHandler(ByVal sender As Object, ByVal e As PercentCompleteEventArgs)
        txtResults.AppendText(My.Resources.ProgressCharacter)
        ScrollToBottom()
        UpdateStatus(e.Percent)
    End Sub

    Private Sub UpdateStatus(ByVal pct As Integer)
        statusBar1.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, _
            My.Resources.CompletedPercent, pct)
        statusBar1.Refresh()
    End Sub


    Private Sub ScrollToBottom()
        txtResults.Select()
        txtResults.SelectionStart = txtResults.Text.Length
        txtResults.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Show the current databases on the server
    ''' </summary>
    ''' <param name="selectDefault"></param>
    ''' <remarks></remarks>
    Private Sub ShowDatabases(ByVal selectDefault As Boolean)
        Dim csr As Cursor = Nothing

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

            ' Clear control
            cmbDatabases.Items.Clear()

            ' Limit the properties returned to just those that we use
            ApplicationGlobal.sqlServer.SetDefaultInitFields(GetType(Database), _
                New String() {"Name", "IsSystemObject", "IsAccessible"})

            ' Add database objects to combobox; the default ToString will display the database name
            For Each db As Database In ApplicationGlobal.sqlServer.Databases
                If db.IsSystemObject = False AndAlso db.IsAccessible = True Then
                    cmbDatabases.Items.Add(db)
                End If
            Next

            If selectDefault = True _
                AndAlso cmbDatabases.Items.Count > 0 Then
                cmbDatabases.SelectedIndex = 0
            End If
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)
        Finally
            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

End Class
