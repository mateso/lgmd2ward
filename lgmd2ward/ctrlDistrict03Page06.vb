Public Class ctrlDistrict03Page06

    Dim TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Dim LivestockInfraDA As New LGMDdataDataSetTableAdapters.LivestockInfrastructure05TableAdapter
    Dim DistrictInfoDA As New LGMDdataDataSetTableAdapters.DistrictInfo05TableAdapter
    Private numberWorking As Integer?
    Private numberNotWorking As Integer?
    Private numberRequired As Integer?
    Private numberRegistered As Integer?

    Private Sub ctrlDistrict03Page06_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        'Me.AppUspDistrictAnnualFillLivestockInfrastructureTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructure, g_RecordID)
        'Me.AppUspDistrictAnnualFillLivestockInfrastructureFirstPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureFirstPart, g_RecordID)
        Me.AppUspDistrictAnnualFillLivestockInfrastructureSecondPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureSecondPart, g_RecordID)
        Me.AppUspDistrictAnnualFillLivestockInfrastructureThirdPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureThirdPart, g_RecordID)
        Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureFourthPart, g_RecordID)
        If Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureSecondPart.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='LivestockInfrastructure05'")
                Me.LivestockInfraDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            'Me.AppUspDistrictAnnualFillLivestockInfrastructureTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructure, g_RecordID)
            'Me.AppUspDistrictAnnualFillLivestockInfrastructureFirstPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureFirstPart, g_RecordID)
            Me.AppUspDistrictAnnualFillLivestockInfrastructureSecondPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureSecondPart, g_RecordID)
            Me.AppUspDistrictAnnualFillLivestockInfrastructureThirdPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureThirdPart, g_RecordID)
            Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartTableAdapter.Fill(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureFourthPart, g_RecordID)
        End If

        Me.DistrictInfoDA.Fill(Me.LGMDdataDataSet.DistrictInfo05, g_RecordID)

        Call LabelTranslation(Me)
        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")
        PopulateHeaderControls(Me)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call SaveFigures(Me)
            'Me.AppUspDistrictAnnualFillLivestockInfrastructureTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructure)
            'Me.AppUspDistrictAnnualFillLivestockInfrastructureFirstPartTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureFirstPart)
            Me.AppUspDistrictAnnualFillLivestockInfrastructureSecondPartTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureSecondPart)
            Me.AppUspDistrictAnnualFillLivestockInfrastructureThirdPartTableAdapter.Update(Me.LGMDdataDataSet.appUspDistrictAnnualFillLivestockInfrastructureThirdPart)
            For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.Rows
                Try
                    If row.IsNewRow Then
                    Else
                        numberWorking = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        numberNotWorking = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        numberRequired = CheckIfIsNullOrEmptyDGVCell(row.Cells(9))
                        numberRegistered = CheckIfIsNullOrEmptyDGVCell(row.Cells(10))
                        Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartTableAdapter.appUspDistrictAnnualUpdateLivestockInfrastructure(row.Cells(0).Value, _
                                                                                                                                               row.Cells(1).Value.ToString, _
                                                                                                                                               row.Cells(2).Value.ToString, _
                                                                                                                                               row.Cells(3).Value.ToString, _
                                                                                                                                               row.Cells(4).Value.ToString, _
                                                                                                                                               row.Cells(5).Value, _
                                                                                                                                               numberWorking, _
                                                                                                                                               numberNotWorking, _
                                                                                                                                               numberRequired, _
                                                                                                                                               numberRegistered, _
                                                                                                                                               row.Cells(11).Value.ToString, _
                                                                                                                                               row.Cells(12).Value)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            Next

            Me.DistrictInfoDA.appUspDistrictAnnualUpdateDistrictInfoPageFive(txtNumberofResourceCentres.Text, _
                                                                             g_RecordID)

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub txtNumberofResourceCentres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberofResourceCentres.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then

            MessageBox.Show("Please enter numbers only", "Stop Prompt", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Handled = True

        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureFirstPartDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureSecondPartDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillLivestockInfrastructureSecondPartDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureThirdPartDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillLivestockInfrastructureThirdPartDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.RowEnter
        If Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.Rows(e.RowIndex).IsNewRow Then
            Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.Rows(e.RowIndex).Cells(3).Value = "LivestockInfrastructure05"
            Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.Rows(e.RowIndex).Cells(4).Value = 1
            Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.Rows(e.RowIndex).Cells(5).Value = Guid.NewGuid
            Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.Rows(e.RowIndex).Cells(12).Value = g_RecordID
        End If
    End Sub

    Private Sub AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.UserDeletingRow
        If Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.CurrentRow.Index < 6 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartDataGridView.SelectedRows
                    Me.AppUspDistrictAnnualFillLivestockInfrastructureFourthPartTableAdapter.appUspDistrictAnnualDeleteLivestockInfrastructure(row.Cells(6).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
