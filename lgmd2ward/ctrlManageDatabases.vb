
'============================================================================
'  File:    ManageDatabases.vb 
'
'  Summary: Implements an SMO create database sample in VB.NET.
'
'  Date:    June 06, 2005
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
Imports LGMD.ApplicationGlobal

Public Class ctrlManageDatabases
    
    Private strCurentAction As String

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strAction As String)
        'This call is required by the Windows Form Designer.
        strCurentAction = strAction
        InitializeComponent()

    End Sub

    Private Sub ctrlManageDatabases_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim scForm As ctrlDatabaseUtilities

        'Display the main window first
        Me.Show()

        Application.DoEvents()

        'sqlServerConnection = New ServerConnection()
        'sqlServerConnection.ConnectionString = My.Settings.DataConnectionString
        'scForm = New ctrlDatabaseUtilities(sqlServerConnection)
        scForm = New ctrlDatabaseUtilities(ApplicationGlobal.sqlServerConnection)

        If ApplicationGlobal.sqlServerConnection.IsOpen = True Then
            'sqlServer = New Microsoft.SqlServer.Management.Smo.Server()
            If Not (ApplicationGlobal.sqlServer Is Nothing) Then
                Me.Text = My.Resources.AppTitle & ApplicationGlobal.sqlServer.Name
                ' Refresh database list
                ShowDatabases(False)
            End If
        End If

        If strCurentAction = "Delete" Then
            Me.btnCreateDatabase.Visible = False
            Me.btnDeleteDatabase.Visible = True
            Me.lblNewDatabase.Visible = False
            Me.txtNewDatabase.Visible = False
        Else
            Me.btnDeleteDatabase.Visible = False
            Me.btnCreateDatabase.Visible = True
        End If

        ApplicationGlobal.sqlServer.Databases.Refresh()

        ' Refresh database list
        ShowDatabases(False)

        UpdateControls()
    End Sub

    Private Sub btnDeleteDatabase_Click(sender As Object, e As EventArgs) Handles btnDeleteDatabase.Click

        Dim sDatabaseName As String
        Dim csr As Cursor = Nothing
        Dim db As Database

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor

            ' Use the selected database as the one to be deleted
            sDatabaseName = listViewDatabases.SelectedItems(0).Text

            ' Drop (Delete) the database
            db = ApplicationGlobal.sqlServer.Databases(sDatabaseName)
            If Not (db Is Nothing) Then
                ' Are you sure?  Default to No.
                If System.Windows.Forms.MessageBox.Show(Me, String.Format( _
                    System.Globalization.CultureInfo.InvariantCulture, _
                    My.Resources.ReallyDrop, _
                    db.Name), Me.Text, MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question, _
                        MessageBoxDefaultButton.Button2, 0) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                db.Drop()
                sbrStatus.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, My.Resources.DatabaseDeleted, sDatabaseName)
            End If

            ' Refresh database list
            ShowDatabases(False)

        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)
        Finally
            UpdateControls()
            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

    Private Sub btnCreateDatabase_Click(sender As Object, e As EventArgs) Handles btnCreateDatabase.Click

        'Create the database
        Dim sDatabaseName As String
        Dim db As Database
        Dim fg As FileGroup
        Dim df As DataFile
        Dim lf As LogFile
        Dim csr As Cursor = Nothing
        Dim DatabaseListViewItem As ListViewItem

        Try
            csr = Me.Cursor 'Save the old cursor
            Me.Cursor = Cursors.WaitCursor 'Display the waiting cursor
            'Get the name of the new database
            sDatabaseName = txtNewDatabase.Text
            'Check for new non-zero length name
            If sDatabaseName.Length = 0 Then
                System.Windows.Forms.MessageBox.Show(Me, _
                My.Resources.NoDatabaseName, Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Error, _
                MessageBoxDefaultButton.Button1, 0)
                Return
            End If

            'Ensure we have the current list of databases to check.
            ApplicationGlobal.sqlServer.Databases.Refresh()

            'Refresh database list
            ShowDatabases(False)

            'Is database name new and unique?
            If (ApplicationGlobal.sqlServer.Databases.Contains(sDatabaseName)) Then
                System.Windows.Forms.MessageBox.Show(Me, _
                My.Resources.DuplicateDatabaseName, _
                Me.Text, MessageBoxButtons.OK, _
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0)
                Return
            End If
            '#Region "Name" 
            'Create a new database
            '' '' Instantiate a new database object
            ' ''db = New Database(SqlServerSelection, sDatabaseName)
            '' '' This may also be accomplished like so:
            '' '' db = new Database()
            '' '' db.Parent = SqlServerSelection
            '' '' db.Name = sDatabaseName
            '' '' Add a new file group named PRIMARY to the database's FileGroups collection
            ' ''fg = New FileGroup(db, "PRIMARY")
            '' '' Create a new data file and add it to the file group's Files collection
            '' '' Give the data file a physical filename using the master database path of the server
            ' ''df = New DataFile(fg, sDatabaseName & "_Data0", _
            ' ''    SqlServerSelection.Information.MasterDBPath & "\" _
            ' ''        & sDatabaseName & "_Data0" & ".mdf")
            '' '' Set the size, growth, and maximum size of the data file
            ' ''df.GrowthType = FileGrowthType.KB
            ' ''df.Growth = 1024 ' In KB
            ' ''df.Size = 10240 ' Set initial size in KB (optional)
            ' ''df.MaxSize = 20480 ' In KB
            ' ''fg.Files.Add(df)
            '' '' Create a new data file and add it to the file group's Files collection
            '' '' Give the data file a physical filename using the master database path of the server
            ' ''df = New DataFile(fg, sDatabaseName & "_Data1", _
            ' ''    SqlServerSelection.Information.MasterDBPath & "\" _
            ' ''        & sDatabaseName & "_Data1" & ".ndf")
            '' '' Set the size, growth, and maximum size of the data file
            ' ''df.GrowthType = FileGrowthType.KB
            ' ''df.Growth = 1024 ' In KB
            ' ''df.Size = 2048 ' Set initial size in KB (optional)
            ' ''df.MaxSize = 8192 ' In KB
            ' ''fg.Files.Add(df)
            '' '' Add the new file group to the database's FileGroups collection
            ' ''db.FileGroups.Add(fg)
            '' '' Add a new file group named PRIMARY to the database's FileGroups collection
            ' ''fg = New FileGroup(db, "SECONDARY")
            '' '' Create a new data file and add it to the file group's Files collection
            '' '' Give the data file a physical filename using the master database path of the server
            ' ''df = New DataFile(fg, sDatabaseName & "_Data2", _
            ' ''    SqlServerSelection.Information.MasterDBPath & "\" _
            ' ''        & sDatabaseName & "_Data2" & ".ndf")
            '' '' Set the size, growth, and maximum size of the data file
            ' ''df.GrowthType = FileGrowthType.KB
            ' ''df.Growth = 512 ' In KB
            ' ''df.Size = 1024 ' Set initial size in KB (optional)
            ' ''df.MaxSize = 4096 ' In KB
            ' ''fg.Files.Add(df)
            '' '' Create a new data file and add it to the file group's Files collection
            '' '' Give the data file a physical filename using the master database path
            ' ''df = New DataFile(fg, sDatabaseName & "_Data3", _
            ' ''    SqlServerSelection.Information.MasterDBPath & "\" _
            ' ''        & sDatabaseName & "_Data3" & ".ndf")
            '' '' Set the size, growth, and maximum size of the data file
            ' ''df.GrowthType = FileGrowthType.KB
            ' ''df.Growth = 512 ' In KB
            ' ''df.Size = 1024 ' Set initial size in KB (optional)
            ' ''df.MaxSize = 4096 ' In KB
            ' ''fg.Files.Add(df)
            '' '' Add the new file group to the database's FileGroups collection
            ' ''db.FileGroups.Add(fg)
            '' '' Define the database transaction log.
            ' ''lf = New LogFile(db, sDatabaseName & "_Log", _
            ' ''    SqlServerSelection.Information.MasterDBPath & "\" _
            ' ''        & sDatabaseName & "_Log" & ".ldf")
            ' ''lf.GrowthType = FileGrowthType.KB
            ' ''lf.Growth = 1024 ' In KB
            ' ''lf.Size = 2048 ' Set initial size in KB (optional)
            ' ''lf.MaxSize = 8192 ' In KB
            ' ''db.LogFiles.Add(lf)
            '' '' Create the database as defined.
            ' ''db.Create()
            '#End Region

            'Attach the database
            Dim sc As StringCollection
            sc = New StringCollection
            Dim owner As String = "dbo"
            Dim logstr As String = ""
            Dim strDatabasesource = My.Computer.FileSystem.GetParentPath(Application.ExecutablePath) & "\Data\LGMD2iDataModel.mdf"
            If Dir(strDatabasesource) = "" Then
                MsgBox("Template File is missing")
                Exit Sub
            End If
            Dim datastr As String = ""
            datastr = My.Computer.FileSystem.GetParentPath(ApplicationGlobal.sqlServer.Databases("master").FileGroups("primary").Files(0).FileName) & "\" & sDatabaseName & ".mdf"
            My.Computer.FileSystem.CopyFile(strDatabasesource, datastr, True)
            sc.Add(datastr)
            'sc.Add(logstr)
            Try
                ApplicationGlobal.sqlServer.AttachDatabase(sDatabaseName, sc, owner, AttachOptions.None)
            Catch ex As Exception
            End Try

            ApplicationGlobal.sqlServer.Databases.Refresh()
            ' Refresh database list
            ShowDatabases(False)

            ' Find and select the database just created
            DatabaseListViewItem = listViewDatabases.FindItemWithText(sDatabaseName)
            DatabaseListViewItem.Selected = True
            DatabaseListViewItem.EnsureVisible()
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)
        Finally
            ' Clean up.
            db = Nothing
            fg = Nothing
            df = Nothing
            lf = Nothing

            UpdateControls()

            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

    Private Sub listViewDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewDatabases.SelectedIndexChanged
        UpdateControls()
    End Sub

    Private Sub txtNewDatabase_TextChanged(sender As Object, e As EventArgs) Handles txtNewDatabase.TextChanged
        UpdateControls()
    End Sub

    Private Sub ShowServerMessagesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowServerMessagesCheckBox.CheckedChanged
        If ShowServerMessagesCheckBox.CheckState = CheckState.Checked Then
            AddHandler sqlServer.ConnectionContext.InfoMessage, _
                AddressOf SqlInfoMessage
            AddHandler sqlServer.ConnectionContext.ServerMessage, _
                AddressOf ServerMessage
        Else
            RemoveHandler sqlServer.ConnectionContext.InfoMessage, _
                AddressOf SqlInfoMessage
            RemoveHandler sqlServer.ConnectionContext.ServerMessage, _
                AddressOf ServerMessage
        End If
    End Sub

    Private Sub SqlInfoMessage(ByVal sender As Object, ByVal e As SqlClient.SqlInfoMessageEventArgs)
        me.txtEventLog.AppendText(My.Resources.SqlInfoMessage & e.ToString() & Environment.NewLine)
    End Sub

    Private Sub ServerMessage(ByVal sender As Object, ByVal e As ServerMessageEventArgs)
        Me.txtEventLog.AppendText(My.Resources.ServerMessage & e.ToString() & Environment.NewLine)
    End Sub

    Private Sub ServerStatementExecuted(ByVal sender As Object, ByVal e As StatementEventArgs)
        Dim sTmp As String = e.ToString().Replace(vbLf, Environment.NewLine)
        txtEventLog.AppendText(My.Resources.SqlStatementExecuted & sTmp & Environment.NewLine)
    End Sub

    Private Sub ShowDatabases(ByVal selectDefault As Boolean)
        ' Show the current databases on the server
        Dim DatabaseListViewItem As ListViewItem
        Dim csr As Cursor = Nothing

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor
            ' Clear control
            listViewDatabases.Items.Clear()

            ' Limit the properties returned to just those that we use
            sqlServer.SetDefaultInitFields(GetType(Database), _
                New String() {"Name", "IsSystemObject", "IsAccessible", _
                "Status", "CreateDate", "Size", _
                "SpaceAvailable", "CompatibilityLevel"})

            For Each db As Database In sqlServer.Databases
                Try
                    If db.IsSystemObject = False AndAlso db.IsAccessible = True Then
                        DatabaseListViewItem = listViewDatabases.Items.Add(db.Name)
                        If ((db.Status And DatabaseStatus.Normal) _
                            = DatabaseStatus.Normal) Then
                            DatabaseListViewItem.SubItems.Add( _
                                db.CreateDate.ToString( _
                                System.Globalization.CultureInfo.InvariantCulture))
                            DatabaseListViewItem.SubItems.Add( _
                                db.Size.ToString( _
                                System.Globalization.CultureInfo.InvariantCulture) _
                                & " MB")
                            DatabaseListViewItem.SubItems.Add( _
                                (db.SpaceAvailable / 1000.0).ToString( _
                                System.Globalization.CultureInfo.InvariantCulture) _
                                & " MB")
                            DatabaseListViewItem.SubItems.Add( _
                                db.CompatibilityLevel.ToString())
                        End If
                    End If
                Catch ex As Exception

                End Try

            Next

            If selectDefault = True AndAlso listViewDatabases.Items.Count > 0 Then
                listViewDatabases.Items(0).Selected = True
            End If
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)
        Finally
            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

    Private Sub UpdateControls()
        If (listViewDatabases.SelectedItems.Count > 0) Then
            btnDeleteDatabase.Enabled = True
        Else
            btnDeleteDatabase.Enabled = False
        End If

        If (txtNewDatabase.Text.Length > 0) Then
            btnCreateDatabase.Enabled = True
        Else
            btnCreateDatabase.Enabled = False
        End If
    End Sub

    Private Sub ShowSqlStatementsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowSqlStatementsCheckBox.CheckedChanged
        If ShowSqlStatementsCheckBox.CheckState = CheckState.Checked Then
            AddHandler sqlServer.ConnectionContext.StatementExecuted, AddressOf ServerStatementExecuted
        Else
            RemoveHandler sqlServer.ConnectionContext.StatementExecuted, AddressOf ServerStatementExecuted
        End If
    End Sub

End Class

