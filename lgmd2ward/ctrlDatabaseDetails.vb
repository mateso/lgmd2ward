
'============================================================================
'  File:    MainForm.vb
'
'  Summary: Implements a sample SMO dependency and scripting utility in VB.NET.
'
'  Date:    September 30, 2005
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
Option Strict Off

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Specialized
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
'Imports Microsoft.SqlServer.MessageBox
Imports LGMD.ApplicationGlobal


''' <summary>
''' Summary description for form.
''' </summary>

Partial Public Class ctrlDatabaseDetails 'The Partial modifier is only required on one class definition per project.
    'Inherits System.Windows.Forms.UserControl
    ' Use the Server object to connect to a specific server
    'Private sqlServerSelection As New Microsoft.SqlServer.Management.Smo.Server(".\SQLEXPRESS")

    Private root As TreeNode
    Private objSelected As Object
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    '''Private components As System.ComponentModel.IContainer = Nothing 'todo

    Public Sub New()
        InitializeComponent()
        Dim strDatabasesource = My.Computer.FileSystem.GetParentPath(Application.ExecutablePath) & "\hemisdata.mdf"
        If Dir(strDatabasesource) = "" Then
            Me.objNewDatabaseMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ConnectToServer(ByVal server As String)
        Try
            If Not ApplicationGlobal.sqlServerConnection.IsOpen Then
                Dim srvr As New Microsoft.SqlServer.Management.Smo.Server(server)
                srvr.ConnectionContext.ConnectTimeout = 5
                srvr.ConnectionContext.Connect()
                'frmMain.SqlServerSelection = srvr
                ApplicationGlobal.sqlServer = srvr
            End If
        Catch ex As ConnectionFailureException
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)

            Cursor = Cursors.Default
            'frmMain.SqlServerSelection = Nothing
            ApplicationGlobal.sqlServer = Nothing
        End Try

        'Me.serverVersionToolStripStatusLabel.Text = frmMain.SqlServerSelection.Information.Version.ToString() + " " + frmMain.SqlServerSelection.Information.Edition
        Me.serverVersionToolStripStatusLabel.Text = ApplicationGlobal.sqlServer.Information.Version.ToString() + " " + ApplicationGlobal.sqlServer.Information.Edition
        Me.SqlServerTreeView.Nodes.Clear()

        ' Add Server node
        'Dim node As New TreeNode(frmMain.SqlServerSelection.ConnectionContext.TrueName + " Logged as " + frmMain.SqlServerSelection.ConnectionContext.TrueLogin)
        Dim node As New TreeNode(ApplicationGlobal.sqlServer.ConnectionContext.TrueName + " Logged as " + ApplicationGlobal.sqlServer.ConnectionContext.TrueLogin)
        ''Dim node As New TreeNode(frmMain.sqlServerSelection.ConnectionContext.TrueName)
        node.Name = My.Resources.Server
        root = node
        'node.Tag = frmMain.SqlServerSelection
        node.Tag = ApplicationGlobal.sqlServer
        node.ImageIndex = 0
        Me.SqlServerTreeView.Nodes.Add(node)

        ' Add Databases node
        node = New TreeNode(My.Resources.Databases)
        node.Name = My.Resources.Databases
        'node.Tag = frmMain.SqlServerSelection.Databases
        node.Tag = ApplicationGlobal.sqlServer.Databases
        node.ImageIndex = 2
        root.Nodes.Add(node)
        If ApplicationGlobal.sqlServerConnection.IsOpen Then AddDummyNode(node)

        Me.SqlServerTreeView.SelectedNode = root

        ' Optimizing code
        ApplicationGlobal.sqlServer.SetDefaultInitFields(GetType(Database), "CreateDate", "IsSystemObject", "CompatibilityLevel")
        ApplicationGlobal.sqlServer.SetDefaultInitFields(GetType(Table), "CreateDate", "IsSystemObject")
        ApplicationGlobal.sqlServer.SetDefaultInitFields(GetType(Microsoft.SqlServer.Management.Smo.View), "CreateDate", "IsSystemObject")
        ApplicationGlobal.sqlServer.SetDefaultInitFields(GetType(StoredProcedure), "CreateDate", "IsSystemObject")
        ApplicationGlobal.sqlServer.SetDefaultInitFields(GetType(Column), True)
    End Sub

    Private Sub SqlServerTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles SqlServerTreeView.AfterSelect
        Cursor = Cursors.WaitCursor
        Dim start As DateTime = DateTime.Now
        ShowDetails(Me.SqlServerTreeView.SelectedNode)
        Dim diff As TimeSpan = DateTime.Now - start
        Me.speedToolStripStatusLabel.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:####}", diff.TotalMilliseconds)
        Cursor = Cursors.Default


    End Sub

    Private Sub SqlServerTreeView_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles SqlServerTreeView.AfterExpand
        Cursor = Cursors.WaitCursor
        LoadTreeViewItems(e.Node)
        Cursor = Cursors.Default
    End Sub

    ' Loads treeview items and updates listview as well.
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")> _
    Private Sub ShowDetails(ByVal node As TreeNode)
        Dim smoObject As SqlSmoObject = Nothing
        Dim smoCollection As SmoCollectionBase = Nothing

        Me.ListView.Items.Clear()

        If node Is Nothing Then
            Return
        End If

        Select Case node.Tag.GetType().Name
            Case "DatabaseCollection", "TableCollection", "ViewCollection", "StoredProcedureCollection", "ColumnCollection", "SqlAssemblyCollection"
                ' Load the items of a collection, if not already loaded
                LoadTreeViewItems(node)

                ' Update the TreeView
                smoCollection = CType(node.Tag, SmoCollectionBase)
                If ApplicationGlobal.sqlServerConnection.IsOpen Then UpdateListViewWithCollection(smoCollection)

            Case "Server"
                smoObject = CType(node.Tag, Microsoft.SqlServer.Management.Smo.Server).Information
                UpdateListView(smoObject, True, "Information")

                smoObject = CType(node.Tag, Microsoft.SqlServer.Management.Smo.Server).Settings
                UpdateListView(smoObject, False, "Settings")

            Case "Database", "Table", "View", "StoredProcedure", "Column", "SqlAssembly"
                smoObject = CType(node.Tag, SqlSmoObject)
                If ApplicationGlobal.sqlServerConnection.IsOpen Then UpdateListView(smoObject, True, Nothing)

            Case Else
                Throw New Exception(My.Resources.UnrecognizedType _
                    & node.Tag.GetType().ToString())
        End Select
    End Sub

    ' Update the list view for a property list
    Private Sub UpdateListView(ByVal smoObject As SqlSmoObject, ByVal clear As Boolean, ByVal group As String)
        smoObject.Initialize(True)
        If clear = True Then
            Me.ListView.Columns.Clear()
            Me.ListView.Groups.Clear()

            Dim colHeader As New ColumnHeader()
            colHeader.Text = My.Resources.PropertyName
            Me.ListView.Columns.Add(colHeader)

            colHeader = New ColumnHeader()
            colHeader.Text = My.Resources.Value
            Me.ListView.Columns.Add(colHeader)
        End If

        Dim lvGroup As ListViewGroup = Nothing
        If Not (group Is Nothing) Then
            lvGroup = New ListViewGroup(group)
            Me.ListView.Groups.Add(lvGroup)
        End If

        Dim lvi As New ListViewItem()
        lvi.Text = My.Resources.Urn
        lvi.Name = My.Resources.Urn
        lvi.Group = lvGroup
        lvi.SubItems.Add(smoObject.Urn)
        Me.ListView.Items.Add(lvi)

        Dim prop As [Property]
        For Each prop In smoObject.Properties
            If Not (prop.Value Is Nothing) Then
                Dim lvItem As New ListViewItem()
                lvItem.Text = prop.Name
                lvItem.Name = prop.Name
                lvItem.Group = lvGroup

                lvItem.SubItems.Add(prop.Value.ToString())
                Me.ListView.Items.Add(lvItem)
            End If
        Next

        Me.ListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView.Sort()
        Me.ListView.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        Me.ListView.Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    ' Lists a collection in the listview if the container node is selected
    Private Sub UpdateListViewWithCollection(ByVal smoCollection As SmoCollectionBase)
        Me.ListView.Columns.Clear()
        Me.ListView.Groups.Clear()

        Dim colHeader As New ColumnHeader()
        colHeader.Text = My.Resources.ObjectName
        Me.ListView.Columns.Add(colHeader)

        colHeader = New ColumnHeader()
        If TypeOf smoCollection Is ColumnCollection Then
            colHeader.Text = My.Resources.DataType
        Else
            colHeader.Text = My.Resources.DateCreated
        End If

        Me.ListView.Columns.Add(colHeader)

        For Each smoObject As SqlSmoObject In smoCollection
            If smoObject.Properties.Contains("IsSystemObject") = True _
                AndAlso CBool(smoObject.Properties("IsSystemObject").Value) = True Then
                Continue For
            End If

            Dim lvi As New ListViewItem()
            lvi.Text = smoObject.ToString()
            lvi.Name = smoObject.ToString()

            If TypeOf smoObject Is Column Then
                lvi.SubItems.Add(smoObject.Properties("DataType").Value.ToString())
            Else
                lvi.SubItems.Add(smoObject.Properties("CreateDate").Value.ToString())
            End If

            lvi.Tag = smoObject
            Me.ListView.Items.Add(lvi)
        Next

        Me.ListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView.Sort()
        Me.ListView.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        Me.ListView.Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    ''' <summary>
    ''' Loads the collection items. This has to be deferred else starting is 
    ''' too expensive.
    ''' </summary>
    ''' <param name="node"></param>
    Private Sub LoadTreeViewItems(ByVal node As TreeNode)
        If node.Nodes.Count = 1 AndAlso Not (node.Nodes(My.Resources.DummyNode) Is Nothing) Then
            node.Nodes(My.Resources.DummyNode).Remove()
        Else
            Return
        End If

        Select Case node.Name
            Case "Databases"
                node.ImageIndex = 2
                LoadTreeViewDatabases(node)


            Case "Stored Procedures"
                LoadTreeViewStoredProcedures(node)


            Case "Assemblies"
                LoadTreeViewAssemblies(node)


            Case "Tables"
                LoadTreeViewTables(node)


            Case "Views"
                LoadTreeViewViews(node)


            Case "Columns"
                LoadTreeViewColumns(node)
        End Select
    End Sub

    Private Sub LoadTreeViewDatabases(ByVal node As TreeNode)
        Dim db As Database
        For Each db In CType(node.Tag, DatabaseCollection)
            If db.IsSystemObject = False And ApplicationGlobal.sqlServerConnection.IsOpen Then
                Dim dbNode As New TreeNode(db.Name)
                dbNode.Name = db.Name
                dbNode.Tag = db
                dbNode.ImageIndex = 1
                root.Nodes("Databases").Nodes.Add(dbNode)
                AddDummyNode(node)
                'TODO this is to be done later

                'Dim tcNode As New TreeNode(My.Resources.Tables)
                'tcNode.Name = My.Resources.Tables
                'tcNode.Tag = db.Tables
                'dbNode.Nodes.Add(tcNode)
                'AddDummyNode(tcNode)

                'Dim vcNode As New TreeNode(My.Resources.Views)
                'vcNode.Name = My.Resources.Views
                'vcNode.Tag = db.Views
                'dbNode.Nodes.Add(vcNode)
                'AddDummyNode(vcNode)

                'Dim spNode As New TreeNode(My.Resources.StoredProcedures)
                'spNode.Name = My.Resources.StoredProcedures
                'spNode.Tag = db.StoredProcedures
                'dbNode.Nodes.Add(spNode)
                'AddDummyNode(spNode)

                'If sqlServerSelection.Information.Version.Major >= 9 Then
                '    Dim assyNode As New TreeNode(My.Resources.Assemblies)
                '    assyNode.Name = My.Resources.Assemblies
                '    assyNode.Tag = db.Assemblies
                '    dbNode.Nodes.Add(assyNode)
                '    AddDummyNode(assyNode)
                'End If
            End If
        Next
    End Sub

    Private Shared Sub LoadTreeViewTables(ByVal node As TreeNode)
        Dim tbl As Table
        For Each tbl In CType(node.Tag, TableCollection)
            If tbl.IsSystemObject = False Then
                Dim tNode As New TreeNode(tbl.ToString())
                tNode.Name = tbl.ToString()
                tNode.Tag = tbl
                node.Nodes.Add(tNode)

                ' Add Columns
                Dim tcNode As New TreeNode(My.Resources.Columns)
                tcNode.Name = My.Resources.Columns
                tcNode.Tag = tbl.Columns
                tNode.Nodes.Add(tcNode)
                AddDummyNode(tcNode)
            End If
        Next
    End Sub

    Private Shared Sub LoadTreeViewViews(ByVal node As TreeNode)
        Dim v As Microsoft.SqlServer.Management.Smo.View
        For Each v In CType(node.Tag, ViewCollection)
            If v.IsSystemObject = False Then
                Dim tNode As New TreeNode(v.ToString())
                tNode.Name = v.ToString()
                tNode.Tag = v
                node.Nodes.Add(tNode)

                ' Add Columns
                Dim tcNode As New TreeNode(My.Resources.Columns)
                tcNode.Name = My.Resources.Columns
                tcNode.Tag = v.Columns
                tNode.Nodes.Add(tcNode)
                AddDummyNode(tcNode)
            End If
        Next
    End Sub

    Private Shared Sub LoadTreeViewColumns(ByVal node As TreeNode)
        Dim col As Column
        For Each col In CType(node.Tag, ColumnCollection)
            Dim tNode As New TreeNode(col.ToString())
            tNode.Name = col.ToString()
            tNode.Tag = col
            node.Nodes.Add(tNode)
        Next
    End Sub

    Private Shared Sub LoadTreeViewStoredProcedures(ByVal node As TreeNode)
        Dim sp As StoredProcedure
        For Each sp In CType(node.Tag, StoredProcedureCollection)
            If sp.IsSystemObject = False Then
                Dim tNode As New TreeNode(sp.ToString())
                tNode.Name = sp.ToString()
                tNode.Tag = sp
                node.Nodes.Add(tNode)
            End If
        Next
    End Sub

    Private Shared Sub LoadTreeViewAssemblies(ByVal node As TreeNode)
        Dim assy As SqlAssembly
        For Each assy In CType(node.Tag, SqlAssemblyCollection)
            Dim tNode As New TreeNode(assy.ToString())
            tNode.Name = assy.ToString()
            tNode.Tag = assy
            node.Nodes.Add(tNode)
        Next
    End Sub

    ' Adds a dummy node, so we can expand a node without querying
    ' whether there are any items
    Private Shared Sub AddDummyNode(ByVal node As TreeNode)
        If node.Nodes.Count <> 0 Then
            Return
        End If

        node.Nodes.Add(My.Resources.DummyNode)
        node.Nodes(0).Name = My.Resources.DummyNode
    End Sub

    Private Sub ListView_ContextMenuChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView.ContextMenuChanged

    End Sub

    ' Double click on a listview item causes the tree to be synced.
    Private Sub ListView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListView.DoubleClick
        If ListView.SelectedItems.Count = 0 Then
            Return
        End If

        Dim obj As Object = ListView.SelectedItems(0).Tag
        If TypeOf obj Is SqlSmoObject = False Then
            Return
        End If

        Dim found As TreeNode() = root.Nodes.Find(obj.ToString(), True)

        ' If new objects are added the names may clash
        If found.Length > 1 Then
            Return
        End If

        SqlServerTreeView.SelectedNode = found(0)
        SqlServerTreeView.Focus()
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")> _
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '' Dim ServerConn As New ServerConnection()
        ' Dim scForm As ctrlDatabaseUtilities  '' ServerConnect 'todo
        'Dim dr As DialogResult

        Try
            ' Display the main window first
            ''Me.Show()
            'Application.DoEvents()
            If ApplicationGlobal.sqlServerConnection Is Nothing Then ApplicationGlobal.sqlServerConnection = New ServerConnection
            ''scForm = New ctrlDatabaseUtilities(ServerConn) ''ServerConnect(ServerConn) 'todo 
            ''scForm.Show()
            '' dr = scForm.ShowDialog(Me)
            ''If Not dr = Windows.Forms.DialogResult.OK AndAlso ServerConn.SqlConnectionObject.State = ConnectionState.Open Then 'TODO dialogue result
            ApplicationGlobal.sqlServer = New Microsoft.SqlServer.Management.Smo.Server(ApplicationGlobal.sqlServerConnection)
            If Not (ApplicationGlobal.sqlServer Is Nothing) Then
                Me.Text = My.Resources.AppTitle + ApplicationGlobal.sqlServer.Name

                ' Refresh database list
                ConnectToServer(ApplicationGlobal.sqlServerConnection.ServerInstance)
            End If
            Me.SqlServerTreeView.ContextMenuStrip = Me.ListViewContextMenuStrip
            ''Else
            '' Me.Close()
            ''End If

        Catch ex As Exception
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)
        End Try
    End Sub

    Private Sub objConnectMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles objConnectMenuItem.Click
        If objSelected = "ListView" Then
            If Me.ListView.SelectedItems.Count = 0 Then
                Return
            End If
        Else
            If Me.SqlServerTreeView.SelectedNode Is Nothing Then
                Return
            End If
        End If
        If Me.SqlServerTreeView.SelectedNode.Name = "Server" Then
            objUserctrl = New ctrlDatabaseUtilities(ApplicationGlobal.sqlServerConnection, "dBDetails")  '' ctrlMainform
            objUserctrl.controls("ServerNamesComboBox").enabled = False
            objUserctrl.controls("ServerNamesComboBox").text = Me.SqlServerTreeView.SelectedNode.Text

        ElseIf Me.SqlServerTreeView.SelectedNode.Parent.Name = "Databases" Then
            'objUserctrl = New ctrlLoginScreen '' ctrlMainform
            Dim f As New frmLogin
            f.ShowDialog()
            Me.Dispose()
        End If
        '' u = New gHalistech

        objUserctrl.Name = "objUserctrl"
        objUserctrl.Tag = "objUserctrl"
        ''Me.SplitContainer1.Panel2.Controls.Add(objUserctrl)
        'Call fnGetWindow(objUserctrl)


        'Dim selectedObject As Object = Me.ListView.SelectedItems(0).Tag
        'Dim scriptableObject As IScriptable = TryCast(selectedObject, IScriptable)
        'If Not (scriptableObject Is Nothing) Then
        '    Dim strings As StringCollection = scriptableObject.Script()
        '    Dim frm As New TextOutputForm(strings)
        '    frm.ShowDialog(Me)
        'End If
    End Sub

    Private Sub scriptwithDependenciesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles objNewDatabaseMenuItem.Click
        If objSelected = "ListView" Then
            If Me.ListView.SelectedItems.Count = 0 Then
                Return
            End If
        Else
            If Me.SqlServerTreeView.SelectedNode Is Nothing Then
                Return
            End If
        End If
        'If 
        'Me.SqlServerTreeView.SelectedNode.Name = "Server" Then
        '            objUserctrl = New ctrlDatabaseUtilities(gHalistech.ServerConn, "dBDetails")  '' ctrlMainform
        '            objUserctrl.controls("ServerNamesComboBox").enabled = False
        '            objUserctrl.controls("ServerNamesComboBox").text = Me.SqlServerTreeView.SelectedNode.Text

        '        Else
        If Me.SqlServerTreeView.SelectedNode.Parent.Name = "Server" Then
            objUserctrl = New ctrlManageDatabases() '"Attach", Nothing) '' ctrlMainform
        End If
        '' u = New gHalistech
        objUserctrl.Name = "objUserctrl"
        objUserctrl.Tag = "objUserctrl"
        ''Me.SplitContainer1.Panel2.Controls.Add(objUserctrl)
        Call fnGetWindow(objUserctrl)
    End Sub

    Private Sub dependenciesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Me.ListView.SelectedItems.Count = 0 Then
            Return
        End If

        Dim selectedObject As Object = Me.ListView.SelectedItems(0).Tag
        Dim scriptableObject As IScriptable = TryCast(selectedObject, IScriptable)
        If Not (scriptableObject Is Nothing) AndAlso Not TypeOf selectedObject Is Database Then
            Dim smoObjects(0) As SqlSmoObject
            smoObjects(0) = CType(selectedObject, SqlSmoObject)

            Dim scripter As New Scripter(ApplicationGlobal.sqlServer)
            Dim frm As New DependenciesForm(ApplicationGlobal.sqlServer, scripter.DiscoverDependencies(smoObjects, DependencyType.Parents))

            frm.ShowDialog(Me)
        End If
    End Sub

    Private Sub ListViewContextMenuStrip_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles ListViewContextMenuStrip.Opening
        Try
            Dim mnuItem As Object ''ToolStripMenuItem

            For Each mnuItem In Me.ListViewContextMenuStrip.Items
                mnuItem.Enabled = False
            Next
            Me.objTasksMenuItem.Enabled = True
            For Each mnuItem In Me.objTasksMenuItem.DropDownItems
                mnuItem.Enabled = False
            Next

            If Me.ListView.SelectedItems.Count = 0 And Me.SqlServerTreeView.SelectedNode Is Nothing Then
                Return
            End If
            Dim s As Object
            If objSelected = "ListView" Then
                s = Me.ListView.SelectedItems(0).Tag
            Else
                s = Me.SqlServerTreeView.SelectedNode.Tag
            End If
            If s.GetType.Name = "DatabaseCollection" Then
                If ApplicationGlobal.sqlServerConnection.IsOpen Then Me.objNewDatabaseMenuItem.Enabled = True
                Me.objAttachMenuItem.Enabled = True
            End If
            Dim smoObject As SqlSmoObject = CType(s, SqlSmoObject)
            '' Else
            ''Dim smoObject As SqlSmoObject = CType(Me.ListView.SelectedItems(0).Tag, SqlSmoObject)
            ''End If

            Dim scriptableObject As IScriptable = TryCast(smoObject, IScriptable)
            If Not (scriptableObject Is Nothing) Then
                ''Me.objConnectMenuItem.Enabled = True
            End If
            If Me.SqlServerTreeView.SelectedNode.Text = "Databases" Then
                'If ApplicationGlobal.ServerConn.IsOpen Then Me.objNewDatabaseMenuItem.Enabled = True
                'Return
                'Me.objConnectMenuItem
            End If
            If TypeOf smoObject Is Database And ApplicationGlobal.sqlServerConnection.IsOpen Then
                Me.objConnectMenuItem.Enabled = True
                Me.objDeleteMenuItem.Enabled = True
                Me.objBackupMenuItem.Enabled = True
                Me.objDetachMenuItem.Enabled = True
                Me.objDisConnectMenuItem.Enabled = True
                Me.objNewDatabaseMenuItem.Enabled = True
                Me.objRestoreMenuItem.Enabled = True
                Me.objRunScriptMenuItem.Enabled = True
                Me.objShrinkMenuItem.Enabled = True
            End If
            If TypeOf smoObject Is Microsoft.SqlServer.Management.Smo.Server Then
                If ApplicationGlobal.sqlServerConnection.IsOpen Then
                    Me.objDisConnectMenuItem.Enabled = True
                Else
                    Me.objConnectMenuItem.Enabled = True
                End If
            End If
            If Not (scriptableObject Is Nothing) AndAlso Not TypeOf smoObject Is Database Then
                ''   Me.scriptwithDependenciesToolStripMenuItem.Enabled = True
                '' Me.dependenciesToolStripMenuItem.Enabled = True
                '' Me.objConnectMenuItem.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub ListView_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView.ItemSelectionChanged
        objSelected = "ListView"
    End Sub

    Private Sub SqlServerTreeView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SqlServerTreeView.Click
        objSelected = "SqlServerTreeView"
    End Sub

    
    Private Sub ListView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseDown
        objSelected = "ListView"
    End Sub

    Private Sub ListView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseUp

    End Sub

    Private Sub SqlServerTreeView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SqlServerTreeView.MouseDown
        objSelected = "SqlServerTreeView"
    End Sub

    Private Sub SqlServerTreeView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SqlServerTreeView.MouseUp

    End Sub

    Public Sub fnGetWindow(Optional ByVal strWindowName As UserControl = Nothing)
        If strWindowName Is Nothing Then
            ''  dim c as New   

            Select Case Me.SplitContainer1.Panel2.Controls("objUserctrl").Tag.ToString
                Case "ctrlDatabaseDetails", "objUserctrl"
                    objUserctrl = New ctrlDatabaseUtilities(ApplicationGlobal.sqlServerConnection)
                Case "ctrlDatabaseUtilities"
                    ' samuel  objUserctrl = New HEMIS.ctrlLoginScreen ''ctrlDatabaseDetails
                Case "ctrlLoginScreen"
                    objUserctrl = New ctrlDatabaseDetails
            End Select
        Else
            objUserctrl = strWindowName

        End If

        Me.splitContainer1.Panel2.Controls.RemoveByKey("ListView")
        If strWindowName Is Nothing Then
            Me.SplitContainer1.Panel2.Controls.Add(objUserctrl)
        Else
            Try
                Me.splitContainer1.Panel2.Controls.RemoveAt(0) '(strWindowName)
            Catch ex As Exception

            End Try

            Me.splitContainer1.Panel2.Controls.Add(strWindowName)
        End If

        objUserctrl.Dock = DockStyle.Fill
        objUserctrl.Tag = objUserctrl.Name
        objUserctrl.Name = "objUserctrl"
    End Sub

    Private Sub objDisConnectMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles objDisConnectMenuItem.Click
        'samuel
        ' ''If Me.SqlServerTreeView.SelectedNode.Name = "Server" Then
        ' ''    'objUserctrl = New ctrlDatabaseUtilities(gHalistech.ServerConn, "dBDetails")  '' ctrlMainform
        ' ''    'objUserctrl.controls("ServerNamesComboBox").enabled = True
        ' ''    'objUserctrl.controls("ServerNamesComboBox").text = Me.SqlServerTreeView.SelectedNode.Text

        ' ''    objUserctrl = New VisualComponent.ctrlDatabaseDetails()
        ' ''    gHalistech.ServerConn.Disconnect()
        ' ''    ''Dim u As frmMainScreen
        ' ''    ''Call gHalistech.fMainScreen.fnGetWindow(objUserctrl)

        ' ''ElseIf Me.SqlServerTreeView.SelectedNode.Parent.Name = "Databases" Then
        ' ''    objUserctrl = New ctrlLoginScreen '' ctrlMainform
        ' ''End If
        ' '' '' u = New gHalistech
        ' ''objUserctrl.Name = "objUserctrl"
        ' ''objUserctrl.Tag = "objUserctrl"
        ' '' ''Me.SplitContainer1.Panel2.Controls.Add(objUserctrl)
        ' '' '' Call fnGetWindow(objUserctrl)
        ' ''Call gHalistech.fMainScreen.fnGetWindow(objUserctrl)
        ' ''ShowDetails(Me.SqlServerTreeView.SelectedNode)

    End Sub
    Public Sub fnTreeviewExpand()
        ''LoadTreeViewItems(Me.SqlServerTreeView.TopNode)
        ''ShowDetails(Me.SqlServerTreeView.TopNode)
        ''ShowDetails(Me.SqlServerTreeView.TopNode)
        'TODO Expand dbs
        Me.SqlServerTreeView.ExpandAll()
    End Sub

    Private Sub objDeleteMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles objDeleteMenuItem.Click
        Dim sDatabaseName As String
        Dim csr As Cursor = Nothing
        Dim db As Database

        Try
            csr = Me.Cursor ' Save the old cursor
            Me.Cursor = Cursors.WaitCursor ' Display the waiting cursor
            If objSelected = "ListView" Then
                sDatabaseName = Me.ListView.SelectedItems(0).Text
            Else
                sDatabaseName = Me.SqlServerTreeView.SelectedNode.Text
            End If
            ' Use the selected database as the one to be deleted
            ' sDatabaseName = DatabasesListView.SelectedItems(0).Text

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

              
            End If

            ' Refresh database list
            ''ShowDatabases(False)
            ConnectToServer(Me.SqlServerTreeView.TopNode.Text)
            Me.SqlServerTreeView.ExpandAll()
        Catch ex As SmoException
            Dim emb As New ExceptionMessageBox(ex)
            emb.Show(Me)

        Finally
            'UpdateControls()
            Me.Cursor = csr ' Restore the original cursor
        End Try
    End Sub

    Private Sub objBackupMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles objBackupMenuItem.Click
        If objSelected = "ListView" Then
            If Me.ListView.SelectedItems.Count = 0 Then
                Return
            End If
        Else
            If Me.SqlServerTreeView.SelectedNode Is Nothing Then
                Return
            End If
        End If
        'If 
        'Me.SqlServerTreeView.SelectedNode.Name = "Server" Then
        '            objUserctrl = New ctrlDatabaseUtilities(gHalistech.ServerConn, "dBDetails")  '' ctrlMainform
        '            objUserctrl.controls("ServerNamesComboBox").enabled = False
        '            objUserctrl.controls("ServerNamesComboBox").text = Me.SqlServerTreeView.SelectedNode.Text

        '        Else
        If Me.SqlServerTreeView.SelectedNode.Parent.Name = "Databases" Then
            objUserctrl = New ctrlDatabaseTasks("Backup", Me.SqlServerTreeView.SelectedNode.Tag) '' ctrlMainform

        End If
        '' u = New gHalistech
        objUserctrl.Name = "objUserctrl"
        objUserctrl.Tag = "objUserctrl"
        ''Me.SplitContainer1.Panel2.Controls.Add(objUserctrl)
        Call fnGetWindow(objUserctrl)

    End Sub

    Private Sub objRestoreMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles objRestoreMenuItem.Click
        If objSelected = "ListView" Then
            If Me.ListView.SelectedItems.Count = 0 Then
                Return
            End If
        Else
            If Me.SqlServerTreeView.SelectedNode Is Nothing Then
                Return
            End If
        End If
        'If 
        'Me.SqlServerTreeView.SelectedNode.Name = "Server" Then
        '            objUserctrl = New ctrlDatabaseUtilities(gHalistech.ServerConn, "dBDetails")  '' ctrlMainform
        '            objUserctrl.controls("ServerNamesComboBox").enabled = False
        '            objUserctrl.controls("ServerNamesComboBox").text = Me.SqlServerTreeView.SelectedNode.Text

        '        Else
        If Me.SqlServerTreeView.SelectedNode.Parent.Name = "Databases" Then
            objUserctrl = New ctrlDatabaseTasks("Restore", Me.SqlServerTreeView.SelectedNode.Tag) '' ctrlMainform
        End If
        '' u = New gHalistech
        objUserctrl.Name = "objUserctrl"
        objUserctrl.Tag = "objUserctrl"
        ''Me.SplitContainer1.Panel2.Controls.Add(objUserctrl)
        Call fnGetWindow(objUserctrl)
    End Sub

    Private Sub objDetachMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles objDetachMenuItem.Click
        If objSelected = "ListView" Then
            If Me.ListView.SelectedItems.Count = 0 Then
                Return
            End If
        Else
            If Me.SqlServerTreeView.SelectedNode Is Nothing Then
                Return
            End If
        End If
        ApplicationGlobal.sqlServer.DetachDatabase(Me.SqlServerTreeView.SelectedNode.Text, False, False)
    End Sub

    Private Sub objAttachMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles objAttachMenuItem.Click
        If objSelected = "ListView" Then
            If Me.ListView.SelectedItems.Count = 0 Then
                Return
            End If
        Else
            If Me.SqlServerTreeView.SelectedNode Is Nothing Then
                Return
            End If
        End If
        'If 
        'Me.SqlServerTreeView.SelectedNode.Name = "Server" Then
        '            objUserctrl = New ctrlDatabaseUtilities(gHalistech.ServerConn, "dBDetails")  '' ctrlMainform
        '            objUserctrl.controls("ServerNamesComboBox").enabled = False
        '            objUserctrl.controls("ServerNamesComboBox").text = Me.SqlServerTreeView.SelectedNode.Text

        '        Else
        If Me.SqlServerTreeView.SelectedNode.Parent.Name = "Server" Then
            objUserctrl = New ctrlDatabaseTasks("Attach", Nothing) '' ctrlMainform
        End If
        '' u = New gHalistech
        objUserctrl.Name = "objUserctrl"
        objUserctrl.Tag = "objUserctrl"
        ''Me.SplitContainer1.Panel2.Controls.Add(objUserctrl)
        Call fnGetWindow(objUserctrl)
    End Sub
End Class
