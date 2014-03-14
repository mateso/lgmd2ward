Public Class ctrlWard03Page06

    Dim PestcideListDA As New AnnuallyDataDataSetTableAdapters.PestcideListTableAdapter
    Dim PestcideDA As New AnnuallyDataDataSetTableAdapters.Pestcide03TableAdapter
    Private usagePerYear As Double?

    Private Sub ctrlWard03Page06_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.AppUspLookupUnitsTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupUnits)
        Me.PestcideListDA.Fill(Me.AnnuallyDataDataSet.PestcideList)
        Me.PestcideDA.Fill(Me.AnnuallyDataDataSet.Pestcide03)

        Me.AppUspAnnualFillPestcideWaduduTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideWadudu, g_RecordID)
        Me.AppUspAnnualFillPestcideFangasiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideFangasi, g_RecordID)
        Me.AppUspAnnualFillPestcideMaguguTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideMagugu, g_RecordID)
        Me.AppUspAnnualFillPestcidePanyaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcidePanya, g_RecordID)
        Me.AppUspAnnualFillPestcideNdegeTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideNdege, g_RecordID)

        If Me.AnnuallyDataDataSet.appUspAnnualFillPestcideWadudu.Rows.Count = 0 Then
            For i As Integer = 1 To 5
                For Each row As DataRow In Me.AnnuallyDataDataSet.PestcideList.Select("PestcideStatus='0'")
                    Me.PestcideDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
            Next
            Me.AppUspAnnualFillPestcideWaduduTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideWadudu, g_RecordID)
            Me.AppUspAnnualFillPestcideFangasiTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideFangasi, g_RecordID)
            Me.AppUspAnnualFillPestcideMaguguTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideMagugu, g_RecordID)
            Me.AppUspAnnualFillPestcidePanyaTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcidePanya, g_RecordID)
            Me.AppUspAnnualFillPestcideNdegeTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideNdege, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            'Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            Me.AppUspAnnualFillPestcideWaduduTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideWadudu)
            Me.AppUspAnnualFillPestcideFangasiTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideFangasi)
            Me.AppUspAnnualFillPestcideMaguguTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillPestcideMagugu)
            Me.AppUspAnnualFillPestcidePanyaTableAdapter.Update(Me.AnnuallyDataDataSet.appUspAnnualFillPestcidePanya)

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualFillPestcideNdegeDataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        usagePerYear = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        Me.PestcideDA.appUspAnnualUpdatePesticide(row.Cells(0).Value, _
                                                                  row.Cells(1).Value.ToString(), _
                                                                  Val(row.Cells(2).Value.ToString()), _
                                                                  row.Cells(3).Value, _
                                                                  row.Cells(5).Value.ToString(), _
                                                                  row.Cells(6).Value.ToString(), _
                                                                  usagePerYear, _
                                                                  row.Cells(8).Value.ToString(), _
                                                                  row.Cells(9).Value)
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspAnnualFillPestcideNdegeDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualFillPestcideNdegeDataGridView.RowEnter
        If Me.AppUspAnnualFillPestcideNdegeDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.AppUspAnnualFillPestcideNdegeDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.AppUspAnnualFillPestcideNdegeDataGridView.Rows(e.RowIndex).Cells(2).Value = 1
            Me.AppUspAnnualFillPestcideNdegeDataGridView.Rows(e.RowIndex).Cells(3).Value = Guid.NewGuid
            Me.AppUspAnnualFillPestcideNdegeDataGridView.Rows(e.RowIndex).Cells(9).Value = g_RecordID
        End If
    End Sub

    Private Sub AppUspAnnualFillPestcideNdegeDataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspAnnualFillPestcideNdegeDataGridView.UserDeletingRow
        If Me.AppUspAnnualFillPestcideNdegeDataGridView.CurrentRow.Index < 5 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspAnnualFillPestcideNdegeDataGridView.SelectedRows
                    Me.PestcideDA.appUspAnnualDeletePestcide(row.Cells(4).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub AppUspAnnualFillPestcideWaduduDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillPestcideWaduduDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillPestcideFangasiDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillPestcideFangasiDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillPestcideMaguguDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillPestcideMaguguDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillPestcidePanyaDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillPestcidePanyaDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualFillPestcideNdegeDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualFillPestcideNdegeDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub
End Class
