Public Class ctrlWard03Page02

    Private TwoDListDA As New LGMDdataDataSetTableAdapters.TwoDListTableAdapter
    Private MachinesDA As New LGMDdataDataSetTableAdapters.Machines03TableAdapter
    Private DrawnListDA As New LGMDdataDataSetTableAdapters.DrawnListTableAdapter
    Private MachineryDrawnDA As New LGMDdataDataSetTableAdapters.MachineryDrawn03TableAdapter
    Private AnimalDrawnDA As New LGMDdataDataSetTableAdapters.AnimalDrawn03TableAdapter
    Private machineWorkingIndividual As Integer?
    Private machineNotWorkingIndividual As Integer?
    Private machineWorkingGroup As Integer?
    Private machineNotWorkingGroup As Integer?
    Private machineryDrawnWorking As Integer?
    Private machineryDrawnNotWorking As Integer?
    Private animalDrawnWorking As Integer?
    Private animalDrawnNotWorking As Integer?

    Private Sub ctrlWard03Page02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TwoDListDA.Fill(Me.LGMDdataDataSet.TwoDList)
        Me.MachinesDA.Fill(Me.LGMDdataDataSet.Machines03)
        Me.AppUspAnnualFillMachinesTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillMachines, g_RecordID)
        Try
            If Me.LGMDdataDataSet.appUspAnnualFillMachines.Rows.Count = 0 Then
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType='Machines03' AND ListItemStatus=0")
                    Me.MachinesDA.Insert(Guid.NewGuid(), row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspAnnualFillMachinesTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillMachines, g_RecordID)
            End If
        Catch ex As Exception
        End Try

        Me.MachineryDrawnDA.Fill(Me.LGMDdataDataSet.MachineryDrawn03)
        Me.AppUspAnnualFillMachineryDrawnTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillMachineryDrawn, g_RecordID)
        Try
            If Me.LGMDdataDataSet.appUspAnnualFillMachineryDrawn.Rows.Count = 0 Then
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType LIKE '%MachineryDrawn%' AND ListItemStatus=0")
                    Me.MachineryDrawnDA.Insert(Guid.NewGuid(), row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspAnnualFillMachineryDrawnTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillMachineryDrawn, g_RecordID)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

        Me.AnimalDrawnDA.Fill(Me.LGMDdataDataSet.AnimalDrawn03)
        Me.AppUspAnnualFillAnimalDrawnTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillAnimalDrawn, g_RecordID)
        Try
            If Me.LGMDdataDataSet.appUspAnnualFillAnimalDrawn.Rows.Count = 0 Then
                For Each row As DataRow In Me.LGMDdataDataSet.TwoDList.Select("ListItemType LIKE '%AnimalDrawn%' AND ListItemStatus=0")
                    Me.AnimalDrawnDA.Insert(Guid.NewGuid(), row.Item(0), g_RecordID, g_FormSerialNumber)
                Next
                Me.AppUspAnnualFillAnimalDrawnTableAdapter.Fill(Me.LGMDdataDataSet.appUspAnnualFillAnimalDrawn, g_RecordID)
            End If
        Catch ex As Exception
        End Try

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub appUspAnnualFillMachinesDataGridView_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles appUspAnnualFillMachinesDataGridView.RowEnter
        If Me.appUspAnnualFillMachinesDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.appUspAnnualFillMachinesDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.appUspAnnualFillMachinesDataGridView.Rows(e.RowIndex).Cells(2).Value = 1
            Me.appUspAnnualFillMachinesDataGridView.Rows(e.RowIndex).Cells(3).Value = Guid.NewGuid()
            Me.appUspAnnualFillMachinesDataGridView.Rows(e.RowIndex).Cells(10).Value = g_RecordID
        End If
    End Sub

    Private Sub appUspAnnualFillMachineryDrawnDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles appUspAnnualFillMachineryDrawnDataGridView.RowEnter
        If Me.appUspAnnualFillMachineryDrawnDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.appUspAnnualFillMachineryDrawnDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.appUspAnnualFillMachineryDrawnDataGridView.Rows(e.RowIndex).Cells(2).Value = "Machine"
            Me.appUspAnnualFillMachineryDrawnDataGridView.Rows(e.RowIndex).Cells(3).Value = 1
            Me.appUspAnnualFillMachineryDrawnDataGridView.Rows(e.RowIndex).Cells(4).Value = Guid.NewGuid()
            Me.appUspAnnualFillMachineryDrawnDataGridView.Rows(e.RowIndex).Cells(8).Value = g_RecordID
        End If
    End Sub

    Private Sub appUspAnnualFillAnimalDrawnDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles appUspAnnualFillAnimalDrawnDataGridView.RowEnter
        If Me.appUspAnnualFillAnimalDrawnDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.appUspAnnualFillAnimalDrawnDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.appUspAnnualFillAnimalDrawnDataGridView.Rows(e.RowIndex).Cells(2).Value = "Animal"
            Me.appUspAnnualFillAnimalDrawnDataGridView.Rows(e.RowIndex).Cells(3).Value = 1
            Me.appUspAnnualFillAnimalDrawnDataGridView.Rows(e.RowIndex).Cells(4).Value = Guid.NewGuid()
            Me.appUspAnnualFillAnimalDrawnDataGridView.Rows(e.RowIndex).Cells(8).Value = g_RecordID
        End If
    End Sub

    Private Sub appUspAnnualFillMachinesDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles appUspAnnualFillMachinesDataGridView.UserDeletingRow
        If Me.appUspAnnualFillMachinesDataGridView.CurrentRow.Index < 13 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.appUspAnnualFillMachinesDataGridView.SelectedRows
                    Me.MachinesDA.appUspAnnualDeleteMachine(row.Cells(4).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub appUspAnnualFillMachineryDrawnDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles appUspAnnualFillMachineryDrawnDataGridView.UserDeletingRow
        If Me.appUspAnnualFillMachineryDrawnDataGridView.CurrentRow.Index < 9 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.appUspAnnualFillMachineryDrawnDataGridView.SelectedRows
                    Me.MachineryDrawnDA.appUspAnnualDeleteMachineryDrawn(row.Cells(5).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub appUspAnnualFillAnimalDrawnDataGridView_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles appUspAnnualFillAnimalDrawnDataGridView.UserDeletingRow
        If Me.appUspAnnualFillAnimalDrawnDataGridView.CurrentRow.Index < 8 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.appUspAnnualFillAnimalDrawnDataGridView.SelectedRows
                    Me.AnimalDrawnDA.appUspAnnualDeleteAnimalDrawn(row.Cells(5).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub appUspAnnualFillMachinesDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles appUspAnnualFillMachinesDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub appUspAnnualFillMachineryDrawnDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles appUspAnnualFillMachineryDrawnDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub appUspAnnualFillAnimalDrawnDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles appUspAnnualFillAnimalDrawnDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub DataGridView4_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If g_form_mode = "Add" Then
            Call SaveForm()
            g_form_mode = "Edit"
        End If

        If g_form_mode = "Edit" Then
            'Call DeleteFigures(Me, ProduceFormSerialNumber, FigureIDCriteria)
            'Call SaveFigures(Me)
            'Call SaveAnswers(Me)

            For Each row As DataGridViewRow In Me.appUspAnnualFillMachinesDataGridView.Rows
                Try
                    If row.IsNewRow() Then
                    Else
                        machineWorkingIndividual = CheckIfIsNullOrEmptyDGVCell(row.Cells(5))
                        machineNotWorkingIndividual = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        machineWorkingGroup = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        machineNotWorkingGroup = CheckIfIsNullOrEmptyDGVCell(row.Cells(8))
                        Me.MachinesDA.appUspAnnualUpdateMachines(row.Cells(0).Value, _
                                                                 row.Cells(1).Value.ToString(), _
                                                                 Val(row.Cells(2).Value.ToString()), _
                                                                 row.Cells(3).Value, _
                                                                 machineWorkingIndividual, _
                                                                 machineNotWorkingIndividual, _
                                                                 machineWorkingGroup, _
                                                                 machineNotWorkingGroup, _
                                                                 row.Cells(9).Value.ToString(), _
                                                                 row.Cells(10).Value)
                    End If
                Catch ex As Exception
                End Try
            Next

            For Each row As DataGridViewRow In Me.appUspAnnualFillMachineryDrawnDataGridView.Rows
                Try
                    If row.IsNewRow() Then
                    Else
                        machineryDrawnWorking = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        machineryDrawnNotWorking = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        Me.MachineryDrawnDA.appUspAnnualUpdateMachineryDrawn(row.Cells(0).Value, _
                                                                             row.Cells(1).Value.ToString(), _
                                                                             row.Cells(2).Value.ToString(), _
                                                                             Val(row.Cells(3).Value.ToString()), _
                                                                             row.Cells(4).Value, _
                                                                             machineryDrawnWorking, _
                                                                             machineryDrawnNotWorking, _
                                                                             row.Cells(8).Value)
                    End If
                Catch ex As Exception
                End Try
            Next

            For Each row As DataGridViewRow In Me.appUspAnnualFillAnimalDrawnDataGridView.Rows
                Try
                    If row.IsNewRow() Then
                    Else
                        animalDrawnWorking = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        animalDrawnNotWorking = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        Me.AnimalDrawnDA.appUspAnnualUpdateAnimalDrawn(row.Cells(0).Value, _
                                                                       row.Cells(1).Value.ToString(), _
                                                                       row.Cells(2).Value.ToString(), _
                                                                       Val(row.Cells(3).Value.ToString()), _
                                                                       row.Cells(4).Value, _
                                                                       animalDrawnWorking, _
                                                                       animalDrawnNotWorking, _
                                                                       row.Cells(8).Value)
                    End If
                Catch ex As Exception
                End Try
            Next

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub appUspAnnualFillMachinesDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles appUspAnnualFillMachinesDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub appUspAnnualFillMachineryDrawnDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles appUspAnnualFillMachineryDrawnDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub appUspAnnualFillAnimalDrawnDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles appUspAnnualFillAnimalDrawnDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
