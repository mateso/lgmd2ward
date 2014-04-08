Public Class ctrlWard03Page03

    Private TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Private ImplementsDA As New AnnuallyDataDataSetTableAdapters.HandOperatedImplements03TableAdapter
    Private ProcessingMachineListDA As New LGMDdataDataSetTableAdapters.ProcessingMachinesListTableAdapter
    Private ProcessingMachineDA As New LGMDdataDataSetTableAdapters.ProcessingMachines03TableAdapter
    Private numberOfImplements As Integer?
    Private numberWorkingIndividually As Integer?
    Private numberWorkingGroup As Integer?
    Private numberNotWorkingIndividually As Integer?
    Private numberNotWorkingGroup As Integer?

    Private Sub ctrlWard03Page03_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.ImplementsDA.Fill(Me.AnnuallyDataDataSet.HandOperatedImplements03)
        Me.AppUspAnnualFillImplementsTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImplements, g_RecordID)

        Try
            If Me.AnnuallyDataDataSet.appUspAnnualFillImplements.Rows.Count = 0 Then
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType = 'HandOperatedImplements03' AND ListItemStatus=0")
                    Me.ImplementsDA.Insert(Guid.NewGuid, row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspAnnualFillImplementsTableAdapter.Fill(Me.AnnuallyDataDataSet.appUspAnnualFillImplements, g_RecordID)
            End If
        Catch ex As Exception
        End Try

        Me.ProcessingMachineDA.Fill(Me.LGMDdataDataSet.ProcessingMachines03)
        Me.AppUspAnnualFillProcessingMachinesTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillProcessingMachines, g_RecordID)

        If Me.LGMDdataDataSet.appUspAnnualFillProcessingMachines.Rows.Count = 0 Then
            For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='ProcessingMachines03' AND ListItemStatus=0")
                Me.ProcessingMachineDA.Insert(Guid.NewGuid(), row.Item(0), g_RecordID, g_FormSerialNumber)
            Next
            Me.AppUspAnnualFillProcessingMachinesTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillProcessingMachines, g_RecordID)
        End If

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub DataGridView4_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.RowEnter
        If Me.DataGridView4.Rows(e.RowIndex).IsNewRow Then
            Me.DataGridView4.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.DataGridView4.Rows(e.RowIndex).Cells(3).Value = 1
            Me.DataGridView4.Rows(e.RowIndex).Cells(4).Value = Guid.NewGuid()
            Me.DataGridView4.Rows(e.RowIndex).Cells(7).Value = g_RecordID
        End If
    End Sub

    Private Sub appUspAnnualFillProcessingMachineDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles appUspAnnualFillProcessingMachineDataGridView.RowEnter
        If Me.appUspAnnualFillProcessingMachineDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.appUspAnnualFillProcessingMachineDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.appUspAnnualFillProcessingMachineDataGridView.Rows(e.RowIndex).Cells(2).Value = 1
            Me.appUspAnnualFillProcessingMachineDataGridView.Rows(e.RowIndex).Cells(3).Value = Guid.NewGuid()
            Me.appUspAnnualFillProcessingMachineDataGridView.Rows(e.RowIndex).Cells(10).Value = g_RecordID
        End If
    End Sub

    Private Sub DataGridView4_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView4.UserDeletingRow
        If Me.DataGridView4.CurrentRow.Index < 5 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.DataGridView4.SelectedRows
                    Me.AppUspAnnualFillImplementsTableAdapter.appUspAnnualDeleteImplements(row.Cells(0).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub appUspAnnualFillProcessingMachineDataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles appUspAnnualFillProcessingMachineDataGridView.UserDeletingRow
        If Me.appUspAnnualFillProcessingMachineDataGridView.CurrentRow.Index < 16 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.appUspAnnualFillProcessingMachineDataGridView.SelectedRows
                    Me.ProcessingMachineDA.appUspAnnualDeleteProcessingMachine(row.Cells(4).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub DataGridView4_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView4.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub appUspAnnualFillProcessingMachineDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles appUspAnnualFillProcessingMachineDataGridView.DataError
        Call DGVNumericError(e, sender)
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

            For Each row As DataGridViewRow In Me.DataGridView4.Rows
                Try
                    If row.IsNewRow Then
                    Else
                        numberOfImplements = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        Me.AppUspAnnualFillImplementsTableAdapter.appUspAnnualUpdateImplements(row.Cells(0).Value, _
                                                                                               row.Cells(1).Value.ToString, _
                                                                                               row.Cells(2).Value.ToString, _
                                                                                               Val(row.Cells(3).Value.ToString()), _
                                                                                               row.Cells(4).Value, _
                                                                                               numberOfImplements, _
                                                                                               row.Cells(7).Value)

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            Next


            For Each row As DataGridViewRow In Me.appUspAnnualFillProcessingMachineDataGridView.Rows
                Try
                    If row.IsNewRow Then
                    Else
                        numberWorkingIndividually = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        numberWorkingGroup = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        numberNotWorkingIndividually = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        numberNotWorkingGroup = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        Me.ProcessingMachineDA.appUspAnnualUpdateProcessingMachine(row.Cells(0).Value, _
                                                                           row.Cells(1).Value.ToString(), _
                                                                           Val(row.Cells(2).Value.ToString()), _
                                                                           row.Cells(3).Value, _
                                                                           numberWorkingIndividually, _
                                                                           numberWorkingGroup, _
                                                                           numberNotWorkingIndividually, _
                                                                           numberNotWorkingGroup, _
                                                                           row.Cells(9).Value.ToString(), _
                                                                           row.Cells(10).Value)
                    End If
                Catch ex As Exception
                End Try
            Next

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub appUspAnnualFillProcessingMachineDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles appUspAnnualFillProcessingMachineDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub DataGridView4_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
