Public Class ctrlDistrict03Page04

    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim PlanningCommiteeDA As New LGMDdataDataSetTableAdapters.PlanningCommitee05TableAdapter

    Private Sub ctrlDistrict03Page04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ExtensionServiceProviders05TableAdapter.Fill(Me.LGMDdataDataSet.ExtensionServiceProviders05, g_RecordID)

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.AppUspDistrictAnnualFillPlanningCommiteeTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillPlanningCommitee, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillPlanningCommitee.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='PlanningCommitee05'")
                Me.PlanningCommiteeDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspDistrictAnnualFillPlanningCommiteeTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillPlanningCommitee, g_RecordID)
        End If
        Me.AppUspLookupTypeOfOwnershipTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupTypeOfOwnership)
        Me.LivestockPopulation05TableAdapter.Fill(Me.LGMDdataDataSet.LivestockPopulation05, g_RecordID)

        Call LabelTranslation(Me)
        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")
        PopulateHeaderControls(Me)
    End Sub

    Private Sub ExtensionServiceProviders05DataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ExtensionServiceProviders05DataGridView.RowEnter
        If Me.ExtensionServiceProviders05DataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.ExtensionServiceProviders05DataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.ExtensionServiceProviders05DataGridView.Rows(e.RowIndex).Cells(5).Value = g_RecordID
        End If
    End Sub

    Private Sub LivestockPopulation05DataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles LivestockPopulation05DataGridView.RowEnter
        If Me.LivestockPopulation05DataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.LivestockPopulation05DataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.LivestockPopulation05DataGridView.Rows(e.RowIndex).Cells(11).Value = g_RecordID
        End If
    End Sub

    Private Sub ExtensionServiceProviders05DataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles ExtensionServiceProviders05DataGridView.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.ExtensionServiceProviders05DataGridView.Rows
                Me.ExtensionServiceProviders05TableAdapter.appUspDistrictAnnualDeleteExtensionServiceProvider(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub LivestockPopulation05DataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles LivestockPopulation05DataGridView.UserDeletingRow
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.LivestockPopulation05DataGridView.Rows
                Me.LivestockPopulation05TableAdapter.appUspDistrictAnnualDeleteLivestockPopulation(row.Cells(0).Value)
            Next
        Else
            e.Cancel = True
            MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)
            Try
                For Each row As DataGridViewRow In Me.ExtensionServiceProviders05DataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        Me.ExtensionServiceProviders05TableAdapter.appUspDistrictAnnualUpdateExtensionServiceProviders(row.Cells(0).Value, _
                                                                                                                       row.Cells(1).Value.ToString, _
                                                                                                                       row.Cells(2).Value.ToString, _
                                                                                                                       row.Cells(3).Value.ToString, _
                                                                                                                       Val(row.Cells(4).Value.ToString()), _
                                                                                                                       row.Cells(5).Value)

                    End If
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.LivestockPopulation05DataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        Me.LivestockPopulation05TableAdapter.appUspDistrictAnnualUpdateLivestockPopulation(row.Cells(0).Value, _
                                                                                                           row.Cells(1).Value.ToString(), _
                                                                                                           row.Cells(2).Value.ToString(), _
                                                                                                           row.Cells(3).Value.ToString(), _
                                                                                                           Val(row.Cells(4).Value.ToString()), _
                                                                                                           Val(row.Cells(5).Value.ToString()), _
                                                                                                           Val(row.Cells(6).Value.ToString()), _
                                                                                                           Val(row.Cells(7).Value.ToString()), _
                                                                                                           Val(row.Cells(8).Value.ToString()), _
                                                                                                           Val(row.Cells(9).Value.ToString()), _
                                                                                                           row.Cells(10).Value.ToString(), _
                                                                                                           row.Cells(11).Value)



                    End If
                Next
            Catch ex As Exception
            End Try

            Me.AppUspDistrictAnnualFillPlanningCommiteeTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillPlanningCommitee)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub ExtensionServiceProviders05DataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles ExtensionServiceProviders05DataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillPlanningCommiteeDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillPlanningCommiteeDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub LivestockPopulation05DataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles LivestockPopulation05DataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub ExtensionServiceProviders05DataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ExtensionServiceProviders05DataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillPlanningCommiteeDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspDistrictAnnualFillPlanningCommiteeDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub LivestockPopulation05DataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles LivestockPopulation05DataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillPlanningCommiteeDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillPlanningCommiteeDataGridView.CellValidated
        Dim total As Integer = 0
        For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillPlanningCommiteeDataGridView.Rows
            If (IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7)))) Then
            Else
                total += row.Cells(7).Value
            End If
        Next

        Try
            For j As Integer = 0 To CInt(Me.AppUspDistrictAnnualFillPlanningCommiteeDataGridView.RowCount - 1)
                Me.AppUspDistrictAnnualFillPlanningCommiteeDataGridView.Rows(j).Cells(8).Value = Math.Round(((Me.AppUspDistrictAnnualFillPlanningCommiteeDataGridView.Rows(j).Cells(7).Value) / total) * 100, 2)
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class
