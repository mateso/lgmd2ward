Imports System.Data.SqlClient

Public Class ctrlLookUpTable
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private dt As DataTable
    Private MonthlyLookUpTableDA As New LookupTableDataDataSetTableAdapters.appUspFillMonthlyLookUpTablesTableAdapter
    Private InsertLookUpItemsDA As New LookupTableDataDataSetTableAdapters.appUspFillLookUpTablesTypeTableAdapter

    Private lookUpStatus As Integer?
    Private lookUpID As Integer?


    Private Sub ctrlLookUpTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                .CommandText = "appUspFillLookUpFormTypes"
                ' .Parameters.AddWithValue("@IndicatorListID", cmbIndicatorList.SelectedValue)
            End With

            da.SelectCommand = cmd
            da.Fill(ds, "appUspFillLookUpFormTypes")
            dt = ds.Tables("appUspFillLookUpFormTypes")

            If dt.Rows.Count > 0 Then
                With Me.cmbLookUpForm
                    .DataSource = dt
                    .ValueMember = "FormTypeNumber"
                    .DisplayMember = "FormNameSwahili"
                End With
            Else
            End If

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
        Call HideLookUpItemControls()
    End Sub

   

    Private Sub cmbLookUpForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLookUpForm.SelectedIndexChanged
        Call HideLookUpItemControls()

        If cmbLookUpForm.SelectedIndex = 0 Then
            lblLookUpType.Visible = False
            cmbLookUpType.Visible = False

        Else
            lblLookUpType.Visible = True
            cmbLookUpType.Visible = True

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand
                da = New SqlDataAdapter
                dt = New DataTable
                ds = New LookupTableDataDataSet

                With cmd
                    .Connection = conn
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "appUspFillLookUpTables"
                    .Parameters.AddWithValue("@LookupFormType", cmbLookUpForm.SelectedValue)
                End With

                da.SelectCommand = cmd
                da.Fill(ds, "appUspFillLookUpTables")
                dt = ds.Tables("appUspFillLookUpTables")

                If dt.Rows.Count > 0 Then
                    With Me.cmbLookUpType
                        .DataSource = dt
                        .ValueMember = "LookUpType"
                        .DisplayMember = "LookUpType"
                    End With
                Else
                End If

            Catch ex As Exception
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub cmbLookUpType_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbLookUpType.SelectionChangeCommitted
        cmd = New SqlCommand()
        da = New SqlDataAdapter()
        dt = New DataTable()
        ds = New DataSet()

        Me.AppUspFillLookUpTablesTypeDataGridView.Visible = False

        If cmbLookUpType.SelectedIndex = 0 Then
            Call HideLookUpItemControls()
        Else
            Call ShowLookUpItemControls()

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Me.LookupTableDataDataSet.appUspFillLookUpTablesType.Clear()
                Me.LookupTableDataDataSet.EnforceConstraints = False

                Me.AppUspFillLookUpTablesTypeTableAdapter.Fill(Me.LookupTableDataDataSet.appUspFillLookUpTablesType, cmbLookUpForm.SelectedValue, cmbLookUpType.SelectedValue.ToString())

            Catch ex As Exception
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub ShowLookUpItemControls()
        Me.AppUspFillLookUpTablesTypeDataGridView.Visible = True
        btnLookUpSave.Visible = True
        btnLookUpCancel.Visible = True
    End Sub

    Private Sub HideLookUpItemControls()
        Me.AppUspFillLookUpTablesTypeDataGridView.Visible = False
        btnLookUpSave.Visible = False
        btnLookUpCancel.Visible = False
    End Sub

    Private Sub btnLookUpSave_Click(sender As Object, e As EventArgs) Handles btnLookUpSave.Click
        Try
            For Each row As DataGridViewRow In Me.AppUspFillLookUpTablesTypeDataGridView.Rows

                If (Not row.IsNewRow) Then
                    '  Me.lookUpStatus = IIf(IsDBNull(row.Cells(5).Value), 0, 0)
                    Me.lookUpStatus = IIf(Val(row.Cells(5).Value.ToString) = 0.0, 0, 1)
                    Me.lookUpID = Val(row.Cells(0).Value.ToString)
                    Me.InsertLookUpItemsDA.appUspInsertLookupTableItems(Me.lookUpID, Me.cmbLookUpForm.SelectedValue, _
                                                                        cmbLookUpType.SelectedValue.ToString(), _
                                                                        row.Cells(1).Value.ToString(), _
                                                                        row.Cells(2).Value.ToString(), _
                                                                      Convert.ToBoolean(Me.lookUpStatus))
                End If
            Next
            MsgBox(" Saved successfully .", MsgBoxStyle.Information, "System Message")
            If MsgBoxResult.Ok Then
                Me.AppUspFillLookUpTablesTypeTableAdapter.Fill(Me.LookupTableDataDataSet.appUspFillLookUpTablesType, cmbLookUpForm.SelectedValue, cmbLookUpType.SelectedValue.ToString())
                Me.AppUspFillLookUpTablesTypeDataGridView.Refresh()
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub btnLookUpCancel_Click(sender As Object, e As EventArgs) Handles btnLookUpCancel.Click

    End Sub
End Class
