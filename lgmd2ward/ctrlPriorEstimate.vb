Imports System.Data.SqlClient

Public Class ctrlPriorEstimate

    Private ds As DataSet
    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private cmdBldr As SqlCommandBuilder
    Private dt As DataTable
    Private PriorEstimateDA As New DistrictAggregatedDataSetTableAdapters.PriorEstimateTableAdapter
    Private priorEstimateID As Double?
    Private estimatedValue As Double?
    Private periodFromFrom As Date
    Private periodToTo As Date

    Private Sub ctrlPriorEstimate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FillPriorEstimatesIndicators()
    End Sub

    Private Sub cmbIndicatorList_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbIndicatorList.SelectionChangeCommitted

        ds = New DataSet()
        cmd = New SqlCommand()
        da = New SqlDataAdapter()

        Me.AppUspFillPriorEstimatesDataGridView.Visible = False
        btnSave.Visible = False
        btnPrevious.Visible = False
        btnNext.Visible = False

        If Me.cmbIndicatorList.SelectedIndex = 0 Then
            Me.lblListItem.Visible = False
            Me.cmbListItem.Visible = False
        Else
            Me.lblListItem.Visible = True
            Me.cmbListItem.Visible = True

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                With cmd
                    .Connection = conn
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "appUspFillPriorEstimatesIndicatorListItem"
                    .Parameters.AddWithValue("@IndicatorListID", cmbIndicatorList.SelectedValue)
                End With

                da.SelectCommand = cmd
                da.Fill(ds, "appUspFillPriorEstimatesIndicatorListItem")
                dt = ds.Tables("appUspFillPriorEstimatesIndicatorListItem")

                If dt.Rows.Count > 0 Then
                    With Me.cmbListItem
                        .DataSource = dt
                        .ValueMember = "ListID"
                        .DisplayMember = "ListItemSw"
                    End With
                Else
                End If

            Catch ex As Exception
            Finally
                conn.Close()
            End Try  
        End If
    End Sub

    Private Sub cmbListItem_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbListItem.SelectionChangeCommitted

        If Me.cmbListItem.SelectedIndex = 0 Then
            Me.AppUspFillPriorEstimatesDataGridView.Visible = False
            btnSave.Visible = False
            btnPrevious.Visible = False
            btnNext.Visible = False
        Else
            Me.AppUspFillPriorEstimatesDataGridView.Visible = True
            btnSave.Visible = True
            btnPrevious.Visible = True
            btnNext.Visible = True
            Try
                Me.DistrictAggregatedDataSet.appUspFillPriorEstimates.Clear()
                Me.DistrictAggregatedDataSet.EnforceConstraints = False

                If Month(Date.Now) > 6 Then
                    Me.periodFromFrom = CDate("01/" & "07/" & Format(Date.Now, "yyyy"))
                    Me.periodToTo = CDate("30/" & "06/" & CStr(Year(Me.periodFromFrom) + 1))
                Else
                    Me.periodFromFrom = CDate("01/" & "07/" & CStr(Year(Date.Now) - 1))
                    Me.periodToTo = CDate("30/" & "06/" & CStr(Year(Date.Now)))
                End If

                Me.AppUspFillPriorEstimatesTableAdapter.Fill(Me.DistrictAggregatedDataSet.appUspFillPriorEstimates, _
                                                             GetConfigArea(), _
                                                             Me.cmbIndicatorList.SelectedIndex, _
                                                             Me.cmbListItem.SelectedValue, _
                                                             Me.periodFromFrom, _
                                                             Me.periodToTo)
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            Finally
                'Me.DistrictAggregatedDataSet.EnforceConstraints = True
            End Try
        End If
    End Sub

    Private Sub FillPriorEstimatesIndicators()
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
                .CommandText = "appUspFillPriorEstimatesIndicators"
            End With

            da.SelectCommand = cmd
            da.Fill(ds, "appUspFillPriorEstimatesIndicators")
            dt = ds.Tables("appUspFillPriorEstimatesIndicators")

            If dt.Rows.Count > 0 Then
                With Me.cmbIndicatorList
                    .DataSource = dt
                    .ValueMember = "IndicatorListID"
                    .DisplayMember = "IndicatorName"
                End With
            Else
            End If

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Month(Date.Now) > 6 Then
            Me.periodFromFrom = CDate("01/" & "07/" & Format(Date.Now, "yyyy"))
            Me.periodToTo = CDate("30/" & "06/" & CStr(Year(Me.periodFromFrom) + 1))
        Else
            Me.periodFromFrom = CDate("01/" & "07/" & CStr(Year(Date.Now) - 1))
            Me.periodToTo = CDate("30/" & "06/" & CStr(Year(Date.Now)))
        End If

        Try
            For Each row As DataGridViewRow In Me.AppUspFillPriorEstimatesDataGridView.Rows
                Me.estimatedValue = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                Me.priorEstimateID = Val(row.Cells(3).Value.ToString)
                Me.PriorEstimateDA.appUspInsertPriorEstimateValues(Me.priorEstimateID, _
                                                                   Me.cmbIndicatorList.SelectedValue, _
                                                                   Me.cmbListItem.SelectedValue, _
                                                                   row.Cells(0).Value.ToString, _
                                                                   Me.estimatedValue, _
                                                                   Me.periodFromFrom, _
                                                                   Me.periodToTo)
            Next

            MsgBox(" Saved successfully .", MsgBoxStyle.Information, "System Message")
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        Finally
            'Me.DistrictAggregatedDataSet.EnforceConstraints = True
        End Try
    End Sub

End Class
