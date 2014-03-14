Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Microsoft.SqlServer.Management.Smo
Imports System.Collections.Specialized
Imports System.Windows.Forms.MessageBox
Imports Microsoft.SqlServer.Management.Common
Imports System.IO
Imports System.IO.Compression
Imports System.IO.Compression.ZipArchive
Imports System.IO.Packaging

Public Class ctrlEditForm

    Dim strSelectedForm As String = ""

    Private Sub ctrlEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnVerifyData.Hide()
        Try
            If GetConfigLevel() = 5 Then
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, Nothing, Nothing)
            Else 
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, 4, 5)
            End If
        Catch ex As Exception
        End Try

        Select Case g_language
            Case "English"
                Me.cmdDelete.Text = "Delete form"
            Case Else
                Me.cmdDelete.Text = "Futa fomu"
        End Select

        If strSelectedNode = "View unapproved data" Then
            Udp_forms_submittedDataGridView.DataSource.filter = "len(isnull(ApprovedByUserID,''))=0"
        ElseIf strSelectedNode = "View approved data" Then
            Udp_forms_submittedDataGridView.DataSource.filter = "len(isnull(ApprovedByUserID,''))>0"
        Else 'If strSelectedForm = "View unapproved data" Then
            Udp_forms_submittedDataGridView.DataSource.filter = "len(isnull(ApprovedByUserID,''))=0"
        End If

        If Me.Udp_forms_submittedDataGridView.RowCount > 0 Then
            g_FormTypeNumber = CLng(Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("FormTypeNumber").Value.ToString)
            g_PeriodFrom = CDate(Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("PeriodFrom").Value.ToString)
            g_PeriodTo = CDate(Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("PeriodTo").Value.ToString)
            g_PeriodHeading = PeriodHeading(g_PeriodFrom, g_PeriodTo)
            g_FormSerialNumber = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("FormSerialNumber").Value.ToString
            g_RecordID = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("RecordID").Value
        End If

    End Sub

    Private Sub RefreshEditButtonCaption()
        If Me.Udp_forms_submittedDataGridView.SelectedRows.Count > 0 Then
            'Me.cmdEdit.Enabled = True
            Select Case g_language
                Case "English"
                    'If Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("Area_ID").Value.ToString = GetConfigArea() And g_bViewOnly = False And Udp_forms_submittedDataGridView.SelectedRows(0).Cells(10).Value.ToString.Length = 0 Then
                    If g_bViewOnly = False Then
                        Me.cmdEdit.Text = "Edit form"
                    Else
                        Me.cmdEdit.Text = "View form"
                    End If
                Case Else
                    'If Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("Area_ID").Value.ToString = GetConfigArea() And g_bViewOnly = False And Udp_forms_submittedDataGridView.SelectedRows(0).Cells(10).Value.ToString.Length = 0 Then
                    If g_bViewOnly = False Then
                        Me.cmdEdit.Text = "Hariri fomu"
                    Else
                        Me.cmdEdit.Text = "Angalia fomu"
                    End If
            End Select
        Else
            'Me.cmdEdit.Enabled = False
            Select Case g_language
                Case "English"
                    Me.cmdEdit.Text = "View/edit form"
                Case Else
                    Me.cmdEdit.Text = "Angalia/hariri fomu"
            End Select
        End If
        Me.txtComments.ReadOnly = Not (Me.BtnApproveData.Enabled Or Me.btnVerifyData.Enabled)
        Me.btnSaveComment.Enabled = Not Me.txtComments.ReadOnly

    End Sub

    Private Function GetFormDetails() As Boolean
        If Me.Udp_forms_submittedDataGridView.SelectedRows.Count = 0 Then
            MsgBoxBilingual("Please choose a form", "Chagua fomu kwanza")
            GetFormDetails = False
            Exit Function
        End If

        g_FormTypeNumber = CLng(Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("FormTypeNumber").Value.ToString)
        g_AreaID = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("Area_ID").Value.ToString
        g_OrganisationID = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("OrganisationID").Value.ToString
        g_AreaHeading = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("Area_Level_Name").Value.ToString & ": " & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("Area_Name").Value.ToString
        g_PeriodFrom = CDate(Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("PeriodFrom").Value.ToString)
        g_PeriodTo = CDate(Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("PeriodTo").Value.ToString)
        g_PeriodHeading = PeriodHeading(g_PeriodFrom, g_PeriodTo)
        g_FormSerialNumber = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("FormSerialNumber").Value.ToString
        g_RecordID = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("RecordID").Value
        GetFormDetails = True
    End Function

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If GetFormDetails() = False Then
            Exit Sub
        End If

        If g_bViewOnly = False Then
            g_form_mode = "Edit"
        Else
            g_form_mode = "View"
        End If
        If g_bViewOnly = True Then
            g_form_mode = "View"
        End If

        Dim ctrl As New System.Windows.Forms.UserControl
        If LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.Count > 0 Then
        End If
        LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.RemoveAt(0)
        Select Case g_FormTypeNumber
            Case 1
                ctrl = New ctrlWard01Page01
            Case 2
                ctrl = New ctrlWard02Page01
            Case 3
                ctrl = New ctrlWard03Page01
            Case 4
                ctrl = New ctrlDistrict02Page01
            Case 5
                ctrl = New ctrlDistrict03Page01
            Case 6
                ctrl = New ctrlWard06Page01
        End Select
        Try
            LGMD.ApplicationGlobal.objFrmMain.SplitContainer.Panel2.Controls.Add(ctrl)
        Catch ex As Exception
        End Try
        g_bSeleted = True

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerifyData.Click
        Dim rowCount As Integer
        Dim conn As New SqlClient.SqlConnection(My.Settings.DataConnectionString) ' My.Settings.LGMDdataConnectionStringMy.Settings.LGMDdataConnectionString)

        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        Try
            conn.Open()
            Dim cmd As New SqlCommand("update RecordInfo set DateVerified=convert(datetime,'" & Now.Date & "',103),VerifiedByUserID='" & g_user_id & "' WHERE FormSerialNumber='" & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells(5).Value.ToString & "' ", conn)
            rowCount = cmd.ExecuteNonQuery()
            If GetConfigLevel() = 5 Then
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, Nothing, Nothing)
            Else
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, 4, 5)
            End If
            MsgBox("Succesfully Verified")
            Me.cmdEdit.Focus()
            Me.btnVerifyData.Enabled = False
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BtnApproveData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnApproveData.Click

        Dim strCommand As String = ""
        Dim strMessageToAsk As String = ""
        Dim strFormSerialNumber = g_FormSerialNumber.Substring(3, 15) + "%" + g_FormSerialNumber.Substring(24)

        If Me.BtnApproveData.Text = "Approve Data" Then
            If g_FormTypeNumber = 4 Then
                'strCommand = "update RecordInfo set DateApproved=convert(datetime,'" & Now.Date & "',103),ApprovedByUserID='" & g_user_id & "' WHERE FormSerialNumber='" & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells(6).Value.ToString & "'"
                strCommand = "update RecordInfo set DateApproved=convert(datetime,'" & Now.Date & "',103),ApprovedByUserID='" & g_user_id & "' WHERE FormSerialNumberIQ LIKE '" & strFormSerialNumber & "'"
            Else
                'strCommand = "update RecordInfo set DateApproved=convert(datetime,'" & Now.Date & "',103),ApprovedByUserID='" & g_user_id & "' WHERE FormSerialNumber='" & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells(6).Value.ToString & "'"
                strCommand = "update RecordInfo set DateApproved=convert(datetime,'" & Now.Date & "',103),ApprovedByUserID='" & g_user_id & "' WHERE FormSerialNumberIA LIKE '" & strFormSerialNumber & "'"
            End If
            strMessageToAsk = "Are you sure you want to Approve this Report?"
        Else
            'strCommand = "update RecordInfo set DateApproved=null, ApprovedByUserID=null, DateVerified=convert(datetime,'" & Now.Date & "',103),VerifiedByUserID='" & g_user_id & "' WHERE FormSerialNumber='" & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells(5).Value.ToString & "'"
            If g_FormTypeNumber = 4 Then
                'strCommand = "update RecordInfo set DateApproved=null, ApprovedByUserID=null WHERE FormSerialNumber='" & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells(6).Value.ToString & "'"
                strCommand = "update RecordInfo set DateApproved=null, ApprovedByUserID=null WHERE FormSerialNumberIQ LIKE '" & strFormSerialNumber & "'"
            Else
                'strCommand = "update RecordInfo set DateApproved=null, ApprovedByUserID=null WHERE FormSerialNumber='" & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells(6).Value.ToString & "'"
                strCommand = "update RecordInfo set DateApproved=null, ApprovedByUserID=null WHERE FormSerialNumberIA LIKE '" & strFormSerialNumber & "'"
            End If
            strMessageToAsk = "Are you sure you want to Allow changes to this Report?"
        End If

        If MsgBox(strMessageToAsk, MsgBoxStyle.Question + MsgBoxStyle.YesNo + vbDefaultButton2) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim rowCount As Integer
        Dim conn As New SqlClient.SqlConnection(My.Settings.DataConnectionString) 'My.Settings.LGMDdataConnectionStringMy.Settings.LGMDdataConnectionString)

        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        Try
            conn.Open()
            Dim cmd As New SqlCommand(strCommand, conn)
            rowCount = cmd.ExecuteNonQuery()
            Try
                If GetConfigLevel() = 5 Then
                    Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, Nothing, Nothing)
                Else
                    Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, 4, 5)
                End If
            Catch ex As Exception
            End Try

            If Me.BtnApproveData.Text = "Approve Data" Then
                MsgBox("Succesfully Approved")
            Else
                MsgBox("Succesfully Allowed Changes")
            End If

            Me.cmdEdit.Focus()
            'Me.BtnApproveData.Enabled = False
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim recordID As Guid
        Dim formSerialNumber As Int32
        If GetFormDetails() = False Then
            Exit Sub
        End If
        Try
            If MsgBoxBilingual("Are you sure you want to delete this form and all the data on it?", "Una uhakika unataka kufuta fomu hii na takwimu zake zote?", 36) = vbYes Then
                Me.Cursor = Cursors.WaitCursor
                For Each row As DataGridViewRow In Me.Udp_forms_submittedDataGridView.SelectedRows
                    recordID = row.Cells(1).Value
                    formSerialNumber = row.Cells(7).Value
                Next
                Call DeleteForm(recordID, formSerialNumber)
                MessageBox.Show("Form successfully deleted", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If GetConfigLevel() = 5 Then
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, Nothing, Nothing)
            Else
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, 4, 5)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try

    End Sub

    Private Sub Udp_forms_submittedDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Udp_forms_submittedDataGridView.SelectionChanged

        If Me.Udp_forms_submittedDataGridView.SelectedRows.Count > 0 And g_bViewOnly = True Then

            'If Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("VerifiedByUserID").Value.ToString = "" And GetConfigLevel() = 4 Then
            '    Me.btnVerifyData.Enabled = True
            'Else
            '    Me.btnVerifyData.Enabled = False
            'End If

            'Removed from the if statement below "Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("VerifiedByUserID").Value.ToString <> "" And"
            If GetConfigLevel() = 4 Then
                Me.cmdEdit.Enabled = False
                Me.txtComments.Enabled = True
                Me.BtnApproveData.Enabled = True
                Me.btnSaveComment.Enabled = True
                Me.cmdDelete.Enabled = False
                Me.btnExport.Enabled = False
                Me.btnExportAlForms.Enabled = False
            ElseIf GetConfigLevel() = 2 Then
                Me.cmdEdit.Enabled = False
                Me.cmdDelete.Enabled = False
                Me.btnExport.Enabled = False
                Me.btnExportAlForms.Enabled = False
            Else
                Me.cmdEdit.Enabled = True
                Me.cmdDelete.Enabled = False
                Me.btnExport.Enabled = False
                Me.btnExportAlForms.Enabled = False
            End If

            If Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("ApprovedByUserID").Value.ToString <> "" Then
                Me.BtnApproveData.Text = "Allow Changes"
            Else
                Me.BtnApproveData.Text = "Approve Data"
            End If

            'If Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("Area_ID").Value.ToString.Equals(GetConfigArea()) Then
            '    Me.cmdDelete.Enabled = True
            '    Me.btnExport.Enabled = True
            '    Me.btnExportAlForms.Enabled = True
            'Else
            '    Me.cmdDelete.Enabled = False
            '    Me.btnExport.Enabled = False
            '    Me.btnExportAlForms.Enabled = False
            'End If
        Else
            Me.BtnApproveData.Enabled = False
            Me.btnVerifyData.Enabled = False
            Me.cmdDelete.Enabled = True
            Me.btnExport.Enabled = True
            Me.btnExportAlForms.Enabled = True
        End If
        Call RefreshEditButtonCaption()
        Try
            If Me.Udp_forms_submittedDataGridView.SelectedRows.Count = 0 Then
                If Udp_forms_submittedDataGridView.Rows.Count > 0 Then
                    g_FormTypeNumber = CLng(Me.Udp_forms_submittedDataGridView.Rows(0).Cells("FormTypeNumber").Value.ToString)
                    g_PeriodHeading = PeriodHeading(g_PeriodFrom, g_PeriodTo)
                    g_FormSerialNumber = Me.Udp_forms_submittedDataGridView.Rows(0).Cells("FormSerialNumber").Value.ToString
                End If
            Else
                g_FormTypeNumber = CLng(Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("FormTypeNumber").Value.ToString)
                g_PeriodHeading = PeriodHeading(g_PeriodFrom, g_PeriodTo)
                g_FormSerialNumber = Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells("FormSerialNumber").Value.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSaveComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveComment.Click

        If GetFormDetails() = False Then
            Exit Sub
        End If
        Dim rowCount As Integer
        Dim conn As New SqlClient.SqlConnection(My.Settings.DataConnectionString) ' My.Settings.LGMDdataConnectionStringMy.Settings.LGMDdataConnectionString)

        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        Try
            conn.Open()
            Dim cmd As New SqlCommand("update RecordInfo set Comments='" & Me.txtComments.Text & "' WHERE FormSerialNumber='" & Me.Udp_forms_submittedDataGridView.SelectedRows(0).Cells(6).Value.ToString & "' ", conn)
            rowCount = cmd.ExecuteNonQuery()
            If rowCount > 0 Then
                MsgBox("Comment Successfully Saved")
            End If
            If GetConfigLevel() = 5 Then
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, Nothing, Nothing)
            Else
                Me.Udp_forms_submittedTableAdapter.Fill(Me.LGMDdataDataSet.udp_forms_submitted, g_language, 4, 5)
            End If
            Me.cmdEdit.Focus()
            Me.btnVerifyData.Enabled = False
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        fnExportFile(False)
    End Sub

    Private Sub btnExportAlForms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportAlForms.Click
        fnExportFile(True)
    End Sub

    Private Sub fnExportFile(Optional ByVal bAllForms As Boolean = True)
        Dim conn As New SqlClient.SqlConnection
        Dim sDatabaseName As String = ""
        Dim db As Microsoft.SqlServer.Management.Smo.Database
        Dim fg As FileGroup
        Dim df As Microsoft.SqlServer.Management.Smo.DataFile
        Dim strSqlValues As String = ""
        Dim strSQLInsert As String = ""
        Dim strValue As String = ""
        Dim cmd As New SqlCommand
        Dim reader As SqlClient.SqlDataReader

        Dim strShellPath As String = ""
        Dim strHostIP As String = ""
        conn.ConnectionString = My.Settings.DataConnectionString ' My.Settings.LGMDdataConnectionString
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        cmd.Connection = conn
        cmd.CommandText = "select area_name from tbl_setup_areas where area_id in (select config_value from tbl_Config where config_name ='Area_id' )"
        reader = cmd.ExecuteReader()
        Using reader
            While reader.Read
                sDatabaseName = Now
                sDatabaseName = sDatabaseName.Replace("/", "").Replace(":", "").Replace("AM", "").Replace("PM", "").Replace("#", "").Replace(" ", "").Replace("-", "_")
                If Not bAllForms Then
                    Dim strCustExport As String = ""
                    Select Case g_FormTypeNumber 'CLng(Me.SplitContainer.Panel2.Controls(0).Udp_forms_submittedDataGridView.SelectedRows(0).Cells("FormTypeNumber").Value.ToString)
                        Case 1
                            strCustExport = "Monthly"
                        Case 2
                            strCustExport = "Quarterly"
                        Case 3
                            strCustExport = "Annual"
                        Case 4
                            strCustExport = "DistrictQuarterly"
                        Case 5
                            strCustExport = "DistrictAnnual"
                        Case 6
                            strCustExport = "AnnualTarget"
                    End Select
                    strCustExport = strCustExport & g_PeriodHeading.Replace(" ", "").Replace("-", "").Replace("/", "").Replace("\", "")

                    sDatabaseName = "LGMD2_Exp" & strCustExport & Replace(Replace(reader.GetValue(0), "'", "''"), " ", "") & sDatabaseName
                Else
                    sDatabaseName = "LGMD2_Exp" & Replace(Replace(reader.GetValue(0), "'", "''"), " ", "") & sDatabaseName
                End If

            End While
        End Using

        Try
            Dim dlgSaveExportFile As New SaveFileDialog
            dlgSaveExportFile.Title = "Save LGMD2 export file to National level"
            dlgSaveExportFile.Filter = "LGMD2 Files(*.zip)|*.zip"
            dlgSaveExportFile.DefaultExt = "zip"
            dlgSaveExportFile.FileName = sDatabaseName
            dlgSaveExportFile.FileName = sDatabaseName & ".zip"
            dlgSaveExportFile.AddExtension = True

            If dlgSaveExportFile.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Me.Cursor = Cursors.WaitCursor
                'Instantiate a new database object
                'db = New Microsoft.SqlServer.Management.Smo.Database(frmMain.SqlServerSelection, sDatabaseName)

                'This may also be accomplished like so:
                db = New Microsoft.SqlServer.Management.Smo.Database()
                db.Parent = ApplicationGlobal.sqlServer
                db.Name = sDatabaseName

                'Add a new file group named PRIMARY to the database's FileGroups collection
                fg = New FileGroup(db, "PRIMARY")

                'Create a new data file and add it to the file group's Files collection
                'Give the data file a physical filename using the master database path of the server
                df = New DataFile(fg, sDatabaseName & "_Data0", _
                    ApplicationGlobal.sqlServer.Information.MasterDBPath & "\" _
                        & sDatabaseName & "_Data0" & ".mdf")

                fg.Files.Add(df)

                db.Create()
                Dim strCriteria As String = ""
                strCriteria = " where FormSerialID = '" & g_FormSerialNumber & "'"
                If Not bAllForms Then
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "appUspExportData"
                        .Parameters.Add(New SqlParameter("@strCriteria", strCriteria))
                        .Parameters.Add(New SqlParameter("@DatabaseName", sDatabaseName))
                        .ExecuteNonQuery()
                    End With
                Else
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "appUspExportData"
                        .Parameters.Add(New SqlParameter("@DatabaseName", sDatabaseName))
                        .ExecuteNonQuery()
                    End With
                End If
                'cmd.CommandText = "select [RecordID],[AreaID],[OfficerName],[SubmissionDate],[PeriodFrom],[PeriodTo],[FormTypeNumber],[DateCaptured],[CapturedByUserID],[DateApproved],[ApprovedByUserID],[Comments],[OrganisationID],[FormSerialID],[FormSerialNumber],[FormSerialNumberIQ],[FormSerialNumberIA] into " & sDatabaseName & ".dbo.Exptbl_RecordInfo from RecordInfo " & strCriteria
                'cmd.CommandText = "select [RecordID],[AreaID],[OfficerName],[SubmissionDate],[PeriodFrom],[PeriodTo],[FormTypeNumber],[DateCaptured],[CapturedByUserID],[DateApproved],[ApprovedByUserID],[Comments],[OrganisationID],[FormSerialID],[FormSerialNumber],[FormSerialNumberIQ],[FormSerialNumberIA] into MyTestDB.dbo.Exptbl_RecordInfo from RecordInfo " & strCriteria
                'cmd.ExecuteNonQuery()

                Dim strSourceFile As String = ApplicationGlobal.sqlServer.Databases(sDatabaseName).FileGroups(0).Files(0).FileName

                ApplicationGlobal.sqlServer.DetachDatabase(sDatabaseName, False)

                ApplicationGlobal.sqlServer.Databases.Refresh()

                Using zipFolder As ZipArchive = ZipFile.Open(dlgSaveExportFile.FileName, ZipArchiveMode.Create)
                    zipFolder.CreateEntryFromFile(strSourceFile, sDatabaseName & ".lge")
                End Using

                My.Computer.FileSystem.DeleteFile(strSourceFile)
                MsgBox("Data exported successfuly")
            Else
            End If
            g_bSeleted = False
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class