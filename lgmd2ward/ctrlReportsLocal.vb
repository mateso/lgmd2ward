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

Partial Public Class ctrlReportsLocal 'The Partial modifier is only required on one class definition per project.
    Inherits MainControl 'System.Windows.Forms.UserControl
    'Use the Server object to connect to a specific server
    'Private sqlServerSelection As New Server
    'Dim localProxy As New HEMISDAL.HEMISManager
    Dim dsData As New LGMDdataDataSet
    Dim ReportMode As String
    Private root As TreeNode
    Private objSelected As Object
    Dim strLocalConnection As String
    Dim objUserctrl As New UserControl
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    '''Private components As System.ComponentModel.IContainer = Nothing 'todo
    Public strReportName As String = My.Application.Info.DirectoryPath & "\Reports\"
    Public strSelectedValue1 As String() = Nothing
    Public strSeletedPeriod As String = ""
    Public sqlCon As New SqlConnection
    Public sqlCmd As New SqlCommand
    Public myDS As New DataSet
    Public sqlDA As New SqlDataAdapter
    Public strFormSerialNumber As String = ""
    Public strFormCumSerialNumber As String = ""
    Public strFormCumSerialNumber1 As String = ""
    Public strFormCumNextYearSerialNumber As String = ""
    Public strFormCumNextYearSerialNumber1 As String = ""
    Private ds As DataSet
    Private da As SqlDataAdapter

    Public Sub New()

        InitializeComponent()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub New(strMode As String)

        InitializeComponent()
        ReportMode = strMode
        Me.ReportViewer1.RefreshReport()
    End Sub

    'Double click on a listview item causes the tree to be synced.

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")> _
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        ds = New DataSet
        conn = New SqlConnection(My.Settings.DataConnectionString)
        da = New SqlDataAdapter

        Me.ReportViewer1.Reset()
        'Dim strLocalConnection As String
        'strLocalConnection = My.Settings.DataConnectionString

        'Dim oConn As New SqlClient.SqlConnection(strLocalConnection)
        'oConn.Open()

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Create Adapter and Fill Dataset
        Dim strSource As String

        If ReportMode = "District" Then
            strSource = "select listCode,Replace(Description,' Ward ',' District ') as Description,Category,Parent from [uvwDistrictReportPeriods] group by listCode,Description,Category,Parent "
        ElseIf ReportMode = "Ward" Then
            strSource = "select listCode,Description,Category,Parent from [uvwWardReportPeriods] group by listCode,Description,Category,Parent "
        ElseIf ReportMode = "Submission" Then
            strSource = "select case when listCode='reports' then 'Ward' else listCode end as "
            strSource = strSource & " listcode,case when Description='reports' then 'Ward' else Description end as Description,Category,case when Parent='reports' then 'Ward' else Parent end as Parent "
            strSource = strSource & " from uvwWardReportPeriodsSubmission group by listCode,Description,Category,Parent having Category<>'ReportWaAndVil' "
            strSource = strSource & " union all"
            strSource = strSource & " select case when listCode='reports' then 'District' else 'D' + listCode end as "
            strSource = "select case when listCode='reports' then 'District' else 'D' + listCode end as "
            strSource = strSource & " listcode,case when Description='reports' then 'District' else  Replace(Description,' Ward ',' District ')  end as Description,Category,case when Parent='reports' then 'District' else 'D' + Parent end as Parent "
            strSource = strSource & " from [uvwMainSubmissionReportPeriods] group by listCode,Description,Category,Parent  having listCode <> 'Mwpg1' and isnull(parent,'') <>'Mwpg1' "
        Else
            strSource = "select listCode,Replace(Description,'Report','Integrated Report') as Description,Category,Parent from [uvwMainReportPeriods] group by listCode,Description,Category,Parent "

        End If

        If GetConfigLevel() = 4 Then
            strSource = strSource & " union all select listCode, Description, Category, "
            strSource = strSource & " parent from (SELECT * FROM tblList where category='report' "
            strSource = strSource & " and isnumeric(Listcode)=1 and parent in ("
            strSource = strSource & " select Area_nid from tbl_setup_areas where area_id in "
            strSource = strSource & " (select config_value from tbl_config where config_name='Area_id') "
            strSource = strSource & " ) ) b"
        End If

        If GetConfigLevel() = 2 Then
            strSource = strSource & " union all select listCode,Description,Category,parent from (SELECT * FROM tblList where"
            strSource = strSource & " isnumeric(Listcode)=1 and parent='53217') b"
            strSource = strSource & " union all "
            strSource = strSource & " select listCode,Description,Category,parent from (SELECT * FROM tblList where"
            strSource = strSource & " isnumeric(Listcode)=1 and parent in"
            strSource = strSource & " (select listCode from (SELECT * FROM tblList where "
            strSource = strSource & " isnumeric(Listcode)=1 and parent='53217')cc) ) bb"
        End If

        'Dim oAdapter As New SqlClient.SqlDataAdapter(strSource, oConn)

        'Dim oDs As New DataSet
        'oAdapter.Fill(oDs)
        'oDs.Tables(0).TableName = "tblList"

        da = New SqlDataAdapter(strSource, conn)
        da.Fill(ds)
        ds.Tables(0).TableName = "tblList"

        tvAvailableReports.Nodes.Clear()
        Dim jj As New ctrlTreeView(Me.tvAvailableReports, ds, "tblList", "ListCode", "Parent", "Description")

        objUserctrl.Name = "ctrlCharts"
        objUserctrl.Tag = "ctrlCharts"
    End Sub

    Private Sub SqlServerTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvAvailableReports.AfterSelect

        Cursor = Cursors.WaitCursor
        Dim start As DateTime = DateTime.Now
        ShowDetails(Me.tvAvailableReports.SelectedNode)
        Dim diff As TimeSpan = DateTime.Now - start
        'Me.speedToolStripStatusLabel.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:####}", diff.TotalMilliseconds)
        Cursor = Cursors.Default

    End Sub

    Private Sub SqlServerTreeView_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvAvailableReports.AfterExpand
        Cursor = Cursors.WaitCursor
        LoadTreeViewItems(e.Node)
        Cursor = Cursors.Default
    End Sub

    'Loads treeview items and updates listview as well.
    '<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage","CA2201:DoNotRaiseReservedExceptionTypes")>
    Private Sub ShowDetails(ByVal node As TreeNode)

        Me.ReportViewer1.Reset()

        Try
            If node Is Nothing Then
                Return
            End If

            Dim objCredentials As Microsoft.Reporting.WinForms.DataSourceCredentials() = New Microsoft.Reporting.WinForms.DataSourceCredentials(0) {}
            If My.Settings.DataConnectionString.Split(";").Contains("Trusted_Connection=true") Or My.Settings.DataConnectionString.Replace(" ", "").Split(";").Contains("IntegratedSecurity=True") Then
                objCredentials(0) = New Microsoft.Reporting.WinForms.DataSourceCredentials()
            Else
                objCredentials(0) = New Microsoft.Reporting.WinForms.DataSourceCredentials()
                objCredentials(0).UserId = My.Settings.DataConnectionString.Split("'").GetValue(3).ToString '"sa"
                objCredentials(0).Password = My.Settings.DataConnectionString.Split("'").GetValue(5).ToString '""
            End If
            Dim objCredentialsa As Microsoft.Reporting.WinForms.ReportDataSource() = New Microsoft.Reporting.WinForms.ReportDataSource(0) {}
            objCredentialsa(0) = New Microsoft.Reporting.WinForms.ReportDataSource()

            'Establish time period
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim strTimePeriod As String = ""
            Dim strPeriodFrom As String = ""
            Dim strPeriodTo As String = ""
            Dim strArray() As String

            If ReportMode = "Submission" Then
                strArray = node.FullPath.Split("\")
                If strArray(1).ToString.Contains("Annual") Then
                    strPeriodFrom = "01Jul" + Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(strArray(2), 4), 2)
                    strPeriodTo = "30Jun" + Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Right(strArray(2), 4), 2)
                    strTimePeriod = strPeriodFrom + strPeriodTo
                    strReportName = strReportName & "DistrictAnnuallyReportSubmissionStatus.rdl"
                    strFormSerialNumber = "005" + "%" + strTimePeriod
                ElseIf strArray(1).ToString.Contains("Quarterly") Then
                    strArray = strArray(3).ToString.Split("-")
                    'strPeriodFrom = "01" + Microsoft.VisualBasic.Left(strArray(3), 3) + Microsoft.VisualBasic.Right(strArray(3), 2)
                    'strPeriodTo = strArray.ToString.Substring(5, 3) + Microsoft.VisualBasic.Right(strArray(3), 2)
                    strPeriodFrom = "01" + Microsoft.VisualBasic.Left(strArray(0), 3) + Microsoft.VisualBasic.Right(strArray(1), 2)
                    strPeriodTo = Microsoft.VisualBasic.Left(strArray(1), 3) + Microsoft.VisualBasic.Right(strArray(1), 2)
                    strTimePeriod = strPeriodFrom + "%" + strPeriodTo
                    strReportName = strReportName & "DistrictQuarterlyReportSubmissionStatus.rdl"
                    strFormSerialNumber = "004" + "%" + strTimePeriod
                Else
                End If
                Me.cmbValues.Items.Add(strFormSerialNumber)

                Dim sParam As String() = Nothing
                Dim j As Int16 = 0

                ReDim Preserve sParam(j)
                sParam(j) = strFormSerialNumber

                j = j + 1
                ReDim Preserve sParam(j)
                sParam(j) = node.Text

                Dim controll As New RdlViewer.ctrlReportControl(My.Settings.DataConnectionString, strReportName, sParam)

                controll.ShowDialogue = False
                controll.Dock = DockStyle.Fill
                'ApplicationGlobal.gfrmMainForm.getControl(controll)
                Exit Sub
            End If

            'Establish the area Name and area level
            Dim strAreaName As String = ""
            Dim strAreaLevel As Int16 = 0

            strAreaName = node.FullPath.Substring(node.FullPath.IndexOf("Tanzania"), node.FullPath.Length - node.FullPath.IndexOf("Tanzania"))

            strAreaLevel = strAreaName.Split("\").Length + 2
            strAreaName = strAreaName.Split("\").Last

            '* Declare objects
            'Dim sqlCon As New SqlConnection
            'Dim sqlCmd As New SqlCommand
            'Dim myDS As New DataSet
            'Dim sqlDA As New SqlDataAdapter
            'Dim strFormSerialNumber As String = ""
            'Dim strFormCumSerialNumber As String = ""
            'Dim strFormCumSerialNumber1 As String = ""
            'Dim strFormCumNextYearSerialNumber As String = ""
            'Dim strFormCumNextYearSerialNumber1 As String = ""

            '* Read connection string from application config file
            sqlCon.ConnectionString = My.Settings.DataConnectionString
            '* Set up command object
            sqlCmd.Connection = sqlCon
            sqlCmd.CommandType = CommandType.Text
            '* Set up data adapter and fill dataset

            Dim strPeriod As String = node.FullPath.ToString.Split("/")(1).Split("\")(0)

            sqlDA.SelectCommand = sqlCmd
            If node.Tag.ToString.Contains("Anpg1") Or node.Tag.ToString.Contains("Awpg1") Then
                If Len(strPeriod) > 0 Then
                    Dim strOtherPeriod As String = ""
                    Dim strMonthFrom As String = ""
                    Dim strMonthTo As String = ""
                    Dim strAnnualPeriod As String = ""

                    strMonthFrom = "Jul" & Mid(CInt(strPeriod) - 1, 3, 2)
                    strMonthTo = "Jun" & Mid(CInt(strPeriod), 3, 2)

                    strAnnualPeriod = CInt(Mid(strPeriod, Len(strPeriod) - 2, 2)) + 1
                    strOtherPeriod = CInt(strPeriod) + 1
                    Try
                        ' strFormSerialNumber = DomainLookup("Area_id", "tbl_setup_areas", "AREA_NID= " & node.Tag.ToString.Split("")(0).ToString.Split("=")(1) & "").ToString & "%" + strMonthFrom + "%" + strMonthTo + "%"
                        strFormSerialNumber = DomainLookup("Area_id", "tbl_setup_areas", "AREA_NID= " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & "").ToString & "%" + strMonthFrom + "%" + strMonthTo + "%"
                        ' strPeriod = "%" + strMonthFrom + "%" + strMonthTo + "%"
                    Catch ex As Exception
                    End Try
                Else
                    strPeriod = "%"
                End If

            ElseIf node.Tag.ToString.Contains("Qtrpg1") Or node.Tag.ToString.Contains("Qwpg1") Then

                strPeriod = node.FullPath.ToString.Split("\")(3)

                If InStr(strPeriod, " ") > 0 And InStr(strPeriod, "-") > 0 Then
                    Dim strOtherPeriod As String = ""
                    Dim strMonthFrom As String = ""
                    Dim strMonthTo As String = ""
                    Dim strAnnualPeriod As String = ""

                    strMonthFrom = Mid(strPeriod, 1, InStr(strPeriod, "-") - 1)
                    strPeriod = Replace(strPeriod, Mid(strPeriod, 1, InStr(strPeriod, "-")), "")
                    strMonthTo = Mid(strPeriod, 1, InStr(strPeriod, " ") - 1)

                    strPeriod = Replace(strPeriod, Mid(strPeriod, 1, InStr(strPeriod, " ")), "")

                    If Mid(strMonthTo, 1, 3) = "Sep" Or Mid(strMonthTo, 1, 3) = "Dec" Then
                        strAnnualPeriod = CInt(Mid(strPeriod, Len(strPeriod) - 2, 2)) + 1
                        strOtherPeriod = CInt(strPeriod) + 1
                    Else
                        strAnnualPeriod = Mid(strPeriod, Len(strPeriod) - 2, 2)
                        strOtherPeriod = CInt(strPeriod) - 1
                    End If

                    strPeriod = DomainLookup("Area_id", "tbl_setup_areas", "AREA_NID= " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & "").ToString & "%" + Mid(strMonthFrom, 1, 3) + Mid(strPeriod, Len(strPeriod) - 1, 2) + "%" + Mid(strMonthTo, 1, 3) + Mid(strPeriod, Len(strPeriod) - 1, 2) + "%"
                    strOtherPeriod = DomainLookup("Area_id", "tbl_setup_areas", "AREA_NID= " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & "").ToString & "%" + Mid(strMonthFrom, 1, 3) + Mid(strOtherPeriod, Len(strOtherPeriod) - 1, 2) + "%" + Mid(strMonthTo, 1, 3) + Mid(strOtherPeriod, Len(strOtherPeriod) - 1, 2) + "%"

                    If strMonthTo = "September" Then
                        strFormCumSerialNumber = strPeriod
                        strFormCumNextYearSerialNumber = strPeriod
                    End If
                    If strMonthTo = "December" Then
                        strFormCumSerialNumber = strPeriod.Replace("Dec", "Sep").Replace("Oct", "Jul")
                        strFormCumNextYearSerialNumber = strFormCumSerialNumber
                    End If
                    If strMonthTo = "March" Then
                        strFormCumSerialNumber = strPeriod
                        strFormCumNextYearSerialNumber = strOtherPeriod.Replace("Jan", "Jul").Replace("Mar", "Sep")
                        strFormCumNextYearSerialNumber1 = strOtherPeriod.Replace("Jan", "Oct").Replace("Mar", "Dec")
                    End If
                    If strMonthTo = "June" Then
                        strFormCumSerialNumber = strPeriod
                        strFormCumSerialNumber1 = strPeriod.Replace("Apr", "Jan").Replace("Jun", "Mar")
                        strFormCumNextYearSerialNumber = strOtherPeriod.Replace("Apr", "Jul").Replace("Jun", "Sep")
                        strFormCumNextYearSerialNumber1 = strOtherPeriod.Replace("Apr", "Oct").Replace("Jun", "Dec")
                    End If
                    strFormSerialNumber = strPeriod
                End If

            ElseIf node.Tag.ToString.Contains("Mwpg1") Then

                Dim strMonth As String
                Dim strYear As String

                strMonth = node.FullPath.ToString.Split("\")(2) & "," & node.FullPath.ToString.Split("\")(3)
                strMonth = Mid(node.FullPath.ToString.Split("\")(3), 1, 3)

                If DatePart(DateInterval.Month, CDate("1-" & node.FullPath.ToString.Split("\")(3))) < 7 Then
                    strYear = Mid(node.FullPath.ToString.Split("\")(2).Split("/")(1), 3, 2)
                Else
                    strYear = Mid(node.FullPath.ToString.Split("\")(2).Split("/")(0), 3, 2)
                End If

                strFormSerialNumber = DomainLookup("Area_id", "tbl_setup_areas", "AREA_NID= " & node.Tag.ToString.Split(" ")(0).ToString.Split("=")(1) & "").ToString & "%" + Mid(strMonth, 1, 3) + strYear + "%" + Mid(strMonth, 1, 3) + strYear + "%"
            Else
                strPeriod = "%"
            End If

            Dim s As New LGMDdataDataSet
            's.tblInstitutions.
            myDS.Merge(s)

            '* Name property of data set (first parameter below) MUST be the same name
            '* as the data set used at design time. While this name can be changed in the
            '* report xml specification it must be manually changed everywhere it occurs.
            '* Choose a meaningful name when the dataset is created.
            '* Note here that the dataset table can be established as a ReportDataSource
            '* Clear out default datasource and add new one (with same structure).

            ReportViewer1.LocalReport.DataSources.Clear()

            'New reports
            If node.Tag.ToString.Contains("Mwpg1") Then
                If ReportMode = "Ward" Then
                    strReportName = strReportName & "PrintoutOfMonthlyASPD.rdl"
                ElseIf ReportMode = "Submission" Then  'This and line before should be commented
                    strReportName = strReportName & "WardMonthlyReportSubmissionStatus.rdl"  ' In here, put the name of your submission report
                Else
                    strReportName = strReportName & "MonthlyWardReport.rdl"
                End If
                strSeletedPeriod = "001"
            ElseIf node.Tag.ToString.Contains("Qwpg1") Then
                If ReportMode = "Ward" Then
                    strReportName = strReportName & "PrintoutOfQuarterlyASPD.rdl"
                ElseIf ReportMode = "Submission" Then    'This and line before should be commented
                    strReportName = strReportName & "WardQuarterlyReportSubmissionStatus.rdl"  ' In here, put the name of your submission report
                Else
                    strReportName = strReportName & "QuarterlyWardReport.rdl"
                End If
                strSeletedPeriod = "002"
            ElseIf node.Tag.ToString.Contains("Awpg1") Then
                If ReportMode = "Ward" Then
                    strReportName = strReportName & "PrintoutOfAnnuallyASPD.rdl"
                ElseIf ReportMode = "Submission" Then   'This and line before should be commented
                    strReportName = strReportName & "WardAnnuallyReportSubmissionStatus.rdl"  ' In here, put the name of your submission report
                Else
                    strReportName = strReportName & "AnnuallyWardReport.rdl"
                End If
                strSeletedPeriod = "003"
            ElseIf node.Tag.ToString.Contains("Qtrpg1") Then
                strReportName = strReportName & "ReportQuarter.rdl"
                'strSeletedPeriod = "004"
            ElseIf node.Tag.ToString.Contains("Anpg1") Then
                strReportName = strReportName & "ReportAnnual.rdl"
                'strSeletedPeriod = "005"
            End If

            strFormSerialNumber = strSeletedPeriod & "%" & strFormSerialNumber
            'For i = 0 To strSelectionOption.Length - 1
            Me.cmbValues.Items.Add(strFormSerialNumber)
            'Next

            Dim sParams As String()
            Dim i As Int16 = 0

            ReDim Preserve sParams(i)
            sParams(i) = strFormSerialNumber

            i = i + 1
            ReDim Preserve sParams(i)
            sParams(i) = strAreaName

            i = i + 1
            ReDim Preserve sParams(i)
            sParams(i) = strAreaLevel

            strSelectedValue1 = fnGetParams(strFormSerialNumber)

            Dim control As New RdlViewer.ctrlReportControl(My.Settings.DataConnectionString, strReportName, sParams)

            control.ShowDialogue = False
            control.Dock = DockStyle.Fill
            'ApplicationGlobal.gfrmMainForm.getControl(control)

        Catch ex As Exception
            'MsgBox(ex.InnerException.ToString)
        End Try
    End Sub

    'Lists a collection in the listview if the container node is selected
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

    Private Sub ListView_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs)
        objSelected = "ListView"
    End Sub

    Private Sub SqlServerTreeView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvAvailableReports.Click
        objSelected = "SqlServerTreeView"
    End Sub

    Private Sub ListView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        objSelected = "ListView"
    End Sub

    Private Sub SqlServerTreeView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvAvailableReports.MouseDown
        objSelected = "SqlServerTreeView"
    End Sub

    Public Sub fnTreeviewExpand()
        Me.tvAvailableReports.ExpandAll()
    End Sub

End Class