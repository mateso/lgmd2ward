
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
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

''' <summary>
''' Summary description for form.
''' </summary>

Partial Public Class ctrlOtherReportsLocal 'The Partial modifier is only required on one class definition per project.
    Inherits MainControl 'System.Windows.Forms.UserControl
    ' Use the Server object to connect to a specific server
    ' Private sqlServerSelection As New Server

    'Dim localProxy As New HEMISDAL.HEMISManager
    Dim dsData As New LGMDdataDataSet

    Private root As TreeNode
    Private objSelected As Object
    Dim strLocalConnection As String
    Dim objUserctrl As New UserControl
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    '''Private components As System.ComponentModel.IContainer = Nothing 'todo

    Public Sub New()
        InitializeComponent()

        'Me.tblStudentsTableAdapter.Connection =
        'dsData.Merge(localProxy.GetObject("tblStudents", My.Settings.HEMISConnectionString))

        Me.ReportViewer1.RefreshReport()

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

    '' Loads treeview items and updates listview as well.
    '<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")> _
    Private Sub ShowDetails(ByVal node As TreeNode)

        Me.ReportViewer1.Reset()

        Try
            If node Is Nothing Then
                Return
            End If

            'ReportViewer1.ServerReport.GetDataSources()

            'Me.ReportViewer1.ServerReport.ReportServerUrl = "Me.ReportViewer1.ServerReport.ReportServerUrl =""" ' = My.Settings.MainServer.ToString

            'If Not node.Tag.ToString.StartsWith("tblList.ListCode='rpt") Then Exit Sub
            'If Not node.Tag.ToString.Split("'")(1).StartsWith("rpt") Then Exit Sub
            'samuel 
            'Me.ReportViewer1.ServerReport.DisplayName = node.Text '"General Enrolment"
            'Me.ReportViewer1.ServerReport.ReportPath = "/HEMIS Reports/" & node.Tag.ToString.Split("'")(1) 'node.Tag.ToString
            'end samuel 

            'Dim j As Microsoft.Reporting.WinForms.ReportParameter() = New Microsoft.Reporting.WinForms.ReportParameter(0) {}
            '
            '       ReDim j(0)
            '      j(0).Name = "ReportName"
            '     j(0).Values(0) = (node.Text & "@" & node.Parent.Text)
            ' Me.ReportViewer1.ServerReport.SetParameters(j)

            Dim objCredentials As Microsoft.Reporting.WinForms.DataSourceCredentials() = New Microsoft.Reporting.WinForms.DataSourceCredentials(0) {}
            If My.Settings.DataConnectionString.Split(";").Contains("Trusted_Connection=true") Or My.Settings.DataConnectionString.Split(";").Contains("Integrated Security=True") Then
                objCredentials(0) = New Microsoft.Reporting.WinForms.DataSourceCredentials()
            Else
                objCredentials(0) = New Microsoft.Reporting.WinForms.DataSourceCredentials()
                objCredentials(0).UserId = My.Settings.DataConnectionString.Split("'").GetValue(3).ToString '"sa"
                objCredentials(0).Password = My.Settings.DataConnectionString.Split("'").GetValue(5).ToString '""
            End If
            Dim objCredentialsa As Microsoft.Reporting.WinForms.ReportDataSource() = New Microsoft.Reporting.WinForms.ReportDataSource(0) {}
            objCredentialsa(0) = New Microsoft.Reporting.WinForms.ReportDataSource()

            'objCredentialsa(0).Value =
            If node.Tag.ToString.Contains("Anpg1") Then
                ReportViewer1.LocalReport.ReportPath = "Reports\WardReportSubmissionStatus.rdl"
            ElseIf node.Tag.ToString.Contains("Qtrpg1") Then
                ReportViewer1.LocalReport.ReportPath = "Reports\WardReportSubmissionStatus.rdl"
            ElseIf node.Tag.ToString.Contains("SubmitStatus") Then
                ReportViewer1.LocalReport.ReportPath = "Reports\WardReportSubmissionStatus.rdl"
            End If

            '££££££££££££££££££££££££££££££££


            '* Declare objects
            Dim sqlCon As New SqlConnection
            Dim sqlCmd As New SqlCommand
            Dim myDS As New DataSet
            Dim sqlDA As New SqlDataAdapter

            '* Read connection string from application config file
            sqlCon.ConnectionString = My.Settings.DataConnectionString

            '* Set up command object
            sqlCmd.Connection = sqlCon
            sqlCmd.CommandType = CommandType.Text
            '* Set up data adapter and fill dataset

            sqlDA.SelectCommand = sqlCmd
            If node.Tag.ToString.Contains("Anpg1") Then
                If node.Tag.ToString.Contains("ListCode") Then
                    Dim strPeriod As String
                    strPeriod = node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1).Replace("'", "")
                    strPeriod = "Jul-" & Mid(strPeriod, 2, 4) & " to Jun-" & Mid(strPeriod, 7, 4) & ""
                    sqlCmd.CommandText = "exec uspRptSubmissionStatus '" & strPeriod & "',1"
                Else
                    sqlCmd.CommandText = "exec uspRptSubmissionStatus 0"
                End If
                sqlDA.Fill(myDS, "uspRptSubmissionStatus")



            ElseIf node.Tag.ToString.Contains("Qtrg1") Then
                If node.Tag.ToString.Contains("ListCode") Then
                    If node.Text.ToString.Contains("-") Then
                        sqlCmd.CommandText = "exec usprptQuarterlyReportPage1 " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1)   '"UspRpt" & Replace(node.Text.ToString, " ", "")
                    Else
                        sqlCmd.CommandText = "exec usprptQuarterlyReportPage1 " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1)   '"UspRpt" & Replace(node.Text.ToString, " ", "")
                    End If
                Else
                    sqlCmd.CommandText = "exec usprptQuarterlyReportPage1 0"
                End If

                sqlDA.Fill(myDS, "usprptQuarterlyReportPage1")


                If node.Tag.ToString.Contains("ListCode") Then
                    If node.FullPath.ToString.Split("\").Count > 3 Then
                        'If node.FirstNode.FullPath.ToString.Split("\")(3) Then
                        sqlCmd.CommandText = "exec usprptQuarterReportPage2 " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & ",'" & node.FullPath.ToString.Split("\")(3) & "'"    '"UspRpt" & Replace(node.Text.ToString, " ", "")
                        'End If
                    Else
                        sqlCmd.CommandText = "exec usprptQuarterReportPage2 " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & ",'" & node.Text & "'"    '"UspRpt" & Replace(node.Text.ToString, " ", "")
                    End If
                Else
                    sqlCmd.CommandText = "exec usprptQuarterReportPage2 0"
                End If
                sqlDA.Fill(myDS, "usprptQuarterReportPage2")

            Else
                If node.Tag.ToString.Contains("ListCode") Then
                    If node.FullPath.ToString.Split("\").Count = 2 Then
                        'If node.FirstNode.FullPath.ToString.Split("\")(3) Then
                        sqlCmd.CommandText = "exec uspRptSubmissionStatus " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & ",'" & node.FullPath.ToString.Split("\")(3) & "'"    '"UspRpt" & Replace(node.Text.ToString, " ", "")
                        'End If
                    Else
                        ' sqlCmd.CommandText = "exec uspRptSubmissionStatus " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & ",'" & node.Text & "'"    '"UspRpt" & Replace(node.Text.ToString, " ", "")
                    End If
                    Dim strPeriod As String
                    strPeriod = node.Tag.ToString.Split("'")(3).Replace("rQtrpg", "")
                    'If strPeriod.EndsWith("1") Then
                    '    strPeriod = "Jan" & "-" & Mid(strPeriod, 2, 4) & " to Mar" & "-" & Mid(strPeriod, 2, 4)
                    'ElseIf strPeriod.EndsWith("2") Then
                    '    strPeriod = "Apr" & "-" & Mid(strPeriod, 2, 4) & " to Jun" & "-" & Mid(strPeriod, 2, 4)
                    'ElseIf strPeriod.EndsWith("3") Then
                    '    strPeriod = "Jul" & "-" & Mid(strPeriod, 2, 4) & " to Sep" & "-" & Mid(strPeriod, 2, 4)
                    'ElseIf strPeriod.EndsWith("4") Then
                    '    strPeriod = "Oct" & "-" & Mid(strPeriod, 2, 4) & " to Dec" & "-" & Mid(strPeriod, 2, 4)

                    'If strPeriod.EndsWith("1") Then
                    '    strPeriod = "Jan" & "-" & strPeriod.Substring(0, 4) & " to Mar" & "-" & strPeriod.Substring(0, 4)
                    'ElseIf strPeriod.EndsWith("2") Then
                    '    strPeriod = "Apr" & "-" & strPeriod.Substring(0, 4) & " to Jun" & "-" & strPeriod.Substring(0, 4)
                    'ElseIf strPeriod.EndsWith("3") Then
                    '    strPeriod = "Jul" & "-" & strPeriod.Substring(0, 4) & " to Sep" & "-" & strPeriod.Substring(0, 4)
                    'ElseIf strPeriod.EndsWith("4") Then
                    '    strPeriod = "Oct" & "-" & strPeriod.Substring(0, 4) & " to Dec" & "-" & strPeriod.Substring(0, 4)
                    'End If

                    If node.Text.Contains("Jan") Then
                        strPeriod = "Jan" & "-" & node.Text.Split(" ")(1) & " to Mar" & "-" & node.Text.Split(" ")(1)
                    ElseIf node.Text.Contains("Apr") Then
                        strPeriod = "Apr" & "-" & node.Text.Split(" ")(1) & " to Jun" & "-" & node.Text.Split(" ")(1)
                    ElseIf node.Text.Contains("Jul") Then
                        strPeriod = "Jul" & "-" & node.Text.Split(" ")(1) & " to Sep" & "-" & node.Text.Split(" ")(1)
                    ElseIf node.Text.Contains("Oct") Then
                        strPeriod = "Oct" & "-" & node.Text.Split(" ")(1) & " to Dec" & "-" & node.Text.Split(" ")(1)
                    Else
                        strPeriod = "--Note Selected--"
                    End If

                    sqlCmd.CommandText = "exec uspRptSubmissionStatus '" & strPeriod & "',3"
                    sqlDA.Fill(myDS, "uspRptSubmissionStatus")
                Else
                    sqlCmd.CommandText = "exec usprptQuarterReportPage2 0"
                End If
                'sqlDA.Fill(myDS, "usprptQuarterReportPage2")

            End If
            'sqlCmd.CommandText = "select * from tblInstitutions"
            'sqlDA.Fill(myDS, "tblInstitutions")

            'sqlCmd.CommandText = "select * from tblStudents"
            'sqlDA.Fill(myDS, "UspRpt" & Replace(node.Text.ToString, " ", ""))

            sqlDA.SelectCommand = sqlCmd
            If Replace(node.Text.ToString, " ", "").EndsWith("All") Then
                sqlCmd.CommandText = "UspRptDatasetAll"
                sqlDA.Fill(myDS, "UspRptDatasetAll")
            Else
                If node.Tag.ToString.Contains("ListCode") Then
                    'sqlCmd.CommandText = "exec UspRptDataset " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & ",'" & node.Text & "'  ,3" '  '"UspRpt" & Replace(node.Text.ToString, " ", "")
                    If node.Tag.ToString.Contains("Qtrpg1") Then
                        Dim strPeriod As String = ""
                        If node.FullPath.ToString.Split("\").Count > 3 Then

                            '    strPeriod = node.FullPath.ToString.Split("\")(3).ToString


                        End If
                        'sqlCmd.CommandText = "exec UspRptDataset '" & strPeriod & "'  ,3" '  '"UspRpt" & Replace(node.Text.ToString, " ", "")
                    Else
                        Dim strPeriod As String = ""
                        If node.FullPath.ToString.Split("\").Count > 2 Then

                            '   strPeriod = node.FullPath.ToString.Split("\")(2).ToString


                        End If


                        'sqlCmd.CommandText = "exec UspRptDataset " & node.Tag.ToString.Split(" ")(0).Split("=")(1) & ",'" & strPeriod & "'  ,1" '  '"UspRpt" & Replace(node.Text.ToString, " ", "")
                    End If

                Else
                    sqlCmd.CommandText = "exec UspRptDataset 0"
                End If
                'sqlDA.Fill(myDS, "UspRptDataset")
            End If

            'sqlCmd.CommandText = "select * from tblInstitutions"
            'sqlDA.Fill(myDS, "tblInstitutions")

            'sqlCmd.CommandText = "select * from tblStudents"




            Dim s As New LGMDdataDataSet
            's.tblInstitutions.
            myDS.Merge(s)


            '* Name property of data set (first parameter below) MUST be the same name
            '* as the data set used at design time. While this name can be changed in the 
            '* report xml specification it must be manually changed everywhere it occurs.
            '* Choose a meaningful name when the dataset is created.
            '* Note here that the dataset table can be established as a ReportDataSource
            'Dim myRDS As New  _
            '            Microsoft.Reporting.WinForms.ReportDataSource("NorthwindDataSet_up_Fill_Employee_Combo", myDS.Tables("Employees"))

            '            Dim myRDS As New  _
            '           Microsoft.Reporting.WinForms.ReportDataSource() '"NorthwindDataSet_up_Fill_Employee_Combo", myDS.Tables("Employees"))



            If myDS.Tables(0).Rows.Count = 0 Then Exit Sub
            '* Clear out default datasource and add new one (with same structure).
            ReportViewer1.LocalReport.DataSources.Clear()
            'ReportViewer1.LocalReport.DataSources.Add(myRDS)

            '$£$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            If Me.ReportViewer1.LocalReport.DataSources.Count = 0 Then
                '                Dim myRDS2 As New  _
                '               Microsoft.Reporting.WinForms.ReportDataSource("LGMDdATA", myDS.Tables("UspRpt" & Replace(node.Text.ToString, " ", "")))

                If node.Tag.ToString.Contains("Anpg1") Then

                    Dim myRDS2 As New  _
                        Microsoft.Reporting.WinForms.ReportDataSource("dsCollectionTools", myDS.Tables("uspRptSubmissionStatus"))

                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    ReportViewer1.LocalReport.DataSources.Add(myRDS2)

                    ' Dim myRDS5 As New  _
                    'Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", myDS.Tables("UspRptAnnualReportPage2"))
                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))

                    'ReportViewer1.LocalReport.DataSources.Add(myRDS5)


                    'Dim myRDS6 As New  _
                    ' Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", myDS.Tables("UspRptAnnualReportPage3"))
                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    ' ReportViewer1.LocalReport.DataSources.Add(myRDS6)
                Else
                    Dim myRDS2 As New  _
                      Microsoft.Reporting.WinForms.ReportDataSource("dsCollectionTools", myDS.Tables("uspRptSubmissionStatus"))

                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    ReportViewer1.LocalReport.DataSources.Add(myRDS2)

                End If


                If Replace(node.Text.ToString, " ", "").EndsWith("All") Then
                    Dim myRDS3 As New  _
                    Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", myDS.Tables("usprptDatasetAll"))
                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    ReportViewer1.LocalReport.DataSources.Add(myRDS3)
                Else
                    ' Dim myRDS4 As New  _

                    'Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", myDS.Tables("usprptDataset"))
                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    'ReportViewer1.LocalReport.DataSources.Add(myRDS4)
                End If

            Else
                For Each ss As String In Me.ReportViewer1.LocalReport.GetDataSourceNames
                    ' Dim myRDS As New  
                    'Microsoft.Reporting.WinForms.ReportDataSource(ss, myDS.Tables("tblInstitutions"))
                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    'ReportViewer1.LocalReport.DataSources.Add(myRDS)

                    ' Dim myRDS1 As New  _
                    'Microsoft.Reporting.WinForms.ReportDataSource(ss, myDS.Tables("tblStudents"))
                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    'ReportViewer1.LocalReport.DataSources.Add(myRDS1)
                    Dim myRDS2 As New  _
                    Microsoft.Reporting.WinForms.ReportDataSource(ss, myDS.Tables("UspRpt" & Replace(node.Text.ToString, " ", "")))
                    'ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource(ss, objCredentialsa))
                    ReportViewer1.LocalReport.DataSources.Add(myRDS2)
                Next
            End If
            ' Me.ReportViewer1.LocalReport.LoadReportDefinition()
            ReportViewer1.LocalReport.Refresh()
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            ' MsgBox(ex.InnerException.ToString)
        End Try
        '   Dim warnings As Warning() = Nothing
        '   Dim streamids As String() = Nothing
        '   Dim mimeType As String = Nothing
        '   Dim encoding As String = Nothing
        '   Dim extension As String = Nothing
        '   Dim deviceInfo As String
        '   Dim bytes As Byte()



        '   Dim lr As New LocalReport

        '   lr.ReportPath = "C:\My Reports\Monthly Sales.rdlc"

        '   'lr.DataSources.Add(New ReportDataSource("Sales", GetSalesDat()))

        '   deviceInfo = _
        '"<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>"

        '   bytes = ReportViewer1.LocalReport.Render("Excel", deviceInfo, mimeType, encoding, extension, streamids, warnings)

        '   Dim fs As New IO.FileStream("c:\output.xls", IO.FileMode.Create)
        '   fs.Write(bytes, 0, bytes.Length)
        '   fs.Close()

    End Sub


    ' Lists a collection in the listview if the container node is selected

    ''' <summary>
    ''' Loads the collection items. This has to be deferred else starting is 
    ''' too expensive.
    ''' </summary>
    ''' <param name="node"></param>
    Private Sub LoadTreeViewItems(ByVal node As TreeNode)
        If node.Nodes.Count = 1 AndAlso Not (node.Nodes("DummyNode") Is Nothing) Then
            node.Nodes("DummyNode").Remove()
        Else
            Return
        End If

        Select Case node.Name
            Case "Databases"
                node.ImageIndex = 2
                LoadTreeViewDatabases(node)
        End Select

    End Sub

    Private Sub LoadTreeViewDatabases(ByVal node As TreeNode)

        Dim strLocalConnection As String
        strLocalConnection = My.Settings.DataConnectionString

        Dim oConn As New SqlClient.SqlConnection(strLocalConnection) '"Data Source=(local);UID=Sa;Initial Catalog=HEMISSQLDB;")
        oConn.Open()
        'Create Adapter and Fill Dataset
        Dim oAdapter As New SqlClient.SqlDataAdapter("SELECT * FROM tblList where category='report'", oConn)
        Dim oDs As New DataSet
        oAdapter.Fill(oDs)
        oDs.Tables(0).TableName = "tblReports"

        SqlServerTreeView.Nodes.Clear()
        Dim jj As New ctrlTreeView(Me.SqlServerTreeView, oDs, "tblList", "ListCode", "Parent", "Description")

    End Sub


    ' Adds a dummy node, so we can expand a node without querying
    ' whether there are any items
    Private Shared Sub AddDummyNode(ByVal node As TreeNode)
        If node.Nodes.Count <> 0 Then
            Return
        End If

        node.Nodes.Add("DummyNode")
        node.Nodes(0).Name = "DummyNode" 'My.Resources.DummyNode
    End Sub

    Private Sub ListView_ContextMenuChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    ' Double click on a listview item causes the tree to be synced.

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")> _
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.Reset()
        Dim strLocalConnection As String
        strLocalConnection = My.Settings.DataConnectionString

        'Try

        Dim oConn As New SqlClient.SqlConnection(strLocalConnection)
        oConn.Open()
        'Create Adapter and Fill Dataset
        Dim strSource As String

        ' strSource = "SELECT  listCode,Description,Category,parent from tbllist where CAtegory='report' union select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) ,'Report'   ,  'Anpg1' "
        'strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))"
        'strSource = strSource & " union select '53217','Tanzania','Report',cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where "
        'strSource = strSource & " formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))"
        'strSource = strSource & " union select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) ,'Report'   ,  'Qtrpg1'"
        'strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))"
        ''strSource = strSource & " union select '53217','Tanzania','Report',cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where "
        'strSource = strSource & " formTypeNumber=3 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))"


        strSource = "SELECT  listCode,Description,Category,parent from tbllist where CAtegory='report'"
        strSource = strSource & " union "
        strSource = strSource & " select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) "
        strSource = strSource & " , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) ,'Report'  "
        strSource = strSource & " ,  'Anpg1'  FROM [dbo].[tbl_data_forms_submitted] where"
        strSource = strSource & " formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) "
        strSource = strSource & " union "
        strSource = strSource & " select '53217','Tanzania','Report',cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))"
        strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted] where  formTypeNumber=1 group by  "
        strSource = strSource & " cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) "
        strSource = strSource & " union "
        strSource = strSource & " select 'Qtrpg1'+cast(datepart(q,[PeriodFrom])  as nvarchar(4))+' '+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) "
        strSource = strSource & " ,'Report'   ,  'Qtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3"
        strSource = strSource & " group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) "
        strSource = strSource & " union "
        strSource = strSource & " select  'Qtrpg1'+ cast(datepart(q,[PeriodFrom])  as nvarchar(4))+' '+cast(datepart(yyyy,[PeriodFrom])    as nvarchar(4))  ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' '+ datename(year,[Periodto])"
        strSource = strSource & " ,'Report'   ,   'Qtrpg1'+ cast(datepart(q,[PeriodFrom])  as nvarchar(4))+' '+cast(datepart(yyyy,[PeriodFrom])    as nvarchar(4))  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3"
        strSource = strSource & " group by  'Qtrpg1'+ cast(datepart(q,[PeriodFrom])  as nvarchar(4))+' '+cast(datepart(yyyy,[PeriodFrom])    as nvarchar(4)) ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' '+ datename(year,[Periodto]),datepart(m,[PeriodFrom]),cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4))  ,cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10))" ' order by datepart(m,[PeriodFrom]) "
        strSource = strSource & " union "
        strSource = strSource & " select '53217','Tanzania'"
        strSource = strSource & " ,'Report',cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10)) FROM [dbo].[tbl_data_forms_submitted] "
        strSource = strSource & " where  formTypeNumber=3 group by "
        strSource = strSource & " cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10))"


        If False Then
            strSource = "SELECT  listCode,Description,Category,parent from tbllist where CAtegory='report' "
            strSource = strSource & " union "
            strSource = strSource & " select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))  , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) ,'Report'   ,  'Anpg1'  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) "
            strSource = strSource & " union "
            strSource = strSource & " select '53217','Tanzania','Report',cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where  formTypeNumber=1 group by   cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))  "
            strSource = strSource & " union "
            'strSource = strSource & " select 'Qtrpg1' "
            'strSource = strSource & " + cast(datepart(q,[PeriodFrom])  as nvarchar(4))+'-'+cast(datepart(yyyy,[PeriodFrom])    as nvarchar(4))   "
            'strSource = strSource & " , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4))  "
            'strSource = strSource & " ,'Report'   ,  'Qtrpg1' "

            strSource = strSource & " select cast(datepart(yyyy,[PeriodFrom])    as nvarchar(4))   "
            strSource = strSource & " , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4))  "
            strSource = strSource & " ,'Report'   ,  'Qtrpg1' "

            strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 "
            strSource = strSource & " group by "
            strSource = strSource & " 'Qtrpg1'+ cast(datepart(q,[PeriodFrom])  as nvarchar(4))+'-'+cast(datepart(yyyy,[PeriodFrom])    as nvarchar(4))  ,"
            strSource = strSource & " cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))      "
            strSource = strSource & " union "
            strSource = strSource & " select cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10)) "
            strSource = strSource & " ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' '+ datename(year,[Periodto]) ,'Report'   ,  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by 'Qtrpg1'+cast(datepart(q,[PeriodFrom])  as nvarchar(4))+'-'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)),datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' '+ datename(year,[Periodto]),datepart(m,[PeriodFrom]),cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4))  ,cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10))"
            strSource = strSource & " union "
            strSource = strSource & " select '53217','Tanzania' ,'Report',cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10)) FROM [dbo].[tbl_data_forms_submitted]  where  formTypeNumber=3 group by  cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10))"

        End If

        strSource = "SELECT  listCode,Description,Category,parent from tbllist where CAtegory='report' union"
        strSource = strSource & " select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))  , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) ,'Report'   ,  'Anpg1'  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))  union  select '53217','Tanzania','Report',cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where  formTypeNumber=1 group by   cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))  union  select 'Qtrpg1'+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) , cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4))  ,'Report'   ,  'Qtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by  cast(datepart(yyyy,[PeriodFrom]) as nvarchar(4))  union  select cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10)) ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' '"
        strSource = strSource & " + datename(year,[Periodto]) ,'Report'   ,  'Qtrpg1'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by  datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' '+ datename(year,[Periodto]),datepart(m,[PeriodFrom]),cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4))  ,cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10)) union  select '53217','Tanzania' ,'Report',cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10)) FROM [dbo].[tbl_data_forms_submitted]  where  formTypeNumber=3 group by  cast(datepart(q,[PeriodFrom]) +'-'+ datename(year,[PeriodFrom]) as nvarchar(10))"


        strSource = "SELECT  listCode,Description,Category,parent from tbllist where CAtegory='report' union select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) ,'Report'   ,  'Anpg1'  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " union  select '53217','Tanzania','Report',cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  FROM [dbo].[tbl_data_forms_submitted] where  formTypeNumber=1 group by   cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  "
        strSource = strSource & " union     select 'Qtrpg1'+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))    ,'Report'   ,  'Qtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by 'Qtrpg1'+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)), cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  "
        strSource = strSource & " union  select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto]) ,'Report' ,  'Qtrpg1'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by   cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto])    ,'Qtrpg1'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) union  select '53217','Tanzania' ,'Report', cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted]  where  formTypeNumber=3 group by   cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "

        'strSource = strSource & " union "
        strSource = ""
        strSource = strSource & " SELECT  'r'+listCode as listCode,Description,Category,'Other reports' as Parent from tbllist where CAtegory='report' and (ListCode='Anpg1' or ListCode='Qtrpg1'  or listcode='Other reports')" ' union " '"SELECT  listCode,Description,Category,parent from tbllist where CAtegory='report' union "
        strSource = strSource & " union SELECT  'Other reports' as listCode,'Report Submission Status' as Description,'Report',null as Parent from tbllist where listcode='Other reports' "
        strSource = strSource & " union Select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) as listcode  , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  as Description,'Report'  as Category  ,  'rAnpg1' as PArent  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " union     select 'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))    ,'Report'   ,  'rQtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by 'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)), cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  "
        strSource = strSource & " union  select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto]) ,'Report' ,  'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto])    ,'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) union  select 'SubmitStatus','Form Submission Status' ,'Report', cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted]  where  formTypeNumber=3 group by   cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        '
        strSource = "SELECT  'r'+listCode as listCode,Description,Category,'Other reports' as Parent  from tbllist where (description <>'other reports') and CAtegory='report' and (ListCode='Anpg1' or ListCode='Qtrpg1'  or listcode='Other reports') union SELECT  'Other reports' as listCode,'Report Submission Status' as Description,'Report',null as Parent from tbllist where listcode='Other reports'  union Select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) as listcode  , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  as Description,'Report'  as Category  ,  'rAnpg1' as PArent  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  union     select 'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))    ,'Report' "
        strSource = strSource & " ,  'rQtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by 'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)), cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))   union  select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto]) ,'Report' ,  'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto])    ,'rQtrpg1'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) "

        strSource = "SELECT  'r'+listCode as listCode,Description,Category,'Other reports' as Parent from tbllist where (description <>'other reports') and CAtegory='report' and (ListCode='Anpg1' or ListCode='Qtrpg1'  or listcode='Other reports') union SELECT  'Other reports' as listCode,'Report Submission Status' as Description,'Report'"
        strSource = strSource & " ,null as Parent from tbllist where listcode='Other reports'  union  Select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) as listcode  , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  as Description,'Report'  as Category  ,  'rAnpg1' as PArent "
        strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " union select 'rQtrpg'+ cast(datepart(q,[PeriodFrom]) as nvarchar(1)) +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) ,case when month([PeriodFrom])>6 then cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  else"
        strSource = strSource & " cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) end  ,'Report'  ,  'rQtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by 'rQtrpg'+cast(datepart(q,[PeriodFrom]) as nvarchar(1))  +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)),  case when month([PeriodFrom])>6 then cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))  end       union  select          case when month([PeriodFrom])>6 then         cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) "
        strSource = strSource & " end        ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto]) ,'Report' ,  'rQtrpg'+cast(datepart(q,[PeriodFrom]) as nvarchar(1)) +cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by   case when month([PeriodFrom])>6 then         cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'"
        strSource = strSource & " +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) end  ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto])    ,'rQtrpg'+cast(datepart(q,[PeriodFrom]) as nvarchar(1)) +cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4)) "

        strSource = "SELECT  'r'+listCode as listCode,Description,Category,'Other reports' as Parent from tbllist where (description <>'other reports') and CAtegory='report' and (ListCode='Anpg1' or ListCode='Qtrpg1'  or listcode='Other reports') union SELECT  'Other reports' as listCode,'Report Submission Status' as Description,'Report'"
        strSource = strSource & " ,null as Parent from tbllist where listcode='Other reports'  union  Select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) as listcode  , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  as Description,'Report'  as Category  ,  'rAnpg1' as PArent "
        strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " union select 'rQtrpg'+ cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+ cast(datepart(q,[PeriodFrom]) as nvarchar(1))  ,case when month([PeriodFrom])>6 then cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  else"
        strSource = strSource & " cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) end  ,'Report'  ,  'rQtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by 'rQtrpg'  +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+cast(datepart(q,[PeriodFrom]) as nvarchar(1)),  case when month([PeriodFrom])>6 then cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))  end       union  select          case when month([PeriodFrom])>6 then         cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) "
        strSource = strSource & " end        ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto]) ,'Report' ,  'rQtrpg' +cast(datepart(yyyy,[PeriodFrom])as  nvarchar(4)) +cast(datepart(q,[PeriodFrom]) as nvarchar(1))  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by   case when month([PeriodFrom])>6 then         cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'"
        strSource = strSource & " +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) end  ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto])    ,'rQtrpg'+cast(datepart(yyyy,[PeriodFrom]) as  nvarchar(4))+cast(datepart(q,[PeriodFrom]) as nvarchar(1))  "

        strSource = "SELECT  'r'+listCode as listCode,Description,Category,'Other reports' as Parent from tbllist where (description <>'other reports') and CAtegory='report' and (ListCode='Anpg1' or ListCode='Qtrpg1'  or listcode='Other reports') union SELECT  'Other reports' as listCode,'Report Submission Status' as Description,'Report'"
        strSource = strSource & " ,null as Parent from tbllist where listcode='Other reports'  union  Select cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) as listcode  , cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  as Description,'Report'  as Category  ,  'rAnpg1' as PArent "
        strSource = strSource & " FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=1 group by  cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = strSource & " union select 'rQtrpg' + CAST(DATEPART(yyyy, PeriodFrom) AS nvarchar(4)) + CASE WHEN month([PeriodFrom]) > 6 THEN CAST(DATEPART(q,PeriodFrom)-2 AS nvarchar(1))  else CAST(DATEPART(q,PeriodFrom)+2 AS nvarchar(1)) end  ,case when month([PeriodFrom])>6 then cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  else"
        strSource = strSource & " cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) end  ,'Report'  ,  'rQtrpg1' FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by 'rQtrpg' + CAST(DATEPART(yyyy, PeriodFrom) AS nvarchar(4)) + CASE WHEN month([PeriodFrom]) > 6 THEN CAST(DATEPART(q,PeriodFrom)-2 AS nvarchar(1))  else CAST(DATEPART(q,PeriodFrom)+2 AS nvarchar(1)) end,  case when month([PeriodFrom])>6 then cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))  end       union  select          case when month([PeriodFrom])>6 then         cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) "
        strSource = strSource & " end        ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto]) ,'Report' ,  'rQtrpg' + CAST(DATEPART(yyyy, PeriodFrom) AS nvarchar(4)) + CASE WHEN month([PeriodFrom]) > 6 THEN CAST(DATEPART(q,PeriodFrom)-2 AS nvarchar(1))  else CAST(DATEPART(q,PeriodFrom)+2 AS nvarchar(1)) end  FROM [dbo].[tbl_data_forms_submitted] where formTypeNumber=3 group by   case when month([PeriodFrom])>6 then         cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4))+'/'"
        strSource = strSource & " +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) else  cast(datepart(yyyy,[PeriodFrom])-1  as nvarchar(4))+'/' +cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) end  ,datename(month,[PeriodFrom]) +'-'+ datename(month,[Periodto]) +' ' + datename(year,[Periodto])    ,'rQtrpg' + CAST(DATEPART(yyyy, PeriodFrom) AS nvarchar(4)) + CASE WHEN month([PeriodFrom]) > 6 THEN CAST(DATEPART(q,PeriodFrom)-2 AS nvarchar(1))  else CAST(DATEPART(q,PeriodFrom)+2 AS nvarchar(1)) end "

        'union  select 'SubmitStatus','Form Submission Status' ,'Report', cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'    +cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4))  FROM [dbo].[tbl_data_forms_submitted]  where  formTypeNumber=3 group by   cast(datepart(yyyy,[PeriodFrom])  as nvarchar(4)) +'/'+cast(datepart(yyyy,[PeriodFrom])+1  as nvarchar(4)) "
        strSource = "Select * from uvwReportPeriods"
        '  xxxxx
        strSource = "select listCode,Description,Category,Parent from [uvwMainReportPeriods]"
        If GetConfigLevel() = 4 Or GetConfigLevel() = 2 Then
            strSource = strSource & " union select listCode,Description,Category,"
            strSource = strSource & " parent from (SELECT * FROM tblList where category='report' "
            strSource = strSource & " and isnumeric(Listcode)=1 and parent in ("
            strSource = strSource & " select Area_nid from tbl_setup_areas where area_id in "
            strSource = strSource & " (select config_value from tbl_config where config_name='Area_id') "
            strSource = strSource & " ) ) b"
        End If

        If GetConfigLevel() = 2 Then
            '            strSource = strSource & " union select listCode,Description,Category,parent from (SELECT * FROM tblList where "
            '            strSource = strSource & " isnumeric(Listcode)=1 and parent ='53218') c"

            strSource = strSource & " union    select listCode,Description,Category,parent from (SELECT * FROM tblList where "
            strSource = strSource & " isnumeric(Listcode)=1 and parent ='53218') b"
            strSource = strSource & " union"
            strSource = strSource & " select listCode,Description,Category,parent from (SELECT * FROM tblList where "
            strSource = strSource & " isnumeric(Listcode)=1 and parent in"
            strSource = strSource & " (select listCode from (SELECT * FROM tblList where "
            strSource = strSource & " isnumeric(Listcode)=1 and parent ='53218')cc) ) bb"

        End If
        strSource = "select listCode,Description,Category,Parent from [uvwMainReportPeriods] where isnumeric(listcode)<>1"
        Dim oAdapter As New SqlClient.SqlDataAdapter(strSource, oConn) '"SELECT * FROM tblList where category='report'", oConn)

        Dim oDs As New DataSet
        oAdapter.Fill(oDs)
        oDs.Tables(0).TableName = "tblList"

        SqlServerTreeView.Nodes.Clear()
        Dim jj As New ctrlTreeView(Me.SqlServerTreeView, oDs, "tblList", "ListCode", "Parent", "Description")

        'Me.SqlServerTreeView.ExpandAll()

        objUserctrl.Name = "ctrlCharts"
        objUserctrl.Tag = "ctrlCharts"

        ' fnGetWindow(objUserctrl)
        'Catch ex As Exception
        '    'Dim emb As New ExceptionMessageBox(ex)
        '    'emb.Show(Me)
        'End Try
    End Sub

    Private Sub ListView_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs)
        objSelected = "ListView"
    End Sub

    Private Sub SqlServerTreeView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SqlServerTreeView.Click
        objSelected = "SqlServerTreeView"
    End Sub

    Private Sub ListView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        objSelected = "ListView"
    End Sub

    Private Sub SqlServerTreeView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SqlServerTreeView.MouseDown
        objSelected = "SqlServerTreeView"
    End Sub

    Public Sub fnTreeviewExpand()
        Me.SqlServerTreeView.ExpandAll()
    End Sub
End Class
