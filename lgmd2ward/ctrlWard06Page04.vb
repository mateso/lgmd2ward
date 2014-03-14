Public Class ctrlWard06Page04

    Dim CropGroupListDA As New AnnualTargetDataSetTableAdapters.CropGroupListTableAdapter
    Dim TargetDA As New AnnualTargetDataSetTableAdapters.TargetImplementationAndCropPrices06TableAdapter
    Private firstNo As Double?
    Private secondNo As Double?
    Private expectedArea As Double?
    Private expectedProd As Double?

    Private Sub ctrlWard06Page04_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CropGroupListDA.Fill(Me.AnnualTargetDataSet.CropGroupList)
        Me.AppUspAnnualTargetFillMatundaTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillMatunda, g_RecordID)
        Me.AppUspAnnualTargetFillMauaTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillMaua, g_RecordID)
        Me.AppUspAnnualTargetFillMengineyoTableAdapter.Fill(Me.AnnualTargetDataSet.appUspAnnualTargetFillMengineyo, g_RecordID)

        Call LabelTranslation(Me)
        Call SetGoButton(Me.cmdSave)

        FillWithGoTo(Me.cmbGoTo, g_FormTypeNumber, "1")

        Me.lblPeriod.Text = g_PeriodHeading
        Me.lblArea.Text = g_AreaHeading
    End Sub

    Private Sub AppUspAnnualTargetFillMengineyoDataGridView_RowEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillMengineyoDataGridView.RowEnter
        If Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows(e.RowIndex).IsNewRow() Then
            Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows(e.RowIndex).Cells(0).Value = Guid.NewGuid
            Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows(e.RowIndex).Cells(1).Value = 10
            Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows(e.RowIndex).Cells(3).Value = 1
            Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows(e.RowIndex).Cells(4).Value = Guid.NewGuid
            Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows(e.RowIndex).Cells(10).Value = g_RecordID
        End If
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

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMatundaDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillMatundaTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMauaDataGridView.Rows
                    expectedArea = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                    expectedProd = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                    Me.AppUspAnnualTargetFillMauaTableAdapter.appUspUpdateAnnualTarget(row.Cells(4).Value, _
                                                                     expectedArea, _
                                                                     expectedProd, _
                                                                     row.Cells(9).Value.ToString, _
                                                                     row.Cells(10).Value)
                Next
            Catch ex As Exception
            End Try

            'Me.AppUspAnnualTargetFillMatundaTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillMatunda)
            'Me.AppUspAnnualTargetFillMauaTableAdapter.Update(Me.AnnualTargetDataSet.appUspAnnualTargetFillMaua)
            For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows
                Try
                    If row.IsNewRow Then
                    Else
                        firstNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(6))
                        secondNo = CheckIfIsNullOrEmptyDGVCell(row.Cells(7))
                        Me.AppUspAnnualTargetFillMengineyoTableAdapter.appUspAnnualTargetsUpdateMengineyo(row.Cells(0).Value, _
                                                                                                          Val(row.Cells(1).Value.ToString()), _
                                                                                                          row.Cells(2).Value.ToString(), _
                                                                                                          Val(row.Cells(3).Value.ToString()), _
                                                                                                          row.Cells(4).Value, _
                                                                                                          firstNo, _
                                                                                                          secondNo, _
                                                                                                          row.Cells(9).Value.ToString(), _
                                                                                                          row.Cells(10).Value)

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            Next

            MsgBoxBilingual("Saved", "Imehifadhiwa")
        End If

        GotoNextPage(g_FormTypeNumber, Me.cmbGoTo.Text)
    End Sub

    Private Sub AppUspAnnualTargetFillMatundaDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillMatundaDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillMauaDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillMauaDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillMengineyoDataGridView_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles AppUspAnnualTargetFillMengineyoDataGridView.DataError
        Call DGVNumericError(e, sender)
    End Sub

    Private Sub AppUspAnnualTargetFillMatundaDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillMatundaDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMatundaDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspAnnualTargetFillMauaDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillMauaDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMauaDataGridView.Rows
            If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                firstNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                Else
                    secondNo = row.Cells(7).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                secondNo = 0
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                Else
                    firstNo = row.Cells(6).Value
                End If
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            Else
                firstNo = row.Cells(6).Value
                secondNo = row.Cells(7).Value
                row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
            End If
        Next
    End Sub

    Private Sub AppUspAnnualTargetFillMengineyoDataGridView_CellValidated(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AppUspAnnualTargetFillMengineyoDataGridView.CellValidated
        For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMengineyoDataGridView.Rows
            If row.IsNewRow Then
            Else
                If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                    firstNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                        secondNo = 0
                    Else
                        secondNo = row.Cells(7).Value
                    End If
                    row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
                ElseIf IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(7))) Then
                    secondNo = 0
                    If IsNothing(CheckIfIsNullOrEmptyDGVCell(row.Cells(6))) Then
                        firstNo = 0
                    Else
                        firstNo = row.Cells(6).Value
                    End If
                    row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
                Else
                    firstNo = row.Cells(6).Value
                    secondNo = row.Cells(7).Value
                    row.Cells(8).Value = AutomateProduct(firstNo, secondNo)
                End If
            End If
        Next
    End Sub

    Private Sub AppUspAnnualTargetFillMengineyoDataGridView_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles AppUspAnnualTargetFillMengineyoDataGridView.UserDeletingRow
        If Me.AppUspAnnualTargetFillMengineyoDataGridView.CurrentRow.Index < 1 Then
            e.Cancel = True
            MessageBox.Show("This record can not be deleted", "Prevent Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.AppUspAnnualTargetFillMengineyoDataGridView.SelectedRows
                    Me.TargetDA.appUspAnnualTargetDeleteTargets(row.Cells(0).Value)
                Next
            Else
                e.Cancel = True
                MessageBox.Show("Record not deleted", "Cancel Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub AppUspAnnualTargetFillMatundaDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillMatundaDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualTargetFillMauaDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillMauaDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub

    Private Sub AppUspAnnualTargetFillMengineyoDataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles AppUspAnnualTargetFillMengineyoDataGridView.KeyDown
        Call DGVChangeEnterKeyBehaviour(sender, e)
    End Sub
End Class
