Public Class ctrlWard03Page05

    Private TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Private FertilizerDA As New LGMDdataDataSetTableAdapters.Fertilizer03TableAdapter
    Private annualNeeds As Double?
    Private annualUsage As Double?

    Private Sub ctrlWard03Page05_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.FertilizerDA.Fill(Me.LGMDdataDataSet.Fertilizer03)
        Me.AppUspAnnualFillFertilizerTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillFertilizer, g_RecordID)

        If Me.LGMDdataDataSet.appUspAnnualFillFertilizer.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='Fertilizer03' AND ListItemStatus=0")
                Me.FertilizerDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspAnnualFillFertilizerTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillFertilizer, g_RecordID)
        End If

        Me.AppUspLookupUnitsTableAdapter.Fill(Me.LookupTableDataDataSet.appUspLookupUnits)

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub appUspAnnualFillFertilizerDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles appUspAnnualFillFertilizerDataGridView.RowEnter
        If Me.appUspAnnualFillFertilizerDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.appUspAnnualFillFertilizerDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.appUspAnnualFillFertilizerDataGridView.Rows(e.RowIndex).Cells(2).Value = 1
            Me.appUspAnnualFillFertilizerDataGridView.Rows(e.RowIndex).Cells(3).Value = Guid.NewGuid
            Me.appUspAnnualFillFertilizerDataGridView.Rows(e.RowIndex).Cells(8).Value = g_RecordID
        End If
    End Sub

    Private Sub appUspAnnualFillFertilizerDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles appUspAnnualFillFertilizerDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub appUspAnnualFillFertilizerDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles appUspAnnualFillFertilizerDataGridView.UserDeletingRow
        If Me.appUspAnnualFillFertilizerDataGridView.CurrentRow.Index < 12 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.appUspAnnualFillFertilizerDataGridView.SelectedRows
                    Me.FertilizerDA.appUspAnnualDeleteFertilizer(row.Cells(4).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
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

            Try
                For Each row As DataGridViewRow In Me.appUspAnnualFillFertilizerDataGridView.Rows
                    If row.IsNewRow() Then
                    Else
                        annualNeeds = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        annualUsage = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        Me.FertilizerDA.appUspAnnualUpdateFertilizer(row.Cells(0).Value, _
                                                                     row.Cells(1).Value.ToString(), _
                                                                     Val(row.Cells(2).Value.ToString()), _
                                                                     row.Cells(3).Value, _
                                                                     annualNeeds, _
                                                                     annualUsage, _
                                                                     row.Cells(7).Value.ToString(), _
                                                                     row.Cells(8).Value)
                    End If
                Next
            Catch ex As Exception
            End Try

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub appUspAnnualFillFertilizerDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles appUspAnnualFillFertilizerDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
