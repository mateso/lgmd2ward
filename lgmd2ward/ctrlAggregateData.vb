Imports System.Data.SqlClient

Public Class ctrlAggregateData

    Private ds As DataSet
    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private cmdBldr As SqlCommandBuilder
    Private dt As DataTable
    Private formSerialID As String = ""
    Private formSerialIDForFilter As String = ""
    Private monthName As String = ""
    Private yearName As String = ""

    Private Sub ctrlAggregateData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.FillFormTypes()
    End Sub

    Private Sub cmbFormType_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbFormType.SelectionChangeCommitted

        Me.lblMonthQuarter.Visible = False
        Me.cmbMonthQuarter.Visible = False
        Me.cmbMonthQuarter.DataBindings.Clear()

        ds = New DataSet()
        cmd = New SqlCommand()
        da = New SqlDataAdapter()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "appUspFillFinancialYear"
                .Parameters.AddWithValue("@FormTypeNumber", Me.cmbFormType.SelectedIndex)
            End With

            da.SelectCommand = cmd
            da.Fill(ds, "appUspFillFinancialYear")
            dt = ds.Tables("appUspFillFinancialYear")

            If dt.Rows.Count > 1 Then
                Me.lblFinancialYear.Visible = True
                Me.cmbFinancialYear.Visible = True

                With Me.cmbFinancialYear
                    .DataSource = dt
                    .ValueMember = "FinancialYear"
                    .DisplayMember = "FinancialYear"
                End With
            Else
                Me.lblFinancialYear.Visible = False
                Me.cmbFinancialYear.Visible = False
                Me.cmbFinancialYear.DataBindings.Clear()

                If Me.cmbFormType.SelectedIndex = 0 Then
                Else
                    MsgBox("fskfk")
                End If
            End If

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub cmbFinancialYear_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbFinancialYear.SelectionChangeCommitted
        ds = New DataSet()
        cmd = New SqlCommand()
        da = New SqlDataAdapter()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "appUspFillMonthOrQuarter"
                .Parameters.AddWithValue("@FormTypeNumber", Me.cmbFormType.SelectedIndex)
                .Parameters.AddWithValue("@PeriodFrom", Microsoft.VisualBasic.Left(Me.cmbFinancialYear.SelectedValue.ToString, 4))
                .Parameters.AddWithValue("@PeriodTo", Microsoft.VisualBasic.Right(Me.cmbFinancialYear.SelectedValue.ToString, 4))
            End With

            da.SelectCommand = cmd
            da.Fill(ds, "appUspFillMonthOrQuarter")
            dt = ds.Tables("appUspFillMonthOrQuarter")

            If dt.Rows.Count > 1 Then

                If Me.cmbFormType.SelectedIndex = 1 Then
                    Me.lblMonthQuarter.Visible = True
                    Me.cmbMonthQuarter.Visible = True
                    Me.lblMonthQuarter.Text = "Select Month"
                ElseIf Me.cmbFormType.SelectedIndex = 2 Then
                    Me.lblMonthQuarter.Visible = True
                    Me.cmbMonthQuarter.Visible = True
                    Me.lblMonthQuarter.Text = "Select Quarter"
                Else
                    Me.lblMonthQuarter.Visible = False
                    Me.cmbMonthQuarter.Visible = False
                    Me.cmbMonthQuarter.DataBindings.Clear()
                End If

                With Me.cmbMonthQuarter
                    .DataSource = dt
                    .ValueMember = "periodfrommonth"
                    .DisplayMember = "monthorquarter"
                End With
            Else
                Me.lblMonthQuarter.Visible = False
                Me.cmbMonthQuarter.Visible = False
                Me.cmbMonthQuarter.DataBindings.Clear()
            End If

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnAggregate_Click(sender As Object, e As EventArgs) Handles btnAggregate.Click

        If Me.cmbFormType.Text.Length = 0 Then
            MsgBox("Select Form Type", MsgBoxStyle.Critical, "System Message")
            Exit Sub
        ElseIf Me.cmbFinancialYear.Visible = True And Me.cmbFinancialYear.Text.Length = 0 Then
            MsgBox("Select Year", MsgBoxStyle.Critical, "System Message")
            Exit Sub
        ElseIf Me.cmbMonthQuarter.Visible = True Then
            If Me.cmbFormType.Text = "Monthly Report" And Me.cmbMonthQuarter.Text.Length = 0 Then
                MsgBox("Select Month", MsgBoxStyle.Critical, "System Message")
                Exit Sub
            ElseIf Me.cmbFormType.Text = "Quarterly Report" And Me.cmbMonthQuarter.Text.Length = 0 Then
                MsgBox("Select Quarter", MsgBoxStyle.Critical, "System Message")
                Exit Sub
            Else
                If Me.cmbFormType.SelectedIndex = 1 Then
                    Me.formSerialID = Me.cmbFormType.SelectedIndex.ToString.PadLeft(3, "0") & GetConfigArea().PadRight(21, "_") & ReturnTimePeriod(Me.cmbFormType.SelectedIndex)
                Else
                    Me.formSerialID = Me.cmbFormType.SelectedIndex.ToString.PadLeft(3, "0") & GetConfigArea().PadRight(21, "_") & ReturnTimePeriod(Me.cmbFormType.SelectedIndex)
                End If
            End If
        Else
            Me.formSerialID = Me.cmbFormType.SelectedIndex.ToString.PadLeft(3, "0") & GetConfigArea().PadRight(21, "_") & ReturnTimePeriod(Me.cmbFormType.SelectedIndex)
        End If

        If MsgBox("Are you sure you want to aggregate?" & vbCrLf & "Note: This process may take some time.", 36, "System Message") = MsgBoxResult.Yes Then

            Try
                Me.Cursor = Cursors.WaitCursor

                Call Me.InsertDistrictAggregateRecord(Me.formSerialID)
                Call Me.AggregateData(Me.formSerialID)

                MsgBox("The selected form has been successfully aggregated.", MsgBoxStyle.Information, "System Message")
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Exit Sub
        End If

    End Sub

    Private Sub FillFormTypes()

        ds = New DataSet()
        cmd = New SqlCommand()
        da = New SqlDataAdapter()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "appUspFillFormTypes"
            End With

            da.SelectCommand = cmd
            da.Fill(ds, "appUspFillFormTypes")
            dt = ds.Tables("appUspFillFormTypes")

            If dt.Rows.Count > 0 Then
                With Me.cmbFormType
                    .DataSource = dt
                    .ValueMember = "FormTypeNumber"
                    .DisplayMember = "FormNameEnglish"
                End With
            Else
            End If

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function ReturnTimePeriod(ByVal formTypeNumber As Integer) As String

        If Not formTypeNumber = 3 Then
            Me.monthName = Me.cmbMonthQuarter.Text.ToString.Substring(0, 3)
            Me.yearName = Microsoft.VisualBasic.Right(Me.cmbMonthQuarter.Text.ToString, 2)
        End If

        If formTypeNumber = 1 Then
            Return "00001" & Me.monthName & Me.yearName & ReturnEndDateOfTheMonth(Me.monthName, CInt("20" & yearName)) & Me.monthName & Me.yearName
        ElseIf formTypeNumber = 2 Then
            Return "00001" & Me.monthName & Me.yearName & ReturnEndDateOfTheMonth(Me.cmbMonthQuarter.Text.ToString.Substring(4, 3)) & Me.cmbMonthQuarter.Text.ToString.Substring(4, 3) & Me.yearName
        Else
            Return "00001Jul" & Me.cmbFinancialYear.SelectedValue.ToString.Substring(2, 2) & "30Jun" & Me.cmbFinancialYear.SelectedValue.ToString.Substring(7, 2)
        End If
    End Function

    Private Function ReturnEndDateOfTheMonth(ByVal monthName As String, Optional ByVal yearName As Integer = 2010) As Integer
        Select Case monthName
            Case "Jan", "Mar", "May", "Jul", "Aug", "Oct", "Dec"
                Return 31
            Case "Apr", "Jun", "Sep", "Nov"
                Return 30
            Case "Feb"
                If Date.IsLeapYear(yearName) Then
                    Return 29
                Else
                    Return 28
                End If
        End Select
    End Function

    Private Sub AggregateData(ByVal formSerialID As String)

        ds = New DataSet
        da = New SqlDataAdapter
        cmd = New SqlCommand
        dt = New DataTable

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "appUspDistrictAggregateData"
                .Parameters.AddWithValue("@formSerialID", formSerialID)
                .Parameters.AddWithValue("@formTypeNumber", Me.cmbFormType.SelectedIndex)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub InsertDistrictAggregateRecord(ByVal formSerialID As String)
        ds = New DataSet
        da = New SqlDataAdapter
        cmd = New SqlCommand
        dt = New DataTable

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            With cmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "appUspInsertDistrictAggregatedRecord"
                .Parameters.AddWithValue("@RecordID", Guid.NewGuid)
                .Parameters.AddWithValue("@AreaID", GetConfigArea())
                .Parameters.AddWithValue("@OfficerName", g_user_id)
                .Parameters.AddWithValue("@SubmissionDate", Date.Now)
                .Parameters.AddWithValue("@PeriodFrom", Date.Now)
                .Parameters.AddWithValue("@PeriodTo", Date.Now)
                .Parameters.AddWithValue("@FormTypeNumber", Me.cmbFormType.SelectedIndex)
                .Parameters.AddWithValue("@NewFormTypeNumber", Me.cmbFormType.SelectedIndex + 6)
                .Parameters.AddWithValue("@DateCaptured", Date.Now)
                .Parameters.AddWithValue("@CapturedByUserID", g_user_id)
                .Parameters.AddWithValue("@OrganisationID", 0)
                .Parameters.AddWithValue("@FormSerialID", formSerialID)
                .Parameters.AddWithValue("@FormSerialNumber", formSerialID)
                .Parameters.AddWithValue("@FormSerialNumberIQ", formSerialID)
                .Parameters.AddWithValue("@FormSerialNumberIA", formSerialID)
                .ExecuteNonQuery()
                .Parameters.Clear()
            End With
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

End Class
